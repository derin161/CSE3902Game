﻿using SuperMetroidvania5Million.Libraries.Sprite.Player;

namespace SuperMetroidvania5Million.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    public class PlayerJumpCommand : ICommand
    {
        private IPlayer player;

        public PlayerJumpCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player;
        }
        public void Execute()
        {
            player.Jump();
        }
    }
}
