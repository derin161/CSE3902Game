using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    public class StartingLevel : IStageState
    {
        public StartingLevel()
        {

        }

        public void LeftDoor()
        {
            // Do nothing - door does not exist
        }
        public void RightDoor()
        {
            LoadCsv.Instance.Load("LevelOne.csv", new Vector2(64, 64));
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
