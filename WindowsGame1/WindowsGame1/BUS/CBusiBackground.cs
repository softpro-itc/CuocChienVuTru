using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;

namespace CuocChienVuTru.BUS
{
    public class CBusiBackground
    {
        private Texture2D textureBackground1;
        private Vector2 positionBackground1;
        private Vector2 positionBackground2;
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private bool isScroll;

        public bool IsScroll
        {
            get { return isScroll; }
            set { isScroll = value; }
        }

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="textureBackground1">hình ảnh</param>
        /// <param name="speed">tốc độ cuộn</param>
        public CBusiBackground(Texture2D textureBackground1, int speed)
        {
            this.textureBackground1 = textureBackground1;
            positionBackground1 = new Vector2(0, 0);
            positionBackground2 = new Vector2(0, -CGlobalVariable.WINDOW_HEIGHT);
            isScroll = true;
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            if (isScroll)
            {
                positionBackground1.Y += speed;
                if (positionBackground1.Y == CGlobalVariable.WINDOW_HEIGHT)
                    positionBackground1.Y = -CGlobalVariable.WINDOW_HEIGHT;

                positionBackground2.Y += speed;
                if (positionBackground2.Y == CGlobalVariable.WINDOW_HEIGHT)
                    positionBackground2.Y = -CGlobalVariable.WINDOW_HEIGHT;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureBackground1, positionBackground1, Color.White);
            spriteBatch.Draw(textureBackground1, positionBackground2, Color.White);
        }
    }
}
