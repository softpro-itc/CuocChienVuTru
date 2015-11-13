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
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiGameSceneBase
    {

        CInfoGameSceneBase dto;// = new CInfoGameSceneBase();

        public CInfoGameSceneBase Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiGameSceneBase(CInfoGameSceneBase info)
        {
           dto = info;
        }

     
        public void Show()
        {
            dto.IsVisible = true;
        }

        public void Hidden()
        {
            dto.IsVisible = false;
        }

        public virtual void Update(GameTime GameTime)
        {
            dto.CglobalFunc.Update();
            dto.Background.Update(GameTime);
            dto.CglobalVar.Update();
            for (int i = 0; i < dto.ListButton.Count; i++)
            {
                if (dto.CglobalVar.mouseBound.Intersects(dto.ListButton[i].Dto.Bound))
                {
                    if (!dto.ListButton[i].Dto.IsHover)
                        dto.CglobalDic.ListSoundEffect["hover"].Play();
                    dto.ListButton[i].Dto.IsHover = true;
                    dto.ListButton[i].Dto.ColorBrush = Color.Red;
                    if (dto.CglobalVar.mouse.LeftButton == ButtonState.Pressed)
                    {
                        dto.ListButton[i].Dto.IsClicked = true;
                        dto.CglobalDic.ListSoundEffect["clicked"].Play();
                    }
                    else
                        dto.ListButton[i].Dto.IsClicked = false;
                }
                else
                {
                    dto.ListButton[i].Dto.ColorBrush = Color.White;
                    dto.ListButton[i].Dto.IsClicked = false;
                    dto.ListButton[i].Dto.IsHover = false;
                }
            }


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (dto.IsVisible)
            {
                dto.Background.Draw(spriteBatch);
                if(dto.ListButton.Count > 0)
                    foreach (CBusiButton b in dto.ListButton)
                        b.Draw(spriteBatch);
            }
        }

        public bool isHover(Rectangle rec1, Rectangle rec2)
        {
            return rec1.Intersects(rec2);
        }
    }
}
