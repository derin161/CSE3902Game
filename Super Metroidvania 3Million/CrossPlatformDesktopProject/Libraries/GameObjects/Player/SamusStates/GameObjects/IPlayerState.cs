using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    public interface IPlayerState
    {
        public IPlayerSprite Sprite { get; set; }
        public void Attack(); //Shoots active beam missile device or places bomb.
        public void Jump();
        public void Morph();
        public void MoveRight();
        public void MoveLeft();
        public void AimUp();
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public void Idle();

    }
}
