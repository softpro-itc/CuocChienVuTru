using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CuocChienVuTru.Helper
{
    public class Input
    {
        KeyboardState preKeyboard;
        KeyboardState curKeyboard;

        public Input()
        {
            preKeyboard = curKeyboard = Keyboard.GetState();
        }

        public void Update()
        {
            preKeyboard = curKeyboard;
            curKeyboard = Keyboard.GetState();
        }

        public bool Release(Keys key)
        {
            if (curKeyboard.IsKeyDown(key) && preKeyboard.IsKeyUp(key))
                return true;
            return false;
        }

    }
}
