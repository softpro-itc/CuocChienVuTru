using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiEnemy : CBusiGameObjectAI
    {
        private CInfoEnemy dto;

        public CInfoEnemy Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        #region constructor
        public CBusiEnemy(CInfoEnemy dto)
        {
            this.dto = dto;
            dto.FolderSkin = "Images/Enemy/";
            LoadContent(dto.SkinName);
        }
        #endregion

        #region khai báo phương thức

        public void LoadContent(string skinName)
        {
            dto.Skin = dto.Game.Content.Load<Texture2D>(dto.FolderSkin + skinName);
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        }

        public override void Update(GameTime gameTime)
        {
            dto.TimerAddBullet += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        }

        public virtual void Move()
        {
            //if(cglobal.random.Next(0,1) == 1)
            //    dto.Position.X += dto.Speed;
            //else
            //    dto.Position.X -= dto.Speed;
            dto.Position = new Vector2( dto.Position.X, dto.Position.Y + dto.Speed);
        }

        public void Shot()
        {
            if (dto.TimerAddBullet >= dto.IntevalAddBullet && dto.ListBullet.Count <= dto.MaxBullet && dto.Position.X >= 0)
            {
                dto.TimerAddBullet -= dto.IntevalAddBullet;
                CBusiBullet b = new CBusiBullet(new CInfoBullet(dto.Game, "bullet_2", new Vector2(dto.Position.X + 15, dto.Position.Y + 10), 2, 1, CInfoBullet.Owner.enemy));
                dto.ListBullet.Add(b);
            }
        }

        public void BulletManagement(GameTime gameTime)
        {
            //cập nhật đạn
            for (int i = 0; i < dto.ListBullet.Count; i++)
            {
                if (dto.ListBullet[i].Dto.Position.Y >= CGlobalVariable.WINDOW_HEIGHT)
                {
                    dto.ListBullet.RemoveAt(i);
                    i--;
                }
                else
                    dto.ListBullet[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (CBusiBullet b in dto.ListBullet)
                b.Draw(spriteBatch);
            spriteBatch.Draw(dto.Skin, dto.Bound, Color.White);
        }

        #endregion
    }
}
