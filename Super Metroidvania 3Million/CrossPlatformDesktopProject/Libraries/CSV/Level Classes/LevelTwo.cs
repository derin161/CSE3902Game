using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.CSV
{
    class LevelTwo : IStageState
    {
        private LevelStatePattern level;

        public LevelTwo(LevelStatePattern level)
        {
            this.level = level;
        }

        public void Door1()
        {
            LoadCsv.Instance.Load("LevelOne");
        }
        public void Door2()
        {
            // Do nothing - door does not exist
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
