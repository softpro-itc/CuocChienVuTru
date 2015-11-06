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

namespace CuocChienVuTru.BUS
{
    public class CBusiLevelBase : CBusiGameSceneBase
    {
        protected List<CBusiEnemy> listEnemy = new List<CBusiEnemy>();
        protected CBusiPlayer player;
        protected int timeAddEnemy = 500;
        protected int timerEnemy = 0;
        protected int maxEnemy = 10;

        protected List<CBusiItem> listItem = new List<CBusiItem>();
        protected int timeAddItem = 500;
        protected int timerItem = 0;
        protected int maxItem = 3;

        protected List<CBusiAnimation> listEffect = new List<CBusiAnimation>();

        /// <summary>
        /// phương thước khởi tạo
        /// </summary>
        /// <param name="game">đối tượng game chính</param>
        /// <param name="background">đối tượng hình nền</param>
        /// <param name="player">đối tượng nhân vật người chơi</param>
        public CBusiLevelBase(Game1 game, CBusiBackground background, CBusiPlayer player) :  base(game, background)
        {
            this.player = player;
            listButton.Add(new CBusiButton(game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT-50)));
            MediaPlayer.Play(game.sound.background);
        }

        public override void Update(GameTime gameTime)
        {
                      
            base.Update(gameTime);
            if(input.KeyboardPress(Keys.Escape))
            {
               game.gameSceneManager.ShowGameScene(game.gameSceneManager.menuStart);
            }
            else
            {
                if (player.Hp == 0)
                {
                    player.Visible = false;
                    player.Animation.isVisible = false;
                }
                else
                {
                    CheckCollision();
                    player.Update(gameTime);
                }

                EnemyManager(gameTime);

                ItemManager(gameTime);
                
                EffectManager(gameTime);
                              
            }

        }

        /// <summary>
        /// quản lý hiệu ứng
        /// </summary>
        /// <param name="gameTime"></param>
        private void EffectManager(GameTime gameTime)
        {
            for (int i = 0; i < listEffect.Count; i++)
            {
                listEffect[i].Update(gameTime);
            }
        }

        /// <summary>
        /// quản lý item (thêm item và câp nhật vị trí item)
        /// </summary>
        /// <param name="gameTime"></param>
        private void ItemManager(GameTime gameTime)
        {
            timerItem += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            //thêm item
            if (timerItem >= timeAddItem && listItem.Count <= maxItem)
            {
                listItem.Add(new CBusiItem(game, cglobal.Content.Load<Texture2D>("Images/Item/star"), new Vector2(cglobal.random.Next(0, CGlobalVariable.WINDOW_HEIGHT), cglobal.random.Next(-100, 0)), 1, 2));
                timerItem = 0;
            }

            //xóa item khi vượt quá màn hình
            for (int i = 0; i < listItem.Count; i++)
            {
                if (listItem[i].Position.Y > CGlobalVariable.WINDOW_HEIGHT)
                {
                    listItem.RemoveAt(i);
                    i--;
                }
            }

            //cập nhật đạn
            for (int i = 0; i < listItem.Count; i++)
                listItem[i].Update(gameTime);
        }

        /// <summary>
        /// Phương thức quản lý quái (thêm quái và câp nhật vị trí quái)
        /// </summary>
        /// <param name="gameTime"></param>
        private void EnemyManager(GameTime gameTime)
        {
            //thêm quái vào danh sách
            timerEnemy += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timerEnemy >= timeAddEnemy && listEnemy.Count <= maxEnemy)
            {
                listEnemy.Add(new CBusiEnemy(game, game.Content.Load<Texture2D>("Images/Enemy/enemy"), new Vector2(cglobal.random.Next(0, CGlobalVariable.WINDOW_HEIGHT), cglobal.random.Next(-100, 0)), 1, 2, 2));
                timerEnemy = 0;
            }

            //xóa quái ra khỏi danh sáhc khi vượt quá màn hình, hoặc hết máu
            for (int i = 0; i < listEnemy.Count; i++)
            {
                if (listEnemy[i].Position.Y > CGlobalVariable.WINDOW_HEIGHT || listEnemy[i].Hp <= 0)
                {
                    if (listEnemy[i].Hp <= 0)
                    {
                        player.Score += listEnemy[i].Damage;
                        cglobal.sound.explosion.Play();
                    }

                    listEnemy.RemoveAt(i);
                    i--;
                }
            }
            //cập nhật quái
            for (int i = 0; i < listEnemy.Count; i++)
                listEnemy[i].Update(gameTime);
        }

        /// <summary>
        /// kiểm tra va chạm
        /// </summary>
        public void CheckCollision()
        {
            for(int i = 0; i < listEnemy.Count; i++)
            {
                //vòng lặp đạn của người chơi
                for(int j = 0; j < player.ListBullet.Count; j ++)
                {
                    //quái trúng đạn
                    if (player.ListBullet[j].Bound.Intersects(listEnemy[i].Bound))
                    {
                        listEffect.Add(new CBusiAnimation(cglobal.Content.Load<Texture2D>("Images/Effect/no"), listEnemy[i].Position, 65, 64, 6, 1));
                        listEnemy[i].Hp -= player.ListBullet[j].Damage;
                    }
                }

                //vòng lặp đạn của quái
                for (int j = 0; j < listEnemy[i].ListBullet.Count; j++)
                {
                    //người chơi bị trúng đạn
                    if (listEnemy[i].ListBullet[j].Bound.Intersects(player.Bound))
                    {
                        listEffect.Add(new CBusiAnimation(cglobal.Content.Load<Texture2D>("Images/Effect/no"), player.PosCenter, 65, 64, 6, 1));
                        listEnemy[i].Hp -= player.Damage;
                        player.Hp -= listEnemy[i].ListBullet[j].Damage;

                        //xóa viên đạn khi va chạm với người chơi
                        listEnemy[i].ListBullet.RemoveAt(j);
                        j--;
                    }
                }

                //người chơi va chạm với quái
                if (listEnemy[i].Bound.Intersects(player.Bound))
                {
                    listEffect.Add(new CBusiAnimation(cglobal.Content.Load<Texture2D>("Images/Effect/no"), player.PosCenter, 65, 64, 6, 1));
                    listEnemy[i].Hp -= player.Damage;
                    player.Hp -= listEnemy[i].Damage;

                    //xóa quái khi va chạm với người chơi
                    listEnemy.RemoveAt(i);
                    i--;
                    cglobal.sound.explosion.Play();
                }
            }

            for(int i = 0; i < listItem.Count; i++)
            {
                if(listItem[i].Bound.Intersects(player.Bound))
                {
                    listEffect.Add(new CBusiAnimation(cglobal.Content.Load<Texture2D>("Images/Effect/effect_2"), player.PosCenter, 128, 118, 8, 1));
                    listItem.RemoveAt(i);
                    i--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //vẽ quái
            foreach (CBusiEnemy e in listEnemy)
                e.Draw(spriteBatch);
            //vẽ item
            foreach (CBusiItem i in listItem)
                i.Draw(spriteBatch);
            //vẽ các hiệu ứng
            foreach (CBusiAnimation a in listEffect)
                a.Draw(spriteBatch);
           //vẽ các button
            foreach (CBusiButton b in listButton)
                b.Draw(spriteBatch);
            spriteBatch.DrawString(cglobal.font, "Score: " + player.Score, new Vector2(10,10), Color.White);
            spriteBatch.DrawString(cglobal.font, "Damage: " + player.Damage, new Vector2(10, 30), Color.White);
            player.Draw(spriteBatch);
        }
    }
}
