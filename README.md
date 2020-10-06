# CSE3902Game
# Super Metroidvania 5Million

**PROGRAM DESCRIPTION**

This program is a clone of the original *Metroid NES* first mini-boss hideout. The player character, Samus, is able to move around and use her beam cannon, missile rockets, and bombs to combat enemies while exploring. Samus can pickup items and upgrades that augment her ability to fight. At the moment, the program essentially showcases all enemies, items, blocks, the player, and all non-collision related behaviors.

___
**PROGRAM CONTROLS**

* UpArrow, W : Player Jump and enter briefly morph form.
* RightArrow, D : Player face and move right.
* LeftArrow, A : Player face and move left.
* DownArrow, S : Player crouch and briefly enter morph form.
* Z, N : Player shoots the beam weapon.
* E : Player takes damage.
* C : If in morph form, places bomb. Else, fires missile rocket.
* Y : Advances the block currently displayed.
* T : Previous block displayed.
* I : Advances the item currently displayed.
* U : Previous item displayed.
* P : Advances the enemy currently displayed.
* O : Previous enemy displayed.
* Q : Quit.
* R : Reset the program to initial state.
* Upgrade Toggle Controls: In Metroid NES, the player doesn't really collect different items so much as upgrades to modify the behavior of the player's abilities. Some of the different upgrades are toggleable as listed below with the number keys.
  * D1, NUM1 : Toggles the ice beam upgrade.
  * D2,NUM2: Toggles the wave beam upgrade.
  * D3, NUM3 : Toggles the long beam upgrade.

___
**PLANNED FEATURES**

* Currently, the player does not "die" when health drops below 0.
* Need to implement some of the player upgrades, such as the Varia suit (reducing incoming damage), the hi-jump boots (1.5 jump height), the energy and missile tanks (increasing energy and missile capactity), and the energy shields.
* At the moment, the player starts with 50 rockets, and can run out. This number will be displayed in later versions.
* Plans to make the wave beam and ice beam mutually exclusive.
* Make the wave beam more sinusoidal

___
**KNOWN BUGS**

* Sometimes the keys (notably 1,2 and 3) can be a little unresponsive. May be due to the supression after a key is pressed not being long enough. May introduce a system to wait for a key to be released before executing a command in the future.

___
**DETAILS ON CURRENT ERRORS/WARNINGS**

Severity	Code	Description	Project	File	Line	Suppression State
Warning	CS0108	'MapInterface.Update(GameTime)' hides inherited member 'ISprite.Update(GameTime)'. Use the new keyword if hiding was intended.	Super Metroidvania 5Million	C:\Users\Albatro5s\Source\Repos\derin161\CSE3902Game\Super Metroidvania 3Million\CrossPlatformDesktopProject\Libraries\Sprite\Map\MapInterface.cs	13	Active

Severity	Code	Description	Project	File	Line	Suppression State
Warning	CS0108	'MapInterface.Draw(SpriteBatch)' hides inherited member 'ISprite.Draw(SpriteBatch)'. Use the new keyword if hiding was intended.	Super Metroidvania 5Million	C:\Users\Albatro5s\Source\Repos\derin161\CSE3902Game\Super Metroidvania 3Million\CrossPlatformDesktopProject\Libraries\Sprite\Map\MapInterface.cs	15	Active

* Both of these are in the new class MapInterface.cs and has not been fully implemented. These errors should be neglegable for the next Sprint.

Severity	Code	Description	Project	File	Line	Suppression State
Warning	CS0649	Field 'MissileRocketExplosion.explosionAnimationPairs' is never assigned to, and will always have its default value null	Super Metroidvania 5Million	C:\Users\Albatro5s\Source\Repos\derin161\CSE3902Game\Super Metroidvania 3Million\CrossPlatformDesktopProject\Libraries\Sprite\Projectiles\MissileRocketExplosion.cs	20	Active

* This should be resolved as collisions are implemented - this variable is just a NULL variable for the time being.

___
**DETAILS OF ANY TOOLS/PROCESSES YOUR TEAM USED THAT AREN'T EXPLICITLY REQUIRED**

* GIMP2.0: Used for texture editing. 
