using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Command
public class NextEnemy : ICommand
{
	private Game1 myGame;

	public SetDeadPlayerSpriteCommand(Game1 game)
	{
		myGame = game;
	}

	public void Execute()
	{
		myGame.sprite = new DeadPlayerSprite(); // tighter coupling

		myGame.setSprite(new DeadPlayerSprite()); // looser coupling 
	}
}