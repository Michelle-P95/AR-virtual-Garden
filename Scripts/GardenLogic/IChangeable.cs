using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeable 
{
    public void initiliaze(float carbonValue, float deforestationValue, float pollutionValue, float waterConsumptionValue );

    public void updatecarbon(float carbonValue);
    public void updateDeforestation(float deforestationValue);
    public void updatePollution(float pollutionValue);
    public void updateWaterConsumption(float waterConsumptionValue);
}
