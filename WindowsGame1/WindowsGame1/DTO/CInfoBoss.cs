using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.BUS;

namespace CuocChienVuTru.DTO
{
    public class CInfoBoss : CInfoEnemy
    {
        CBusiAnimation animation;

        public CBusiAnimation Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        bool isMoveLeft = true;

        public bool IsMoveLeft
        {
            get { return isMoveLeft; }
            set { isMoveLeft = value; }
        }
        public CInfoBoss(Game1 game, string skinName, Vector2 position, int speed, int damage, int hp)
            : base(game, skinName, position, speed, damage)
        {
            visible = false;
            animation = new CBusiAnimation(new CInfoAnimation(game, FolderSkin + skinName, position, 1000, 311, 320, 3, 1, true));
        }
    }
}
