using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SongInstance : ISound
    {
        private Song song;
        public SongInstance(Song s) {
            song = s;
        }

        /*Constructor assumes si is of type SongInstance */
        public SongInstance(ISound si)
        {
            SongInstance localSi = (SongInstance) si;
            song = localSi.song;
        }

        public double Duration()
        {
            return song.Duration.TotalMilliseconds;
        }

        public void PlaySound() {
            
            MediaPlayer.Play(song);
            
        }


    }
}
