using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;



public class ReadCSV : MonoBehaviour
{

    public Dropdown behaviour;
    public Dropdown category;
    public Text text;
    public TextAsset csvData;
    public InputField input;
    List<string> categories = new List<string>();
    List<string> behaviours = new List<string>();
    

public void Initiliaze()
    {
        string[] data = csvData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            if (!categories.Contains(row[3])){
               categories.Add(row[3]);     
            }
                
        }
     
        categories.Sort(); 
        
        foreach (string ca in categories)
        {
            category.options.Add(new Dropdown.OptionData(ca));
        }

        DropdownValueChanged(category);
       
        category.RefreshShownValue();
        behaviour.RefreshShownValue();

        text.text = "Stück";
        category.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(category);
            DdValueChanged(behaviour);
        });
        behaviour.onValueChanged.AddListener(delegate
        {
            DdValueChanged(behaviour);
        });

     

    }

    void DropdownValueChanged(Dropdown change)
    {   
        behaviours.Clear(); 
        behaviour.ClearOptions();

        string[] data = csvData.text.Split(new char[] { '\n' });

        string cat = category.options[change.value].text;
             
        for (int i = 1; i < data.Length; i++)
        {
            string[] row1 = data[i].Split(new char[] { ';' });
            if (row1[3].Equals(cat))
            {   
                behaviours.Add(row1[0]);

            }
        }

        behaviours.Sort(); 
        
        foreach (string beh in behaviours){
        behaviour.options.Add(new Dropdown.OptionData(beh));
        }

        behaviour.RefreshShownValue();

   }

    void DdValueChanged(Dropdown behaviour)
    {
        String s = behaviour.options[behaviour.value].text;
        string[] data = csvData.text.Split(new char[] { '\n' });
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });
            if (row[0].Equals(s))
            {
                text.text = row[2];
                break;
            }
        }
    }

    public void addBehaviour(){

        int inputValue = 0;

        if(int.TryParse(input.text, out inputValue)){
            EcoFactor ecoFactor = GetComponent<EcoFactor>();
            SaveComponent saveComponent = GetComponent<SaveComponent>();
            String s = behaviour.options[behaviour.value].text;
            TipTextManager tipManagerComponent = GetComponent<TipTextManager>();


            string[] data = csvData.text.Split(new char[] { '\n' });

            for (int i = 1; i < data.Length; i++)
            {
                string[] row = data[i].Split(new char[] { ';' });
                if(row[0].Equals(s)){

                    Debug.LogFormat("ReadCSV: carbon: {0} deforestation: {1} pollution: {2} water: {3} ",
                                    ecoFactor.CarbonInfluence, ecoFactor.DeforestationInfluence, ecoFactor.PollutionInfluence, ecoFactor.WaterConsumptionInfluence);

                    float amount = inputValue/float.Parse(row[1]);
                    float carbon;
                    float deforestation;
                    float pollution;
                    float consumption;
                    string strCurCulture = System.Globalization.CultureInfo.CurrentCulture.ToString();
                    if (strCurCulture.Equals("de-DE")) {
                        carbon = float.Parse(row[8]);
                        deforestation = float.Parse(row[9]);
                        pollution = float.Parse(row[10]);
                        consumption = float.Parse(row[11]);
                    } else {
                        carbon = float.Parse(row[8].Replace(",", "."));
                        deforestation = float.Parse(row[9].Replace(",", "."));
                        pollution = float.Parse(row[10].Replace(",", "."));
                        consumption = float.Parse(row[11].Replace(",", "."));
                    }

                   
                        ecoFactor.CarbonInfluence += (amount*carbon);
                        ecoFactor.DeforestationInfluence += (amount*deforestation);
                        ecoFactor.PollutionInfluence += (amount*pollution);
                        ecoFactor.WaterConsumptionInfluence += (amount*consumption);

                    //SET TIPS
                    TipText tip = new TipText();
                    tip.Product = s;
                    tip.Tip = row[12];
                    tip.Positive = int.Parse(row[13]) > 0;
                    if (carbon != 0)
                    {
                        tip.addSector("carbon");
                    }
                    if (deforestation != 0)
                    {
                        tip.addSector("deforestation");
                    }
                    if (pollution != 0)
                    {
                        tip.addSector("pollution");
                    }
                    if (consumption != 0)
                    {
                        tip.addSector("consumption");
                    }

                    tipManagerComponent.addTipText(tip);

                    Debug.LogFormat("ReadCSV: carbon: {0} deforestation: {1} pollution: {2} water: {3} ",
                                    ecoFactor.CarbonInfluence, ecoFactor.DeforestationInfluence, ecoFactor.PollutionInfluence, ecoFactor.WaterConsumptionInfluence);

                    saveComponent.SaveEco();
                    break;
                }
            }
        }
    }
}
