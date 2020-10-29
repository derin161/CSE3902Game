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

        private static StartingLevel startingLevel = new StartingLevel();
        private static LevelOne levelOne = new LevelOne();
        private static LevelTwo levelTwo = new LevelTwo();

        public IStageState state { get; set; } = startingLevel;

        private static LevelStatePattern instance = new LevelStatePattern();
       
        public static LevelStatePattern Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize()
        {
            LoadCsv.Instance.Load("startingLevel.csv");
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
