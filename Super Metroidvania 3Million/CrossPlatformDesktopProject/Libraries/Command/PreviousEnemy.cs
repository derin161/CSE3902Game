﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
	class PreviousEnemy : ICommand
	{
		private Game1 myGame;

		public PreviousEnemy(Game1 game)
		{
			myGame = game;
		}

		public void Execute()
		{

		}
	}
}