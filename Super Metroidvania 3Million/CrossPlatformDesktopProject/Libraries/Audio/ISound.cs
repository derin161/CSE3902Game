using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Nyigel Spann
namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public interface ISound
    {
        public double Duration { get; }
        public String Name { get; }
        public void PlaySound();

    }
}
