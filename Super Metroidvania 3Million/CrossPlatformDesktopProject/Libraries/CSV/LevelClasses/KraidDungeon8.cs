using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeon8 : IStageState
    {
        public KraidDungeon8()
        {

        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon7.csv", new Vector2(1400, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeon7();
            game.EnterBrinstarRoom();
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon8.csv", new Vector2(64, 224), game);
            LevelStatePattern.Instance.state = new KraidDungeon8();
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
