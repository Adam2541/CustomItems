# CustomItems

## Description
- Updated Joker-119's customitems to EXILED 9.5.1 and re-added or changed features. 
- New custom items coming very soon.
- If you encounter issues/bugs open Issue on github or contact me on discord: adam2541
### Item list
ItemName | ItemID | Description
:---: | :---: | :------
Anti-Memetic pills | 1 | Pills that, when consumed, make you forget SCP-096's face if you have recently seen it. Removing you from being one of his targets, with some side effects.
Semtex C4 | 2 | A frag-grenade with a much longer than normal fuse, that will stick to the first solid surface it comes in contact with. It can be detonated using a console command. ".detonate"
Deflector shield | 3 | A deflector shield that reflects bullets back at the shooter.
S4-EMP | 4 | An EMP Grenade. This grenade acts similar to an Implosion grenade, however when it detonates, all of the doors in the room it is in are locked open, and the lights disabled for a few seconds. If SCP-079 is present in the room, it will disable his camera view and ability to change cameras for a short while. Also disabled all speakers in the facility temporarily. 
M320-GL | 5 | A grenade launcher. This weapon shoots grenades that explode on impact with anything, instead of bullets.
M49-IG | 6 | An Implosion Grenade. This grenade will act similar to a normal Frag grenade, however it has an extremely short fuse, and does very low damage. Upon exploding, anyone within the explosion will be quickly drawn in towards the center of the explosion for a few seconds. 
CZ-LJ | 7 | An injection of lethal chemicals that, when injected, immediately kills the user. If the user happens to be the target of a currently enraged SCP-096, the SCP-096 will immediately calm down, regardless of how many other targets they may or may not have.
B87-MG | 8 | This gun is modified to fire self-injecting projectile darts. When fired at friendly targets, it will heal them. When fired at SCP-049-2, it will slowly begin to 'cure' them, repeated applications will eventually revert the SCP-049-2 to their human state. Has no effect on other hostile targets.
SCP-127 | 9 | A gun that slowly regenerates it's clip over time, but trying to reload it normally has no effect.
SCP-1499 | 10 | The gas mask that teleports you to another dimension, when you put it on.
SCP-2818 | 11 | A weapon that, when fired, will convert the entire biomass of it's shooter into the ammunition it fires.
SCP-714 | 12 | A coin that, when held in your hand, makes you invulnerable to SCP-049 and SCP-049-2. However, as you hold the coin, your stamina will slowly drain. If you run out, your health will start to drain.
M82-SR | 13 | A sniper rifle. Also self-explanatory.
Tranquilizer Gun | 14 | This gun is also modified to fire self-injecting projectile darts. When fired at a hostile target, it will tranquilize them, rendering them unconscious for several seconds. **Known Issues**
~~LC-119~~ | X | Coin that shows the correct way from pocket dimension. **Will be re-added soon.**
~~Rock~~ | X | Throwable rock. **I want to replace it with something more cool.**
~~Autogun~~ | X | Aimbot gun. **Will be probably added later, i want to change it a little**

### Item Configs
Config settings for the individual items will ***NOT*** be found in the default plugin config file. Instead they will be located in ~/.config/EXILED/Configs/CustomItems on Linux or %AppData%\EXILED\Configs\CustomItems on Windows.
The default config file will be named "global.yml" however, the file used can be changed for each SCP server via that server's normal plugin config file, if you wish to run multiple servers with different custom item config settings.

The actual config values for the items should have descriptions and names that make them self-explanatory.

### Commands
Command | Arguments | Permissions | Description
:---: | :---: | :---: | :------
ci give | (item name/id) [player] | citems.give | Gives the specified item to the indicated player. If no player is specified it gives it to the person running the command. IN-GAME RA COMMAND ONLY.
ci spawn | (item name/id) (location) | citems.spawn | Spawns the specified item at the specified location. This location can either be one of the valid Spawn Location's below, a player's name (it spawns at their feet), or in-game coordinates.
ci info | (item name/id) | none | Prints a more detailed list of info about a specific item, including name, id, description and spawn locations + chances.
ci list | none | none| Lists the names and ID's of all installed and enabled custom items on the server.
.detonate | none | none | Detonates any C4-Charges you have placed, if you are within range of them.

