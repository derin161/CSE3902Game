namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Shyamal Shah
    public class RestartCommand : ICommand
    {
        private Game1 currentGame;
        public RestartCommand(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Restart();
        }
    }
}
