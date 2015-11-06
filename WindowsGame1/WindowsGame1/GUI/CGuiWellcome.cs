using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework.Input;
using CuocChienVuTru.BUS;

namespace CuocChienVuTru.GUI
{
    public class CGuiWellcome : CBusiGameSceneBase
    {
        CBusiButton btnContinue;
        CBusiButton btnNewGame;
        CBusiButton btnOption;
        CBusiButton btnQuit;
        MouseState mouse; 

        public CGuiWellcome(Game1 game, CBusiBackground background) : base(game, background)
        {
            btnContinue = new CBusiButton(cglobal.Content.Load<Texture2D>("Images/Button/continue"), new Vector2(200, 200));
            btnNewGame = new CBusiButton(cglobal.Content.Load<Texture2D>("Images/Button/new_game"), new Vector2(200, 300));
           // background.IsScroll = false;
            listButton.Add(btnContinue);
            listButton.Add(btnNewGame);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(btnNewGame.IsClicked)
            {
                Texture2D tmp = game.Content.Load<Texture2D>("Images/Background/space");
                CBusiPlayer player = new CBusiPlayer(game, game.Content.Load<Texture2D>("Images/Player/player_3"), new Vector2(200, 400), 5, 2, 5, 100);
                CBusiLevelBase level1 = new CBusiLevelBase(game, new CBusiBackground(tmp, 2), player);
                game.gameSceneManager.ShowGameScene(level1);
            }

            if (btnContinue.IsClicked)
                game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
