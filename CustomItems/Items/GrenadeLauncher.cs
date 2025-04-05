// -----------------------------------------------------------------------
// <copyright file="GrenadeLauncher.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups.Projectiles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.EventArgs;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;

using InventorySystem.Items.Firearms.BasicMessages;
using InventorySystem.Items.Firearms.Modules;
using InventorySystem.Items.Firearms.Modules.Misc;
using MEC;
using Mirror;
using RemoteAdmin;
using UnityEngine;
using YamlDotNet.Serialization;
using CollisionHandler = Exiled.API.Features.Components.CollisionHandler;

/// <inheritdoc />
[CustomItem(ItemType.GunLogicer)]
public class GrenadeLauncher : CustomWeapon
{

    private ProjectileType loadedGrenade = ProjectileType.FragGrenade;

    /// <inheritdoc/>
    public override uint Id { get; set; } = 5;

    /// <inheritdoc/>
    public override string Name { get; set; } = "M320-GL";

    /// <inheritdoc/>
    public override string Description { get; set; } = "This weapon will launch grenades in the direction you are firing, instead of bullets. Requires Frag Grenades in your inventory to reload.";

    /// <inheritdoc/>
    public override float Weight { get; set; } = 2.95f;

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
            new()
            {
                Chance = 40,
                Location = SpawnLocationType.InsideHczArmory,
            },
        },
    };

    /// <inheritdoc/>
    [YamlIgnore]
    public override float Damage { get; set; } = 0f;

    /// <inheritdoc/>
    [YamlIgnore]
    public override byte ClipSize { get; set; } = 1;

    /// <summary>
    /// Gets or sets a value indicating whether or not players will need actual frag grenades in their inventory to use as ammo. If false, the weapon's base ammo type is used instead.
    /// </summary>
    [Description("Whether or not players will need actual frag grenades in their inventory to use as ammo. If false, the weapon's base ammo type is used instead.")]
    public bool UseGrenades { get; set; } = true;
    /// <inheritdoc/>
    protected override void OnPickingUp(PickingUpItemEventArgs ev)
    {
        if (ev.Player.GetAmmo(AmmoType.Nato762) < 1)
            ev.Player.AddAmmo(AmmoType.Nato762, 1);
    }
    protected override void OnReloading(ReloadingWeaponEventArgs ev)
    {
        if (UseGrenades)
        {
            foreach (Item item in ev.Player.Items.ToList())
            {
                if (item.Type != ItemType.SCP2176 && item.Type != ItemType.GrenadeHE && item.Type != ItemType.GrenadeFlash && item.Type != ItemType.SCP018)
                    continue;
                loadedGrenade = item.Type.GetProjectileType();
                ev.Player.RemoveItem(item);
                Log.Debug($"{Name}.{nameof(OnReloading)}: {ev.Player.Nickname} reloaded {loadedGrenade}");
                ev.IsAllowed = true;
                return;
            }
            ev.IsAllowed = false;
            Log.Debug($"{Name}.{nameof(OnReloading)}: {ev.Player.Nickname} was unable to reload - No grenades in inventory.");
        }
    }
    /// <inheritdoc/>
    protected override void OnShooting(ShootingEventArgs ev)
    {
        Projectile projectile; //Needed for Scp2176 popping on impact and projectiles flying out of the gun.
        switch (loadedGrenade)
        {
            case ProjectileType.FragGrenade:
                projectile = ev.Player.ThrowGrenade(ProjectileType.FragGrenade).Projectile;
                break;
            case ProjectileType.Flashbang:
                projectile = ev.Player.ThrowGrenade(ProjectileType.Flashbang).Projectile;
                break;
            case ProjectileType.Scp2176:
                projectile = ev.Player.ThrowGrenade(ProjectileType.Scp2176).Projectile;
                break;
            default:
                 projectile = ev.Player.ThrowGrenade(ProjectileType.Scp018).Projectile;
                break;
        }
        if (ev.Player.GetAmmo(AmmoType.Nato762) < 1)
            ev.Player.AddAmmo(AmmoType.Nato762, 1);
    }
}
