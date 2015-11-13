using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiItem : CBusiGameObject
    {

        CInfoItem dto;

        public CInfoItem Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiItem(CInfoItem info)
        {
            this.dto = info;
        }

        public override void Update(GameTime gameTime)
        {
            dto.Position = new Vector2(dto.Position.X, dto.Position.Y + dto.Speed);
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width - ((dto.Animation.Dto.MaxFrame-1) * dto.Animation.Dto.FrameWidth), dto.Skin.Height);

            if (dto.IsAnimation)
            {
                dto.Animation.Update(gameTime);
                dto.Animation.Dto.Position = dto.Position;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!dto.IsAnimation)
                spriteBatch.Draw(dto.Skin, dto.Bound, Color.White);
            else
                dto.Animation.Draw(spriteBatch);
        }
    }
}
