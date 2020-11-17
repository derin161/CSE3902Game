using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();
        public ProjectileEffects Projectiles { get; private set; }
        public PlayerEffects Player { get; private set; }
        public ItemEffects Items { get; private set; }
        public MiscEffects Misc { get; private set; }
        public BlockEffects Blocks { get; private set; }
        public EnemyEffects Enemies { get; private set; }
        public SongManager Songs { get; private set; }

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private SoundManager() {
            MediaPlayer.Volume = 0.3f;  //Volume scales from 0.0f (silent) to 1.0f
            Projectiles = ProjectileEffects.Instance;
            Player = PlayerEffects.Instance;
            Enemies = EnemyEffects.Instance;
            Misc = MiscEffects.Instance;
            Blocks = BlockEffects.Instance;
            Items = ItemEffects.Instance;
            Songs = SongManager.Instance;
        }
        public void LoadAllSounds(ContentManager content) {
            Projectiles.LoadAllSounds(content);
            Songs.LoadAllSounds(content);
            Enemies.LoadAllSounds(content);
            Misc.LoadAllSounds(content);
            Blocks.LoadAllSounds(content);
            Items.LoadAllSounds(content);
            Player.LoadAllSounds(content);
        }

        public void Update(GameTime gtime) {
            Songs.Update(gtime);
        }

    }
}
