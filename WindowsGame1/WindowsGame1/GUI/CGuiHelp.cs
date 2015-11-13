using CuocChienVuTru.BUS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.GUI
{
    public class CGuiHelp : CBusiGameSceneBase
    {
        CBusiButton btnBack;

        public CGuiHelp(CInfoGameSceneBase dto)
            : base(dto)
        {
            Dto.Background = new CBusiBackground(new CInfoBackground(dto.Game, "bg_help", 0));
            btnBack = new CBusiButton(new CInfoButton(dto.CglobalVar.Content.Load<Texture2D>("Images/Button/btn_back"), new Vector2(0, 500)));
            Dto.ListButton.Add(btnBack);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (btnBack.Dto.IsClicked)
                Dto.Game.gameSceneManager.ShowGameScene(new CGuiWellcome(new CInfoGameSceneBase(Dto.Game)));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
