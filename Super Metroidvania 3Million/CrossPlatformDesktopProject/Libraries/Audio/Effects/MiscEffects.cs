using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SuperMetroidvania5Million.Libraries.Audio
{
    //Author: Nyigel Spann
    public class MiscEffects
    {
        public ISound GameOverSound { get; private set; }

        private static MiscEffects instance = new MiscEffects();
        public static MiscEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private MiscEffects()
        {

        }
        public void LoadAllSounds(ContentManager content)
        {
            GameOverSound = new EffectInstance(content.Load<SoundEffect>("Sounds/GameOverSound"));
        }
    }
}
