using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Command;
using System.Collections;
using CrossPlatformDesktopProject.Libraries.CSV;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class PlayerBlockCollision
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
                    LevelStatePattern.Instance.SwitchLevel(LevelStatePattern.Door.right);
                }
                else
                {
                    LevelStatePattern.Instance.SwitchLevel(LevelStatePattern.Door.left);
                }
            }

            else
            {
                //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
                if (collisionZone.Height > collisionZone.Width)
                { //LEFT/RIGHT collision
                    sam.Physics.HortizontalBreak();
                    if (player.SpaceRectangle().X < block.SpaceRectangle().X)
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
                    if (player.SpaceRectangle().Y < block.SpaceRectangle().Y)
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