using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CuocChienVuTru.BUS;

namespace CuocChienVuTru.CGlobal
{
    public class CGlobalVariable
    {
        public static int WINDOW_WIDTH = 800;
        public static int WINDOW_HEIGHT = 600;

        public ContentManager Content;
        public SpriteFont font;
        public MouseState mouse;
        public KeyboardState keyboard;
        public Rectangle mouseBound;
        public CBusiSoundManager sound;
        public Random random;

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="game">đôi tượng game chính</param>
        public CGlobalVariable(Game1 game)
        {
            Content = game.Content;
            font = Content.Load<SpriteFont>("Font/fontMain");
            sound = game.sound;
            random = new Random();
        }

        public void Update()
        {
            mouse = Mouse.GetState();
            mouseBound = new Rectangle(mouse.X, mouse.Y, 2, 2);
            keyboard = Keyboard.GetState();
        }

    }
}
