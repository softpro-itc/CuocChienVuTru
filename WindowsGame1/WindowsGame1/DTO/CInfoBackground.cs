using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoBackground
    {
        private Texture2D textureBackground1;
        private Texture2D textureBackground2;
        private Vector2 positionBackground1;
        private Vector2 positionBackground2;
        private int speed;
        private bool isScroll;
        private Game1 game;

        public Game1 Game
        {
            get { return game; }
            set { game = value; }
        }


        public Texture2D TextureBackground2
        {
            get { return textureBackground2; }
            set { textureBackground2 = value; }
        }

        public Texture2D TextureBackground1
        {
            get { return textureBackground1; }
            set { textureBackground1 = value; }
        }
        public Vector2 PositionBackground1
        {
            get { return positionBackground1; }
            set { positionBackground1 = value; }
        }
        public Vector2 PositionBackground2
        {
            get { return positionBackground2; }
            set { positionBackground2 = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public bool IsScroll
        {
            get { return isScroll; }
            set { isScroll = value; }
        }



        #region khai báo constructer
        /// <summary>
        /// phương thức khởi tạo 
        /// </summary>
        /// <param name="textureBackground1">hình ảnh </param>
        /// <param name="positionBackground1">vị trí ảnh 1 </param>
        /// <param name="positionBackground2">vị trí ảnh 2</param>
        /// <param name="speed">tốc độ</param>
        /// <param name="isScroll">cho phép cuộn</param>
        public CInfoBackground(Texture2D textureBackground1, Vector2 positionBackground1, Vector2 positionBackground2, int speed, bool isScroll)
        {
            this.textureBackground1 = textureBackground1;
            this.positionBackground1 = positionBackground1;
            this.positionBackground2 = positionBackground2;
            this.speed = speed;
            this.isScroll = isScroll;
        }
        public CInfoBackground(Game1 game, string bgName, int speed)
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
        public CInfoBackground(Game1 game, string bgName1, string bgName2, int speed)
        {
            this.textureBackground1 = game.Content.Load<Texture2D>("Images/Background/" + bgName1);
            this.textureBackground2 = game.Content.Load<Texture2D>("Images/Background/" + bgName2);
            positionBackground1 = new Vector2(0, 0);
            positionBackground2 = new Vector2(0, -CGlobalVariable.WINDOW_HEIGHT);
            isScroll = true;
            this.speed = speed;
            this.game = game;
        }
        #endregion
    }
}
