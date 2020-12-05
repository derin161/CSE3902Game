using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB6 : IStageState
    {
        public KraidDungeonB6()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
            
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB10.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB10();
        }
        public void TopLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB7.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB7();
        }
        public void BottomLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB14.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB14();
        }
    }
}
