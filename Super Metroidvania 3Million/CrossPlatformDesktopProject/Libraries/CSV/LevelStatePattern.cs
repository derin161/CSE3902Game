using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
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

        public enum Door { left, right };
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
            LoadCsv.Instance.Load("StartingLevel.csv", new Vector2(64, 64));
        }

        public void switchLevel(Door door)
        {
  
            if (state == startingLevel)
            {
                RightDoor();
                state = levelOne;
            }
            else if (state == levelOne)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = startingLevel;
                    
                }
                else
                {
                    RightDoor();
                    state = levelTwo;
                    
                }
            }
            else if (state == levelTwo)
            {
                LeftDoor();
                state = levelOne;
                
            }
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

        public void LeftDoor() 
        {
            state.LeftDoor();
        }
        public void RightDoor() 
        {
            state.RightDoor();
        }
        public void TopLeftDoor() 
        {
            state.TopLeftDoor();
        }
        public void TopRightDoor() 
        {
            state.TopRightDoor();
        }
        public void BottomLeftDoor() 
        {
            state.BottomLeftDoor();
        }
        public void BottomRightDoor() 
        {
            state.BottomRightDoor();
        }

        public void FarBottomLeftDoor()
        {
            state.FarBottomLeftDoor();
        }
        public void FarBottomRightDoor()
        {
            state.FarBottomRightDoor();
        }
    }
}
