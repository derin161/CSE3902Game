using Microsoft.Xna.Framework;

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
            LoadCsv.Instance.Load("LevelOne.csv", new Vector2(64, 64));
        }

        public void SwitchLevel(Door door)
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

        public void LoadNext()
        {
            switch (levelIndex)
            {
                case 0:
                    LoadCsv.Instance.Load("StartingLevel.csv", new Vector2(64, 64));
                    break;
                case 1:
                    LoadCsv.Instance.Load("LevelOne.csv", new Vector2(64, 64));
                    break;
                case 2:
                    LoadCsv.Instance.Load("LevelTwo.csv", new Vector2(64, 64));
                    break;
            }
            levelIndex++;
            if (levelIndex >= numLevels)
            {
                levelIndex = 0;
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
        public IStageState GetLevel()
        {
            return state;
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
