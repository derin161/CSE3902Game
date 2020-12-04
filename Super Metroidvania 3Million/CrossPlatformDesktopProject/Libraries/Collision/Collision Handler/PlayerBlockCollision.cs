using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.CSV;
using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class PlayerBlockCollision
    {
        public PlayerBlockCollision()
        {

        }

        public void HandleCollision(IPlayer player, IBlock block, Rectangle collisionZone)
        {
            Samus sam = ((Samus)player);
            if (block is IDoorBlock) //&& ((IDoorBlock)block).isOpen())
            {
                if (collisionZone.X >= 240)
                {
                    LevelStatePattern.Instance.RightDoor();
                }
                else
                {
                    LevelStatePattern.Instance.LeftDoor();
                }
            }
            else if (block is LavaBlockTop)
            {
                sam.TakeDamage(BlockUtilities.Instance.lavaDamage);
            }
            else
            {
                //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
                if (collisionZone.Height > collisionZone.Width)
                { //LEFT/RIGHT collision
                    sam.Physics.HortizontalBreak();
                    if (player.SpriteRectangle().X < block.SpaceRectangle().X)
                    { //LEFT Collision
                      //sam.position = new Vector2(sam.position.X - collisionZone.Width, sam.position.Y);
                        sam.x -= collisionZone.Width;
                        sam.space = new Rectangle(sam.space.X - collisionZone.Width, sam.space.Y, sam.space.Width, sam.space.Height);
                    }
                    else
                    { //RIGHT Collision 
                      //sam.position = new Vector2(sam.position.X + collisionZone.Width, sam.position.Y);
                        sam.x += collisionZone.Width;
                        sam.space = new Rectangle(sam.space.X + collisionZone.Width, sam.space.Y, sam.space.Width, sam.space.Height);
                    }
                }
                else
                { //TOP/BOTTOM collision
                    sam.Physics.VerticalBreak();
                    if (player.SpriteRectangle().Y < block.SpaceRectangle().Y)
                    { //TOP Collision
                      //sam.position = new Vector2(sam.position.X, sam.position.Y - collisionZone.Height);
                        if (sam.Jumping)
                        {
                            sam.Jumping = false;
                            sam.Idle();
                        }
                        sam.y -= collisionZone.Height;
                        sam.space = new Rectangle(sam.space.X, sam.space.Y - collisionZone.Height, sam.space.Width, sam.space.Height);
                    }
                    else
                    { //BOTTOM Collision 
                      //sam.position = new Vector2(sam.position.X, sam.position.Y + collisionZone.Height);
                        sam.y += collisionZone.Height;
                        sam.space = new Rectangle(sam.space.X, sam.space.Y + collisionZone.Height, sam.space.Width, sam.space.Height);
                    }
                }
            }

        }

    }
}