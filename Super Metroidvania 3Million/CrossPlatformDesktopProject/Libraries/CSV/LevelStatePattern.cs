using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    public class LevelStatePattern // We can use this to additionally track game states (i.e. game over/starting screen/etc.)
    {
        // public int [InsertItemPickupNameHere] { get; private set; }
        int levelIndex = 1, numLevels = 3;

        /*private static StartingLevel startingLevel = new StartingLevel();
        private static LevelOne levelOne = new LevelOne();
        private static LevelTwo levelTwo = new LevelTwo();*/

        private static KraidDungeon1 kraidDungeon1 = new KraidDungeon1();
        private static KraidDungeon2 kraidDungeon2 = new KraidDungeon2();
        private static KraidDungeon3 kraidDungeon3 = new KraidDungeon3();
        private static KraidDungeon4 kraidDungeon4 = new KraidDungeon4();
        private static KraidDungeon5 kraidDungeon5 = new KraidDungeon5();
        private static KraidDungeon6 kraidDungeon6 = new KraidDungeon6();
        private static KraidDungeon7 kraidDungeon7 = new KraidDungeon7();
        private static KraidDungeon8 kraidDungeon8 = new KraidDungeon8();

        private static KraidDungeonB1 kraidDungeonB1 = new KraidDungeonB1();
        private static KraidDungeonB2 kraidDungeonB2 = new KraidDungeonB2();
        private static KraidDungeonB3 kraidDungeonB3 = new KraidDungeonB3();
        private static KraidDungeonB4 kraidDungeonB4 = new KraidDungeonB4();
        private static KraidDungeonB5 kraidDungeonB5 = new KraidDungeonB5();
        private static KraidDungeonB6 kraidDungeonB6 = new KraidDungeonB6();
        private static KraidDungeonB7 kraidDungeonB7 = new KraidDungeonB7();
        private static KraidDungeonB8 kraidDungeonB8 = new KraidDungeonB8();
        private static KraidDungeonB9 kraidDungeonB9 = new KraidDungeonB9();
        private static KraidDungeonB10 kraidDungeonB10 = new KraidDungeonB10();
        private static KraidDungeonB11 kraidDungeonB11 = new KraidDungeonB11();
        private static KraidDungeonB12 kraidDungeonB12 = new KraidDungeonB12();
        private static KraidDungeonB13 kraidDungeonB13 = new KraidDungeonB13();
        private static KraidDungeonB14 kraidDungeonB14 = new KraidDungeonB14();
        private static KraidDungeonB15 kraidDungeonB15 = new KraidDungeonB15();
        private static KraidDungeonB16 kraidDungeonB16 = new KraidDungeonB16();
        private static KraidDungeonB17 kraidDungeonB17 = new KraidDungeonB17();
        private static KraidDungeonB18 kraidDungeonB18 = new KraidDungeonB18();
        private static KraidDungeonB19 kraidDungeonB19 = new KraidDungeonB19();


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
        private LevelStatePattern() { //private constructor for singleton
        
        }

        public void Initialize(Game1 game)
        {
            this.game = game;
            state = kraidDungeon5;
            LoadCsv.Instance.Load("KraidDungeon5.csv", new Vector2(368, 354), game);
            game.SetCamera(true);
        }

        public void InitializeB(Game1 game)
        {
            this.game = game;
            state = kraidDungeonB3;
            LoadCsv.Instance.Load("KraidDungeonB3.csv", new Vector2(368, 354), game);
            game.SetCamera(true);
        }

        public void InitializeEndlessMode(Game1 game)
        {
            this.game = game;
            game.endlessMode = true;
            LoadCsv.Instance.Load("EndlessLevel.csv", new Vector2(368, 354), game);
            game.SetCamera(true);
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
            state.TopLeftDoor(game);
        }
        public void TopRightDoor()
        {
            state.TopRightDoor(game);
        }
        public void BottomLeftDoor()
        {
            state.BottomLeftDoor(game);
        }
        public void BottomRightDoor()
        {
            state.BottomRightDoor(game);
        }
    }
}
