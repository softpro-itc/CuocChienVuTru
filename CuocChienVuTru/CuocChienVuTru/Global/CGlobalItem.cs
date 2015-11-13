using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CuocChienVuTru.BUS;
using CuocChienVuTru.DTO;

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
            
        }

    }
}
