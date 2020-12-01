using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class PlayerEffects
    {
        public ISound JumpSound { get; private set; }
        public ISound PlayerDamageSound { get; private set; }

        private static PlayerEffects instance = new PlayerEffects();
        public static PlayerEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private PlayerEffects()
        {

        }
        public void LoadAllSounds(ContentManager content)
        {
            JumpSound = new EffectInstance(content.Load<SoundEffect>("Sounds/JumpSound"));
            PlayerDamageSound = new EffectInstance(content.Load<SoundEffect>("Sounds/PlayerDamageSound"));
        }
    }
}
