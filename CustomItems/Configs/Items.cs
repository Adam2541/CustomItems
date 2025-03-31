// -----------------------------------------------------------------------
// <copyright file="Items.cs" company="Joker119">
// Copyright (c) Joker119. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using CustomItems.Items;

namespace CustomItems.Configs;

using System.Collections.Generic;
using System.ComponentModel;

public class Items
{

    [Description("The list of antimemeticpills.")]
    public List<AntiMemeticPills> AntiMemeticPills { get; private set; } = new()
    {
        new AntiMemeticPills(),
    };
    [Description("The list of C4 charges.")]
    public List<C4Charge> C4Charge { get; private set; } = new()
    {
        new C4Charge(),
    };
    [Description("C4 command config")]
    public List<Commands.C4Charge> C4Command { get; private set; } = new()
    {
        new Commands.C4Charge(),
    };
    [Description("The list of deflector shields.")]
    public List<DeflectorShield> DeflectorShield { get; private set; } = new()
    {
        new DeflectorShield(),
    };
    [Description("The list of EMP grenades.")]
    public List<EmpGrenade> EMPgrenade { get; private set; } = new()
    {
        new EmpGrenade(),
    };
    [Description("The list of grenade launchers.")]
    public List<GrenadeLauncher> GrenadeLauncher { get; private set; } = new()
    {
        new GrenadeLauncher(),
    };
    [Description("The list of implosion grenades.")]
    public List<ImplosionGrenade> ImplosionGrenade { get; private set; } = new()
    {
        new ImplosionGrenade(),
    };
    [Description("The list of lethal injections.")]
    public List<LethalInjection> LethalInjection { get; private set; } = new()
    {
        new LethalInjection(),
    };
    [Description("The list of medi guns.")]
    public List<MediGun> MediGun { get; private set; } = new()
    {
        new MediGun(),
    };
    [Description("The list of SCP-127큦")]
    public List<Scp127> SCP127 { get; private set; } = new()
    {
        new Scp127(),
    };
    [Description("The list of SCP-1499큦")]
    public List<Scp1499> SCP1499 { get; private set; } = new()
    {
        new Scp1499(),
    };
    [Description("The list of SCP-2818큦")]
    public List<Scp2818> SCP2818 { get; private set; } = new()
    {
        new Scp2818(),
    };
    [Description("The list of SCP-127큦")]
    public List<Scp714> SCP714 { get; private set; } = new()
    {
        new Scp714(),
    };
    [Description("The list of sniper rifles.")]
    public List<SniperRifle> SniperRifle { get; private set; } = new()
    {
        new SniperRifle(),
    };
}