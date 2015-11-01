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
    public class CBusiButton
    {
        private Texture2D texture;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Rectangle bound;

        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }

        private Color colorBrush;

        public Color ColorBrush
        {
            get { return colorBrush; }
            set { colorBrush = value; }
        }
        private bool isClicked;

        public bool IsClicked
        {
            get { return isClicked; }
            set { isClicked = value; }
        }
        private bool isHover;

        public bool IsHover
        {
            get { return isHover; }
            set { isHover = value; }
        }

        public CBusiButton(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            bound = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            isClicked = isHover = false;
            colorBrush = Color.White;
        }

        public void ChangeSkin(Texture2D skin)
        {
            this.texture = skin;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, bound, colorBrush);
        }
    }
}
