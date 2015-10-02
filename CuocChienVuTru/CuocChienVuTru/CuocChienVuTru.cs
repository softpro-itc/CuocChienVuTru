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
using CuocChienVuTru.Helper;

namespace CuocChienVuTru
{

    public class CuocChienVuTru : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Input input;

        public Scene.SceneManager sceneManager;

        //kích thước màn hình game
        public int width = 800;
        public int height = 600;

        public CuocChienVuTru()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            Window.Title = "Cuoc Chien Vu Tru";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            spriteFont = Content.Load<SpriteFont>(@"Font\SpriteFontUnicode");
            Services.AddService(typeof(SpriteFont), spriteFont);

            input = new Input();
            Services.AddService(typeof(Input), input);

            //Background.Background bacground = new Background.Background(this);
            //Components.Add(bacground);
           
            sceneManager = new Scene.SceneManager(this);
            Components.Add(sceneManager);
        }

 
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //update keyboard
            input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
