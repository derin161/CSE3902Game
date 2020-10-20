using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public interface IContainer
    {
        public void Add(IGameObject obj);
        public void Update(GameTime gametime);
        public void Draw(SpriteBatch sb);
        public List<IGameObject> GetList();

        //Might move these methods to a collision detection object in the future.
        public List<KeyValuePair<IGameObject, IGameObject>> DetectCollisions(IContainer container);
        public List<IGameObject> DetectCollisions(IGameObject obj);
    }
}
