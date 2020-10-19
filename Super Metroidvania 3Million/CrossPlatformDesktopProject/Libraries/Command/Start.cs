namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class Start : ICommand
    {
        private Game1 currentGame;
        public Start(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Exit();
        }
    }
}
