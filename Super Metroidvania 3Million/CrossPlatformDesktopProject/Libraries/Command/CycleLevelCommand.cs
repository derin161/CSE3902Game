using SuperMetroidvania5Million.Libraries.CSV;

namespace SuperMetroidvania5Million.Libraries.Command
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
