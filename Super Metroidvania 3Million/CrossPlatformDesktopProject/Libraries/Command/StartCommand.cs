namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class StartCommand : ICommand
    {
        private Game1 currentGame;
        public StartCommand(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Exit();
        }
    }
}
