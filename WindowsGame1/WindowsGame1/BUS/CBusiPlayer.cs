using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.CGlobal;

namespace CuocChienVuTru.BUS
{
    public class CBusiPlayer : CBusiGameObjectAI
    {
        #region khai báo biến
        private int score;
        private int life;
        private CGloabalFunction input = new CGloabalFunction();
        private Texture2D skinHealthBar;
        private CBusiAnimation animation;
        private CBusiAnimation animationLeft, animationRight;
        private Vector2 posCenter;
        #endregion

        #region khai báo propeties


        public CBusiAnimation Animation
        {
            get { return animation; }
            set { animation = value; }
        }

        public Vector2 PosCenter
        {
            get { return animation.Position;}
            set { posCenter = value; }
        }  

        public int Life
        {
            get { return life; }
            set { if(value >=0) life = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        #endregion

        #region constructor
        public CBusiPlayer(Game1 game, string skinName, Vector2 position, int speed, int damage)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Player/";
            life = 5;
            score = 0;
            hp = 100;
            skinHealthBar = cglobalVar.Content.Load<Texture2D>("Images/Button/HealthBar");
            LoadContent(skinName);
            animation = new CBusiAnimation(game, FolderSkin + skinName, position, 80, 64, 64, 3, 1, true);
            animationLeft = new CBusiAnimation(game, "Images/Effect/effect_player_1", new Vector2(posCenter.X, posCenter.Y+skin.Height), 80, 83, 76, 6, 1, true);
        }

        public CBusiPlayer(Game1 game, string skinName, Vector2 position, int speed, int damage, int life, int hp)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Player/";
            score = 0;
            this.life = life;
            this.hp = hp;
            skinHealthBar = cglobalVar.Content.Load<Texture2D>("Images/Button/HealthBar");
            LoadContent(skinName);
            animation = new CBusiAnimation(game, "Images/Player/" + skinName, position, 80, 82, 64, 3, 3, true);

            animationRight = new CBusiAnimation(game, "Images/Effect/effect_player_2", position, 50, 20, 50, 4, -1);
            animationLeft = new CBusiAnimation(game, "Images/Effect/effect_player_2", position, 50, 20, 50, 4, -1);
            IntevalAddBullet = 100;
        }

        public CBusiPlayer() { }
        ////Game1 game, Texture2D skin, Vector2 position, int speed, int damage, int life, int hp, int score
        //public CBusiPlayer(CInfoPlayer dto)
        //{
        //    game = dto.Game;
        //    skin = dto.Skin;
        //    position = dto.Position;
        //    score = dto.Score;
        //    life = dto.Life;
        //    hp = dto.Hp;
        //    animation = new CBusiAnimation(skin, position, 80, 64, 64, 3, 1, true);
        //}
        #endregion

        #region khai báo phương thức
        public override void Update(GameTime gameTime)
        {
            bound.Width = animation.Rectangle.Width;

            input.Update();
            timerAddBullet += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);

            bound.X = (int)position.X;
            bound.Y = (int)position.Y;
                                
            animation.Update(gameTime);
            animation.Position = position;

            animationRight.Update(gameTime);
            animationRight.Position = new Vector2(position.X - 5, position.Y + 45);

            animationLeft.Update(gameTime);
            animationLeft.Position = new Vector2(position.X + 65, position.Y + 45);
        }

        /// <summary>
        /// phương thức di chuyển nhân vật
        /// </summary>
        private void Move()
        {
            if (input.KeyboardPress(Keys.Up) && position.Y > 0)
                position.Y -= speed;
            if (input.KeyboardPress(Keys.Down) && position.Y < CGlobalVariable.WINDOW_HEIGHT - skin.Height)
                position.Y += speed;
            if (input.KeyboardPress(Keys.Left) && position.X > - 10)
                position.X -= speed;
            if (input.KeyboardPress(Keys.Right) && position.X < CGlobalVariable.WINDOW_WIDTH - 82)
                position.X += speed;
        }

        /// <summary>
        /// phương thức bắn đạn
        /// </summary>
        public void Shot()
        {
            if (input.KeyboardPress(Keys.Space))
            {
                if (timerAddBullet >= IntevalAddBullet)
                {
                    timerAddBullet -= IntevalAddBullet;
                    CBusiBullet b = new CBusiBullet(game, "bullet_1", new Vector2(position.X + animation.Rectangle.Width / 2, position.Y), 10, 3, CBusiBullet.Owner.player);
                    listBullet.Add(b);
                    game.cglobalDic.ListSoundEffect["shoot"].Play();
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
            for(int i = 0; i < listBullet.Count; i++)
            {
                if (listBullet[i].Position.Y <= 0)
                {
                    listBullet.RemoveAt(i);
                    i--;
                }
                else
                    listBullet[i].Update(gameTime);
            }
        }

        public void DrawHeadBar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skinHealthBar, new Rectangle(800 / 2 - skinHealthBar.Width / 2, 30, skinHealthBar.Width, 20), new Rectangle(0, 45, skinHealthBar.Width, 44), Color.Gray);
            spriteBatch.Draw(skinHealthBar, new Rectangle(800 / 2 - skinHealthBar.Width / 2, 30, (int)(skinHealthBar.Width * ((double)hp / 100)), 20), new Rectangle(0, 45, skinHealthBar.Width, 44), Color.Red);
            spriteBatch.DrawString(cglobalVar.font, hp.ToString(), new Vector2(800 / 2 - skinHealthBar.Width / 2, 28), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawHeadBar(spriteBatch);
            //spriteBatch.Draw(skin, bound, Color.White);


            if (visible)
            {
                animation.Draw(spriteBatch);
                animationLeft.Draw(spriteBatch);
                animationRight.Draw(spriteBatch);

                foreach (CBusiBullet b in listBullet)
                    b.Draw(spriteBatch);
            }
        }

        #endregion
    }
}