### Valid Dynamic Spawn Location names (v. 14.0.2)
The following list of locations are the only ones that are able to be used in the SpawnLocation configs for each item:
(Their names must be typed EXACTLY as they are listed, otherwise you will probably break your item config file)
```
Inside049Armory
Inside079First
Inside079Secondary
Inside096
Inside173Armory
Inside173Bottom
Inside173Connector
Inside173Gate
Inside330
Inside330Chamber
Inside914
InsideEscapePrimary
InsideEscapeSecondary
InsideGateA
InsideGateB
InsideGateGR18
InsideHczArmory
InsideHid
InsideHidLeft
InsideHidRight
InsideIntercom
InsideLczArmory
InsideLczCafe
InsideLczWc
InsideNukeArmory
InsideServersBottom
InsideSurfaceNuke
```
### Attachment Names (v. 14.0.2)
```
None
IronSights
DotSight
HoloSight
NightVisionSight
AmmoSight
ScopeSight
StandardStock
ExtendedStock
RetractedStock
LightweightStock
HeavyStock
RecoilReducingStock
Foregrip
Laser
Flashlight
AmmoCounter
StandardBarrel
ExtendedBarrel
SoundSuppressor
FlashHider
MuzzleBrake
MuzzleBooster
StandardMagFMJ
StandardMagAP
StandardMagJHP
ExtendedMagFMJ
ExtendedMagAP
ExtendedMagJHP
DrumMagFMJ
DrumMagAP
DrumMagJHP,
LowcapMagFMJ
LowcapMagAP
LowcapMagJHP
CylinderMag4
CylinderMag6
CylinderMag8
CarbineBody
RifleBody
ShortBarrel
ShotgunChoke
ShotgunExtendedBarrel
ShotgunDoubleShot
ShotgunSingleShot
NoRifleStock
```
### Future Plans
 - Adding keybinds
 - Adding custom googles.

