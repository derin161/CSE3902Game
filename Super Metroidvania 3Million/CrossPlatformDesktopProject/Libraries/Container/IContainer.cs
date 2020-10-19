using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    public interface IContainer
    {
        public void Add(IGameObject obj);
        public void Update(GameTime gametime);
        public List<IGameObject> GetList();
        public List<KeyValuePair<IGameObject, IGameObject>> DetectCollisions(IContainer container);
        public List<IGameObject> DetectCollisions(IGameObject obj);
    }
}
