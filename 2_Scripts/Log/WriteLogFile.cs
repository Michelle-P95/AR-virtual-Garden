using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Globalization;

public class WriteLogFile : MonoBehaviour
{
    public Dropdown behaviour;
    public Text text;
    public InputField input;
    // Start is called before the first frame update

    public void writeToFile()
    {
        //string path = "Assets/Resources/log.txt";
        string path = Application.persistentDataPath + "/log.txt";
        DateTime date = DateTime.Now;
        String s = behaviour.options[behaviour.value].text;
        String e = text.text;
        String n = input.text;
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(date.ToString(new CultureInfo("de-DE")) + " : " + n + " " + e + " " + s);
        writer.Close();

        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(path);
    }

}
