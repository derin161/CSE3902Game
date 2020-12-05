using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB10 : IStageState
    {
        public KraidDungeonB10()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
           
        }
        public void RightDoor(Game1 game)
        {
            
        }
        public void TopLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB6.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB6();
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB2.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB2();
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
