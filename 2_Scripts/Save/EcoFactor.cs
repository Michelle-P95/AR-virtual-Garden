using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoFactor : MonoBehaviour
{
    private float carbonInfluence;
    private float deforestationInfluence;
    private float pollutionInfluence;
    private float waterConsumptionInfluence;
    private float carbonInfluenceOld;
    private float deforestationInfluenceOld;
    private float pollutionInfluenceOld;
    private float waterConsumptionInfluenceOld;
    public float CarbonInfluence{
        get { return carbonInfluence; }
        set { carbonInfluence = value;}
    }

    public float DeforestationInfluence{
        get { return deforestationInfluence; }
        set { deforestationInfluence = value;}
    }
    public float PollutionInfluence{
        get { return pollutionInfluence; }
        set { pollutionInfluence = value;}
    }

    public float WaterConsumptionInfluence{
        get { return waterConsumptionInfluence; }
        set { waterConsumptionInfluence = value;}
    }
    public float CarbonInfluenceOld{
        get { return carbonInfluenceOld; }
        set { carbonInfluenceOld = value;}
    }

    public float DeforestationInfluenceOld{
        get { return deforestationInfluenceOld; }
        set { deforestationInfluenceOld = value;}
    }
    public float PollutionInfluenceOld{
        get { return pollutionInfluenceOld; }
        set { pollutionInfluenceOld = value;}
    }

    public float WaterConsumptionInfluenceOld{
        get { return waterConsumptionInfluenceOld; }
        set { waterConsumptionInfluenceOld = value;}
    }
}
