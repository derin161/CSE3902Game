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

        /*I wanted to put these methods in the song controller, 
         * but there really isn't a great way to pass and hide all of the necessary info, 
         * so these methods will simply appear in both*/
        public void Shuffle()
        {
            if (!Controls.ShuffleMode) //Keeps the song controller and the song manager on the same page and prevents mutual recursion
            {
                Controls.Shuffle();
            }
            else {
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
        }

        public void UnShuffle()
        {
            if (Controls.ShuffleMode) //Keeps the song controller and the song manager on the same page and prevents mutual recursion
            {
                Controls.UnShuffle();
            }
            else
            {
                activeThemes = themeSongs;
                songIndex = 0;
                mstimer = 0;
            }
        }

        public void PlayPreviousTheme()
        {
            songIndex = (((songIndex - 1) % activeThemes.Count) + activeThemes.Count) % activeThemes.Count; //Mod that works for negative numbers

            activeSong = activeThemes[songIndex];
            play();
        }

        public void PlayNextTheme()
        {
            songIndex = (songIndex + 1) % activeThemes.Count;
            activeSong = activeThemes[songIndex];
            play();
        }

    }
}
