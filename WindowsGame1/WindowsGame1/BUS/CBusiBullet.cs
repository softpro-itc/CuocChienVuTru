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
    public class CBusiBullet : CBusiGameObject
    {
        private CInfoBullet dto;

        public CInfoBullet Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiBullet(CInfoBullet dto)
            : base()
        {
            this.dto = dto;
            dto.FolderSkin = "Images/Bullet/";
            LoadContent(dto.SkinName);
        }

        public void LoadContent(string skinName)
        {
            dto.Skin = dto.Game.Content.Load<Texture2D>(dto.FolderSkin + skinName);
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        }

        public override void Update(GameTime gameTime)
        {
            if (dto.Owner1 == CInfoBullet.Owner.enemy)
                dto.Position = new Vector2(dto.Position.X, dto.Position.Y+dto.Speed);
            else
                dto.Position = new Vector2(dto.Position.X, dto.Position.Y - dto.Speed);

            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(dto.Skin,dto.Bound, Color.White);
        }

    }
}
