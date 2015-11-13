using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.DTO
{
   public class CInfoItem:CInfoGameObject
    {
        private CBusiAnimation animation;
        private bool isAnimation;

        public bool IsAnimation
        {
            get { return isAnimation; }
            set { isAnimation = value; }
        }

        public CBusiAnimation Animation
        {
            get { return animation; }
            set { animation = value; }
        }

        #region khai báo constructer
        ///// <summary>
        ///// phương thức khởi tạo item
        ///// </summary>
        ///// <param name="animation">đối tượng chuyển động</param>
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
        //public CInfoItem(CBusiAnimation animation, Texture2D skin, Vector2 position, Rectangle bound, int speed, int hp, int damage, bool visible, Game1 game, CGlobalVariable cglobal, SpriteFont font)
        //    : base(skin, position, bound, speed, hp, damage, visible, game, cglobal, font)
        //{
        //    this.animation = animation;
        //}
        public CInfoItem(Game1 game, string skinName, Vector2 position, int speed, int damage)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Item/";
            animation = new CBusiAnimation(new CInfoAnimation(game, FolderSkin + skinName, position, 80, 50, 50, 5, -1));
            LoadContent(skinName);
        }
        #endregion
    }
}
