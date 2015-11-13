using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoPlayer : CInfoGameObjectAl
    {
        #region khai báo biến
        private int score;
        private int life;
        private CGloabalFunction input = new CGloabalFunction();
        private Texture2D skinHealthBar;
        private CBusiAnimation animation;
        private CBusiAnimation animationLeft;       
        private CBusiAnimation animationRight;
        private Vector2 posCenter;
        #endregion

        #region khai báo propeties
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int Life
        {
            get { return life; }
            set { if (value >= 0) life = value; }
        }
        public CGloabalFunction Input
        {
            get { return input; }
            set { input = value; }
        }
        public Texture2D SkinHealthBar
        {
            get { return skinHealthBar; }
            set { skinHealthBar = value; }
        }
        public CBusiAnimation Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        public Vector2 PosCenter
        {
            get { return new Vector2(position.X + 10, position.Y ); }
            set { posCenter = value; }
        }

        public CBusiAnimation AnimationLeft
        {
            get { return animationLeft; }
            set { animationLeft = value; }
        }
        public CBusiAnimation AnimationRight
        {
            get { return animationRight; }
            set { animationRight = value; }
        }

        #endregion

        #region khai báo constructor
        ///// <summary>
        ///// phương thức khởi tạo người chơi
        ///// </summary>
        ///// <param name="listBullet">danh sách đạn</param>
        ///// <param name="timerAddBullet">biến đếm thời gian thêm đạn</param>
        ///// <param name="intevalAddBullet">thời gian thêm đạn</param>
        ///// <param name="skin">hình ảnh đối tượng</param>
        ///// <param name="position">vị trí</param>
        ///// <param name="bound">bao quanh đối tượng</param>
        ///// <param name="speed">tốc độ</param>
        ///// <param name="hp">máu của đối tượng</param>
        ///// <param name="damage">mức sát thương</param>
        ///// <param name="visible">thuộc tính ẩn hiện</param>
        ///// <param name="game">đối tượng game</param>
        ///// <param name="cglobal">đối tượng toàn cục</param>
        ///// <param name="font">đối tượng chữ</param>
        ///// <param name="score">điểm</param>
        ///// <param name="life">mạng sống</param>
        ///// <param name="input">đối tượng input</param>
        ///// <param name="skinHealthBar">hình ảnh thanh máu</param>
        ///// <param name="animation">đối tượng chuyển động</param>
        ///// <param name="posCenter">vị trí giữa</param>
        //public CInfoPlayer(List<CBusiBullet> listBullet, int timerAddBullet, int intevalAddBullet, Texture2D skin, Vector2 position, Rectangle bound, int speed, int hp, int damage, bool visible, Game1 game, CGlobalVariable cglobal, SpriteFont font, int score, int life, CGloabalFunction input, Texture2D skinHealthBar, CBusiAnimation animation, Vector2 posCenter)
        //    : base(listBullet, timerAddBullet, intevalAddBullet, skin, position, bound, speed, hp, damage, visible, game, cglobal, font)
        //{
        //    this.score = score;
        //    this.life = life;
        //    this.input = input;
        //    this.skinHealthBar = skinHealthBar;
        //    this.animation = animation;
        //    this.posCenter = posCenter;
        //}

        public CInfoPlayer(Game1 game, string skinName, Vector2 position, int speed, int damage)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Player/";
            life = 5;
            score = 0;
            hp = 100;
            skinHealthBar = game.Content.Load<Texture2D>("Images/Button/HealthBar");
            LoadContent(skinName);
            animation = new CBusiAnimation(new CInfoAnimation(game, FolderSkin + skinName, position, 80, 64, 64, 3, 1, true));
            animationLeft = new CBusiAnimation(new CInfoAnimation(game, "Images/Effect/effect_player_1", new Vector2(posCenter.X, posCenter.Y + skin.Height), 80, 83, 76, 6, 1, true));
        }

        public CInfoPlayer(Game1 game, string skinName, Vector2 position, int speed, int damage, int life, int hp)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Player/";
            this.skinName = skinName;
            score = 0;
            this.life = life;
            this.hp = hp;
            skinHealthBar = game.Content.Load<Texture2D>("Images/Button/HealthBar");
            LoadContent(skinName);
            animation = new CBusiAnimation(new CInfoAnimation( game, "Images/Player/" + skinName, position, 80, 82, 64, 3, 3, true));

            animationRight = new CBusiAnimation(new CInfoAnimation(game, "Images/Effect/effect_player_2", position, 50, 20, 50, 4, -1));
            animationLeft = new CBusiAnimation(new CInfoAnimation(game, "Images/Effect/effect_player_2", position, 50, 20, 50, 4, -1));
            IntevalAddBullet = 100;
        }

        public CInfoPlayer() { }
        #endregion
    }
        
}
