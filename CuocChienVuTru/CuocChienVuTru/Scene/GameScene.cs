using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using CuocChienVuTru.Helper;

namespace CuocChienVuTru.Scene
{
    public class GameScene : DrawableGameComponent
    {
        protected List<GameComponent> components;
        protected Texture2D background;
        protected SpriteBatch spritePatch;
        protected List<GUI.Button> listButton;
        public GUI.Menu menu;

        protected CuocChienVuTru game;
        protected Input input;

        public List<GameComponent> Components
        {
            get { return components; }
            set { components = value; }
        }

        public GameScene(CuocChienVuTru game, Texture2D background)
            : base(game)
        {
            this.game = game;
            components = new List<GameComponent>();
            spritePatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            input = (Input)game.Services.GetService(typeof(Input)) as Input;
            this.background = background;
            Visible = false;
            Enabled = false;
        }

        public void Show()
        {
            Visible = true;
            Enabled = true;
        }

        public void Hide()
        {
            Visible = false;
            Enabled = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (components.Count > 0)
            {
                for (int i = 0; i < components.Count; i++)
                {
                    if (components[i].Enabled)
                        components[i].Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spritePatch.Begin();
            spritePatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            spritePatch.End();
            if (components.Count > 0)
            {
                for (int i = 0; i < components.Count; i++)
                {
                    GameComponent gc = components[i];
                    if ((gc is DrawableGameComponent) && ((DrawableGameComponent)gc).Visible)
                        ((DrawableGameComponent)gc).Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
    }
}
