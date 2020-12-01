using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class CollisionDetector
    {
        private CollisionHandler handler = new CollisionHandler();
        private static CollisionDetector instance = new CollisionDetector();

        public static CollisionDetector Instance
        {
            get { return instance; }
        }

        private CollisionDetector() //Private constructor for singleton
        {

        }

        public void Update()
        {
            IPlayer player = GameObjectContainer.Instance.Player;
            //Check if the player is colliding with any enemies
            foreach (IEnemy enemy in GameObjectContainer.Instance.EnemyList)
            {
                if (CheckCollisions(player, enemy))
                {
                    handler.PlayerEnemyCollision(player, enemy);
                }
            }

            //Check if the player is colliding with any blocks
            foreach (IBlock block in GameObjectContainer.Instance.BlockList)
            {
                if (CheckCollisions(player, block))
                {
                    handler.PlayerBlockCollision(player, block, Rectangle.Intersect(player.SpriteRectangle(), block.SpaceRectangle()));
                }
            }

            //check if the player is colliding with any projectiles
            foreach (IProjectile projectile in GameObjectContainer.Instance.ProjectileList)
            {
                if (CheckCollisions(player, projectile))
                {
                    handler.PlayerProjectileCollision(player, projectile);
                }
            }

            //Check if the player is colliding with any items
            foreach (IItem item in GameObjectContainer.Instance.ItemList)
            {
                if (CheckCollisions(player, item))
                {
                    handler.PlayerItemCollision(player, item);
                }
            }

            //check if the enemies are colliding with any blocks
            foreach (IEnemy enemy in GameObjectContainer.Instance.EnemyList)
            {
                foreach (IBlock block in GameObjectContainer.Instance.BlockList)
                {
                    if (CheckCollisions(enemy, block))
                    {
                        handler.EnemyBlockCollision(enemy, block, Rectangle.Intersect(enemy.SpaceRectangle(), block.SpaceRectangle()));
                    }
                }
            }

            //check if the enemies are colliding with any blocks
            foreach (IProjectile projectile in GameObjectContainer.Instance.ProjectileList)
            {
                foreach (IBlock block in GameObjectContainer.Instance.BlockList)
                {
                    if (CheckCollisions(projectile, block))
                    {
                        handler.ProjectileBlockCollision(projectile, block);
                    }
                }
            }

            //check if the enemies are colliding with any projectiles
            foreach (IProjectile projectile in GameObjectContainer.Instance.ProjectileList)
            {
                foreach (IEnemy enemy in GameObjectContainer.Instance.EnemyList)
                {
                    if (CheckCollisions(projectile, enemy))
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
