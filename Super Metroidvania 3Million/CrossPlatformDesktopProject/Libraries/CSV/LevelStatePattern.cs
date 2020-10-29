using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class LevelStatePattern // We can use this to additionally track game states (i.e. game over/starting screen/etc.)
    {
        // public int [InsertItemPickupNameHere] { get; private set; }
        public IStageState state;

        private StartingLevel startingLevel;
        private LevelOne levelOne;
        private LevelTwo levelTwo;

        public LevelStatePattern()
        {
            startingLevel = new StartingLevel(this);
            levelOne = new LevelOne(this);
            levelTwo = new LevelTwo(this);

            state = startingLevel;
        }

        public void Restart()
        {
            LoadCsv.Instance.Load("levelOne.csv");
        }

        public IStageState GetState(string stateID)
        {
            return stateID switch
            {
                "startingLevel" => startingLevel,
                "levelOne" => levelOne,
                "levelTwo" => levelTwo,
                _ => null,
            };
        }

        public void Door1() // Top left door
        {
            state.Door1();
        }
        public void Door2() // Top right door
        {
            state.Door2();
        }
        public void Door3() // Middle left door
        {
            state.Door3();
        }
        public void Door4() // Middle right door
        {
            state.Door4();
        }
        public void Door5() // Top left door
        {
            state.Door5();
        }
        public void Door6() // Top right door
        {
            state.Door6();
        }
    }
}
