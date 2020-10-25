using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class PreviousItemCommand : ICommand
    {
		private Game1 game;
		public PreviousItemCommand(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			if (game.itemIndex == 0)
			{
				game.itemIndex = game.itemSprites.Count() - 1;
			}
			else
			{
				game.itemIndex -= 1;
			}
		}
	}
}
