using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB11 : IStageState
    {
        public KraidDungeonB11()
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
            LoadCsv.Instance.Load("KraidDungeonB2.csv", new Vector2(400, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB2();
            game.SetCamera(false);
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB12.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB12();
            game.SetCamera(false);
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
