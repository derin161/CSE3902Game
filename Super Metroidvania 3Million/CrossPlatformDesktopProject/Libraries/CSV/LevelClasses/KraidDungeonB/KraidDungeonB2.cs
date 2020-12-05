using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeonB2 : IStageState
    {
        public KraidDungeonB2()
        {
            
        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB7.csv", new Vector2(920, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB7();
            game.SetCamera(true);
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB8.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB8();
            game.SetCamera(true);
            game.EnterBrinstarRoom();
        }
        public void TopLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB1.csv", new Vector2(360, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB1();
            game.SetCamera(true);
        }
        public void TopRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB3.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB3();
            game.SetCamera(true);
        }
        public void BottomLeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB10.csv", new Vector2(792, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB10();
            game.SetCamera(true);
        }
        public void BottomRightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonB11.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeonB11();
            game.SetCamera(true);
        }
    }
}
