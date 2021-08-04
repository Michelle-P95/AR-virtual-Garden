using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EcoData 
{
    public float carbonInfluence;
    public float deforestationInfluence;
    public float pollutionInfluence;
    public float waterConsumptionInfluence;
    
    public EcoData(){
        carbonInfluence = 0;
        deforestationInfluence = 0;
        pollutionInfluence = 0;
        waterConsumptionInfluence = 0;
    }
    public EcoData(GameObject g){
        EcoFactor ecoFactor = g.GetComponent<EcoFactor>();
        carbonInfluence = ecoFactor.CarbonInfluence;
        deforestationInfluence = ecoFactor.DeforestationInfluence;
        pollutionInfluence = ecoFactor.PollutionInfluence;
        waterConsumptionInfluence = ecoFactor.WaterConsumptionInfluence;
    }

}
