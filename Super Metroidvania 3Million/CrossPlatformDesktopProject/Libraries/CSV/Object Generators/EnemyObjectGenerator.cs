using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using Microsoft.Xna.Framework;
using System;

namespace CrossPlatformDesktopProject.Libraries.CSV.Object_Generators
{
    public class EnemyObjectGenerator
    {
        private static EnemyObjectGenerator instance = new EnemyObjectGenerator();
        public static EnemyObjectGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        public void createEnemy(Vector2 location, String enemyType)
        {
            switch (enemyType)
            {
                case "SideHopper":
                    GameObjectContainer.Instance.Add(new SideHopper(location));
                    break;
                case "ReverseSideHopper":
                    GameObjectContainer.Instance.Add(new ReverseSideHopper(location));
                    break;
                case "Skree":
                    GameObjectContainer.Instance.Add(new Skree(location));
                    break;
                case "Geega":
                    GameObjectContainer.Instance.Add(new Geega(location));
                    break;
                case "Kraid":
                    GameObjectContainer.Instance.Add(new Kraid(location));
                    break;
                case "Zeela":
                    GameObjectContainer.Instance.Add(new Zeela(location));
                    break;
            }
        }
    }
}
