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
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using CuocChienVuTru.DAO;

namespace CuocChienVuTru
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D skinCursor;

        public CBusiGameSceneManager gameSceneManager;
        public CGlobalDictionary cglobalDic;
        CDAOSaveGame a;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = CGlobalVariable.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = CGlobalVariable.WINDOW_WIDTH;
            cglobalDic = new CGlobalDictionary(this);
            a = new CDAOSaveGame();
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
            gameSceneManager = new CBusiGameSceneManager(this);
            skinCursor = Content.Load<Texture2D>("Images/global/cursor");
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

            //spriteBatch.DrawString(Content.Load<SpriteFont>("Font/fontMain"), a.LoadData(), Vector2.Zero, Color.White);
            gameSceneManager.Draw(spriteBatch);

            spriteBatch.Draw(skinCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
