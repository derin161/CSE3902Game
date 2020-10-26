
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    //Author: Nyigel Spann
    public class PlayerInventory
    {
        public int CurrentEnergyLevel { get; private set; }
        public int CurrentEnergyTanksFilled { get; private set; }
        public int CurrentEnergyTanks { get; private set; }
        private int energyCapacityPerTank = 99;
        private int MaximumEnergyTanks = 6;

        public int CurrentMissileRocketCount { get; private set; }
        private int CurrentMissileRocketCapacity = 0;
        private int MaximumMissileRocketCapacity = 255;

        public bool HasLongBeam { get; private set; }
        public bool HasIceBeam { get; private set; }
        public bool HasWaveBeam { get; private set; }
        public bool HasScrewAttack { get; private set; }
        public bool HasHighJump { get; private set; }
        public bool HasVaria { get; private set; }
        public bool HasMaruMari { get; private set; }
        public bool HasBomb { get; private set; }

        private enum ItemType { Bomb, EnergyDrop, EnergyTank, HighJump, IceBeam, LongBeam, MissileRocket, MaruMari, RocketDrop, ScrewAttack, Varia, WaveBeam }
        private Dictionary<Type, ItemType> typeDict = new Dictionary<Type, ItemType> { //Used in GiveItem method below.

            {typeof(BombItem), ItemType.Bomb },
             {typeof(EnergyDropItem), ItemType.EnergyDrop },
             {typeof(EnergyTankItem), ItemType.EnergyTank },
             {typeof(HighJumpItem), ItemType.HighJump },
             {typeof(IceBeamItem), ItemType.IceBeam },
             {typeof(LongBeamItem), ItemType.LongBeam },
             {typeof(MissileRocketItem), ItemType.MissileRocket },
             {typeof(MorphBallItem), ItemType.MaruMari },
             {typeof(RocketDropItem), ItemType.RocketDrop },
             {typeof(ScrewAttackItem), ItemType.ScrewAttack },
             {typeof(VariaItem), ItemType.Varia },
             {typeof(WaveBeamItem), ItemType.WaveBeam }

        };


        public PlayerInventory(int startingEnergyLevel) {
            CurrentEnergyTanksFilled = 0;
            CurrentEnergyTanks = 0;
            CurrentMissileRocketCapacity = 0;
            CurrentEnergyLevel = startingEnergyLevel;
            HasLongBeam = false;
            HasIceBeam = false;
            HasWaveBeam = false;
            HasScrewAttack = false;
            HasHighJump = false;
            HasVaria = false;
            HasMaruMari = false;
            HasBomb = false;
        }

        /* Okay, this one is kind've a mess, but you can't directly do "case typeOf(class):" because a case needs a defined value at compile-time 
         * (is my understanding) so we need a dictionary to map typeOf(class) to an enum to use with the switch-case. I prefered a switch case to doing many if-elseifs
         * to use the "is" keyword. -Nyigel
         * Idea from: https://stackoverflow.com/questions/708911/using-case-switch-and-gettype-to-determine-the-object */
        public void GiveItem(IItem item) {
            switch (typeDict[item.GetType()]) {
                case ItemType.Bomb:
                    HasBomb = true;
                    break;
                case ItemType.EnergyDrop:
                    CurrentEnergyLevel += 5;
                    if (CurrentEnergyLevel > energyCapacityPerTank && CurrentEnergyTanksFilled < CurrentEnergyTanks)
                    {
                        CurrentEnergyLevel -= energyCapacityPerTank;
                        CurrentEnergyTanksFilled++;
                    }
                    else if (CurrentEnergyLevel > energyCapacityPerTank) {
                        CurrentEnergyLevel = energyCapacityPerTank;
                    }
                    break;
                case ItemType.EnergyTank:
                    if (CurrentEnergyTanks < MaximumEnergyTanks) {
                        CurrentEnergyTanks++;
                    }
                    break;
                case ItemType.HighJump:
                    HasHighJump = true;
                    break;
                case ItemType.IceBeam:
                    HasIceBeam = true;
                    break;
                case ItemType.LongBeam:
                    HasLongBeam = true;
                    break;
                case ItemType.MaruMari:
                    HasMaruMari = true;
                    break;
                case ItemType.MissileRocket:
                    CurrentMissileRocketCapacity += 5;
                    if (CurrentMissileRocketCapacity > MaximumMissileRocketCapacity) {
                        CurrentMissileRocketCapacity = MaximumMissileRocketCapacity;
                    }
                    break;
                case ItemType.RocketDrop:
                    if (CurrentMissileRocketCount < CurrentMissileRocketCapacity) {
                        CurrentMissileRocketCount++;
                    }
                    break;
                case ItemType.ScrewAttack:
                    HasScrewAttack = true;
                    break;
                case ItemType.Varia:
                    HasVaria = true;
                    break;
                case ItemType.WaveBeam:
                    HasWaveBeam = true;
                    break;
            }
        }

    } 
}
