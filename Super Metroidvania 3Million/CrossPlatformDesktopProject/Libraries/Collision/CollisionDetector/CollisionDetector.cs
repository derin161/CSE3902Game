using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Collision.CollisionDetector
{
    class CollisionDetector
    {
        IPlayer player;
        List<IGameObject> enemyList;
        List<IGameObject> blockList;
        List<IGameObject> projectileList; 

        public CollisionDetector(IPlayer Player, IContainer enemyContainer, IContainer blockContainer, IContainer projectileContainer)
        {

            player = Player;
            enemyList = enemyContainer.GetList();
            blockList = blockContainer.GetList();
            projectileList = projectileContainer.GetList();
            
        }

        public void Update()
        {
            //Check if the player is colliding with any enemies
            foreach (IGameObject enemy in enemyList) 
            {
                CheckCollisions(player, enemy);
            }

            //Check if the player is colliding with any blocks
            foreach (IGameObject block in blockList)
            {
                CheckCollisions(player, block);
            }

            //check if the player is colliding with any projectiles
            foreach (IGameObject projectile in projectileList)
            {
                CheckCollisions(player, projectile);
            }

            
        }

        private void CheckCollisions(IGameObject obj1, IGameObject obj2)
        {
            //TODO: insert collision detection logic here after implementing 
        }
    }
}
