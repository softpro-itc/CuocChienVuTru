using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CuocChienVuTru.BUS
{
    public class CBusiGameSceneBase
    {
        public List<CBusiButton> listButton;
        public CBusiBackground background;
        public CGlobalVariable cglobal;
        public bool isVisible;
        protected Game1 game;
        protected CGloabalFunction input;

        public CBusiGameSceneBase(Game1 game, CBusiBackground background)
        {
            this.background = background;
            cglobal = new CGlobalVariable(game);
            isVisible = false;
            listButton = new List<CBusiButton>();
            this.game = game;
            input = new CGloabalFunction();
        }

        public void Show()
        {
            isVisible = true;
        }

        public void Hidden()
        {
            isVisible = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            input.Update();
            background.Update(gameTime);
            cglobal.Update();
            for (int i = 0; i < listButton.Count; i++)
            {
                if (cglobal.mouseBound.Intersects(listButton[i].Bound))
                {
                    if (!listButton[i].IsHover)
                        cglobal.sound.hover.Play();

                    listButton[i].IsHover = true;
                    listButton[i].ColorBrush = Color.SkyBlue;
                    if (cglobal.mouse.LeftButton == ButtonState.Pressed)
                    {
                        listButton[i].IsClicked = true;
                        cglobal.sound.clicked.Play();
                    }
                    else
                        listButton[i].IsClicked = false;
                }
                else
                {
                    listButton[i].ColorBrush = Color.White;
                    listButton[i].IsClicked = false;
                    listButton[i].IsHover = false;
                }
            }


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                background.Draw(spriteBatch);
                foreach (CBusiButton b in listButton)
                    b.Draw(spriteBatch);
            }
        }

        public bool isHover(Rectangle rec1, Rectangle rec2)
        {
            return rec1.Intersects(rec2);
        }
    }
}
