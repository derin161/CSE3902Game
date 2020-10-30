using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public class GameObjectContainer
	{
        private List<IProjectile> projectileList = new List<IProjectile>();
        private List<IEnemy> enemyList = new List<IEnemy>();
        private List<IBlock> blockList = new List<IBlock>();
        private List<IItem> itemList = new List<IItem>();
        private IPlayer player;

        private static GameObjectContainer instance = new GameObjectContainer();

        public static GameObjectContainer Instance
        {
            get
            {
                return instance;
            }
        }

        public List<IProjectile> ProjectileList
        {
            get{ return projectileList; }
        }
        public List<IBlock> BlockList
        {
            get{ return blockList; }
        }
        public List<IItem> ItemList
        {
            get { return itemList; }
            
        }
        public List<IEnemy> EnemyList
        {
            get { return enemyList; }
            
        }
        public IPlayer Player
        {
            get { return player; }
        }

        private GameObjectContainer() //private constructor for singleton
        {
        }

        public void RegisterPlayer(IPlayer p) {
            player = p;
        }

        public void Add(IProjectile projectile) {
            projectileList.Add(projectile);
        }

        public void Add(IEnemy enemy)
        {
            enemyList.Add(enemy);
        }

        public void Add(IBlock block)
        {
            blockList.Add(block);
        }

        public void Add(IItem item)
        {
            itemList.Add(item);
        }

        public void Update(GameTime gametime) {
            player.Update(gametime);
            
            /* Doing this a for loop rather than for-each loop allows us to remove dead sprites during iteration. */
            for (int i = 0; i < projectileList.Count; i++)
            {
                projectileList[i].Update(gametime);
                if (projectileList[i].IsDead())
                {
                    projectileList.RemoveAt(i);
                    i--; //The element at pos i was just removed, so decrement i to account for the decreasing size of the list.
                }
            }
            /* Doing this a for loop rather than for-each loop allows us to remove dead sprites during iteration. */
            for (int i = 0; i < blockList.Count; i++)
            {
                blockList[i].Update(gametime);
                if (blockList[i].IsDead())
                {
                    blockList.RemoveAt(i);
                    i--; //The element at pos i was just removed, so decrement i to account for the decreasing size of the list.
                }
            }
            /* Doing this a for loop rather than for-each loop allows us to remove dead sprites during iteration. */
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(gametime);
                if (enemyList[i].IsDead())
                {
                    enemyList.RemoveAt(i);
                    i--; //The element at pos i was just removed, so decrement i to account for the decreasing size of the list.
                }
            }
            /* Doing this a for loop rather than for-each loop allows us to remove dead sprites during iteration. */
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Update(gametime);
                if (itemList[i].IsDead())
                {
                    itemList.RemoveAt(i);
                    i--; //The element at pos i was just removed, so decrement i to account for the decreasing size of the list.
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            player.Draw(sb);
            foreach (IProjectile p in projectileList)
            {
                p.Draw(sb);
            }
            foreach (IEnemy e in enemyList)
            {
                e.Draw(sb);
            }
            foreach (IItem i in itemList)
            {
                i.Draw(sb);
            }
            foreach (IBlock b in blockList)
            {
                b.Draw(sb);
            }
        }

        public void Clear() {
            // player = null;
            projectileList = new List<IProjectile>();
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();
        }

        public void clearMap()
        {
            blockList = new List<IBlock>();
        }

    }
}
