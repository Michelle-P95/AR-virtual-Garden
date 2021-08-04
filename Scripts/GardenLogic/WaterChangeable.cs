using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChangeable : Changeable
{
    public GameObject hakenWater;
    public GameObject ausrufezeichenWater; 
    public GameObject hakenTrash;
    public GameObject ausrufezeichenTrash; 
    private float waterConsumptionValueOld;
    private float pollutionValueOld;
    //ONLY FOR TEST PRUPOSES
    [SerializeField]
    private int testPollution;
    private int testPollutionCache = 0;
    [SerializeField]
    private int testConsumption;
    private int testConsumptionCache = 0;

    [SerializeField]
    private GameObject fishManager;

    [SerializeField]
    private Material waterSurfaceMaterial;
    private GameObject waterSurface;
    private Transform[] trashObjects;
    private Transform trashGroup;

    private Color clean_deep = new Color(0.0331f,0.2264f,0.1684f,0.7019f);
    private Color clean_shallow = new Color(0.0477f,0.3490f,0.2861f,0.2980f);
    private Color dirty_deep = new Color(0.1603f,0.1133f,0.0552f,0.9450f);
    private Color dirty_shallow = new Color(0.3773f,0.1862f,0.0800f,0.8980f);

    private int fishCountPollution;
    private int fishCountConsumption;


    public override void updatePollution(float pollutionValue){
        if(pollutionValue <= 0) {
            float lerpValue = (-1 * pollutionValue) / 100;
            float lerpValueOld = (-1 * pollutionValueOld) / 100;

            //Water Colour
            Color currentColorDeep = Color.Lerp(clean_deep,dirty_deep, lerpValue);
            Color currentColorShallow = Color.Lerp(clean_shallow,dirty_shallow, lerpValue);
            waterSurfaceMaterial.SetColor("Color_242c206647c14ff4a23fbefd57ad9196", currentColorDeep);
            waterSurfaceMaterial.SetColor("Color_2b02c78c47a54409a39ea41bd9170956", currentColorShallow);

            //Trash
            int n = 0;
            int nrTrash = 0;
            int nrTrashOld = 0;

            foreach(Transform trash in trashObjects) {
                if(n <= lerpValue * 10) {
                    trash.gameObject.SetActive(true);
                    nrTrash++;
                } else {
                    trash.gameObject.SetActive(false);
                }
                n += 1;
            }
            //Zählervariable auf 0 zurücksetzten und Müllmenge des letzten Speicherstands bestimmen
            n = 0;
            foreach(Transform trash in trashObjects) {
                if(n <= lerpValueOld * 10) {
                    nrTrashOld++;
                } 
                n += 1;
            }
            if(nrTrashOld > nrTrash){
                if(hakenTrash.activeSelf == false && ausrufezeichenTrash.activeSelf == false){
                    hakenTrash.SetActive(true);
                }               
            }
            else if(nrTrashOld < nrTrash){
                if(hakenTrash.activeSelf == false && ausrufezeichenTrash.activeSelf == false){
                    ausrufezeichenTrash.SetActive(true);
                }
            }


            fishCountPollution = 8 - (int)(lerpValue * 8);

        } else {
            waterSurfaceMaterial.SetColor("Color_242c206647c14ff4a23fbefd57ad9196", clean_deep);
            waterSurfaceMaterial.SetColor("Color_2b02c78c47a54409a39ea41bd9170956", clean_shallow);

            fishCountPollution = 8;
            //Trash
            foreach(Transform trash in trashObjects) {
                trash.gameObject.SetActive(false);
                if(pollutionValueOld < 0){
                    if(hakenTrash.activeSelf == false && ausrufezeichenTrash.activeSelf == false){
                        hakenTrash.SetActive(true);
                    }
                }
            }
        }
    }
    public override void updateWaterConsumption(float waterConsumptionValue){
        Transform waterSurface = gameObject.transform.Find("WaterSurface");
        float waterLevel = waterConsumptionValue / 20000;
        float waterLevelOld = waterConsumptionValueOld / 20000;

        if(waterLevel > 0) {
            waterLevel = 0;
        } else if (waterLevel < -3.7f) {
            waterLevel = -3.7f;
        }

        if(waterLevelOld > 0) {
            waterLevelOld = 0;
        } else if (waterLevelOld < -3.7f) {
            waterLevelOld = -3.7f;
        }

        if(waterLevelOld < waterLevel && Mathf.Abs(waterLevelOld-waterLevel) > 0.5f){
            if(hakenWater.activeSelf == false && ausrufezeichenWater.activeSelf == false){
                hakenWater.SetActive(true);
            }
        }
        else if(waterLevelOld > waterLevel && Mathf.Abs(waterLevelOld-waterLevel) > 0.5f){
            if(hakenWater.activeSelf == false && ausrufezeichenWater.activeSelf == false){
                ausrufezeichenWater.SetActive(true);
            }
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,waterLevel,gameObject.transform.position.z);
        FishBehaviour fishBehaviour = fishManager.GetComponent<FishBehaviour>();
        fishBehaviour.waterLevel = waterLevel;
        fishCountConsumption = 8 + (int)(waterLevel * 4);
        setFishCount();


        //Hacken.SetActive(true);
    }

    public override void updatePollutionOld(float pollutionValue)
    {
        this.pollutionValueOld = pollutionValue;
    }

    public override void updateWaterConsumptionOld(float waterConsumptionValue)
    {
        this.waterConsumptionValueOld = waterConsumptionValue;
    }

    void setFishCount() {
        FishBehaviour fishBehaviour = fishManager.GetComponent<FishBehaviour>();
        if(fishCountPollution<=fishCountConsumption) {
            fishBehaviour.setFishCount(fishCountPollution);
        } else {
            fishBehaviour.setFishCount(fishCountConsumption);
        }
    }

    void Start() {
        testPollution = 0;
        testConsumption = 0;
        waterSurface = gameObject.transform.Find("WaterSurface").gameObject;
        trashGroup = gameObject.transform.Find("Trash");
        trashObjects = trashGroup.GetComponentsInChildren<Transform>();
        foreach(Transform trashObject in trashObjects) {
            trashObject.gameObject.SetActive(false);
        }
    }

    void Update() {
        //FOR TEST PRUPOSES ONLY
        if(testPollution != testPollutionCache) {
            testPollutionCache = testPollution;
            updatePollution(testPollution);
        }

        if(testConsumption != testConsumptionCache) {
            testConsumptionCache = testConsumption;
            updateWaterConsumption(testConsumption);
        }
    }
}
