# Super Metroidvania 5Million
### Developed By Group 2

**PROGRAM DESCRIPTION**

This program is a clone of the original *Metroid NES* first mini-boss hideout. The player character, Samus, is able to move around and use her beam cannon, missile rockets, and bombs to combat enemies while exploring. Samus can pickup items and upgrades that augment her ability to fight. At the moment, the program has collision related behaviors and a working map design.

___
**PROGRAM CONTROLS**

* UpArrow, W : Player jump.
* RightArrow, D : Player face and move right.
* LeftArrow, A : Player face and move left.
* DownArrow, S : Player enter morph form.
* Z, N : Player shoots the currently active beam missile weapon or drops bombs if in morph form.
* Space : Player jump.
* C : Cycle currently active beam weapon.
* Q : Quit.
* R : Reset the program to initial state.
* T : Cycle current level being loaded.
* F : Toggle fullscreen.
* K : Play next music theme.
* L : Shuffle music themes.
* O : Unshuffle music themes.
* P : Pause/Unpause.
___
**PLAYER UPGRADES**

* Long Beam : Lengthens the attacking range of the beam weapon. Also increases damage.
* Ice Beam : This allows you to freeze an enemy temporarily. If you already have a long beam, then the ice beam becomes a long beam. This can't be used at the same time as the wave beam.
* Wave Beam : The beams are wave-shaped and are stronger than normal beams. If you already have a long beam, the long beam becomes a long wave beam.
* Screw Attack : This super strong Power Item spins in flight to attack the enemy. Samus's armor flashes during a screw attack.
 * Varia : This raises Samus's powers of resistance and cuts in half the amount of energy he uses up when attacked by an enemy.
 * Maru Mari : Samus grows small and round like a ball when he gets this Power Item. Useful when travelling along narrow passageways.
 * Bomb : Samus can use the bomb when he is still small and round. Drop bombs to damage enemies or blast through barriers.
 * Energy Tank : Energy is stored in these tanks. Normally, the amount of storable energy cannot go above 99, but with each tank it grows by 100. You can collect as many as 6.
 * Missile Rocket : This stores the missiles. If you capture one, you get 5 more missiles. Collect missiles from defeated enemies. You can store a maximum of 255.

___
**PLANNED CHANGES**

* Currently, the player does not "die" when health drops below 0. Will add a gameover sequence.
* Need to implement some of the player upgrades, such as the Varia suit (reducing incoming damage), the hi-jump boots (1.5 jump height), the energy and missile tanks (increasing energy and missile capacity), and the energy shields.
* Resize some sprites for better balance/collision handling.
*Tweak HUD. Make it travel with the camera.
*Add Item Functionality
*Player Upgrades are not implemented
*Implement Rest of First boss Dungeon
*Implement Game State Transitions
*Make doors have health/take damage

___
**KNOWN BUGS**

* Some textures need to be cleaned up.
* Health gets printed over

___
**DETAILS ON CURRENT ERRORS/WARNINGS / CODE ANALYSIS**

* (No Current Errors)

* Warning		Unable to load one or more of the requested types. Retrieve the LoaderExceptions property for more information.	
    - Unused and/or unrecognized variable/function calls; should be resolved with further feature implementations and clean-up.

___
**OTHER TOOLS/PROCESSES**

* GIMP2.0: Used for texture editing. 

___
**CREDITS**  
Developed By: Nyigel Spann, Shyamal Shah, Tristan Roman, Alex Nguyen, Will Wloyd, Danny Attia  
Spritesheets taken from: https://www.spriters-resource.com/nes/metroid/  
*Metroid NES* Manual: http://www.digitpress.com/library/manuals/nes/Metroid%20v1.pdf  

