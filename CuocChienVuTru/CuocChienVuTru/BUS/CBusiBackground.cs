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
    public class CBusiBackground
    {
        private CInfoBackground dto;

        public CInfoBackground Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiBackground(CInfoBackground dto)
        {
            this.dto = dto;
        }

        public void Update(GameTime GameTime)
        {
            if (dto.IsScroll)
            {
                dto.PositionBackground1 = new Vector2(dto.PositionBackground1.X, dto.PositionBackground1.Y + dto.Speed);
                if (dto.PositionBackground1.Y == CGlobalVariable.WINDOW_HEIGHT)
                    dto.PositionBackground1 = new Vector2(dto.PositionBackground1.X, -CGlobalVariable.WINDOW_HEIGHT);

                dto.PositionBackground2 = new Vector2(dto.PositionBackground2.X, dto.PositionBackground2.Y + dto.Speed);
                if (dto.PositionBackground2.Y == CGlobalVariable.WINDOW_HEIGHT)
                    dto.PositionBackground2 = new Vector2(dto.PositionBackground2.X, -CGlobalVariable.WINDOW_HEIGHT);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(dto.TextureBackground1, dto.PositionBackground1, Color.White);
            spriteBatch.Draw(dto.TextureBackground2, dto.PositionBackground2, Color.White);
        }
    }
}
