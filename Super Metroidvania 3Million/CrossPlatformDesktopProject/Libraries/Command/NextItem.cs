﻿using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class NextItem : ICommand
    {
		private Game1 game;

		public NextItem(Game1 game)
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
