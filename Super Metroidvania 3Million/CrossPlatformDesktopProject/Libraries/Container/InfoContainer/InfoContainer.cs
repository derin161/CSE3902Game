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
    public class InfoContainer
    {
        public ProjectileUtilities Projectiles { get; private set; }
        public PlayerUtilities Player { get; private set; }
        public ItemUtilities Items { get; private set; }
        public MiscUtilities Misc { get; private set; }
        public BlockUtilities Blocks { get; private set; }
        public EnemyUtilities Enemies { get; private set; }
        public SoundUtilities Sounds { get; private set; }

        private static InfoContainer instance = new InfoContainer();

        public static InfoContainer Instance
        {
            get
            {
                return instance;
            }
        }

        private InfoContainer() //private constructor for singleton
        {
            Projectiles = ProjectileUtilities.Instance;
            Player = PlayerUtilities.Instance;
            Items = ItemUtilities.Instance;
            Misc = MiscUtilities.Instance;
            Blocks = BlockUtilities.Instance;
            Enemies = new EnemyUtilities();
            Sounds = SoundUtilities.Instance;
        }
    }
}
