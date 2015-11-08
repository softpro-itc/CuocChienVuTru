using CuocChienVuTru.BUS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DAO;

namespace CuocChienVuTru.GUI
{
    public class CGuiPause : CBusiGameSceneBase
    {
        CBusiButton btnContinue;
        CBusiButton btnNewGame;
        CBusiButton btnSave;
        CBusiButton btnMenu;
        CBusiButton btnQuit;
        CBusiLevelBase preScene;

        public CGuiPause(Game1 game, CBusiLevelBase preScene)
            : base(game)
        {
            background = new CBusiBackground(game,"bg_pause", 0);
            btnContinue = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_continue"), new Vector2(268, 250));
            btnMenu = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_backmenu"), new Vector2(268, 330));
            btnSave = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_save"), new Vector2(268, 410));
            btnQuit = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_exit"), new Vector2(268, 490));
            // background.IsScroll = false;
            listButton.Add(btnContinue);
            listButton.Add(btnMenu);
            listButton.Add(btnSave);
            listButton.Add(btnQuit);
            this.preScene = preScene;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (btnContinue.IsClicked)
            {
                preScene.IsPLaying = true;
                preScene.background.IsScroll = true;
                game.gameSceneManager.ShowGameScene(preScene);
                btnContinue.IsClicked = false;
            }

            else if (btnMenu.IsClicked)
            {
                btnMenu.IsClicked = false;
                game.gameSceneManager.ShowGameScene(new CGuiWellcome(game));                
            }

            else if(btnSave.IsClicked)
            {
                preScene.IsPLaying = true;
                CDAOSaveGame objSave = new CDAOSaveGame();
                objSave.SaveData(preScene);
                btnSave.IsClicked = false;
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
