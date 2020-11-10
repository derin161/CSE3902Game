using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SongController
    {
        public bool LoopMode { get; private set; }
        public bool ShuffleMode { get; private set; }
        public bool IsMuted
        {
            get
            {
                return MediaPlayer.IsMuted;
            }
        }

        public bool IsPaused { get; private set; }

        
        private float maxVolume = 1f;
        private float minVolume = 0f;
        private float volumeChange = 0.1f;

        private SongManager SongManager;


        public SongController(SongManager sm)
        {
            SongManager = sm;
        }

        public void PlayPreviousTheme()
        {
            SongManager.PlayPreviousTheme();
        }

        public void PlayNextTheme()
        {
            SongManager.PlayNextTheme();
        }

        public void RaiseVolume()
        {
            float volume = MediaPlayer.Volume + volumeChange;
            if (volume > maxVolume) {
                volume = maxVolume;
            }
            MediaPlayer.Volume = maxVolume;
        }

        public void LowerVolume()
        {
            float volume = MediaPlayer.Volume - volumeChange;
            if (volume < minVolume)
            {
                volume = minVolume;
            }
            MediaPlayer.Volume = minVolume;
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            IsPaused = true;
        }

        public void Resume()
        {
            MediaPlayer.Resume();
            IsPaused = false;
        }

        public void Shuffle() {
            ShuffleMode = true;
            SongManager.Shuffle();
        }

        public void UnShuffle()
        {
            ShuffleMode = false;
            SongManager.UnShuffle();
        }

        public void Mute()
        {
            MediaPlayer.IsMuted = true;
        }

        public void UnMute()
        {
            MediaPlayer.IsMuted = false;
        }

        public void Loop()
        {
            LoopMode = true;
        }

        public void UnLoop()
        {
            LoopMode = false;
        }

    }
}
