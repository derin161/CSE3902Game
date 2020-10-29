using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    class LevelOne : IStageState
    {
        public LevelOne()
        {

        }

        public void Door1()
        {
            LoadCsv.Instance.Load("StartingLevel");
        }
        public void Door2()
        {
            LoadCsv.Instance.Load("LevelOne");
        }
        public void Door3()
        {
            // Do nothing - door does not exist
        }
        public void Door4()
        {
            // Do nothing - door does not exist
        }
        public void Door5()
        {
            // Do nothing - door does not exist
        }
        public void Door6()
        {
            // Do nothing - door does not exist
        }

    }
}
