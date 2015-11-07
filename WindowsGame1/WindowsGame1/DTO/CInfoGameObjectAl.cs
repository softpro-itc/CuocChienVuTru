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
    class CInfoGameObjectAl : CInfoGameObject
    {
        protected List<CBusiBullet> listBullet = new List<CBusiBullet>();
        protected int timerAddBullet = 0;
        private int intevalAddBullet = 2000;
        

        protected int IntevalAddBullet
        {
            get { return intevalAddBullet; }
            set { intevalAddBullet = value; }
        }
        public List<CBusiBullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }
        
        /// <summary>
        /// phương thức khởi tạo đối tượng
        /// </summary>
        /// <param name="listBullet">danh sách đạn</param>
        /// <param name="timerAddBullet">biến đếm thời gian thêm đạn</param>
        /// <param name="intevalAddBullet">thời gian bắn đạn</param>
        /// <param name="skin">hình ảnh đối tượng</param>
        /// <param name="position">vị trí</param>
        /// <param name="bound">bao quanh đối tượng</param>
        /// <param name="speed">tốc độ</param>
        /// <param name="hp">máu của đối tượng</param>
        /// <param name="damage">mức sát thương</param>
        /// <param name="visible">thuộc tính ẩn hiện</param>
        /// <param name="game">đối tượng game</param>
        /// <param name="cglobal">đối tượng toàn cục</param>
        /// <param name="font">đối tượng chữ</param>
        public CInfoGameObjectAl(List<CBusiBullet> listBullet,int timerAddBullet,int intevalAddBullet,Texture2D skin,Vector2 position,Rectangle bound,int speed,int hp,int damage,bool visible,Game1 game,CGlobalVariable cglobal,SpriteFont font)
            : base( skin, position, bound, speed, hp, damage, visible, game, cglobal, font)
        {
            this.intevalAddBullet = intevalAddBullet;
            this.timerAddBullet = timerAddBullet;
            this.listBullet = listBullet;
        }

    }
}
