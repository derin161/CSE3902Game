using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SongManager
    {
        public SongController Controls { get; private set; }

        private static SongManager instance = new SongManager();
        private ISound tourianTheme;
        private ISound endingTheme;
        private ISound escapeTheme;
        private ISound norfairTheme;
        private ISound titleTheme;
        private ISound ridleysHideoutTheme;
        private ISound secretAreaTheme;
        private ISound motherBrainBattleTheme;
        private ISound gameStartSong;
        private ISound brinTheme;
        private ISound getItemSong;
        private ISound darudeSand;
        private ISound activeSong; //Song currently being played

        private List<ISound> themeSongs = new List<ISound>();
        private List<ISound> shuffledThemes = new List<ISound>();
        private List<ISound> activeThemes;

        private int mstimer = 0; //Timer used for looping or playing next song
        private int songIndex = 0;



        public static SongManager Instance
        {
            get
            {
                return instance;
            }
        }

        //private constructor for singleton
        private SongManager()
        {
        }

        public void LoadAllSounds(ContentManager content)
        {
            brinTheme = new SongInstance(content.Load<Song>("Sounds/BrinstarThemeSong"));
            getItemSong = new SongInstance(content.Load<Song>("Sounds/ItemAcquisitionSong"));
            darudeSand = new SongInstance(content.Load<Song>("Sounds/DarudeSandstormSong"));
            tourianTheme = new SongInstance(content.Load<Song>("Sounds/TourianTheme"));
            endingTheme = new SongInstance(content.Load<Song>("Sounds/EndingTheme"));
            escapeTheme = new SongInstance(content.Load<Song>("Sounds/EscapeTheme"));
            norfairTheme = new SongInstance(content.Load<Song>("Sounds/NorfairTheme"));
            titleTheme = new SongInstance(content.Load<Song>("Sounds/TitleTheme"));
            ridleysHideoutTheme = new SongInstance(content.Load<Song>("Sounds/RidleysHideout"));
            secretAreaTheme = new SongInstance(content.Load<Song>("Sounds/SecretArea"));
            motherBrainBattleTheme = new SongInstance(content.Load<Song>("Sounds/MotherBrainBattle"));
            gameStartSong = new SongInstance(content.Load<Song>("Sounds/GameStart"));

            Controls = new SongController(this);

            /* Add the Theme Songs */
            themeSongs.Add(brinTheme);
            themeSongs.Add(tourianTheme);
            themeSongs.Add(endingTheme);
            themeSongs.Add(escapeTheme);
            themeSongs.Add(norfairTheme);
            themeSongs.Add(ridleysHideoutTheme);
            themeSongs.Add(secretAreaTheme);
            themeSongs.Add(motherBrainBattleTheme);
            themeSongs.Add(titleTheme);
            themeSongs.Add(darudeSand);
            shuffledThemes = themeSongs.ConvertAll((s => (ISound) new SongInstance(s)));
            activeThemes = themeSongs;

        }

        public void Update(GameTime gtime)
        {
            if (!Controls.IsPaused)
            {
                mstimer -= (int)gtime.ElapsedGameTime.TotalMilliseconds;
                if (mstimer < 0)
                {
                    if (Controls.LoopMode)
                    {
                        play();
                    }
                    else
                    {
                        PlayNextTheme();
                    }
                }
            }
        }

        public void PlayBrinstarTheme() {
            activeSong = brinTheme;
            play();
        }

        public void PlayItemAcquisitionSong() {
            activeSong = getItemSong;
            play();
        }

        public void PlayDarudeSandstorm() {
            activeSong = darudeSand;
            play();
        }

        public void PlayTourianTheme()
        {
            activeSong = tourianTheme;
            play();
        }

        public void PlayEscapeTheme()
        {
            activeSong = escapeTheme;
            play();
        }

        public void PlayRidleysHidoutTheme()
        {
            activeSong = ridleysHideoutTheme;
            play();
        }

        public void PlayNorfairTheme()
        {
            activeSong = norfairTheme;
            play();
        }

        public void PlaySecretAreaTheme()
        {
            activeSong = secretAreaTheme;
            play();
        }

        public void PlayMotherBrainBattleTheme()
        {
            activeSong = motherBrainBattleTheme;
            play();
        }

        public void PlayTitleTheme()
        {
            activeSong = titleTheme;
            play();
        }

        public void PlayEndingTheme()
        {
            activeSong = endingTheme;
            play();
        }

        public void PlayGameStartSong()
        {
            activeSong = gameStartSong;
            play();
        }

        private void play() {
            mstimer = (int) activeSong.Duration() + 50;
            activeSong.PlaySound();
        }

        /*These are the problem methods that caused me to nest SongController in SongManager*/
        private void Shuffle()
        {
                Random rng = new Random();
                int n = shuffledThemes.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    ISound theme = shuffledThemes[k];
                    shuffledThemes[k] = shuffledThemes[n];
                    shuffledThemes[n] = theme;
                }
                activeThemes = shuffledThemes;
                songIndex = 0;
                mstimer = 0;
        }

        private void UnShuffle()
        {
            
             activeThemes = themeSongs;
             songIndex = 0;
             mstimer = 0;
        }

        private void PlayPreviousTheme()
        {
            songIndex = (((songIndex - 1) % activeThemes.Count) + activeThemes.Count) % activeThemes.Count; //Mod that works for negative numbers

            activeSong = activeThemes[songIndex];
            play();
        }

        private void PlayNextTheme()
        {
            songIndex = (songIndex + 1) % activeThemes.Count;
            activeSong = activeThemes[songIndex];
            play();
        }

        //Author: Nyigel Spann
        /*I originally had this class in its own file, 
         * but getting The SoundManager and SoundController methods to have the correct accessibility I wanted and 
         * ensuring the best information hiding simply wasn't working out previously.
            As such, I decided nesting the SongController in the SongManager was the best solution. */
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
                if (volume > maxVolume)
                {
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

            public void Shuffle()
            {
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
}
