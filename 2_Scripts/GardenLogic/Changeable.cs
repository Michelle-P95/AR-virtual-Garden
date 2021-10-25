using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeable : MonoBehaviour, IChangeable
{
    public void initiliaze(float carbonValue, float deforestationValue, float pollutionValue, float waterConsumptionValue ){
        updatecarbon(carbonValue);
        updateDeforestation(deforestationValue);
        updatePollution(pollutionValue);
        updateWaterConsumption(waterConsumptionValue);
    }

    public void initiliazeOld(float carbonValue, float deforestationValue, float pollutionValue, float waterConsumptionValue){
        updatecarbonOld(carbonValue);
        updateDeforestationOld(deforestationValue);
        updatePollutionOld(pollutionValue);
        updateWaterConsumptionOld(waterConsumptionValue);
    }

    public virtual void updatecarbon(float carbonValue){

    }
    public virtual void updateDeforestation(float deforestationValue){

    }
    public virtual void updatePollution(float pollutionValue){

    }
    public virtual void updateWaterConsumption(float waterConsumptionValue){

    }
    
    public virtual void updatecarbonOld(float carbonValue){

    }
    public virtual void updateDeforestationOld(float deforestationValue){

    }
    public virtual void updatePollutionOld(float pollutionValue){

    }
    public virtual void updateWaterConsumptionOld(float waterConsumptionValue){

    }


}
