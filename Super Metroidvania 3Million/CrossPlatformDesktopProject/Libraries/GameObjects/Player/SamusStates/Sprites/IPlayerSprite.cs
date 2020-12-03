using Microsoft.Xna.Framework;
using SuperMetroidvania5Million;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMetroidvania5Million.Libraries.Sprite.Player
{
    //Author: Nyigel Spann
    public interface IPlayerSprite : ISprite
    {
        public Color Color {get; set;}
    }
}
