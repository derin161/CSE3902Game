using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class EnableCommandCommand : ICommand
    {
        private IDisableableCommand toEnable;
        public EnableCommandCommand(IDisableableCommand disableableCommand)
        {
            toEnable = disableableCommand;
        }
        public void Execute()
        {
            toEnable.Disabled = false;
        }
    }
}
