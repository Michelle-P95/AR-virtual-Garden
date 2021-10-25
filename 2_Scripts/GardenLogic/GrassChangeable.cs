using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassChangeable : Changeable
{
    public int id;
    public Material[] materials;

    private float carbonValue;


    public override void updatecarbon(float carbonValue)
    {
        this.carbonValue = carbonValue;
    }

    public override void updateDeforestation(float deforestationValue)
    {
        if(materials != null && materials.Length==3){
            float ecoValue = 0.8f*deforestationValue + 0.6f*carbonValue;
            if(id%2 == 0){
                IDUngerade(ecoValue);
            }
            else{
                IDGerade(ecoValue);
            }
        }
    }

    public override void updatePollution(float pollutionValue)
    {
        base.updatePollution(pollutionValue);
    }
    public override void updateWaterConsumption(float waterConsumptionValue)
    {
        base.updateWaterConsumption(waterConsumptionValue);
    }

    private void IDGerade(float ecoValue){
        if(tag.Equals("GrassObject")){
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach(Transform child in children){
                if(child.gameObject.tag.Equals("Grass")){
                    if(ecoValue > -500.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[0];
                    }
                    else if(ecoValue > -1000.0f && ecoValue < -500.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[1];
                    }
                    else if(ecoValue > -2000.0f && ecoValue < -1000.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[2];
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("Shroom")){
                    if(ecoValue > 50){
                        child.gameObject.SetActive(true);
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("Flower")){
                    if(ecoValue > 90){
                        child.gameObject.SetActive(true);
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void IDUngerade(float ecoValue){
        if(tag.Equals("GrassObject")){
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach(Transform child in children){
                if(child.gameObject.tag.Equals("Grass")){
                    if(ecoValue > -750.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[0];
                    }
                    else if(ecoValue > -1250.0f && ecoValue < -750.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[1];
                    }
                    else if(ecoValue > -2500.0f && ecoValue < -1250.0f){
                        child.gameObject.SetActive(true);
                        child.gameObject.GetComponent<Renderer>().sharedMaterial = materials[2];
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("Shroom")){
                    if(ecoValue > 75){
                        child.gameObject.SetActive(true);
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("Flower")){
                    if(ecoValue > 100){
                        child.gameObject.SetActive(true);
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
