using CuocChienVuTru.BUS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.GUI
{
    public class CGuiHelp : CBusiGameSceneBase
    {
        CBusiButton btnBack;

        public CGuiHelp(Game1 game)
            : base(game)
        {
            background = new CBusiBackground(game, "bg_help", 0);
            btnBack = new CBusiButton(cglobalVar.Content.Load<Texture2D>("Images/Button/btn_back"), new Vector2(0, 500));
            listButton.Add(btnBack);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (btnBack.IsClicked)
                game.gameSceneManager.ShowGameScene(new CGuiWellcome(game));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
