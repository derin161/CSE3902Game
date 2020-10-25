using System.Collections.Generic;
using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class PreviousBlockCommand : ICommand
    {
		private Game1 game;
		public PreviousBlockCommand(Game1 game)
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
