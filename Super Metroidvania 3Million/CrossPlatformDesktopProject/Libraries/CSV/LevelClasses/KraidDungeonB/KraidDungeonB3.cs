using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB3 : IStageState
    {
        public KraidDungeonB3()
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
            LoadCsv.Instance.Load("KraidDungeonB2.csv", new Vector2(400, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB2();
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB4.csv", new Vector2(64, 224), game);
            LevelStatePattern.Instance.state = new KraidDungeonB4();
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
