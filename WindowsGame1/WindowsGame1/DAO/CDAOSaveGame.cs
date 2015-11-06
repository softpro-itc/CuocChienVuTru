using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CuocChienVuTru.DAO
{
    class CDAOSaveGame
    {
        public string strFileSave;

        public CDAOSaveGame()
        {
            SaveData();         
        }

        public void SaveData()
        {
            strFileSave = Directory.GetCurrentDirectory() + @"\data " + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".txt";    
            using (StreamWriter write = new StreamWriter(strFileSave, true, Encoding.Unicode))
            {
                write.WriteLine("tiendinh");
                write.WriteLine("1995");
            }
        }

        public string LoadData()
        {
            using(StreamReader reader = new StreamReader(strFileSave))
            {
                string line, rs = "";
                while ((line = reader.ReadLine()) != null)
                    rs += line + " | ";

                return rs;
            }
        }
    }
}
