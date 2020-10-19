using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.Map;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;

namespace CrossPlatformDesktopProject.Libraries.Container
{
	public class GameObjectContainer : IContainer
	{
        private List<IGameObject> objList = new List<IGameObject>();

        public GameObjectContainer()
        {
        }

        public void Add(IGameObject obj) {
            objList.Add(obj);
        }
        public void Update(GameTime gametime) {
            foreach (IGameObject e in objList) {
                e.Update(gametime);
            }
        }

        public List<IGameObject> GetList() {
            return objList;
        }

        public List<KeyValuePair<IGameObject, IGameObject>> DetectCollisions(IContainer container) {
            List<KeyValuePair<IGameObject, IGameObject>> collisionPairs = new List<KeyValuePair < IGameObject, IGameObject>>();
            List<IGameObject> otherList = container.GetList();
            foreach (IGameObject obj1 in objList) {
                foreach (IGameObject obj2 in otherList) {
                    if (obj1 != obj2) { //Make sure we don't compare something against itself.
                        bool collision = false; //temporary var til collision detection actually possible.
                        if (collision) {
                            collisionPairs.Add(new KeyValuePair<IGameObject, IGameObject>(obj1, obj2));
                        }
                    }
                }
            }
            return collisionPairs;
        }
        public List<IGameObject> DetectCollisions(IGameObject obj)
        {
            List<KeyValuePair<IGameObject, IGameObject>> collidingObjects = new List<KeyValuePair<IGameObject, IGameObject>>();
            foreach (IGameObject e in objList)
            {
                bool collision = false; //temporary var til collision detection actually possible.
                if (collision)
                {
                    collidingObjects.Add(e);
                }
            }
            return collidingObjects;
        }
    }
}
