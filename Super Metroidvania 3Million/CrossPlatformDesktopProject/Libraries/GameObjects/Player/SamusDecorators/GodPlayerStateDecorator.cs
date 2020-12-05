using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMetroidvania5Million.Libraries.Sprite.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidvania5Million.Libraries.GameObjects.Player
{
    //Author: Nyigel Spann
    public class DamagedPlayerStateDecorator : AbstractPlayerStateDecorator
    {
        private int timer = 1000;
        private int interval = 100;
        private Color damagedColor;
        private Color originalColor;

        public DamagedPlayerStateDecorator(IPlayerState playerState, Color tintColor) : base(playerState) {
            DecoratedPlayerState = playerState;
            Sprite = playerState.Sprite;

            damagedColor = tintColor;
            originalColor = playerState.Sprite.Color;
        }

        public override void Update(GameTime gameTime)
        {
            DecoratedPlayerState.Update(gameTime);
            DecoratedPlayerState.Sprite.Color = damagedColor;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DecoratedPlayerState.Draw(spriteBatch);
        }
    }
}
