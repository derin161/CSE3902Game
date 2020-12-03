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
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeon8.csv", new Vector2(64, 224), game);
        }
        public void TopLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void TopRightDoor()
        {
            // Do nothing - door does not exist
        }
        public void BottomLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void BottomRightDoor()
        {
            // Do nothing - door does not exist
        }
        public void FarBottomLeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void FarBottomRightDoor()
        {
            // Do nothing - door does not exist
        }
    }
}
