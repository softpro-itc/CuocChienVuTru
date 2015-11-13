using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiButton
    {

        CInfoButton dto;

        public CInfoButton Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiButton(CInfoButton dto)
        {
            this.dto = dto;
        }

        public void ChangeSkin(Texture2D skin)
        {
            dto.Texture = skin;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(dto.Texture, dto.Bound, dto.ColorBrush);
        }
    }
}
