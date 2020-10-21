using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ShootBeam : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;
        private float speed = 7;
        private List<PlayerSprite.State> bannedStates = new List<PlayerSprite.State> { PlayerSprite.State.Crouch, PlayerSprite.State.Jump};

        public ShootBeam(Game1 game, PlayerSprite player) {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!bannedStates.Contains(samus.currentState))
            {
                Vector2 direction = new Vector2(speed, 0);
                samus.currentState = PlayerSprite.State.Attack;
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
