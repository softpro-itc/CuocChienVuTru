using CuocChienVuTru.BUS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DAO;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.GUI
{
    public class CGuiPause : CBusiGameSceneBase
    {
        CBusiButton btnContinue;
        CBusiButton btnSave;
        CBusiButton btnMenu;
        CBusiButton btnQuit;
        CBusiLevelBase preScene;

        public CGuiPause(CInfoGameSceneBase  info, CBusiLevelBase preScene)
            : base(info)
        {
            Dto.Background = new CBusiBackground(new CInfoBackground(info.Game,"bg_pause", 0));
            btnContinue = new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/btn_continue"), new Vector2(268, 250)));
            btnMenu = new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/btn_backmenu"), new Vector2(268, 330)));
            btnSave = new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/btn_save"), new Vector2(268, 410)));
            btnQuit = new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/btn_exit"), new Vector2(268, 490)));
            // background.IsScroll = false;
            Dto.ListButton.Add(btnContinue);
            Dto.ListButton.Add(btnMenu);
            Dto.ListButton.Add(btnSave);
            Dto.ListButton.Add(btnQuit);
            this.preScene = preScene;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (btnContinue.Dto.IsClicked)
            {
                preScene.Dto.IsPLaying = true;
                preScene.Dto.Background.Dto.IsScroll = true;
                Dto.Game.gameSceneManager.ShowGameScene(preScene);
                btnContinue.Dto.IsClicked = false;
            }

            else if (btnMenu.Dto.IsClicked)
            {
                btnMenu.Dto.IsClicked = false;
                Dto.Game.gameSceneManager.ShowGameScene(new CGuiWellcome(new CInfoGameSceneBase(Dto.Game)));                
            }

            else if(btnSave.Dto.IsClicked)
            {
                preScene.Dto.IsPLaying = true;
                CDAOSaveGame objSave = new CDAOSaveGame();
                objSave.SaveData(preScene);
                btnSave.Dto.IsClicked = false;
            }
            
            else if (btnQuit.Dto.IsClicked)
                Dto.Game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
