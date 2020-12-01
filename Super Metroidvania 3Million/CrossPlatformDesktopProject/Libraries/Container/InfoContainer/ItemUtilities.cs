namespace CrossPlatformDesktopProject.Libraries.Container
{
    //Author:
    public class ItemUtilities
    {
        private static ItemUtilities instance = new ItemUtilities();

        public static ItemUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemUtilities() //private constructor for singleton
        {

        }

    }
}
