using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoBackground
    {
        private Texture2D textureBackground1;
        private Vector2 positionBackground1;
        private Vector2 positionBackground2;
        private int speed;
        private bool isScroll;



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
        /// <summary>
        /// phương thức khởi tạo 
        /// </summary>
        /// <param name="textureBackground1">hình ảnh </param>
        /// <param name="positionBackground1">vị trí ảnh 1 </param>
        /// <param name="positionBackground2">vị trí ảnh 2</param>
        /// <param name="speed">tốc độ</param>
        /// <param name="isScroll">cho phép cuộn</param>
        public CInfoBackground( Texture2D textureBackground1,Vector2 positionBackground1, Vector2 positionBackground2,int speed, bool isScroll)
        {
            this.textureBackground1 = textureBackground1;
            this.positionBackground1 = positionBackground1;
            this.positionBackground2 = positionBackground2;
            this.speed = speed;
            this.isScroll = isScroll;
        }
    }
}
