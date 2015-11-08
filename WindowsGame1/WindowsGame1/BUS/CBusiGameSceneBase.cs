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
using CuocChienVuTru.Global;

namespace CuocChienVuTru.BUS
{
    public class CBusiGameSceneBase
    {
        public List<CBusiButton> listButton;
        public CBusiBackground background;
        public CGlobalVariable cglobalVar;
        public bool isVisible;
        protected Game1 game;
        protected CGloabalFunction cglobalFunc;
        protected CGlobalDictionary cglobalDic;

        public CBusiGameSceneBase(Game1 game, CBusiBackground background)
        {
            this.background = background;
            isVisible = false;
            listButton = new List<CBusiButton>();
            this.game = game;
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
        }

        public CBusiGameSceneBase(Game1 game) 
        {
            this.game = game;
            listButton = new List<CBusiButton>();
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
        }

        public CBusiGameSceneBase() 
        {
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
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
            cglobalFunc.Update();
            background.Update(gameTime);
            cglobalVar.Update();
            for (int i = 0; i < listButton.Count; i++)
            {
                if (cglobalVar.mouseBound.Intersects(listButton[i].Bound))
                {
                    if (!listButton[i].IsHover)
                        cglobalDic.ListSoundEffect["hover"].Play();
                    listButton[i].IsHover = true;
                    listButton[i].ColorBrush = Color.Red;
                    if (cglobalVar.mouse.LeftButton == ButtonState.Pressed)
                    {
                        listButton[i].IsClicked = true;
                        cglobalDic.ListSoundEffect["clicked"].Play();
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
                if(listButton.Count > 0)
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
