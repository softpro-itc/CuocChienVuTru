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
        private Texture2D textureBackground2;
        private Vector2 positionBackground1;
        private Vector2 positionBackground2;
        private int speed;
        private List<CBusiItem> listItem = new List<CBusiItem>();
        private int timerAddItem = 0;

        public int TimerAddItem
        {
            get { return timerAddItem; }
            set { timerAddItem = value; }
        }
        private int intervalAddItem = 500;
        private int maxItem = -1;

        public int MaxItem
        {
            get { return maxItem; }
            set { maxItem = value; }
        }
        private Game1 game;

        public List<CBusiItem> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }

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
        public CBusiBackground(Game1 game, string bgName, int speed)
        {
            this.game = game;
            this.textureBackground1 = this.textureBackground2 = game.Content.Load<Texture2D>("Images/Background/" + bgName);
            positionBackground1 = new Vector2(0, 0);
            positionBackground2 = new Vector2(0, -CGlobalVariable.WINDOW_HEIGHT);
            isScroll = true;
            this.speed = speed;
        }

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="textureBackground1">hình ảnh</param>
        /// <param name="speed">tốc độ cuộn</param>
        public CBusiBackground(Game1 game, string bgName1, string bgName2, int speed)
        {
            this.textureBackground1 = game.Content.Load<Texture2D>("Images/Background/" + bgName1);
            this.textureBackground2 = game.Content.Load<Texture2D>("Images/Background/" + bgName2);
            positionBackground1 = new Vector2(0, 0);
            positionBackground2 = new Vector2(0, -CGlobalVariable.WINDOW_HEIGHT);
            isScroll = true;
            this.speed = speed;
            this.game = game;
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
            spriteBatch.Draw(textureBackground2, positionBackground2, Color.White);

            if (listItem.Count > 0)
                foreach (CBusiItem item in listItem)
                    item.Draw(spriteBatch);
        }
    }
}
