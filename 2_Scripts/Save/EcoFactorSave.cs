using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class EcoFactorSave{

    
    public static void SaveEcoFactor(GameObject g){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/garden.eco";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        EcoData data = new EcoData(g);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    } 

        public static EcoData LoadEcoFactor(){
        string path = Application.persistentDataPath + "/garden.eco";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            EcoData data = formatter.Deserialize(fileStream) as EcoData;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file was not found in" + path);
            return new EcoData();
        }
    }
}
