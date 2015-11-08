using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoButton
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle bound;
        private Color colorBrush;
        private bool isClicked;
        private bool isHover;


        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }
        public Color ColorBrush
        {
            get { return colorBrush; }
            set { colorBrush = value; }
        }
        public bool IsClicked
        {
            get { return isClicked; }
            set { isClicked = value; }
        }
        public bool IsHover
        {
            get { return isHover; }
            set { isHover = value; }
        }

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="texture">hình ảnh của button</param>
        /// <param name="position">vị trí của buttton</param>
        /// <param name="bound">thuộc tính bao quanh button</param>
        /// <param name="colorBrush">màu của button</param>
        /// <param name="isClicked">thuộc tính click</param>
        /// <param name="isHover">thuộc tính hover</param>
        public CInfoButton( Texture2D texture, Vector2 position, Rectangle bound,Color colorBrush, bool isClicked, bool isHover)
        {
            this.texture = texture;
            this.position = position;
            this.bound = bound;
            this.colorBrush = colorBrush;
            this.isClicked = isClicked;
            this.isHover = isHover;
        }
    }
}
