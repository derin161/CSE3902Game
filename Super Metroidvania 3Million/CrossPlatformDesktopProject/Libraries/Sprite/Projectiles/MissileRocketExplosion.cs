using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    class MissileRocketExplosion : ISprite
    {
        enum AnimationPos { 
            Right, BottomRight, Bottom, BottomLeft, Left, UpperLeft, Upper, UpperRight
        }

        private Dictionary<AnimationPos, Vector2> explosionAnimationPairs; //Contains animationPos mapped to their relative positions (to explosion origin)
        private Vector2 explosionOrigin;
        private Texture2D texture;
        private int time = 0;
        private int endTime = 500;
        private bool isDead = false;
        public MissileRocketExplosion(Texture2D texture, Vector2 location) {
            this.texture = texture;
            explosionOrigin = location;

            explosionAnimationPairs.Add(AnimationPos.Right, new Vector2(1, 0));
            explosionAnimationPairs.Add(AnimationPos.Bottom, new Vector2(0, 1));
            explosionAnimationPairs.Add(AnimationPos.Left, new Vector2(-1, 0));
            explosionAnimationPairs.Add(AnimationPos.Upper, new Vector2(0, -1));
            explosionAnimationPairs.Add(AnimationPos.BottomRight, new Vector2(1, 1));
            explosionAnimationPairs.Add(AnimationPos.UpperRight, new Vector2(1, -1));
            explosionAnimationPairs.Add(AnimationPos.BottomLeft, new Vector2(-1, 1));
            explosionAnimationPairs.Add(AnimationPos.UpperLeft, new Vector2(-1, -1));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (time < endTime)
            {
                foreach (KeyValuePair<AnimationPos, Vector2> entry in explosionAnimationPairs)
                {
                    Rectangle recSrc = new Rectangle(26, 0, 8, 8); //Explosion corner texture
                    if (entry.Value.X == 0 || entry.Value.Y == 0) {
                        recSrc = new Rectangle(35, 0, 8, 8); //Explosion side texture
                    }
                    Rectangle recDest = new Rectangle((int)(explosionOrigin.X + entry.Value.X), (int)(explosionOrigin.Y + entry.Value.Y), 8, 8);
                    rotateAndDraw(spriteBatch, entry.Key, recDest, recSrc);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;

            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
            Vector2 up = new Vector2(0, -1);
            Vector2 down = new Vector2(0, 1);

            //Adjust all x and y relative positions to push them further from the explosion origin
            foreach (KeyValuePair<AnimationPos, Vector2> entry in explosionAnimationPairs) {
                if (entry.Value.X > 0) {
                    explosionAnimationPairs[entry.Key] = Vector2.Add(entry.Value, right);
                } else if (entry.Value.X < 0) {
                    explosionAnimationPairs[entry.Key] = Vector2.Add(entry.Value, left);
                }

                if (entry.Value.Y > 0)
                {
                    explosionAnimationPairs[entry.Key] = Vector2.Add(entry.Value, down);
                }
                else if (entry.Value.Y < 0)
                {
                    explosionAnimationPairs[entry.Key] = Vector2.Add(entry.Value, up);
                }
            }
        }

        public bool IsDead() {
            return isDead;
        }

        private void rotateAndDraw(SpriteBatch sb, AnimationPos pos, Rectangle dest, Rectangle src) {
            Vector2 center = new Vector2(src.Width/2, src.Height / 2);
            switch (pos) {
                case AnimationPos.Right:
                    sb.Draw(texture, dest, src, Color.White, 0, center, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimationPos.Left:
                    sb.Draw(texture, dest, src, Color.White, 0, center, SpriteEffects.None, 0);
                    break;
                case AnimationPos.Bottom:
                    sb.Draw(texture, dest, src, Color.White, 90, center, SpriteEffects.None, 0);
                    break;
                case AnimationPos.Upper:
                    sb.Draw(texture, dest, src, Color.White, 270, center, SpriteEffects.None, 0);
                    break;
                case AnimationPos.UpperRight:
                    sb.Draw(texture, dest, src, Color.White, 0, center, SpriteEffects.FlipHorizontally, 0);
                    break;
                case AnimationPos.UpperLeft:
                    sb.Draw(texture, dest, src, Color.White, 0, center, SpriteEffects.None, 0);
                    break;
                case AnimationPos.BottomRight:
                    sb.Draw(texture, dest, src, Color.White, 180, center, SpriteEffects.None, 0);
                    break;
                case AnimationPos.BottomLeft:
                    sb.Draw(texture, dest, src, Color.White, 0, center, SpriteEffects.FlipVertically, 0);
                    break;
                default:
                    //Nothing here.
                    break;
            }
        }
    }
}
