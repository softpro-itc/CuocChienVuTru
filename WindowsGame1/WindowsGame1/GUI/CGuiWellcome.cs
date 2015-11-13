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
using CuocChienVuTru.DTO;
namespace CuocChienVuTru.GUI
{
    public class CGuiWellcome : CBusiGameSceneBase
    {
        CBusiButton btnContinue;
        CBusiButton btnNewGame;
        CBusiButton btnOption;
        CBusiButton btnHelp;
        CBusiButton btnQuit;

        public CGuiWellcome(CInfoGameSceneBase info) : base(info)
        {
            Dto.Background = new CBusiBackground(new CInfoBackground(Dto.Game, "bg_wellcome", 0));
            btnContinue = new CBusiButton(new CInfoButton(Dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_continue"), new Vector2(265, 230)));
            btnNewGame = new CBusiButton(new CInfoButton(Dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_newgame"), new Vector2(265, 300)));
            btnOption = new CBusiButton(new CInfoButton(Dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_optinon"), new Vector2(265, 370)));
            btnHelp = new CBusiButton(new CInfoButton(Dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_help"), new Vector2(265, 440)));
            btnQuit = new CBusiButton(new CInfoButton(Dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_exit"), new Vector2(265, 510)));
           // background.IsScroll = false;
            Dto.ListButton.Add(btnContinue);
            Dto.ListButton.Add(btnNewGame);
            Dto.ListButton.Add(btnOption);
            Dto.ListButton.Add(btnHelp);
            Dto.ListButton.Add(btnQuit);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(btnNewGame.Dto.IsClicked)
            {
                Dto.Game.gameSceneManager.ShowGameScene(new CGuiLevel1(new CInfoLevelBase(Dto.Game)));
            }

            else if (btnHelp.Dto.IsClicked)
            {
                Dto.Game.gameSceneManager.ShowGameScene(new CGuiHelp(new CInfoGameSceneBase(Dto.Game)));
                btnHelp.Dto.IsClicked = false;
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
