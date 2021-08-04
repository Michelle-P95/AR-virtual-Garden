using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogChangeable : Changeable
{
    public GameObject haken;
    public GameObject ausrufezeichen;
    private float carbonValueOld;

    public override void updatecarbon(float carbonValue)
    {
        RenderSettings.fog = true;
        fogDensity(carbonValue);
    }

    public override void updatecarbonOld(float carbonValue)
    {
        this.carbonValueOld = carbonValue;
    }

    private void fogDensity(float carbonValue){

        if(carbonValue >= 0){
            RenderSettings.fogDensity = 0.0f;
            if(carbonValueOld < 0){
                haken.SetActive(true);
            }
        }
        else if(carbonValue > -100.0f){
            RenderSettings.fogDensity = 0.005f;
            if(carbonValueOld <= -100.0f){
                haken.SetActive(true);
            }
            else if(carbonValueOld >= 0){
                ausrufezeichen.SetActive(true);
            }
        }
        else if(carbonValue > -200.0f){
            RenderSettings.fogDensity = 0.01f;
            if(carbonValueOld <= -200.0f){
                haken.SetActive(true);
            }
            else if(carbonValueOld >= -100.0f){
                ausrufezeichen.SetActive(true);
            }
        }
        else if(carbonValue > -300.0f){
            RenderSettings.fogDensity = 0.015f;
            if(carbonValueOld <= -300.0f){
                haken.SetActive(true);
            }
            else if(carbonValueOld >= -200.0f){
                ausrufezeichen.SetActive(true);
            }
        }
        else if(carbonValue > -500.0f){
            RenderSettings.fogDensity = 0.02f;
            if(carbonValueOld <= -500.0f){
                haken.SetActive(true);
            }
            else if(carbonValueOld >= -300.0f){
                ausrufezeichen.SetActive(true);
            }
        }
        else if(carbonValue <= -500.0f){
            RenderSettings.fogDensity = 0.025f;
            if(carbonValueOld > -500.0f){
                ausrufezeichen.SetActive(true);
            }
        }
    }
}
