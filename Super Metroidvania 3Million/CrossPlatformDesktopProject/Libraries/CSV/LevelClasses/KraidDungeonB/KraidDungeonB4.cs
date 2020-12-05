using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB4 : IStageState
    {
        public KraidDungeonB4()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void RightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB3.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeon3();
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB5.csv", new Vector2(64, 224), game);
            LevelStatePattern.Instance.state = new KraidDungeon5();
        }
        public void BottomLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
    }
}
