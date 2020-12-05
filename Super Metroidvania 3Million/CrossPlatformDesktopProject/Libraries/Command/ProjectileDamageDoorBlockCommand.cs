using Microsoft.Xna.Framework;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV.Object_Generators;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using System.Collections.Generic;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Danny Attia 
    class ProjectileDamageDoorBlockCommand : ICommand
    {
        private IBlock block;
        private IProjectile projectile;
        public ProjectileDamageDoorBlockCommand(IProjectile projectile, IBlock block)
        {
            this.block = block;
            this.projectile = projectile;
        }
        public void Execute()
        {
            if (block is BlueDoorBottomRight || block is BlueDoorMiddleRight || block is BlueDoorTopRight)
            {
                IBlock bottom = block;
                IBlock middle = block;
                IBlock top = block;

                List<IBlock> blockList = GameObjectContainer.Instance.BlockList;
                foreach (IBlock b in blockList)
                {
                    if (b is BlueDoorBottomRight)
                    {
                        bottom = b;
                    }
                    else if (b is BlueDoorMiddleRight)
                    {
                        middle = b;
                    }
                    else if (b is BlueDoorTopRight)
                    {
                        top = b;
                    }

                }
                bottom.Kill();
                middle.Kill();
                top.Kill();
            }
            else if (block is BlueDoorBottomLeft || block is BlueDoorMiddleLeft || block is BlueDoorTopLeft)
            {
                IBlock bottom = block;
                IBlock middle = block;
                IBlock top = block;

                List<IBlock> blockList = GameObjectContainer.Instance.BlockList;
                foreach (IBlock b in blockList)
                {
                    if (b is BlueDoorBottomLeft)
                    {
                        bottom = b;
                    }
                    else if (b is BlueDoorMiddleLeft)
                    {
                        middle = b;
                    }
                    else if (b is BlueDoorTopLeft)
                    {
                        top = b;
                    }

                }
                bottom.Kill();
                middle.Kill();
                top.Kill();
            }
            else if (block is RedDoorBottomRightBlock || block is RedDoorMiddleRightBlock || block is RedDoorTopRightBlock)
            {
                IBlock bottom = block;
                IBlock middle = block;
                IBlock top = block;

                List<IBlock> blockList = GameObjectContainer.Instance.BlockList;
                foreach (IBlock b in blockList)
                {
                    if (b is RedDoorBottomRightBlock)
                    {
                        bottom = b;
                    }
                    else if (b is RedDoorMiddleRightBlock)
                    {
                        middle = b;
                    }
                    else if (b is RedDoorTopRightBlock)
                    {
                        top = b;
                    }

                }
                bottom.Kill();
                middle.Kill();
                top.Kill();
            }
            else if (block is RedDoorBottomLeftBlock || block is RedDoorMiddleLeftBlock || block is RedDoorTopLeftBlock)
            {
                IBlock bottom = block;
                IBlock middle = block;
                IBlock top = block;

                List<IBlock> blockList = GameObjectContainer.Instance.BlockList;
                foreach (IBlock b in blockList)
                {
                    if (b is RedDoorBottomLeftBlock)
                    {
                        bottom = b;
                    }
                    else if (b is RedDoorMiddleLeftBlock)
                    {
                        middle = b;
                    }
                    else if (b is RedDoorTopLeftBlock)
                    {
                        top = b;
                    }

                }
                bottom.Kill();
                middle.Kill();
                top.Kill();
            }
        }
    }
}
