

using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class PlayerPhysics
    {
        private Vector2 acceleration = new Vector2(0, 0.5f);
        private Vector2 velocity = new Vector2(0, 0);
        private float maxFallVelocity = 5;
        private float maxHorizontalVelocity = 5;
        private float horizontalRunAcceleration = 0.5f;
        private Samus player;

        public PlayerPhysics(Samus player) {
            this.player = player;
        }

        public void Update() {
            player.position = Vector2.Add(player.position, velocity);
            player.space = new Rectangle((int) player.position.X, (int) player.position.Y, player.space.Width, player.space.Height);

            velocity = Vector2.Add(velocity, acceleration);
            if (velocity.Y > maxFallVelocity) {
                velocity = new Vector2(velocity.X, maxFallVelocity);
            }
            if (velocity.X > maxHorizontalVelocity) {
                velocity = new Vector2( maxHorizontalVelocity, velocity.Y);
            } else if (velocity.X < -1 * maxHorizontalVelocity) {
                velocity = new Vector2(-1 * maxHorizontalVelocity, velocity.Y);
            }
        }

        public void VerticalBreak() {
            this.velocity = new Vector2(this.velocity.X, 0);
        }

        public void HortizontalBreak()
        {
            this.velocity = new Vector2(0, this.velocity.Y);
        }

        public void MoveRight() {
            this.velocity = Vector2.Add(this.velocity, new Vector2(horizontalRunAcceleration, 0));
        }

        public void MoveLeft() {
            this.velocity = Vector2.Add(this.velocity, new Vector2(horizontalRunAcceleration * -1, 0));
        }


    }
}
