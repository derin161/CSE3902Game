using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Sprite;

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
