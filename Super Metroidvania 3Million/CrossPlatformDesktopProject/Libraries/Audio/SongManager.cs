using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public class SongManager
    {
        public ISound BrinstarTheme { get; private set; }
        public SongManager()
        {
            
        }
        public void LoadAllSounds(ContentManager content)
        {
            BrinstarTheme = new SongInstance(content.Load<Song>("Sounds/BrinstarThemeSong"));
        }
    }
}
