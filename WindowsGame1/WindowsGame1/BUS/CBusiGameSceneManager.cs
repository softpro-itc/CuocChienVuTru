using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.GUI;

namespace CuocChienVuTru.BUS
{
   public class CBusiGameSceneManager
    {
        public CGuiWellcome menuStart;

        public CBusiGameSceneBase active;


        public CBusiGameSceneManager(Game1 game)
        {
            Texture2D tmp = game.Content.Load<Texture2D>("Images/Background/12");
            menuStart = new CGuiWellcome(game, new CBusiBackground(tmp, 0));
            active = menuStart;
            active.isVisible = true;
        }

        public void ShowGameScene(CBusiGameSceneBase gameScene)
        {
            active.Hidden();
            active = gameScene;
            active.Show();
        }

        public void Update(GameTime gameTime)
        {
            active.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            active.Draw(spriteBatch);
        }
    }
}
