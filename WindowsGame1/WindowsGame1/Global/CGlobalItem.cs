using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CuocChienVuTru.BUS;

namespace CuocChienVuTru.Global
{
    public class CGlobalItem
    {
        private Dictionary<string, CBusiItem> dicItem = new Dictionary<string, CBusiItem>();

        public Dictionary<string, CBusiItem> DicItem
        {
            get { return dicItem; }
            set { dicItem = value; }
        }


        public CGlobalItem(Game1 game)
        {
            for(int i = 1; i <= 9; i++)
            {
                DicItem.Add("item_may_" + i, new CBusiItem(game, "item_may_" + game.cglobalVar.random.Next(1, 9), new Vector2(100, 100), 2, 0));
                //DicItem.Add("item_may_" + i, new CBusiItem(game, "item_may_" + game.cglobalVar.random.Next(1, 9), new Vector2(game.cglobalVar.random.Next(0, CGlobal.CGlobalVariable.WINDOW_WIDTH), game.cglobalVar.random.Next(-20, 0)), 2, 0));
                DicItem["item_may_"+i].IsAnimation = false;
            }
        }

    }
}
