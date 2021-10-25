using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagingLoad : MonoBehaviour
{
    private ReadCSV managerCSV;
    private WriteLogFile managerLogWrite;
    private ReadLogFile managerLogRead;
    private TipTextManager managerTipText;
    

    void Start()
    {
        SaveComponent managerSave = FindObjectOfType<SaveComponent>();
        if(managerSave != null){
            managerSave.LoadEco();
            managerCSV = managerSave.gameObject.GetComponent<ReadCSV>(); 
            managerLogWrite = managerSave.gameObject.GetComponent<WriteLogFile>();
            managerLogRead = managerSave.gameObject.GetComponent<ReadLogFile>();
            managerTipText = managerSave.gameObject.GetComponent<TipTextManager>();
            //Ist behaviour im managerCSV null sind auch alle anderen Variablen im ReadCSV, sowie im managerLog null
            if(managerCSV.behaviour == null){
                if(GameObject.FindGameObjectWithTag("Behaviour") != null){
                    managerCSV.behaviour = GameObject.FindGameObjectWithTag("Behaviour").GetComponent<Dropdown>();
                    managerCSV.category = GameObject.FindGameObjectWithTag("Category").GetComponent<Dropdown>();
                    managerCSV.text = GameObject.FindGameObjectWithTag("Einheit").GetComponent<Text>();
                    managerCSV.input = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>();
                    managerLogWrite.behaviour = managerCSV.behaviour;
                    managerLogWrite.text = managerCSV.text;
                    managerLogWrite.input = managerCSV.input;
                    managerCSV.Initiliaze();
                }
            }
            if(managerLogRead.output == null){
                if(GameObject.FindGameObjectWithTag("Log") != null){
                    managerLogRead.output = GameObject.FindGameObjectWithTag("Log").GetComponent<Text>();
                    managerLogRead.Initiliaze();
                }
            }
        }

        
    }

    public void AddBehaviour(){

        managerCSV.addBehaviour();
        managerLogWrite.writeToFile();

    }

    public void setOldEcoValues(){
        EcoFactor ecoFactor = FindObjectOfType<EcoFactor>();
        ecoFactor.CarbonInfluenceOld = ecoFactor.CarbonInfluence;
        ecoFactor.DeforestationInfluenceOld = ecoFactor.DeforestationInfluence;
        ecoFactor.WaterConsumptionInfluenceOld = ecoFactor.WaterConsumptionInfluence;
        ecoFactor.PollutionInfluenceOld = ecoFactor.PollutionInfluence;
        Debug.Log("Carbon Old: "+ecoFactor.CarbonInfluenceOld);
        Debug.Log("Deforestation Old: "+ecoFactor.DeforestationInfluenceOld);
    }

    public void ShowTip(string sectors) {
        Text tipTextFieldGood = GameObject.FindGameObjectWithTag("TipTextGood").GetComponent<Text>();
        Text tipTextFieldBad = GameObject.FindGameObjectWithTag("TipTextBad").GetComponent<Text>();
        tipTextFieldGood.text = "";
        tipTextFieldBad.text = "";
        string[] sectorList = sectors.Split(';');
        List<string> addedTips = new List<string>();
        
        foreach(string sector in sectorList) {
            List<TipText> tipTexts = managerTipText.getTipsOfSector(sector);
            foreach(TipText tip in tipTexts) {
                if(addedTips.Contains(tip.Product) == false) {
                    if(tip.Positive) {
                        tipTextFieldGood.text += tip.Product + "\n" + "\n";
                        tipTextFieldGood.text += tip.Tip +"\n" + "\n"+ "\n";
                    } else {
                        tipTextFieldBad.text += tip.Product + "\n" + "\n";
                        tipTextFieldBad.text += tip.Tip + "\n" + "\n" + "\n";
                    }
                    addedTips.Add(tip.Product);
                }
            } 
        }
    }
}
