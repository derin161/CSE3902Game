using CrossPlatformDesktopProject.Libraries.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class CycleLevel : ICommand
    {
        private Game1 game;
        public CycleLevel(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            LevelStatePattern.Instance.LoadNext();
        }
    }
}
