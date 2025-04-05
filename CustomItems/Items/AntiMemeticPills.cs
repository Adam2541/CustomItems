// -----------------------------------------------------------------------
// <copyright file="AntiMemeticPills.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomItems.Items;

using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;

[CustomItem(ItemType.SCP500)]
public class AntiMemeticPills : CustomItem
{
    /// <inheritdoc/>
    public override uint Id { get; set; } = 1;

    /// <inheritdoc/>
    public override string Name { get; set; } = "Anti-Memetic pills";

    /// <inheritdoc/>
    public override string Description { get; set; } =
        "Drugs that make you forget things. If you use these while you are targeted by SCP-096, you will forget what his face looks like, and thus no longer be a target.";

    /// <inheritdoc/>
    public override float Weight { get; set; } = 1f;

    /// <inheritdoc/>
    public override SpawnProperties? SpawnProperties { get; set; } = new()
    {
        DynamicSpawnPoints = new List<DynamicSpawnPoint>
        {
            new() { Chance = 100, Location = SpawnLocationType.Inside096 },
        },
    };

    /// <inheritdoc/>
    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.UsingItem += OnUsingItemm;
        base.SubscribeEvents();
    }

    /// <inheritdoc/>
    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.UsingItem -= OnUsingItemm;
        base.UnsubscribeEvents();
    }
    protected override void OnAcquired(Player player, Item item, bool displayMessage)
    {
        base.OnAcquired(player, item, displayMessage);
        IEnumerable<Player> scp096S = Player.Get(RoleTypeId.Scp096);
        foreach (Player scp in scp096S)
        {
            if (scp.Role is Scp096Role scp096)
            {
                scp096.Enrage(30);
            }
        }
    }
    protected override void OnDroppingItem(DroppingItemEventArgs ev)
    {
        IEnumerable<Player> scp096S = Player.Get(RoleTypeId.Scp096);

        foreach (Player scp in scp096S)
        {
            if (scp.Role is Scp096Role scp096)
            {
                if (scp096.HasTarget(ev.Player))
                {
                    foreach (Player str in scp096.Targets)
                    {
                        Log.Debug(str.DisplayNickname);
                    }
                }
            }
        }

        ev.Player.EnableEffect<AmnesiaVision>(10f, true);
    }
    private void OnUsingItemm(UsingItemEventArgs ev)
    {
        if (!Check(ev.Player.CurrentItem))
            return;
        IEnumerable<Player> scp096S = Player.Get(RoleTypeId.Scp096);

        Timing.CallDelayed(0.05f, () =>
        {
            foreach (Player scp in scp096S)
            {
                if (scp.Role is Scp096Role scp096)
                {
                    if (scp096.HasTarget(ev.Player))
                    {
                        Log.Debug(scp096.Targets);
                        scp096.RemoveTarget(ev.Player);
                    }
                }
            }

            ev.Player.EnableEffect<AmnesiaVision>(15f, true);
        });
    }
    private void OnUsingItem(UsingItemEventArgs ev)
    {
        if (!Check(ev.Player.CurrentItem))
            return;
    }
}
