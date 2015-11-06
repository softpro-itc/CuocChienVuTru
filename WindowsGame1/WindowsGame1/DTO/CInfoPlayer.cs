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
    public class CInfoPlayer
    {
        #region khai baso biến
        private int score; //điểm người chơi
        private int life; //mạng sống người chơi
        private List<CBusiBullet> listBullet = new List<CBusiBullet>(); //danh sách đạn người chơi bắn ra
        private CGloabalFunction input = new CGloabalFunction(); //đố tượng toàn cục 
        private int timer = 0; //đếm thời gian bắn đạn
        private int inteval = 100; //thời gian bắn đạn
        private int hp;
        private Game1 game;
        private Texture2D skin;
        private Vector2 position;

        #endregion

        #region propeties
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public List<CBusiBullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }

        public CGloabalFunction Input
        {
            get { return input; }
            set { input = value; }
        }

        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public int Inteval
        {
            get { return inteval; }
            set { inteval = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public Game1 Game
        {
            get { return game; }
            set { game = value; }
        }
        public Texture2D Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="score">số điểm người chơi</param>
        /// <param name="life">số mạng sống của người chơi</param>
        /// <param name="listBullet">danh sách đạn</param>
        /// <param name="timer">đếm thời gian bắn đạn</param>
        /// <param name="inteval">thời gian bắn đạn</param>
        public CInfoPlayer(int score, int life, List<CBusiBullet> listBullet, int timer, int inteval)
        {
            this.score = score;
            this.life = life;
            this.listBullet = listBullet;
            this.timer = timer;
            this.inteval = inteval;
        }

        public CInfoPlayer()
        { }
    }
}
