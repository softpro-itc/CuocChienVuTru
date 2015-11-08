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
        CBusiButton btnHelp;
        CBusiButton btnQuit;

        public CGuiWellcome(Game1 game) : base(game)
        {
            background = new CBusiBackground(game, "bg_wellcome", 0);
            btnContinue = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_continue"), new Vector2(265, 230));
            btnNewGame = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_newgame"), new Vector2(265, 300));
            btnOption = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_optinon"), new Vector2(265, 370));
            btnHelp = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_help"), new Vector2(265, 440));
            btnQuit = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_exit"), new Vector2(265, 510));
           // background.IsScroll = false;
            listButton.Add(btnContinue);
            listButton.Add(btnNewGame);
            listButton.Add(btnOption);
            listButton.Add(btnHelp);
            listButton.Add(btnQuit);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(btnNewGame.IsClicked)
            {
                game.gameSceneManager.ShowGameScene(new CGuiLevel1(game));
                
            }

            else if (btnHelp.IsClicked)
            {
                game.gameSceneManager.ShowGameScene(new CGuiHelp(game));
                btnHelp.IsClicked = false;
            }

            else if (btnQuit.IsClicked)
                game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
