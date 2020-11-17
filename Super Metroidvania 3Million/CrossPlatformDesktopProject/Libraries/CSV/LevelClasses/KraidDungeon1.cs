using Microsoft.Xna.Framework;
using System.Dynamic;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    class KraidDungeon1 : IStageState
    {
        public KraidDungeon1()
        {

        }

        public void LeftDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonSample.csv", new Vector2(672, 192), game);
        }
        public void RightDoor(Game1 game)
        {
            LoadCsv.Instance.Load("KraidDungeonSample.csv", new Vector2(672, 192), game);
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
