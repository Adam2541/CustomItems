// -----------------------------------------------------------------------
// <copyright file="TranquilizerGun.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pools;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Interfaces;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using InventorySystem.Items.Usables;
using MEC;
using Mirror;
using PlayerRoles;
using PlayerRoles.Spectating;
using PlayerStatsSystem;
using PluginAPI.Enums;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using Ragdoll = Exiled.API.Features.Ragdoll;
using Random = UnityEngine.Random;

/// <inheritdoc />
[CustomItem(ItemType.GunCOM18)]

//DOES NOT WORK - when spawned and created ragdoll method doesnt fire and gives error. No idea why it is not working - waiting for newer exiled version.
public class TranquilizerGun : CustomWeapon
{
    private readonly Dictionary<Player, float> tranquilizedPlayers = new();
    private readonly List<Player> activeTranqs = new();

    /// <inheritdoc/>
    public override uint Id { get; set; } = 14;

    /// <inheritdoc/>
    public override string Name { get; set; } = "Tranquilizer Gun";

    /// <inheritdoc/>
    public override string Description { get; set; } = "Gun which shoots strong sedative which will calm down people and even some SCPs.";
    public override bool ShouldMessageOnGban { get; } = false;
    /// <inheritdoc/>
    public override float Weight { get; set; } = 1.55f;

    /// <inheritdoc />
    public override SpawnProperties? SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = new List<DynamicSpawnPoint>
        {
            new()
            {
                Chance = 50,
                Location = SpawnLocationType.InsideGr18,
            },
            new()
            {
                Chance = 40,
                Location = SpawnLocationType.Inside173Gate,
            },
        },
    };
    public override AttachmentName[] Attachments { get; set; } = new[]
       {
            AttachmentName.SoundSuppressor,
        };

    /// <inheritdoc/>
    public override byte ClipSize { get; set; } = 2;

    /// <inheritdoc/>
    public override float Damage { get; set; } = 95f;

    /// <summary>
    /// Gets or sets a value indicating whether or not SCPs should be resistant to tranquilizers. (Being resistant gives them a chance to not be tranquilized when shot).
    /// </summary>
    [Description("Whether or not SCPs should be resistant to tranquilizers. (Being resistant gives them a chance to not be tranquilized when shot).")]
    public bool ResistantScps { get; set; } = true;

    /// <summary>
    /// Gets or sets the amount of time a successful tranquilization lasts for.
    /// </summary>
    [Description("The amount of time a successful tranquilization lasts for.")]
    public float Duration { get; set; } = 5f;

    [Description("Whether or not tranquilized targets should drop all of their items.")]
    public bool DropItems { get; set; } = true;

    protected override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();
    }

    /// <inheritdoc/>
    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
    }
    protected override void OnHurting(HurtingEventArgs ev)
    {
        Timing.RunCoroutine(TranquilizePlayer(ev.Player, 5f));
    }
private IEnumerator<float> TranquilizePlayer(Player player, float duration)
{
    activeTranqs.Add(player);
    Vector3 oldPosition = player.Position;
    Item previousItem = player.CurrentItem;
    Vector3 previousScale = player.Scale;
    float newHealth = player.Health - Damage;
    List<StatusEffectBase> activeEffects = ListPool<StatusEffectBase>.Pool.Get();

    player.CurrentItem = null;

    if (newHealth <= 0)
        yield break;

    activeEffects.AddRange(player.ActiveEffects.Where(effect => effect.IsEnabled));

    try
    {
        if (DropItems)
        {
            if (player.Items.Count < 0)
            {
                foreach (Item item in player.Items.ToList())
                {
                    if (TryGet(item, out CustomItem? customItem))
                    {
                        customItem?.Spawn(player.Position, item, player);
                        player.RemoveItem(item);
                    }
                }

                player.DropItems();
            }
        }
    }
    catch (Exception e)
    {
        Log.Error($"{nameof(TranquilizePlayer)}: {e}");
    }

    Ragdoll? ragdoll = null;
    if (player.Role.Type != RoleTypeId.Scp106) // Internal error here - if i want to create and spawn ragdoll i get error. No clue why.
        ragdoll = Ragdoll.CreateAndSpawn(player.Role, player.DisplayNickname, "Tranquilized", player.Position, player.ReferenceHub.PlayerCameraReference.rotation, player);

    if (player.Role is Scp096Role scp)
        scp.RageManager.ServerEndEnrage();

    try
    {
        player.EnableEffect<Invisible>(duration);
        player.Scale = Vector3.one * 0.2f;
        player.Health = newHealth;
        player.IsGodModeEnabled = true;

        player.EnableEffect<AmnesiaVision>(duration);
        player.EnableEffect<AmnesiaItems>(duration);
        player.EnableEffect<Ensnared>(duration);
    }
    catch (Exception e)
    {
        Log.Error(e);
    }

    yield return Timing.WaitForSeconds(duration);

    try
    {
        if (ragdoll != null)
            NetworkServer.Destroy(ragdoll.GameObject);

        if (player.GameObject == null)
            yield break;

        newHealth = player.Health;

        player.IsGodModeEnabled = false;
        player.Scale = previousScale;
        player.Health = newHealth;

      //  if (!DropItems)
     //       player.CurrentItem = previousItem;

        foreach (StatusEffectBase effect in activeEffects.Where(effect => (effect.Duration - duration) > 0))
            player.EnableEffect(effect, effect.Duration);

        activeTranqs.Remove(player);
        ListPool<StatusEffectBase>.Pool.Return(activeEffects);
    }
    catch (Exception e)
    {
        Log.Error($"{nameof(TranquilizePlayer)}: {e}");
    }

    if (Warhead.IsDetonated && player.Position.y < 900)
    {
        player.Hurt(new UniversalDamageHandler(-1f, DeathTranslations.Warhead));
        yield break;
    }

    player.Position = oldPosition;
}
}
