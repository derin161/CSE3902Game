using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.BlockSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class NextBlock : ICommand
    {
		private Game1 game;

		public NextBlock(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			int result;
			foreach (List<ISprite> entry in game.blockSpriteListIndexes)
			{
				result = blockSpriteListIndexes.TryGetValue(entry, out result);
				if (result == entry.Count() - 2)
                {
					blockSpriteListIndexes[entry] = 0;
				}
				else if (result = entry.Count() - 1)
                {
					blockSpriteListIndexes[entry] = 1;
				}
                else
                {
					blockSpriteListIndexes[entry] += 2;
				}
			}

		}
	}
}
