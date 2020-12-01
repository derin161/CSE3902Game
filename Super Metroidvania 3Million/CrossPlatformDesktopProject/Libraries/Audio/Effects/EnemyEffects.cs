using Microsoft.Xna.Framework.Content;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class EnemyEffects
    {
        private static EnemyEffects instance = new EnemyEffects();
        public static EnemyEffects Instance
        {
            get
            {
                return instance;
            }
        }

        //private contructor for singleton
        private EnemyEffects()
        {

        }
        public void LoadAllSounds(ContentManager content)
        {

        }
    }
}
