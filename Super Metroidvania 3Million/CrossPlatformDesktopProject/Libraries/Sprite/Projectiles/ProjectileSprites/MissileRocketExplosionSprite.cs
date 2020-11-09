using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    //This class isn't needed until collisions are added.
    class MissileRocketExplosionSprite : ISprite
    {
        enum AnimationPos { 
            Right, BottomRight, Bottom, BottomLeft, Left, UpperLeft, Upper, UpperRight
        }

        private Dictionary<AnimationPos, Vector2> explosionAnimationPairs = new Dictionary<AnimationPos, Vector2>(); //Contains animationPos mapped to their relative positions (to explosion origin)
        private Texture2D texture;
        private MissileRocketExplosion projectile;
        public MissileRocketExplosionSprite(Texture2D texture, MissileRocketExplosion mre) {
            this.texture = texture;
            projectile = mre;

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
                foreach (KeyValuePair<AnimationPos, Vector2> entry in explosionAnimationPairs)
                {
                    Rectangle recSrc = new Rectangle(26, 0, 8, 8); //Explosion corner texture
                    if (entry.Value.X == 0 || entry.Value.Y == 0) {
                        recSrc = new Rectangle(35, 0, 8, 8); //Explosion side texture
                    }
                    Rectangle recDest = new Rectangle((int)(projectile.Location.X + entry.Value.X), (int)(projectile.Location.Y + entry.Value.Y), 8, 8);
                    rotateAndDraw(spriteBatch, entry.Key, recDest, recSrc);
                }
        }

        public void Update(GameTime gameTime)
        {
            

            Vector2 right = new Vector2(1, 0);
            Vector2 left = new Vector2(-1, 0);
            Vector2 up = new Vector2(0, -1);
            Vector2 down = new Vector2(0, 1);
            //Adjust all x and y relative positions to push them further from the explosion origin
            for (int i = 0; i < 7; i++) {
                /*This is kind've stupid but allows me to change to dictionary during iteration whereas a foreach loop wouldn't
                  This cast is guaranteed to succeed as well as the dictionary indexing. */
                AnimationPos key = (AnimationPos) i;
                Vector2 pos = explosionAnimationPairs[key];
                if (pos.X > 0)
                {
                    pos = Vector2.Add(pos, right);
                }
                else if (pos.X < 0)
                {
                    pos = Vector2.Add(pos, left);
                }

                if (pos.Y > 0)
                {
                    pos = Vector2.Add(pos, down);
                }
                else if (pos.Y < 0)
                {
                    pos = Vector2.Add(pos, up);
                }
                explosionAnimationPairs[key] = pos;
                Console.WriteLine(explosionAnimationPairs + " = " + pos);
            }

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
