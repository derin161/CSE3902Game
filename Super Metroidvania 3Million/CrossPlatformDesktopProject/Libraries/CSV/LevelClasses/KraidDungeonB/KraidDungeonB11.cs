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
            LoadCsv.Instance.Load("KraidDungeon1.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeon1();
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon2.csv", new Vector2(64, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeon2();
            game.EnterBrinstarRoom();
        }
        public void TopLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void TopRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
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
