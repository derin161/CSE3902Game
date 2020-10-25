using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class NextItemCommand : ICommand
    {
		private Game1 game;

		public NextItemCommand(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			if (game.itemIndex == game.itemSprites.Count() - 1)
			{
				game.itemIndex = 0;
			}
			else
			{
				game.itemIndex += 1;
			}
		}
	}
}
