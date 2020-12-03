using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.CSV
{
    //Author: Tristan Roman
    class LevelTwo : IStageState
    {
        public LevelTwo()
        {

        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("LevelOne.csv", new Vector2(672, 352), game);
        }
        public void RightDoor(Game1 game)
        {
            // Do nothing - door does not exist
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
