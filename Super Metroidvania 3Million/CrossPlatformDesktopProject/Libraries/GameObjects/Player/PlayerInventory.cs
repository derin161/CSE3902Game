
using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.Sprite.Items;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
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
        public bool HasHiddenPuzzles { get; private set; }

        public PlayerInventory(int startingEnergyLevel)
        {
            CurrentEnergyTanksFilled = 2;
            CurrentEnergyTanks = 3;
            CurrentMissileRocketCapacity = 25;
            CurrentEnergyLevel = startingEnergyLevel;
            HasLongBeam = false;
            HasIceBeam = false;
            HasWaveBeam = false;
            HasScrewAttack = false;
            HasHighJump = false;
            HasVaria = false;
            HasMaruMari = false;
            HasBomb = false;
            HasHiddenPuzzles = false;
        }

        public void Damage(int damage, IPlayer player)
        {
            CurrentEnergyLevel -= damage;
            if (CurrentEnergyLevel <= 0)
            {
                CurrentEnergyTanksFilled--;
                CurrentEnergyLevel = ((CurrentEnergyLevel % energyCapacityPerTank) + energyCapacityPerTank) % energyCapacityPerTank; //Mod that works for negative numbers
                if (CurrentEnergyTanksFilled < 0)
                { //Player is dead
                    player.Kill();
                }
            }

        }

        public void GiveItem(BombItem bomb)
        {
            HasBomb = true;
            upgradePickupSequence();
        }

        public void GiveItem(EnergyDropItem endrop)
        {
            CurrentEnergyLevel += 5;
            if (CurrentEnergyLevel > energyCapacityPerTank && CurrentEnergyTanksFilled < CurrentEnergyTanks)
            {
                CurrentEnergyLevel -= energyCapacityPerTank;
                CurrentEnergyTanksFilled++;
            }
            else if (CurrentEnergyLevel > energyCapacityPerTank)
            {
                CurrentEnergyLevel = energyCapacityPerTank;
            }
            SoundManager.Instance.Items.EnergyPickupSound.PlaySound();
        }

        public void GiveItem(EnergyTankItem entank)
        {
            if (CurrentEnergyTanks < MaximumEnergyTanks)
            {
                CurrentEnergyTanks++;
            }
            upgradePickupSequence();
        }

        public void GiveItem(HiddenPuzzles hp)
        {
            HasHiddenPuzzles = true;
            upgradePickupSequence();
        }

        public void GiveItem(HighJumpItem hj)
        {
            HasHighJump = true;

            upgradePickupSequence();
        }

        public void GiveItem(IceBeamItem ib)
        {
            HasIceBeam = true;
            upgradePickupSequence();
        }

        public void GiveItem(LongBeamItem lb)
        {
            HasLongBeam = true;
            upgradePickupSequence();
        }
        public void GiveItem(MorphBallItem mb)
        {
            HasMaruMari = true;
            upgradePickupSequence();
        }
        public void GiveItem(MissileRocketItem mr)
        {
            CurrentMissileRocketCapacity += 25;
            if (CurrentMissileRocketCapacity > MaximumMissileRocketCapacity)
            {
                CurrentMissileRocketCapacity = MaximumMissileRocketCapacity;
            }

            upgradePickupSequence();
        }
        public void GiveItem(RocketDropItem rd)
        {
            CurrentMissileRocketCount += 5;
            if (CurrentMissileRocketCount > CurrentMissileRocketCapacity)
            {
                CurrentMissileRocketCount = CurrentMissileRocketCapacity;
            }
        }

        public void GiveItem(ScrewAttackItem sa)
        {
            HasScrewAttack = true;
            upgradePickupSequence();
        }
        public void GiveItem(VariaItem v)
        {
            HasVaria = true;
            upgradePickupSequence();
        }
        public void GiveItem(WaveBeamItem wb)
        {
            HasWaveBeam = true;
            upgradePickupSequence();
        }

        private void upgradePickupSequence()
        {
            SoundManager.Instance.Songs.PlayItemAcquisitionSong();
            //pause not implemented for good flow when picking up all of the items
        }

        public void useRocket(){
            CurrentMissileRocketCount -= 1;
        }
    }
}
