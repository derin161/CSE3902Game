using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Will Floyd
    class PreviousEnemy : ICommand
	{
		private Game1 game;

		public PreviousEnemy(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			//Move to previous enemy or last enemy if at the beginning
			if (game.enemyIndex == 0)
            {
				game.enemyIndex = game.enemySprites.Count() - 1;
            }else{
				game.enemyIndex -= 1;
            }
			
		}
	}
}