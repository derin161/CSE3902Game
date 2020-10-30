using CrossPlatformDesktopProject.Libraries.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class CycleLevelCommand : ICommand
    {
        private Game1 game;
        public CycleLevelCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            LevelStatePattern.Instance.LoadNext();
        }
    }
}
