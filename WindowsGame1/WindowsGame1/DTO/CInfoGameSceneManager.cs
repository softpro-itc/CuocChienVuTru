using CuocChienVuTru.BUS;
using CuocChienVuTru.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoGameSceneManager
    {
        private CGuiWellcome menuStart;
        private CBusiGameSceneBase active;


        public CGuiWellcome MenuStart
        {
            get { return menuStart; }
            set { menuStart = value; }
        }
        public CBusiGameSceneBase Active
        {
            get { return active; }
            set { active = value; }
        }
        /// <summary>
        /// phương thức khởi tạo quản lý màn hình
        /// </summary>
        /// <param name="menuStart"> menu bắt đầu</param>
        /// <param name="active">màn hình đang hoạt động</param>
        public CInfoGameSceneManager( CGuiWellcome menuStart,CBusiGameSceneBase active)
        {
            this.menuStart = menuStart;
            this.active = active;
        }
    }
}
