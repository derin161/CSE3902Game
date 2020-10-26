using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Will Floyd
    class PreviousEnemyCommand : ICommand
	{
		private Game1 game;

		public PreviousEnemyCommand(Game1 game) //Unused
		{
			this.game = game;
		}

		public void Execute()
		{
			/*Move to previous enemy or last enemy if at the beginning
			if (game.enemyIndex == 0)
            {
				game.enemyIndex = game.enemySprites.Count() - 1;
            }else{
				game.enemyIndex -= 1;
            }*/
			
		}
	}
}