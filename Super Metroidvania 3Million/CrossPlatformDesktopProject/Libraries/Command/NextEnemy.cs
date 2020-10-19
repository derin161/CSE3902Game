using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Will Floyd
    class NextEnemy : ICommand
	{
		private Game1 game;

		public NextEnemy(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			//Move to next element in array or back to beginning if at the end
			if (game.enemyIndex == game.enemySprites.Count() - 1)
			{
				game.enemyIndex = 0;
			}
			else
			{
				game.enemyIndex += 1;
			}
		}
	}
}