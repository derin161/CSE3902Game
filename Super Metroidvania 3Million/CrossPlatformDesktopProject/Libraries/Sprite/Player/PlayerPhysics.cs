

using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class PlayerPhysics
    {
        private Vector2 acceleration = new Vector2(0, 0.5f);
        private Vector2 velocity = new Vector2(0, 0);
        private Vector2 maxVelocity;
        private Samus player;

        public PlayerPhysics(Samus player) {
            this.player = player;
        }

        public void Update() {
            player.position = Vector2.Add(player.position, velocity);
            player.space = new Rectangle((int)player.position.X, (int)player.position.Y, 64, 64);
            velocity = Vector2.Add(velocity, acceleration);
        }

        public void Break() {
            this.velocity = new Vector2(0, 0);
        }


    }
}
