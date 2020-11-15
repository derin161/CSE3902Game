using CrossPlatformDesktopProject.Libraries.SFactory;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author: Nyigel Spann
    public static class InfoContainer
    {
        public static ProjectileUtilities Projectiles { get; private set; }
        public static PlayerUtilities Player { get; private set; }
        public static ItemUtilities Items { get; private set; }
        public static MiscUtilities Misc { get; private set; }
        public static BlockUtilities Blocks { get; private set; }
        private static EnemyUtilities enemies = new EnemyUtilities();
        public static EnemyUtilities Enemies
        {
            get
            {
                return enemies;
            }
        }
        public static SongUtilities Songs { get; private set; }
    }
}
