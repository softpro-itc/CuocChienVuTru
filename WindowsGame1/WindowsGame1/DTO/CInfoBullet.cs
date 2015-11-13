
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoBullet : CInfoGameObject
    {
        public enum Owner
        {
            enemy,
            player
        };

        Owner owner;

        public Owner Owner1
        {
            get { return owner; }
            set { owner = value; }
        }

        #region khai báo constructer
        ///// <summary>
        ///// phương thức khởi tạo
        ///// </summary>
        ///// <param name="owner">enum</param>
        ///// <param name="skin">hình viên đạn</param>
        ///// <param name="position">vị trí</param>
        ///// <param name="bound">thuộc tính bao quanh</param>
        ///// <param name="speed">tốc độ</param>
        ///// <param name="hp"></param>
        ///// <param name="damage">mức sát thương</param>
        ///// <param name="visible">thuộc tính ẩn hiện</param>
        ///// <param name="game">đối tượng game</param>
        ///// <param name="cglobal">đối tượng toàn cục</param>
        ///// <param name="font">đối tượng chữ</param>
        //public CInfoBullet(Owner owner, Texture2D skin, Vector2 position, Rectangle bound, int speed, int hp, int damage, bool visible, Game1 game, CGlobalVariable cglobal, SpriteFont font)
        //    : base(skin, position, bound, speed, hp, damage, visible, game, cglobal, font)
        //{
        //    this.owner = owner;
        //}
        public CInfoBullet(Game1 game, string skinName, Vector2 position, int speed, int damage, Owner owner)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Bullet/";
            LoadContent(skinName);
            this.owner = owner;
        }
        #endregion
    }
}