### Default Config 
```
# The list of antimemeticpills.
anti_memetic_pills:
- id: 1
  name: 'Anti-Memetic pills'
  description: 'Drugs that make you forget things. If you use these while you are targeted by SCP-096, you will forget what his face looks like, and thus no longer be a target.'
  weight: 1
  spawn_properties:
    limit: 0
    dynamic_spawn_points:
    - location: Inside096
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  scale:
    x: 1
    y: 1
    z: 1
  type: None
# The list of C4 charges.
c4_charge:
- id: 2
  name: 'Semtex C4'
  weight: 0.75
  spawn_properties:
    limit: 5
    dynamic_spawn_points:
    - location: InsideLczArmory
      chance: 10
    - location: InsideHczArmory
      chance: 25
    - location: InsideNukeArmory
      chance: 50
    - location: InsideSurfaceNuke
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points:
    - zone: Unspecified
      use_chamber: false
      offset:
        x: 0
        y: 0
        z: 0
      type: Misc
      chance: 40
  description: 'Explosive charge that can be remotly detonated.'
  # Should C4 charge stick to walls / ceiling.
  is_sticky: true
  # Should C4 require a specific item to be detonated.
  require_detonator: true
  # The Detonator Item that will be used to detonate C4 Charges
  detonator_item: Radio
  # What happens with C4 charges placed by player, when he dies/leaves the game. (Remove / Detonate / Drop)
  method_on_death: Drop
  # Should shooting at C4 charges do something.
  allow_shoot: true
  # What happens with C4 charges after they are shot. (Remove / Detonate / Drop)
  shot_method: Remove
  # Maximum distance between C4 Charge and player to detonate.
  max_distance: 100
  # Time after which the C4 charge will automatically detonate.
  fuse_time: 9999
  scale:
    x: 1
    y: 1
    z: 1
# C4 command config
c4_command:
- command: 'detonate'
  aliases:
  - 'det'
  description: 'Detonate command for detonating C4 charges'
# The list of deflector shields.
deflector_shield:
- id: 3
  name: 'Deflector shield'
  description: 'A deflector shield that reflects bullets back at the shooter'
  weight: 1.64999998
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: InsideHidChamber
      chance: 10
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # How long the deflector shield can be wore, before automaticly player takes it off. (set to 0 for no limit)
  duration: 15
  # By what will the Damage be multiplied
  multiplier: 1
  scale:
    x: 1
    y: 1
    z: 1
# The list of EMP grenades.
e_m_pgrenade:
- id: 4
  name: 'S4-EMP'
  weight: 1.14999998
  spawn_properties:
    limit: 3
    dynamic_spawn_points:
    - location: Inside173Gate
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points:
    - zone: Unspecified
      use_chamber: false
      offset:
        x: 0
        y: 0
        z: 0
      type: Misc
      chance: 40
    - zone: Unspecified
      use_chamber: false
      offset:
        x: 0
        y: 0
        z: 0
      type: LargeGun
      chance: 60
  description: 'This flashbang has been modified to emit a short-range EMP when it detonates. When detonated, any lights, doors, cameras and in the room, as well as all speakers in the facility, will be disabled for a short time.'
  explode_on_collision: true
  fuse_time: 1.5
  # Whether or not EMP grenades will open doors that are currently locked.
  open_locked_doors: true
  # Whether or not EMP grenades will open doors that require keycard permissions.
  open_keycard_doors: true
  # A list of door names that will not be opened with EMP grenades regardless of the above configs.
  blacklisted_door_types: []
  # Whether or not EMP grenades disable tesla gates in the rooms the affect, for their duration.
  disable_tesla_gates: true
  # How long the EMP effect should last on the rooms affected.
  duration: 20
  type: None
  scale:
    x: 1
    y: 1
    z: 1
# The list of grenade launchers.
grenade_launcher:
- id: 5
  name: 'M320-GL'
  description: 'This weapon will launch grenades in the direction you are firing, instead of bullets. Requires Frag Grenades in your inventory to reload.'
  weight: 2.95000005
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: Inside049Armory
      chance: 50
    - location: InsideHczArmory
      chance: 40
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # Whether or not players will need actual frag grenades in their inventory to use as ammo. If false, the weapon's base ammo type is used instead.
  use_grenades: true
  attachments: []
  type: None
  friendly_fire: false
  scale:
    x: 1
    y: 1
    z: 1
# The list of implosion grenades.
implosion_grenade:
- id: 6
  name: 'M49-IG'
  description: 'This grenade does almost 0 damage, however it will succ nearby players towards the center of the implosion area.'
  weight: 0.649999976
  spawn_properties:
    limit: 3
    dynamic_spawn_points:
    - location: InsideHczArmory
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points:
    - zone: Unspecified
      use_chamber: false
      offset:
        x: 0
        y: 0
        z: 0
      type: Misc
      chance: 40
    - zone: Unspecified
      use_chamber: false
      offset:
        x: 0
        y: 0
        z: 0
      type: LargeGun
      chance: 40
  explode_on_collision: true
  fuse_time: 1.5
  # The % of normal frag grenade damage this grenade will deal to those in it's radius.
  damage_modifier: 0.0500000007
  # The amount of suction ticks each grenade will generate.
  suction_count: 90
  # The distance each tick will move players towards the center.
  suction_per_tick: 0.125
  # How often each suction tick will occus. Note: Setting the tick-rate and suction-per-tick to lower numbers maks for a 'smoother' suction movement, however causes more stress on your server. Adjust accordingly.
  suction_tick_rate: 0.0250000004
  # What roles will not be able to be affected by Implosion Grenades. Keeping SCP-173 on this list is highly recommended.
  blacklisted_roles:
  - Scp173
  - Tutorial
  type: None
  scale:
    x: 1
    y: 1
    z: 1
# The list of lethal injections.
lethal_injection:
- id: 7
  name: 'CZ-LJ'
  description: 'This is a Lethal Injection that, when used, will cause SCP-096 to immediately leave his enrage, regardless of how many targets he currently has, if you are one of his current targets. You always die when using this, even if there''s no enrage to break, or you are not a target.'
  weight: 1
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: Inside096
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # Whether the Lethal Injection should always kill the user, regardless of if they stop SCP-096's enrage.
  kill_on_fail: true
  scale:
    x: 1
    y: 1
    z: 1
  type: None
# The list of medi guns.
medi_gun:
- id: 8
  name: 'B87-MG'
  description: 'A specialized weapon that fires darts filled with a special mixture of Painkillers, Antibiotics, Antiseptics and other medicines. When fires at friendly targets, they will be healed. When fired at instances of SCP-049-2, they will be slowly converted back to human form. Does nothing when fired at anyone else.'
  weight: 1.95000005
  damage: 0
  clip_size: 10
  friendly_fire: true
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: InsideGr18
      chance: 40
    - location: InsideGateA
      chance: 50
    - location: InsideGateB
      chance: 50
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # Whether or not zombies can be 'cured' by this weapon.
  heal_zombies: true
  # Whether or not zombies who are healed will become teammates for the healer, or remain as their old class.
  heal_zombies_team_check: true
  # The % of damage the weapon would normally deal, that is converted into healing. 1 = 100%, 0.5 = 50%, 0.0 = 0%
  healing_modifier: 1
  # The amount of total 'healing' a zombie will require before being cured.
  zombie_healing_required: 200
  attachments: []
  type: None
  scale:
    x: 1
    y: 1
    z: 1
# The list of SCP-127´s
s_c_p127:
- id: 9
  name: 'SCP-127'
  description: 'SCP-127 is a pistol that slowly regenerates it''s ammo over time but cannot be reloaded normally.'
  weight: 1.45000005
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: Inside173Armory
      chance: 100
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # The amount of extra damage this weapon does, as a multiplier.
  damage_multiplier: 1
  clip_size: 25
  # How often ammo will be regenerated. Regeneration occurs at all times, however this timer is reset when the weapon is picked up or dropped.
  regeneration_delay: 10
  # The amount of ammo that will be regenerated each regeneration cycle.
  regeneration_amount: 2
  attachments: []
  type: None
  friendly_fire: false
  scale:
    x: 1
    y: 1
    z: 1
# The list of SCP-1499´s
s_c_p1499:
- id: 10
  name: 'SCP-1499'
  description: 'The gas mask that temporarily teleports you to another dimension, when you put it on.'
  weight: 1.5
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: Inside330
      chance: 10
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # How long the SCP-1499 can be wore, before automaticly player takes it off. (set to 0 for no limit)
  duration: 15
  # The location to teleport when using SCP-1499. Default is tutorial/admin tower.
  teleport_position:
    x: 38.464
    y: 1014.112
    z: -32.689
  scale:
    x: 1
    y: 1
    z: 1
  type: None
# The list of SCP-2818´s
s_c_p2818:
- id: 11
  name: 'SCP-2818'
  description: 'When this weapon is fired, it uses the biomass of the shooter as the bullet.'
  weight: 3.95000005
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: InsideHidChamber
      chance: 60
    - location: InsideLczArmory
      chance: 20
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # The amount of damage the weapon deals when the projectile hits another player.
  damage: 110
  attachments: []
  type: None
  friendly_fire: false
  scale:
    x: 1
    y: 1
    z: 1
# The list of SCP-127´s
s_c_p714:
- id: 12
  name: 'SCP-714'
  description: 'The jade ring that protects you from hazards.'
  weight: 1.14999998
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: Inside049Armory
      chance: 60
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # Which roles shouldn't be able to deal damage to the player that has SCP-714 put on.
  scp714_roles:
  - Scp049
  - Scp0492
  # Which effects should be given to the player, when he will put on SCP-714.
  scp714_effects:
  - Corroding
  - Exhausted
  prevented_effects:
  - None
  - Vitality
  - Burned
  - Bleeding
  - Ensnared
  # Message shown to player, when he takes off the SCP-714.
  take_off_message: 'You''ve taken off the ring.'
  put_on_message: 'You have put on the ring.'
  scp049_damage: 40
  pocket_dimension_modifier: 0.75
  stam_limit_modifier: 0.5
  scale:
    x: 1
    y: 1
    z: 1
  type: None
# The list of sniper rifles.
sniper_rifle:
- id: 13
  name: 'M82-SR'
  description: 'This modified E-11 Rifle fires high-velocity anti-personnel sniper rounds.'
  weight: 3.25
  clip_size: 1
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - location: InsideNukeArmory
      chance: 80
    - location: InsideHczArmory
      chance: 60
    static_spawn_points: []
    role_spawn_points: []
    room_spawn_points: []
    locker_spawn_points: []
  # The amount of extra damage this weapon does, as a multiplier.
  damage_multiplier: 7.5
  type: None
  friendly_fire: false
  scale:
    x: 1
    y: 1
    z: 1


```
