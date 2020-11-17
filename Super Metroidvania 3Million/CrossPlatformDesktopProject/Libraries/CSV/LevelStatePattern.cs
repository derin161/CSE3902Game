﻿using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Container;


namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class LevelStatePattern // We can use this to additionally track game states (i.e. game over/starting screen/etc.)
    {
        // public int [InsertItemPickupNameHere] { get; private set; }
        int levelIndex = 1, numLevels = 3;

        private static StartingLevel startingLevel = new StartingLevel();
        private static LevelOne levelOne = new LevelOne();
        private static LevelTwo levelTwo = new LevelTwo();

        public enum Door { left, right };
        public IStageState state { get; set; } = startingLevel;

        private Game1 game;

        private static LevelStatePattern instance = new LevelStatePattern();
       
        public static LevelStatePattern Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize(Vector2 playerSpawnLocation, Game1 game)
        {
            this.game = game;
            //LoadCsv.Instance.Load("KraidDungeonSample.csv", new Vector2(3904, 400));
            LoadCsv.Instance.Load("KraidDungeonSample.csv", new Vector2(64, 200),game);
        }

        public void SwitchLevel(Door door)
        {
            if (door == Door.left)
            {
                //GameObjectContainer.Instance.Player.UpdateLocation();
            }
            else
            {

            }

            /*if (state == startingLevel)
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
                
            }*/
        }

        public void LoadNext()
        {
            switch (levelIndex)
            {
                case 0:
                    LoadCsv.Instance.Load("StartingLevel.csv", new Vector2(64, 64), game);
                    break;
                case 1:
                    LoadCsv.Instance.Load("LevelOne.csv", new Vector2(64, 64), game);
                    break;
                case 2:
                    LoadCsv.Instance.Load("LevelTwo.csv", new Vector2(64, 64), game);
                    break;
            }
            levelIndex++;
            if (levelIndex >= numLevels)
            {
                levelIndex = 0;
            }
        }

        public void LeftDoor() 
        {
            state.LeftDoor(game);
        }
        public void RightDoor() 
        {
            state.RightDoor(game);
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
