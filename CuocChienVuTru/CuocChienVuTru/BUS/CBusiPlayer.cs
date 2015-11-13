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
    public class CBusiPlayer : CBusiGameObjectAI
    {

        private CInfoPlayer dto;

        public CInfoPlayer Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        #region constructor

        public CBusiPlayer(CInfoPlayer info)
        {
            dto = info;
            dto.Score = 0;
            dto.SkinHealthBar = info.CglobalVar.Content.Load<Texture2D>("Images/Button/HealthBar");
            LoadContent(info.SkinName);
            dto.Animation = new CBusiAnimation(new CInfoAnimation(info.Game, "Images/Player/" + dto.SkinName, dto.Position, 80, 82, 64, 3, 3, true));
             
            dto.AnimationRight = new CBusiAnimation(new CInfoAnimation(info.Game, "Images/Effect/effect_player_2", dto.Position, 50, 20, 50, 4, -1));
            dto.AnimationLeft = new CBusiAnimation(new CInfoAnimation(info.Game, "Images/Effect/effect_player_2", dto.Position, 50, 20, 50, 4, -1));
            dto.IntevalAddBullet = 100;
        }

        public CBusiPlayer() { }
        #endregion

        #region khai báo phương thức

        public void LoadContent(string skinName)
        {
            dto.Skin = dto.Game.Content.Load<Texture2D>(dto.FolderSkin + skinName);
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        }

        public override void Update(GameTime gameTime)
        {
            dto.CglobalFunc.Update();
            dto.TimerAddBullet += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);
            
            dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Animation.Dto.Rectangle.Width, dto.Skin.Height);
                                
            dto.Animation.Update(gameTime);
            dto.Animation.Dto.Position = dto.Position;

            dto.AnimationRight.Update(gameTime);
            dto.AnimationRight.Dto.Position = new Vector2(dto.Position.X - 5, dto.Position.Y + 45);

            dto.AnimationLeft.Update(gameTime);
            dto.AnimationLeft.Dto.Position = new Vector2(dto.Position.X + 65, dto.Position.Y + 45);
        }

        /// <summary>
        /// phương thức di chuyển nhân vật
        /// </summary>
        private void Move()
        {           
            if ( dto.CglobalFunc.KeyboardPress(Keys.Up) && dto.Position.Y > 0)
               dto.Position = new Vector2(dto.Position.X,  dto.Position.Y - dto.Speed);
            if ( dto.CglobalFunc.KeyboardPress(Keys.Down) && dto.Position.Y < CGlobalVariable.WINDOW_HEIGHT - dto.Skin.Height)
                dto.Position = new Vector2(dto.Position.X, dto.Position.Y + dto.Speed);
            if ( dto.CglobalFunc.KeyboardPress(Keys.Left) && dto.Position.X > - 10)
                dto.Position = new Vector2(dto.Position.X - dto.Speed, dto.Position.Y);
            if ( dto.CglobalFunc.KeyboardPress(Keys.Right) && dto.Position.X < CGlobalVariable.WINDOW_WIDTH - 82)
                dto.Position = new Vector2(dto.Position.X + dto.Speed, dto.Position.Y);
        }

        /// <summary>
        /// phương thức bắn đạn
        /// </summary>
        public void Shot()
        {
            if ( dto.CglobalFunc.KeyboardPress(Keys.Space))
            {
                if (dto.TimerAddBullet >= dto.IntevalAddBullet)
                {
                    dto.TimerAddBullet -= dto.IntevalAddBullet;
                    CBusiBullet b = new CBusiBullet(new CInfoBullet(dto.Game, "bullet_1", new Vector2(dto.Position.X + dto.Animation.Dto.Rectangle.Width / 2, dto.Position.Y), 10, 3, CInfoBullet.Owner.player));
                    dto.ListBullet.Add(b);
                    dto.CglobalDic.ListSoundEffect["shoot"].Play();
                }
            }
        }

        /// <summary>
        /// Phương thức cập nhập đạn
        /// </summary>
        /// <param name="gameTime"></param>
        public void BulletManagement(GameTime gameTime)
        {
            //cập nhật đạn
            for(int i = 0; i < dto.ListBullet.Count; i++)
            {
                if (dto.ListBullet[i].Dto.Position.Y <= 0)
                {
                    dto.ListBullet.RemoveAt(i);
                    i--;
                }
                else
                    dto.ListBullet[i].Update(gameTime);
            }
        }

        public void DrawHeadBar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( dto.SkinHealthBar, new Rectangle(800 / 2 -  dto.SkinHealthBar.Width / 2, 30,  dto.SkinHealthBar.Width, 20), new Rectangle(0, 45,  dto.SkinHealthBar.Width, 44), Color.Gray);
            spriteBatch.Draw(dto.SkinHealthBar, new Rectangle(800 / 2 - dto.SkinHealthBar.Width / 2, 30, (int)(dto.SkinHealthBar.Width * ((double)dto.Hp / 100)), 20), new Rectangle(0, 45, dto.SkinHealthBar.Width, 44), Color.Red);
            spriteBatch.DrawString(dto.CglobalVar.font, dto.Hp.ToString(), new Vector2(800 / 2 -  dto.SkinHealthBar.Width / 2, 28), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawHeadBar(spriteBatch);
            //spriteBatch.Draw(skin, dto.Bound, Color.White);


            if (dto.Visible)
            {
                dto.Animation.Draw(spriteBatch);
                dto.AnimationLeft.Draw(spriteBatch);
                dto.AnimationRight.Draw(spriteBatch);

                foreach (CBusiBullet b in dto.ListBullet)
                    b.Draw(spriteBatch);
            }
        }

        #endregion
    }
}
