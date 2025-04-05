// -----------------------------------------------------------------------
// <copyright file="Scp127.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;

using MEC;

using YamlDotNet.Serialization;

using Firearm = Exiled.API.Features.Items.Firearm;
using FirearmPickup = InventorySystem.Items.Firearms.FirearmPickup;

/// <inheritdoc />
[CustomItem(ItemType.GunCOM18)]
public class Scp127 : CustomWeapon
{
    /// <inheritdoc/>
    public override uint Id { get; set; } = 9;

    /// <inheritdoc/>
    public override string Name { get; set; } = "SCP-127";

    /// <inheritdoc/>
    public override string Description { get; set; } = "SCP-127 is a pistol that slowly regenerates it's ammo over time but cannot be reloaded normally.";

    /// <inheritdoc/>
    public override float Weight { get; set; } = 1.45f;

    /// <inheritdoc/>
    public override SpawnProperties? SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = new List<DynamicSpawnPoint>
        {
            new()
            {
                Chance = 50,
                Location = SpawnLocationType.Inside049Armory,
            },
        },
    };

    /// <inheritdoc/>
    [Description("Sets the SCP-127 damage.")]
    public override float Damage { get; set; } = 14f;
    /// <inheritdoc/>
    [Description("Sets the SCP-127 Magazine size.")]
    public override byte ClipSize { get; set; } = 61;

    /// <summary>
    /// Gets or sets how often ammo will be regenerated. Regeneration occurs at all times, however this timer is reset when the weapon is picked up or dropped.
    /// </summary>
    [Description("How often ammo will be regenerated. Regeneration occurs at all times, however this timer is reset when the weapon is picked up or dropped.")]
    public float RegenerationDelay { get; set; } = 3f;

    /// <summary>
    /// Gets or sets the amount of ammo that will be regenerated each regeneration cycle.
    /// </summary>
    [Description("The amount of ammo that will be regenerated each regeneration cycle.")]
    public byte RegenerationAmount { get; set; } = 3;
    /// <summary>
    /// Gets or sets the amount of hume shield that will be gained by the player.
    /// </summary>
    [Description("Sets the delay in which will the player holding SCP-127 getting health regeneration")]
    public float HealthRegenerationDelay { get; set; } = 4f;

    private List<CoroutineHandle> Coroutines { get; } = new();

    /// <inheritdoc/>
    public override void Init()
    {
        Coroutines.Add(Timing.RunCoroutine(DoAmmoRegeneration()));
        base.Init();
    }

    /// <inheritdoc/>
    public override void Destroy()
    {
        foreach (CoroutineHandle handle in Coroutines)
            Timing.KillCoroutines(handle);

        base.Destroy();
    }

    /// <inheritdoc/>
    protected override void OnHurting(HurtingEventArgs ev)
    {
        if (DamageMultiplier > 0)
            ev.Amount *= Damage;
    }

    /// <inheritdoc/>
    protected override void OnReloading(ReloadingWeaponEventArgs ev) => ev.IsAllowed = false;

    /// <inheritdoc/>
    protected override void ShowPickedUpMessage(Player player)
    {
        Coroutines.Add(Timing.RunCoroutine(AmmoRegeneration(player)));
        Coroutines.Add(Timing.RunCoroutine(HealthGeneration(player)));
        base.ShowPickedUpMessage(player);
    }
     /// <inheritdoc/>
    protected override void OnDroppingItem(DroppingItemEventArgs ev)
    {
        foreach (CoroutineHandle handle in Coroutines)
            Timing.KillCoroutines(handle);
        base.OnDroppingItem(ev);
    }
    private IEnumerator<float> HealthGeneration(Player player)
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(HealthRegenerationDelay);
            if (!Check(player.CurrentItem))
                continue;
            if (player.Health != player.MaxHealth)
                player.Health += 1;
        }
    }
    private IEnumerator<float> AmmoRegeneration(Player player)
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(RegenerationDelay);

            bool hasItem = false;

            foreach (Item item in player.Items)
            {
                if (!Check(item) || !(item is Firearm firearm))
                    continue;
                if (firearm.MagazineAmmo < ClipSize)
                    firearm.MagazineAmmo += RegenerationAmount;
                hasItem = true;
            }

            if (!hasItem)
                yield break;
        }
    }
}
