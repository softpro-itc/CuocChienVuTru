using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiBoss : CBusiEnemy
    {
        private CInfoBoss dto;

        public CInfoBoss Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiBoss(CInfoBoss dto)
            : base(dto)
        {
            this.dto = dto;
            dto.Animation = new CBusiAnimation(new CInfoAnimation(dto.Game, dto.FolderSkin + dto.SkinName, dto.Position, 1000, 311, 320, 3, 1, true));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            dto.Animation.Update(gameTime);
            dto.Animation.Dto.Position = dto.Position;
            if (dto.Position.X <= 0)
                dto.IsMoveLeft = false;
            if (dto.Position.X >= 800)
                dto.IsMoveLeft = true;

            if (dto.IsMoveLeft)
                MoveLeft();
            else
                MoveRight();
        }

        public override void Move()
        {
            //position.X -= 2;
        }

        private void MoveLeft()
        {
            dto.Animation.Dto.CurrentFrame = 0;
            dto.Position = new Vector2(dto.Position.X - 2f, dto.Position.Y);
        }

        private void MoveRight()
        {
            dto.Animation.Dto.CurrentFrame = 0;
            dto.Position = new Vector2(dto.Position.X + 2f, dto.Position.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (CBusiBullet b in dto.ListBullet)
                b.Draw(spriteBatch);
            dto.Animation.Draw(spriteBatch);
        }

    }
}
