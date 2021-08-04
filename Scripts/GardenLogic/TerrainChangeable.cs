using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChangeable : Changeable
{
    public Texture TerrainNormal;
    public Texture TerrainMediumBrown;
    public Texture TerrainBrown;

    [SerializeField]
    private float carbonValueTest;
    private float carbonValueCache;

    public override void updatecarbon(float carbonValue){
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if(carbonValue>=-300) {
            meshRenderer.material.SetTexture("_BaseMap", TerrainNormal);
        } else if (carbonValue >= -800) {
            meshRenderer.material.SetTexture("_BaseMap", TerrainMediumBrown);
        } else {
            meshRenderer.material.SetTexture("_BaseMap", TerrainBrown);
        }
    }
    public override void updateDeforestation(float deforestationValue){

    }
    public override void updatePollution(float pollutionValue){

    }
    public override void updateWaterConsumption(float waterConsumptionValue){

    }
    // Start is called before the first frame update
    void Start()
    {
        updatecarbon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(carbonValueTest != carbonValueCache) {
            updatecarbon(carbonValueTest);
            carbonValueCache = carbonValueTest;
        }
    }
}
