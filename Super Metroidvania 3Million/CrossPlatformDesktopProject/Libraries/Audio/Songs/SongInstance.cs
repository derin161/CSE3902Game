using Microsoft.Xna.Framework.Media;

namespace SuperMetroidvania5Million.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SongInstance : ISound
    {
        public string Name => song.Name;
        public double Duration => song.Duration.TotalMilliseconds;

        private Song song;
        public SongInstance(Song s)
        {
            song = s;
        }

        /*Constructor assumes si is of type SongInstance */
        public SongInstance(ISound si)
        {
            SongInstance localSi = (SongInstance)si;
            song = localSi.song;
        }


        public void PlaySound()
        {

            MediaPlayer.Play(song);

        }


    }
}
