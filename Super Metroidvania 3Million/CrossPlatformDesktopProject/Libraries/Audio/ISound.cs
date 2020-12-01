using System;

//Author: Nyigel Spann
namespace SuperMetroidvania5Million.Libraries.Audio
{
    public interface ISound
    {
        public double Duration { get; }
        public String Name { get; }
        public void PlaySound();

    }
}
