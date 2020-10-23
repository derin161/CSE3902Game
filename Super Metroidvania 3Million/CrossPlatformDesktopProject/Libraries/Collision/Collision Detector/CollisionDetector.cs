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
        List<IGameObject> itemList;
        bool collision;
        CollisionHandler handler;

        public CollisionDetector(IPlayer Player, IContainer enemyContainer, IContainer blockContainer, IContainer projectileContainer, IContainer itemContainer)
        {

            player = Player;
            enemyList = enemyContainer.GetList();
            blockList = blockContainer.GetList();
            projectileList = projectileContainer.GetList();
            itemList = itemContainer.GetList();
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

            //Check if the player is colliding with any items
            foreach (IGameObject item in itemList)
            {
                collision = CheckCollisions(player, item);
                if (collision)
                {
                    handler.PlayerItemCollision(player, item);
                }
            }

            //check if the enemies are colliding with any blocks
            foreach (IGameObject enemy in enemyList)
            {
                foreach(IGameObject block in blockList)
                {
                    collision = CheckCollisions(enemy, block);
                    if (collision)
                    {
                        handler.EnemyBlockCollision(enemy, block);
                    }
                }
            }

            //check if the enemies are colliding with any blocks
            foreach (IGameObject projectile in projectileList)
            {
                foreach (IGameObject block in blockList)
                {
                    collision = CheckCollisions(projectile, block);
                    if (collision)
                    {
                        handler.ProjectileBlockCollision(projectile, block);
                    }
                }
            }

            //check if the enemies are colliding with any blocks
            foreach (IGameObject projectile in projectileList)
            {
                foreach (IGameObject enemy in enemyList)
                {
                    collision = CheckCollisions(projectile, enemy);
                    if (collision)
                    {
                        handler.ProjectileEnemyCollision(projectile, enemy);
                    }
                }
            }


            /*Collisions that we DO NOT need to check for:
            - block - block (Static, will never collide)
            - enemy - enemy (fine if they pass through each other)
            - projectiles - projectiles
            */


        }

        private bool CheckCollisions(IGameObject obj1, IGameObject obj2)
        {
            return obj1.SpaceRectangle().Intersects(obj2.SpaceRectangle());
        }
    }
}
