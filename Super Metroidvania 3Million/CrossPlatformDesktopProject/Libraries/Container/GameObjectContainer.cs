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
        private List<IGameObject> deadList = new List<IGameObject>(); //List for keeping dead objects that need to be removed.
        private Player player;

        private static GameObjectContainer instance = new GameObjectContainer();

        public static GameObjectContainer Instance
        {
            get
            {
                return instance;
            }
        }

        private GameObjectContainer()
        {
        }

        public void RegisterPlayer(Player p) {
            player = p;
        }

        public void Add(IProjectile projectile) {
            projectileList.Add(projectile);
        }
        public void Update(GameTime gametime) {
            foreach (IGameObject e in objList) {
                e.Update(gametime);
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (IGameObject e in objList)
            {
                e.Draw(sb);
            }
        }

        public List<IGameObject> GetList() {
            return objList;
        }
    }
}
