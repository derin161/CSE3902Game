using CrossPlatformDesktopProject.Libraries.Audio;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class PlayerPhysics
    {
        private Vector2 acceleration = new Vector2(0, 0.3f);
        public Vector2 velocity {get; set;}
        private float maxFallVelocity = 8;
        private float horizontalRunSpeed = 3;
        private float jumpSpeed = -8f;
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
            velocity = new Vector2(velocity.X, 0);
        }

        public void HortizontalBreak()
        {
            velocity = new Vector2(0, velocity.Y);
        }

        public void MoveRight() {
            velocity = new Vector2(horizontalRunSpeed, velocity.Y);
        }

        public void MoveLeft() {
            velocity = new Vector2(horizontalRunSpeed * -1, velocity.Y);
        }

        public void Jump() {
            velocity = new Vector2(velocity.X, jumpSpeed);
            SoundManager.Instance.Player.JumpSound.PlaySound();
        }

        public float getYVelocity(){
            return velocity.Y;
        }


    }
}
