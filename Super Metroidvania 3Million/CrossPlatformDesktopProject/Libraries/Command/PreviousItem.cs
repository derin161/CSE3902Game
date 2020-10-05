using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class PreviousItem : ICommand
    {
		private Game1 game;
		public PreviousItem(Game1 game)
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
