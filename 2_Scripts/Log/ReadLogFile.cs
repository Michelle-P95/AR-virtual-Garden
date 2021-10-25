using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class ReadLogFile: MonoBehaviour
{
    public Text output;

    void Start()
    {
        //string path = "Assets/Resources/log.txt";
        string path = Application.persistentDataPath + "/log.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string logText = reader.ReadToEnd();
        Debug.Log(logText);
        reader.Close();

        string[] lines = logText.Split("\n"[0]);
        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log(lines[i].Length);
            String s = lines[i];
            if(i==(lines.Length-2) && i!=0){
                regeneration(s.Substring(0, 19));
            }
        }
    }

    public void Initiliaze(){
        //string path = "Assets/Resources/log.txt";
        string path = Application.persistentDataPath + "/log.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string logText = reader.ReadToEnd();
        Debug.Log(logText);
        reader.Close();

        string[] lines = logText.Split("\n"[0]);
        for (int i = 0; i < lines.Length; i++)
        {
            output.text += lines[i] + "\n" + "\n";
        }
    }

    private void regeneration(String dateString){
        EcoFactor ecoFactor = GetComponent<EcoFactor>();
        SaveComponent saveComponent = GetComponent<SaveComponent>();
        DateTime oldDate = DateTime.ParseExact(dateString, "G", new CultureInfo("de-DE"));
        DateTime currentDate = DateTime.Now;
        TimeSpan interval = currentDate - oldDate;
        //Falls 30 Tage seit dem letzen Eintrag vergangen sind, regeneriert der Garten auf seinen normalen Zustand zürück
        if(interval.TotalHours > 720){
            ecoFactor.CarbonInfluence = 0;
            ecoFactor.DeforestationInfluence = 0;
            ecoFactor.PollutionInfluence = 0;
            ecoFactor.WaterConsumptionInfluence = 0;
        }
        else{
            
            if(ecoFactor.CarbonInfluence < 0){
                ecoFactor.CarbonInfluence += (float)interval.TotalHours;
            }
            if(ecoFactor.DeforestationInfluence < 0){
                ecoFactor.DeforestationInfluence += (float)interval.TotalHours;
            }
            if(ecoFactor.PollutionInfluence < 0){
                ecoFactor.PollutionInfluence += (float)interval.TotalHours;
            }
            if(ecoFactor.WaterConsumptionInfluence < 0){
                ecoFactor.WaterConsumptionInfluence += (float)interval.TotalHours;
            }
        }
        saveComponent.SaveEco();
    }
}

