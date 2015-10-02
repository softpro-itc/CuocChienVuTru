using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace CuocChienVuTru.Object
{
   
    public class GameObject : DrawableGameComponent
    {
        #region variable
        protected Texture2D texture;
        protected int speed;
        protected Vector2 position;
        protected Rectangle bound;
        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont;
        protected CuocChienVuTru game;
        protected KeyboardState keyboard;
        #endregion

        #region propeties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }
        #endregion

        public GameObject(CuocChienVuTru game, Texture2D texture, Rectangle bound, Vector2 position, int speed)
            : base(game)
        {
            this.game = game;
            this.texture = texture;
            this.bound = bound;
            this.position = position;
            this.speed = speed;
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            spriteFont = (SpriteFont)game.Services.GetService(typeof(SpriteFont)) as SpriteFont;
        }


        public override void Initialize()
        {
           
            base.Initialize();
        }

        public void Hide()
        {
            this.Enabled = true;
            this.Visible = false;
        }

        public void Show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        public void Remove()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(texture, bound, Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
