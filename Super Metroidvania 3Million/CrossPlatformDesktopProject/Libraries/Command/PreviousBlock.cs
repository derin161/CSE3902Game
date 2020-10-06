using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class PreviousBlock : ICommand
    {
		private Game1 game;
		public PreviousBlock(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			int result;
			foreach (List<ISprite> entry in game.blockSpriteListIndexes.Keys.ToList())
			{
				game.blockSpriteListIndexes.TryGetValue(entry, out result);
				if (result == 1)
				{
					game.blockSpriteListIndexes[entry] = entry.Count() - 1;
				}
				else if (result == 0)
				{
					game.blockSpriteListIndexes[entry] = entry.Count() - 2;
				}
				else
				{
					game.blockSpriteListIndexes[entry] -= 2;
				}
			}
		}
	}
}
