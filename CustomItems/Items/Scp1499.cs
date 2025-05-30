﻿// -----------------------------------------------------------------------
// <copyright file="Scp1499.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerStatsSystem;
using UnityEngine;

[CustomItem(ItemType.SCP268)]
public class Scp1499 : CustomItem
{
    private readonly Dictionary<Player, Vector3> scp1499Players = new();

    /// <inheritdoc/>
    public override uint Id { get; set; } = 10;

    /// <inheritdoc/>
    public override string Name { get; set; } = "SCP-1499";

    /// <inheritdoc/>
    public override string Description { get; set; } = "The gas mask that temporarily teleports you to another dimension, when you put it on.";

    /// <inheritdoc/>
    public override float Weight { get; set; } = 1.5f;

    /// <inheritdoc/>
    public override SpawnProperties? SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = new List<DynamicSpawnPoint>
        {
            new()
            {
                Chance = 10,
                Location = SpawnLocationType.Inside330,
            },
        },
    };

    /// <summary>
    /// Gets or sets how long the SCP-1499 can be wore, before automaticly player takes it off. (set to 0 for no limit).
    /// </summary>
    [Description("How long the SCP-1499 can be wore, before automaticly player takes it off. (set to 0 for no limit)")]
    public float Duration { get; set; } = 15f;

    [Description("The location to teleport when using SCP-1499. Default is the third tower. Not the admin/tutorial tower.")]
    public Vector3 TeleportPosition { get; set; } = new(-15.559f, 1015f, -31.578f);

    /// <inheritdoc/>
    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.UsedItem += OnUsingItem;
        Exiled.Events.Handlers.Player.Destroying += OnDestroying;
        Exiled.Events.Handlers.Player.Died += OnDied;

        base.SubscribeEvents();
    }

    /// <inheritdoc/>
    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.UsedItem -= OnUsingItem;
        Exiled.Events.Handlers.Player.Destroying -= OnDestroying;
        Exiled.Events.Handlers.Player.Died -= OnDied;

        base.UnsubscribeEvents();
    }

    /// <inheritdoc/>
    protected override void OnDroppingItem(DroppingItemEventArgs ev)
    {
        if (scp1499Players.ContainsKey(ev.Player) && Check(ev.Item))
        {
            ev.IsAllowed = false;

            SendPlayerBack(ev.Player);
        }
        else
        {
            base.OnDroppingItem(ev);
        }
    }

    /// <inheritdoc/>
    protected override void OnWaitingForPlayers()
    {
        scp1499Players.Clear();

        base.OnWaitingForPlayers();
    }

    private void OnDied(DiedEventArgs ev)
    {
        if (scp1499Players.ContainsKey(ev.Player))
            scp1499Players.Remove(ev.Player);
    }

    private void OnDestroying(DestroyingEventArgs ev)
    {
        if (scp1499Players.ContainsKey(ev.Player))
            scp1499Players.Remove(ev.Player);
    }
    private void OnUsingItem(UsedItemEventArgs ev)
    {
        if (!Check(ev.Player.CurrentItem))
            return;
        if (scp1499Players.ContainsKey(ev.Player))
            scp1499Players[ev.Player] = ev.Player.Position;
        else
            scp1499Players.Add(ev.Player, ev.Player.Position);
        Log.Debug("SCP1499" + scp1499Players.FirstOrDefault());


        ev.Player.Position = TeleportPosition;
        ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Invisible>();

        if (Duration > 0)
        {
            Timing.CallDelayed(Duration, () =>
            {
                SendPlayerBack(ev.Player);
            });
        }
    }

    private void OnUsedItem(UsedItemEventArgs ev)
    {
        if (!Check(ev.Player.CurrentItem))
            return;
        if (scp1499Players.ContainsKey(ev.Player))
            scp1499Players[ev.Player] = ev.Player.Position;
        else
            scp1499Players.Add(ev.Player, ev.Player.Position);

        ev.Player.Position = TeleportPosition;
        ev.Player.ReferenceHub.playerEffectsController.DisableEffect<Invisible>();
        if (Duration > 0)
        {
            Timing.CallDelayed(Duration, () =>
            {
                SendPlayerBack(ev.Player);
            });
        }
    }

    private void SendPlayerBack(Player player)
    {
        if (!scp1499Players.ContainsKey(player))
            return;
        player.Position = scp1499Players[player];

        bool shouldKill = false;
        if (Warhead.IsDetonated)
        {
            if (player.CurrentRoom.Zone != ZoneType.Surface)
            {
                shouldKill = true;
            }
            else
            {
                if (player.Lift != null)
                {
                    shouldKill = true;
                }
            }

            if (shouldKill)
                player.Hurt(new WarheadDamageHandler());
        }
        else if (Map.IsLczDecontaminated)
        {
            if (player.CurrentRoom.Zone == ZoneType.LightContainment)
            {
                shouldKill = true;
            }
            else
            {
                if (player.Lift.Type == ElevatorType.LczA || player.Lift.Type == ElevatorType.LczB)
                {
                    shouldKill = true;
                }
            }

            if (shouldKill)
                player.Hurt(new UniversalDamageHandler(-1f, DeathTranslations.Decontamination));
        }

        scp1499Players.Remove(player);
    }
}
