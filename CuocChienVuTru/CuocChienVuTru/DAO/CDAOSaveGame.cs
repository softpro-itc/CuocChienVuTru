using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CuocChienVuTru.BUS;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CuocChienVuTru.DAO
{
    [Serializable]
    class CDAOSaveGame
    {
        public string strFileSave;

        public CDAOSaveGame()
        {
        }

        public void SaveData(CBusiLevelBase gameScene)
        {
            strFileSave = Directory.GetCurrentDirectory() + @"\data " + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".dat";
            FileStream FS = File.Create(strFileSave);
            BinaryFormatter binSerializer = new BinaryFormatter();
            binSerializer.Serialize(FS, gameScene);
            FS.Close();

        }

        public CBusiLevelBase LoadData(string strFileData)
        {
            FileStream FS = File.OpenRead(strFileData);
            BinaryFormatter binSerializer = new BinaryFormatter();
            CBusiLevelBase obj = (CBusiLevelBase)binSerializer.Deserialize(FS);
            FS.Close();
            return (obj);
        }

    }



   
}
