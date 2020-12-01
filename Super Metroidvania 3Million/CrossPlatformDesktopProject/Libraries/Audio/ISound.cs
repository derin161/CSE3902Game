using System;

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
