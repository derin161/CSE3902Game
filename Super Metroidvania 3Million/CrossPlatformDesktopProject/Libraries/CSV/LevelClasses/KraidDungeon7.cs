using Microsoft.Xna.Framework;
using System.Dynamic;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    class KraidDungeon7 : IStageState
    {
        public KraidDungeon7()
        {

        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("StartingLevel.csv", new Vector2(672, 192), game);
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("LevelTwo.csv", new Vector2(96, 224), game);
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
