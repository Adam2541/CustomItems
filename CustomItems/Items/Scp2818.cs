// -----------------------------------------------------------------------
// <copyright file="Scp2818.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;

using MEC;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;
using YamlDotNet.Serialization;

/// <summary>
/// A gun that kills you.
/// </summary>
[CustomItem(ItemType.GunE11SR)]
public class Scp2818 : CustomWeapon
{
    /// <inheritdoc/>
    public override uint Id { get; set; } = 11;

    /// <inheritdoc/>
    public override string Name { get; set; } = "SCP-2818";

    /// <inheritdoc/>
    public override string Description { get; set; } =
        "When this weapon is fired, it uses the biomass of the shooter as the bullet.";

    /// <inheritdoc/>
    public override float Weight { get; set; } = 3.95f;

    /// <inheritdoc/>
    [YamlIgnore]
    public override byte ClipSize { get; set; } = 1;
    /// <inheritdoc/>
    public override SpawnProperties? SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = new List<DynamicSpawnPoint>
        {
            new()
            {
                Chance = 60,
                Location = SpawnLocationType.InsideHid,
            },
            new()
            {
                Chance = 20,
                Location = SpawnLocationType.InsideLczArmory,
            },
        },
    };

    /// <inheritdoc/>
    [Description("The amount of damage the weapon deals when the projectile hits another player.")]
    public override float Damage { get; set; } = 100f;

    /// <inheritdoc/>
    protected override void OnHurting(HurtingEventArgs ev)
    {
        ev.Player.Health += ev.Player.Health - 20;
        Log.Debug($"Hit with SCP-2818 player: {ev.Player}. Target Health: {ev.Player.Health}");
        base.OnHurting(ev);
    }
    protected override void OnReloaded(ReloadedWeaponEventArgs ev)
    {
        base.OnReloaded(ev);
    }
}
