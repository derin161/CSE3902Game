namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    public class Select : ICommand
    {
        private Game1 currentGame;
        public Select(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Restart();
        }
    }
}
