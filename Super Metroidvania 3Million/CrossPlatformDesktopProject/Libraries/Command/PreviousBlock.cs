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
			foreach (List<ISprite> entry in game.blockSpriteListIndexes)
			{
				result = blockSpriteListIndexes.TryGetValue(entry, out result);
				if (result == 1)
				{
					blockSpriteListIndexes[entry] = entry.Count() - 2;
				}
				else if (result == 0)
				{
					blockSpriteListIndexes[entry] = entry.Count() - 1;
				}
				else
				{
					blockSpriteListIndexes[entry] -= 2;
				}
			}
		}
	}
}
