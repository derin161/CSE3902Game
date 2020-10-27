namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class QuitCommand : ICommand
    {
        private Game1 currentGame;
        public QuitCommand(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Exit();
        }
    }
}
