namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author:
    public class MiscUtilities
    {
        private static MiscUtilities instance = new MiscUtilities();

        public static MiscUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private MiscUtilities() //private constructor for singleton
        {

        }

    }
}
