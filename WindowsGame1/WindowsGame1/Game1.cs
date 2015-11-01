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
using CuocChienVuTru.BUS;
using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.BUS;

namespace CuocChienVuTru
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public CBusiSoundManager sound;

        public CBusiGameSceneManager gameSceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = CGlobalVariable.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = CGlobalVariable.WINDOW_WIDTH;
            sound = new CBusiSoundManager();
        }


        protected override void Initialize()
        {
            Services.AddService(typeof(ContentManager), Content);
            Window.Title = "Cuoc Chien Vu Tru";
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sound.loadContent(Content);
            gameSceneManager = new CBusiGameSceneManager(this);
            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gameSceneManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            gameSceneManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
