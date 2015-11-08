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
        public CGlobalVariable cglobalVar;
        public CGloabalFunction cglobalFunc;
        public CGlobalItem cglobalItem;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //thiết lập độ phâm giả
            graphics.PreferredBackBufferHeight = CGlobalVariable.WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = CGlobalVariable.WINDOW_WIDTH;                        
        }


        protected override void Initialize()
        {
            Services.AddService(typeof(ContentManager), Content);
            Window.Title = "Cuoc Chien Vu Tru";
            base.Initialize();
        }


        protected override void LoadContent()
        {
            //khơi tạo đối tượng toàn cục
            cglobalVar = new CGlobalVariable(Content);
            cglobalFunc = new CGloabalFunction();
            cglobalDic = new CGlobalDictionary(this);
            cglobalItem = new CGlobalItem(this);

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

            gameSceneManager.Draw(spriteBatch);

            spriteBatch.Draw(skinCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
