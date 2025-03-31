# CustomItems

## Description
Updated Joker-119's customitems to EXILED 9.5.1 and re-added or changed features. 
New custom items coming very soon.
If you encounter issues contact me on discord: adam2541
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

### Valid Spawn Location names (v. 14.0.1)
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
### Attachment Names (v. 14.0.1)
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
 - 
### Credits
 - NeonWizard for the original TranqGun
 - Killer0992 for the original Shotgun
 - Dimenzio for the SpawnGrenade method
 - Michal78900 for SCP-1499
 - SebasCapo for slight API rework.
