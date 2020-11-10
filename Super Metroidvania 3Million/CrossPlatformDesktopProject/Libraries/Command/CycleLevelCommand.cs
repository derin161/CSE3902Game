using CrossPlatformDesktopProject.Libraries.CSV;

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
