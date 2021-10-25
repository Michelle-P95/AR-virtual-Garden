using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValues : MonoBehaviour
{
    // Start is called before the first frame update
    public void reset(){
        EcoFactor ecoFactor = FindObjectOfType<EcoFactor>();
        ecoFactor.CarbonInfluence = 0;
        ecoFactor.DeforestationInfluence = 0;
        ecoFactor.WaterConsumptionInfluence = 0;
        ecoFactor.PollutionInfluence = 0;
        ecoFactor.gameObject.GetComponent<SaveComponent>().SaveEco();
    }
}
