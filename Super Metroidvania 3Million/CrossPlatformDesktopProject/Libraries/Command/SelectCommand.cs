namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    public class SelectCommand : ICommand
    {
        private Game1 currentGame;
        public SelectCommand(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Restart();
        }
    }
}
