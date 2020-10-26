using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
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
        public Player Player
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

            /* Casting the lists to objects then to IGameObject lists to make them IGameObject lists for the updateList method. 
             * Taken from: https://stackoverflow.com/questions/1917844/how-to-cast-listobject-to-listmyclass/1920865 */
            updateList((List<IGameObject>) (object) projectileList, gametime);
            updateList((List<IGameObject>) (object) enemyList, gametime);
            updateList((List<IGameObject>) (object) blockList, gametime);
            updateList((List<IGameObject>) (object) itemList, gametime);
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
            player = null;
            projectileList = new List<IProjectile>();
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();
        }

        private void updateList(List<IGameObject> goList, GameTime gt)
        {
            /* Doing this a for loop rather than for-each loop allows us to remove dead sprites during iteration. */
            for (int i = 0; i < goList.Count; i++)
            {
                goList[i].Update(gt);
                if (goList[i].IsDead())
                {
                    goList.RemoveAt(i);
                    i--; //The element at pos i was just removed, so decrement i to account for the decreasing size of the list.
                }
            }
        }

    }
}
