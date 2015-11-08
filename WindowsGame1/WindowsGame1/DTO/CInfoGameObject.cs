using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoGameObject
    {
        #region khai báo biến
        protected Texture2D skin;
        protected Vector2 position;
        protected Rectangle bound;
        protected int speed;
        protected int hp;
        protected int damage;
        protected bool visible;
        protected Game1 game;
        protected CGlobalVariable cglobal;
        protected SpriteFont font;
        #endregion

        #region khai báo propeties
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
        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Hp
        {
            get { return hp; }
            set
            {
                hp = (value >= 0) ? value : 0;
            }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        #endregion
        /// <summary>
        /// phương thức khởi tạo game
        /// </summary>
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
        public CInfoGameObject(Texture2D skin,Vector2 position,Rectangle bound,int speed,int hp,int damage,bool visible,Game1 game,CGlobalVariable cglobal,SpriteFont font)
        {
             this.skin=skin;
            this.position=position;
            this.bound=bound;
            this.speed=speed;
            this.hp=hp;
            this.damage=damage;
            this.visible=visible;
            this.game=game;
            this.cglobal=cglobal;
            this.font = font;
           
        }
    }
}
