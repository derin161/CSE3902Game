using System.Collections.Generic;
using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class NextBlockCommand : ICommand
    {
		private Game1 game;

		public NextBlockCommand(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			int result;
			foreach (List<ISprite> entry in game.blockSpriteListIndexes.Keys.ToList())
			{
				game.blockSpriteListIndexes.TryGetValue(entry, out result);
				if (result == entry.Count() - 2)
                {
					game.blockSpriteListIndexes[entry] = 0;
				}
				else if (result == entry.Count() - 1)
                {
					game.blockSpriteListIndexes[entry] = 1;
				}
                else
                {
					game.blockSpriteListIndexes[entry] += 2;
				}
			}

		}
	}
}
