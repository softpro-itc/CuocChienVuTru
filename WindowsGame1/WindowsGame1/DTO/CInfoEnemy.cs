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
    class CInfoEnemy : CInfoGameObjectAl
    {
        private int maxBullet = 3;

        public int MaxBullet
        {
            get { return maxBullet; }
            set { maxBullet = value; }
        }
        /// <summary>
        /// phương thức khởi tạo quái
        /// </summary>
        /// <param name="maxBullet">số đạn lớn nhất của quái</param>
        /// <param name="listBullet">danh sách đạn</param>
        /// <param name="timerAddBullet">biến đếm thời gian bắn đạn</param>
        /// <param name="intevalAddBullet">thời gian bắn đạn</param>
        /// <param name="skin">hình quái</param>
        /// <param name="position">vị trí</param>
        /// <param name="bound">bao quanh</param>
        /// <param name="speed">tốc độ</param>
        /// <param name="hp">máu quái</param>
        /// <param name="damage">sát thương</param>
        /// <param name="visible">thuộc tính ẩn hiện</param>
        /// <param name="game">đối tượng game</param>
        /// <param name="cglobal">đối tượng toàn cục</param>
        /// <param name="font">đối tượng chữ</param>
        public CInfoEnemy(int maxBullet, List<CBusiBullet> listBullet, int timerAddBullet, int intevalAddBullet, Texture2D skin, Vector2 position, Rectangle bound, int speed, int hp, int damage, bool visible, Game1 game, CGlobalVariable cglobal, SpriteFont font)
            : base(listBullet, timerAddBullet, intevalAddBullet, skin, position, bound, speed, hp, damage, visible, game, cglobal, font)
        {
            this.maxBullet = maxBullet;
        }
    }
}
