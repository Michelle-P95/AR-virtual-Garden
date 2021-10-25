using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInitialization : MonoBehaviour
{
    public GameObject manager;
    void Awake()
    {
        DontDestroyOnLoad(manager);
        manager.GetComponent<SaveComponent>().LoadEco();
        EcoFactor ecoFactor = manager.GetComponent<EcoFactor>();
        ecoFactor.CarbonInfluenceOld = ecoFactor.CarbonInfluence;
        ecoFactor.DeforestationInfluenceOld = ecoFactor.DeforestationInfluence;
        ecoFactor.WaterConsumptionInfluenceOld = ecoFactor.WaterConsumptionInfluence;
        ecoFactor.PollutionInfluenceOld = ecoFactor.PollutionInfluence;
        Debug.Log("Carbon Old: "+ecoFactor.CarbonInfluenceOld);
        Debug.Log("Deforestation Old: "+ecoFactor.DeforestationInfluenceOld);
        GetComponent<backToMain>().home();
    }
}
