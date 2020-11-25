using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class InGameMenu : AbstractMenu
    {
        public InGameMenu() { 

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GameObjectContainer.Instance.Draw(spriteBatch); //draw the GOContainer first so that the menu goes overtop.
        }

        //May move this is AbstractMenu and just override it if needed idk yet.
        public override void Update(GameTime gameTime)
        {
            //Do some timer stuff to make the actively selected button blink.
        }

        public override void ExitMenu()
        {
            GameStateMachine.Instance.Play();
        }
    }
}
