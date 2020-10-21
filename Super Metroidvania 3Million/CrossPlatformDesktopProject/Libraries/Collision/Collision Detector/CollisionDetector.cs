using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class CollisionDetector
    {
        IPlayer player;
        List<IGameObject> enemyList;
        List<IGameObject> blockList;
        List<IGameObject> projectileList;
        bool collision;
        CollisionHandler handler;

        public CollisionDetector(IPlayer Player, IContainer enemyContainer, IContainer blockContainer, IContainer projectileContainer)
        {

            player = Player;
            enemyList = enemyContainer.GetList();
            blockList = blockContainer.GetList();
            projectileList = projectileContainer.GetList();
            handler = new CollisionHandler();
            
        }

        public void Update()
        {
            //Check if the player is colliding with any enemies
            foreach (IGameObject enemy in enemyList) 
            {
                collision = CheckCollisions(player, enemy);
                if (collision)
                {
                    handler.PlayerEnemyCollision(player, enemy);
                }
            }

            //Check if the player is colliding with any blocks
            foreach (IGameObject block in blockList)
            {
                collision = CheckCollisions(player, block);
                if (collision)
                {
                    handler.PlayerBlockCollision(player, block);
                }
            }

            //check if the player is colliding with any projectiles
            foreach (IGameObject projectile in projectileList)
            {
                collision = CheckCollisions(player, projectile);
                if (collision)
                {
                    handler.PlayerProjectileCollision(player, projectile);
                }
            }

            /*Collisions that we DO NOT need to check for:
            - block - block (Static, will never collide)
            - enemy - enemy (fine if they pass through each other)
            - projectile - enemy (fine if enemies get hit by projectile)
            */

            /*Collisions that we MIGHT need to check for:
            - enemy - block
            - projectile - block
             */


        }

        private bool CheckCollisions(IGameObject obj1, IGameObject obj2)
        {
            //TODO: insert collision detection logic here

            //Use obj.Space rectangles to determine collisions (follow slides)
            return false; //placeholder
        }
    }
}
