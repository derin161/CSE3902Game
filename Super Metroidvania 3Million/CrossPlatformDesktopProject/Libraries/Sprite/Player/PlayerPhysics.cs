

using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class PlayerPhysics
    {
        private Vector2 acceleration = new Vector2(0, 1.0f);
        public Vector2 velocity {get; set;}
        private float maxFallVelocity = 13;
        private float horizontalRunSpeed = 5;
        private float jumpSpeed = -13.0f;
        private Samus player;

        public PlayerPhysics(Samus player) {
            this.player = player;
            velocity = new Vector2(0, 0);
        }

        public void Update() {
            player.x += velocity.X;
            player.y += velocity.Y;
            player.space = new Rectangle((int) player.x, (int) player.y, player.space.Width, player.space.Height);

            //Set velocity to max velocity if it goes over
            velocity = Vector2.Add(velocity, acceleration);
            if (velocity.Y > maxFallVelocity) {
                velocity = new Vector2(velocity.X, maxFallVelocity);
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
            this.velocity = new Vector2(horizontalRunSpeed, this.velocity.Y);
        }

        public void MoveLeft() {
            this.velocity = new Vector2(horizontalRunSpeed * -1, this.velocity.Y);
        }

        public void Jump() {
            this.velocity = new Vector2(this.velocity.X, jumpSpeed);
        }


    }
}
