namespace SuperMetroidvania5Million.Libraries.Container
{
    //Author:
    public class BlockUtilities
    {

        public int lavaDamage = 5;

        private static BlockUtilities instance = new BlockUtilities();

        public static BlockUtilities Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockUtilities() //private constructor for singleton
        {

        }

    }
}
