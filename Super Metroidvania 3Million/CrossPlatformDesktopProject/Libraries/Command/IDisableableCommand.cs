using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public interface IDisableableCommand : ICommand
    {

        public bool Disabled { get; set;}

    }
}
