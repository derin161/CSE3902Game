using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB12 : IStageState
    {
        public KraidDungeonB12()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB16.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB16();
            game.SetCamera(true);
        }
        public void RightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB11.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB11();
            game.SetCamera(true);
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB13.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB13();
            game.SetCamera(true);
        }
        public void BottomLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB19.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB19();
            game.SetCamera(true);
        }
        public void BottomRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
    }
}
