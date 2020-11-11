using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.CSV.Object_Generators
{
    public class ItemObjectGenerator
    {
        private static ItemObjectGenerator instance = new ItemObjectGenerator();
        public static ItemObjectGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        public void createItem(Vector2 location, String itemType)
        {
            switch (itemType)
            {
                case "BombItem":
                    GameObjectContainer.Instance.Add(new BombItem(location));
                    break;
                case "EnergyDropItem":
                    GameObjectContainer.Instance.Add(new EnergyDropItem(location));
                    break;
                case "EnergyTankItem":
                    GameObjectContainer.Instance.Add(new EnergyTankItem(location));
                    break;
                case "HighJumpItem":
                    GameObjectContainer.Instance.Add(new HighJumpItem(location));
                    break;
                case "IceBeamItem":
                    GameObjectContainer.Instance.Add(new IceBeamItem(location));
                    break;
                case "LongBeamItem":
                    GameObjectContainer.Instance.Add(new LongBeamItem(location));
                    break;
                case "MissileRocketItem":
                    GameObjectContainer.Instance.Add(new MissileRocketItem(location));
                    break;
                case "MorphBallItem":
                    GameObjectContainer.Instance.Add(new MorphBallItem(location));
                    break;
                case "RocketDropItem":
                    GameObjectContainer.Instance.Add(new RocketDropItem(location));
                    break;
                case "ScrewAttackItem":
                    GameObjectContainer.Instance.Add(new ScrewAttackItem(location));
                    break;
                case "VariaItem":
                    GameObjectContainer.Instance.Add(new VariaItem(location));
                    break;
                case "WaveBeamItem":
                    GameObjectContainer.Instance.Add(new WaveBeamItem(location));
                    break;
            }
        }
    }
}
