using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    public class LevelStatePattern // We can use this to additionally track game states (i.e. game over/starting screen/etc.)
    {
        // public int [InsertItemPickupNameHere] { get; private set; }
        int levelIndex = 1, numLevels = 3;

        private static StartingLevel startingLevel = new StartingLevel();
        private static LevelOne levelOne = new LevelOne();
        private static LevelTwo levelTwo = new LevelTwo();

        private static KraidDungeon1 kraidDungeon1 = new KraidDungeon1();
        private static KraidDungeon2 kraidDungeon2 = new KraidDungeon2();
        private static KraidDungeon3 kraidDungeon3 = new KraidDungeon3();
        private static KraidDungeon4 kraidDungeon4 = new KraidDungeon4();
        private static KraidDungeon5 kraidDungeon5 = new KraidDungeon5();
        private static KraidDungeon6 kraidDungeon6 = new KraidDungeon6();
        private static KraidDungeon7 kraidDungeon7 = new KraidDungeon7();
        private static KraidDungeon8 kraidDungeon8 = new KraidDungeon8();


        public enum Door { left, right };
        public IStageState state { get; set; } = kraidDungeon5;

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
            LoadCsv.Instance.Load("KraidDungeon5.csv", new Vector2(368, 354), game);
            //LoadCsv.Instance.Load("KraidDungeon1.csv", new Vector2(64, 200), game);
        }

        public void SwitchLevel(Door door)
        {
            
            if (door == Door.left)
            {
                //GameObjectContainer.Instance.Player.UpdateLocation();             ////////
            }
            else
            {

            }
            

            // Probably need to remove
            if (state == kraidDungeon1)
            {
                RightDoor();
                state = kraidDungeon2;
            }
            else if (state == kraidDungeon2)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon1;
                }
                else
                {
                    RightDoor();
                    state = kraidDungeon3;

                }
            }
            else if (state == kraidDungeon3)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon2;

                }
                else
                {
                    RightDoor();
                    state = kraidDungeon4;

                }
            }
            else if (state == kraidDungeon4)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon3;

                }
                else
                {
                    RightDoor();
                    state = kraidDungeon5;

                }
            }
            else if (state == kraidDungeon5)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon4;

                }
                else
                {
                    RightDoor();
                    state = kraidDungeon6;

                }
            }
            else if (state == kraidDungeon6)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon5;

                }
                else
                {
                    RightDoor();
                    state = kraidDungeon7;

                }
            }
            else if (state == kraidDungeon7)
            {
                if (door == Door.left)
                {
                    LeftDoor();
                    state = kraidDungeon6;

                }
                else
                {
                    RightDoor();
                    state = kraidDungeon8;

                }
            }
            else if (state == kraidDungeon8)
            {
                LeftDoor();
                state = kraidDungeon7;
            }
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
        /*public void TopLeftDoor()
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
        }*/
    }
}
