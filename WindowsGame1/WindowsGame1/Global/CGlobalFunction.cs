using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CuocChienVuTru.CGlobal
{
    public class CGloabalFunction
    {
        KeyboardState preKeyboard;
        KeyboardState curKeyboard;

        public CGloabalFunction()
        {
            preKeyboard = curKeyboard = Keyboard.GetState();
        }

        public void Update()
        {
            preKeyboard = curKeyboard;
            curKeyboard = Keyboard.GetState();
        }

        public bool KeyboardPress(Keys key)
        {
            if (curKeyboard.IsKeyDown(key))
                return true;
            return false;
        }

        public bool KeyboardRelease(Keys key)
        {
            if (curKeyboard.IsKeyDown(key) && preKeyboard.IsKeyUp(key))
                return true;
            return false;
        }

    }
}
