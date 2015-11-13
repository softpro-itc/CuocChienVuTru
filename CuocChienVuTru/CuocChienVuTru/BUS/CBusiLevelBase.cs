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
using CuocChienVuTru.GUI;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiLevelBase : CBusiGameSceneBase
    {
        protected CInfoLevelBase dto;
        private Texture2D lblScore;
        private Vector2 posScore;
        private Texture2D lblLife;
        private Vector2 posLife;

        public CInfoLevelBase Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiLevelBase(CInfoLevelBase info) : base(info) 
        {
            dto = info;
            lblScore = dto.Game.Content.Load<Texture2D>("Images/Label/lbl_score");
            lblLife = dto.Game.Content.Load<Texture2D>("Images/Label/lbl_life");
            posScore = new Vector2(10, 10);
            posLife = new Vector2(800, 550);
        }

        //public CBusiLevelBase() { }

        public override void Update(GameTime gameTime)
        {
                      
            base.Update(gameTime);

            //pause
            if (dto.CglobalFunc.KeyboardRelease(Keys.Escape))
            {
                dto.IsPLaying = !dto.IsPLaying;
                dto.Background.Dto.IsScroll = !dto.Background.Dto.IsScroll;
            }

            if (dto.IsPLaying)
            {

                if (Dto.Player.Dto.Score >= Dto.PointDestination)
                {
                    Dto.Boss.Dto.Visible = true;
                    Dto.Boss.Update(gameTime);
                }

                if (dto.Player.Dto.Hp <= 0)
                {
                    dto.Player.Dto.Visible = false;
                    dto.Player.Dto.Animation.Dto.IsVisible = false;
                }
                else
                {
                    CheckCollision();
                    dto.Player.Update(gameTime);
                }
                EnemyManager(gameTime);
                ItemManager(gameTime);
                EffectManager(gameTime);
            }
            else
            {
                dto.Game.gameSceneManager.ShowGameScene(new CGuiPause(new CInfoGameSceneBase(dto.Game), this));
            }

        }

        /// <summary>
        /// quản lý hiệu ứng
        /// </summary>
        /// <param name="gameTime"></param>
        private void EffectManager(GameTime gameTime)
        {
            for (int i = 0; i < dto.ListEffect.Count; i++)
            {
                dto.ListEffect[i].Update(gameTime);
            }
        }

        /// <summary>
        /// quản lý item (thêm item và câp nhật vị trí item)
        /// </summary>
        /// <param name="gameTime"></param>
        private void ItemManager(GameTime gameTime)
        {
            dto.TimerItem += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            //thêm item
            if (dto.TimerItem >= dto.TimeAddItem && dto.ListItem.Count <= dto.MaxItem)
            {
                CInfoItem dtoItem = new CInfoItem(dto.Game, "star", new Vector2(dto.CglobalVar.random.Next(0, CGlobal.CGlobalVariable.WINDOW_WIDTH), dto.CglobalVar.random.Next(-100, 0)), 1, 2);
                dtoItem.IsAnimation = true;
                dto.ListItem.Add(new CBusiItem(dtoItem));
                dto.TimerItem = 0;
            }

            //xóa item khi vượt quá màn hình
            for (int i = 0; i < dto.ListItem.Count; i++)
            {
                if (dto.ListItem[i].Dto.Position.Y > CGlobalVariable.WINDOW_HEIGHT)
                {
                    dto.ListItem.RemoveAt(i);
                    i--;
                }
            }

            //cập nhật đạn
            for (int i = 0; i < dto.ListItem.Count; i++)
                dto.ListItem[i].Update(gameTime);
        }

        /// <summary>
        /// Phương thức quản lý quái (thêm quái và câp nhật vị trí quái)
        /// </summary>
        /// <param name="gameTime"></param>
        private void EnemyManager(GameTime gameTime)
        {
            //thêm quái vào danh sách
            dto.TimerEnemy += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (dto.TimerEnemy >= dto.TimeAddEnemy && dto.ListEnemy.Count <= dto.MaxEnemy)
            {
                dto.ListEnemy.Add(new CBusiEnemy(new CInfoEnemy(dto.Game, "enemy", new Vector2(dto.CglobalVar.random.Next(0, CGlobalVariable.WINDOW_HEIGHT), dto.CglobalVar.random.Next(-100, 0)), 1, 2, 2)));
                dto.TimerEnemy = 0;
            }

            //xóa quái ra khỏi danh sáhc khi vượt quá màn hình, hoặc hết máu
            for (int i = 0; i < dto.ListEnemy.Count; i++)
            {
                if (dto.ListEnemy[i].Dto.Position.Y > CGlobalVariable.WINDOW_HEIGHT || dto.ListEnemy[i].Dto.Hp <= 0)
                {
                    if (dto.ListEnemy[i].Dto.Hp <= 0)
                    {
                        dto.Player.Dto.Score += dto.ListEnemy[i].Dto.Damage;
                        dto.Game.cglobalDic.ListSoundEffect["explode"].Play();
                    }

                    dto.ListEnemy.RemoveAt(i);
                    i--;
                }
            }
            //cập nhật quái
            for (int i = 0; i < dto.ListEnemy.Count; i++)
                dto.ListEnemy[i].Update(gameTime);
        }

        /// <summary>
        /// kiểm tra va chạm
        /// </summary>
        public void CheckCollision()
        {
            for(int i = 0; i < dto.ListEnemy.Count; i++)
            {
                //vòng lặp đạn của người chơi
                for(int j = 0; j < dto.Player.Dto.ListBullet.Count; j ++)
                {
                    //quái trúng đạn
                    if (dto.Player.Dto.ListBullet[j].Dto.Bound.Intersects(dto.ListEnemy[i].Dto.Bound))
                    {
                        dto.ListEffect.Add(new CBusiAnimation(new CInfoAnimation(dto.Game, "Images/Effect/no", dto.ListEnemy[i].Dto.Position, 50, 65, 64, 6, 1)));
                        dto.ListEnemy[i].Dto.Hp -= dto.Player.Dto.ListBullet[j].Dto.Damage;
                    }
                }

                //vòng lặp đạn của quái
                for (int j = 0; j < dto.ListEnemy[i].Dto.ListBullet.Count; j++)
                {
                    //người chơi bị trúng đạn
                    if (dto.ListEnemy[i].Dto.ListBullet[j].Dto.Bound.Intersects(dto.Player.Dto.Bound))
                    {
                        dto.ListEffect.Add(new CBusiAnimation(new CInfoAnimation(dto.Game, "Images/Effect/no", dto.Player.Dto.PosCenter, 50, 65, 64, 6, 1)));
                        dto.Player.Dto.Hp -= dto.ListEnemy[i].Dto.ListBullet[j].Dto.Damage;
                        dto.Game.cglobalDic.ListSoundEffect["explode"].Play();

                        //xóa viên đạn khi va chạm với người chơi
                        dto.ListEnemy[i].Dto.ListBullet.RemoveAt(j);
                        j--;
                    }
                }

                //người chơi va chạm với quái
                if (dto.ListEnemy[i].Dto.Bound.Intersects(dto.Player.Dto.Bound))
                {
                    dto.ListEffect.Add(new CBusiAnimation(new CInfoAnimation(dto.Game, "Images/Effect/no", dto.Player.Dto.PosCenter, 50, 65, 64, 6, 1)));
                    dto.ListEnemy[i].Dto.Hp -= dto.Player.Dto.Damage;
                    dto.Player.Dto.Hp -= dto.ListEnemy[i].Dto.Damage;

                    //xóa quái khi va chạm với người chơi
                    dto.ListEnemy.RemoveAt(i);
                    i--;
                    dto.Game.cglobalDic.ListSoundEffect["explode"].Play();
                }
            }

            //vòng lặp item
            for(int i = 0; i < dto.ListItem.Count; i++)
            {
                if(dto.ListItem[i].Dto.Bound.Intersects(dto.Player.Dto.Bound))
                {
                    dto.ListEffect.Add(new CBusiAnimation(new CInfoAnimation(dto.Game, "Images/Effect/effect_2", dto.ListItem[i].Dto.Position, 30, 128, 118, 8, 1)));
                    dto.Game.cglobalDic.ListSoundEffect["item"].Play();
                    dto.ListItem.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
            //vẽ quái

            if (dto.Boss.Dto.Visible)
                dto.Boss.Draw(spriteBatch);
            foreach (CBusiEnemy e in dto.ListEnemy)
                e.Draw(spriteBatch);
            //vẽ item
            foreach (CBusiItem i in dto.ListItem)
                i.Draw(spriteBatch);
            
           //vẽ các button
            foreach (CBusiButton b in dto.ListButton)
                b.Draw(spriteBatch);

            //vẽ người chơi
            dto.Player.Draw(spriteBatch);

            //vẽ các hiệu ứng
            foreach (CBusiAnimation a in dto.ListEffect)
                a.Draw(spriteBatch);

            spriteBatch.Draw(lblScore, posScore, Color.White);
            spriteBatch.DrawString(dto.CglobalVar.font, dto.Player.Dto.Score.ToString(), new Vector2(40,10), Color.White);

            for (int i = 1; i <= dto.Player.Dto.Life; i++ )
            {
                spriteBatch.Draw(lblLife, new Vector2(posLife.X - i*50, posLife.Y), Color.White);
            }
        }
    }
}
