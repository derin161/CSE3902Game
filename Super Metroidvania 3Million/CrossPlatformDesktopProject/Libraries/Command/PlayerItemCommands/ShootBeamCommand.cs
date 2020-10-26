using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ShootBeamCommand : ICommand
    {
        private Player samus;
        private Game1 game;
        private float speed = 7;
        private List<Player.State> bannedStates = new List<Player.State> { Player.State.Crouch, Player.State.Jump};

        public ShootBeamCommand(Game1 game, IPlayer player) {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!bannedStates.Contains(samus.currentState))
            {
                Vector2 direction = new Vector2(speed, 0);
                samus.currentState = Player.State.Attack;
                samus.idleFrames = 0;
                Vector2 location = new Vector2(samus.Location.X + 46, samus.Location.Y + 18);

                if (!samus.facingRight)
                {
                    direction = new Vector2(-speed, 0);
                    location = new Vector2(samus.Location.X + 12, samus.Location.Y + 18);
                }
                
                if (samus.wave)
                {
                    game.AddSprite(ProjectilesGOFactory.Instance.CreateWaveBeam(location, direction, samus.elong));
                }
                else //Power beam or ice beam
                {
                    game.AddSprite(ProjectilesGOFactory.Instance.CreatePowerBeam(location, direction, samus.elong, samus.ice));
                }
            }
        }
    }
}
