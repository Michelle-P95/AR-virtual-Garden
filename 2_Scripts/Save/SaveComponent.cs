using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveComponent : MonoBehaviour
{
    void Awake(){
        LoadEco();
    }
    public void SaveEco(){
        EcoFactorSave.SaveEcoFactor(gameObject);
    }
    public void LoadEco(){
        EcoData data = EcoFactorSave.LoadEcoFactor();
        EcoFactor ecoFactor = GetComponent<EcoFactor>();
        ecoFactor.CarbonInfluence = data.carbonInfluence;
        ecoFactor.DeforestationInfluence = data.deforestationInfluence;
        ecoFactor.PollutionInfluence = data.pollutionInfluence;
        ecoFactor.WaterConsumptionInfluence = data.waterConsumptionInfluence;
        callChangeable(ecoFactor); 
    }

    private void callChangeable(EcoFactor ecoFactor){
        Changeable[] changeables = FindObjectsOfType<Changeable>();

        foreach(Changeable elem in changeables){
            elem.initiliazeOld(ecoFactor.CarbonInfluenceOld, ecoFactor.DeforestationInfluenceOld, ecoFactor.PollutionInfluenceOld, ecoFactor.WaterConsumptionInfluenceOld);
            elem.initiliaze(ecoFactor.CarbonInfluence, ecoFactor.DeforestationInfluence, ecoFactor.PollutionInfluence, ecoFactor.WaterConsumptionInfluence);
        }
    }
}
