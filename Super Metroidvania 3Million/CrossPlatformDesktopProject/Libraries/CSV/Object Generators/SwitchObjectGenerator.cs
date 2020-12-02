using Microsoft.Xna.Framework;
using System;

namespace SuperMetroidvania5Million.Libraries.CSV.Object_Generators
{
    public class SwitchObjectGenerator
    {
        private static SwitchObjectGenerator instance = new SwitchObjectGenerator();
        public static SwitchObjectGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        public void createSwitch(Vector2 location, String switchType)
        {
            /*    ISwitch switchBlock;
                switch (switchType)
                {
                    case "CameraLockDown":
                        switchBlock = new CameraLockDownSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraLockUp":
                        switchBlock = new CameraLockUpSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraLockLeft":
                        switchBlock = new CameraLockLeftSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraLockRight":
                        switchBlock = new CameraLockRightSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraUnlockDown":
                        switchBlock = new CameraUnlockDownSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraUnlockUp":
                        switchBlock = new CameraUnlockUpSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraUnlockLeft":
                        switchBlock = new CameraUnlockLeftSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;

                    case "CameraUnlockRight":
                        switchBlock = new CameraUnlockRightSwitch(location);
                        GameObjectContainer.Instance.Add(switchBlock);
                        break;
                }*/

        }
    }
}
