using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace SuperMetroidvania5Million.Libraries.Audio
{
    //Author: Nyigel Spann
    public class SongManager
    {
        public SongController Controls { get; private set; }
        public bool IsMuted => MediaPlayer.IsMuted;
        public float Volume => MediaPlayer.Volume;

        public bool LoopMode { get; private set; }
        public bool ShuffleMode { get; private set; }
        public bool IsPaused { get; private set; }
        public List<String> ActiveThemesNames { get; private set; }
        public String ActiveSongName => activeThemes[songIndex].Name;

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

        private int mstimer = 100000; //Timer used for looping or playing next song
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
            shuffledThemes = themeSongs.ConvertAll((s => (ISound)new SongInstance(s)));
            activeThemes = themeSongs;
            ActiveThemesNames = activeThemes.ConvertAll(s => s.Name);

        }

        public void Update(GameTime gtime)
        {
            if (!IsPaused)
            {
                mstimer -= (int)gtime.ElapsedGameTime.TotalMilliseconds;
                if (mstimer < 0)
                {
                    if (LoopMode)
                    {
                        play();
                    }
                    else
                    {
                        Controls.PlayNextTheme();
                    }
                }
            }
        }

        public void PlayBrinstarTheme()
        {
            activeSong = brinTheme;
            play();
        }

        public void PlayItemAcquisitionSong()
        {
            activeSong = getItemSong;
            play();
        }

        public void PlayDarudeSandstorm()
        {
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

        private void play()
        {
            mstimer = (int)activeSong.Duration + 50;
            activeSong.PlaySound();
        }

        //Author: Nyigel Spann
        /*I originally had this class in its own file, 
         * but getting The SoundManager and SoundController methods to have the correct accessibility I wanted and 
         * ensuring the best information hiding simply wasn't working out previously.
            As such, I decided nesting the SongController in the SongManager was the best solution. */
        public class SongController
        {

            public float VolumeChange { get; private set; } = 0.1f;

            private float maxVolume = 1f;
            private float minVolume = 0f;

            private SongManager SongManager;


            public SongController(SongManager sm)
            {
                SongManager = sm;
            }

            public void PlayPreviousTheme()
            {
                SongManager.songIndex = (((SongManager.songIndex - 1) % SongManager.activeThemes.Count) + SongManager.activeThemes.Count) % SongManager.activeThemes.Count; //Mod that works for negative numbers

                SongManager.activeSong = SongManager.activeThemes[SongManager.songIndex];
                SongManager.play();
            }

            public void PlayNextTheme()
            {

                SongManager.songIndex = (SongManager.songIndex + 1) % SongManager.activeThemes.Count;
                SongManager.activeSong = SongManager.activeThemes[SongManager.songIndex];
                SongManager.play();

            }

            public void RaiseVolume()
            {
                float volume = MediaPlayer.Volume + VolumeChange;
                if (volume > maxVolume)


                {
                    volume = maxVolume;
                }
                MediaPlayer.Volume = volume;
                SongManager.play();
            }

            public void LowerVolume()
            {
                float volume = MediaPlayer.Volume - VolumeChange;
                if (volume < minVolume)
                {
                    volume = minVolume;
                }
                MediaPlayer.Volume = volume;
                SongManager.play();
            }

            public void Pause()
            {
                MediaPlayer.Pause();
                SongManager.IsPaused = true;
            }

            public void Resume()
            {
                MediaPlayer.Resume();
                SongManager.IsPaused = false;
            }

            public void Shuffle()
            {
                SongManager.ShuffleMode = true;
                Random rng = new Random();
                int n = SongManager.shuffledThemes.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    ISound theme = SongManager.shuffledThemes[k];
                    SongManager.shuffledThemes[k] = SongManager.shuffledThemes[n];
                    SongManager.shuffledThemes[n] = theme;
                }
                SongManager.activeThemes = SongManager.shuffledThemes;
                shufflePlay();
            }

            public void UnShuffle()
            {
                SongManager.ShuffleMode = false;
                SongManager.activeThemes = SongManager.themeSongs;
                shufflePlay();
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
                SongManager.LoopMode = true;
            }

            public void UnLoop()
            {
                SongManager.LoopMode = false;
            }

            private void shufflePlay()
            {
                SongManager.ActiveThemesNames.Clear();
                SongManager.ActiveThemesNames.AddRange(SongManager.activeThemes.ConvertAll(s => s.Name));
                SongManager.activeSong = SongManager.activeThemes[SongManager.songIndex];
                SongManager.play();
            }

        }
    }
}
