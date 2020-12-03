using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using Microsoft.Xna.Framework;
using System;

namespace SuperMetroidvania5Million.Libraries.CSV.Object_Generators
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

        public void createEnemy(Vector2 location, String enemyType, Game1 game)
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
                    GameObjectContainer.Instance.Add(new Kraid(location, game));
                    break;
                case "Zeela":
                    GameObjectContainer.Instance.Add(new Zeela(location));
                    break;
            }
        }
    }
}
