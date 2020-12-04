using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman, Danny Attia
    class KraidDungeon7 : IStageState
    {
        public KraidDungeon7()
        {

        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon6.csv", new Vector2(672, 192), game);
            LevelStatePattern.Instance.state = new KraidDungeon6();
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon8.csv", new Vector2(64, 224), game);
            LevelStatePattern.Instance.state = new KraidDungeon8();
            game.EnterSecretRoom();
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
        public void FarBottomLeftDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
        public void FarBottomRightDoor(Game1 game)
        {
            // Do nothing - door does not exist
        }
    }
}
