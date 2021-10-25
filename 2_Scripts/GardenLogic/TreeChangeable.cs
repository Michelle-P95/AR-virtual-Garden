using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChangeable : Changeable
{
    public int id;
    public GameObject hacken;
    public GameObject ausrufezeichen;  
    private float carbonValueOld;
    private float deforestationValueOld;
    private float carbonValue;

    void Start(){
        Debug.Log("In Start: "+hacken.activeSelf+" "+ausrufezeichen.activeSelf);
    }

    public override void updatecarbon(float carbonValue)
    {
        this.carbonValue = carbonValue;
    }

    public override void updateDeforestation(float deforestationValue)
    {
        float ecoValue = deforestationValue + 0.5f*carbonValue;
        float ecoValueOld = deforestationValueOld + 0.5f*carbonValueOld;
        if(id%2 == 0){
            IDUngerade(ecoValue, ecoValueOld);
        }
        else{
            IDGerade(ecoValue, ecoValueOld);
        }
    }

    public override void updatecarbonOld(float carbonValue)
    {
        this.carbonValueOld = carbonValue;
    }

    public override void updateDeforestationOld(float deforestationValue)
    {
        this.deforestationValueOld = deforestationValue;
    }

    private void IDGerade(float ecoValue, float ecoValueOld){
        if(tag.Equals("Tree")){
            //Ein Array der KindObjekte des TreeObjekts wird erzeugt
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach(Transform child in children){
                if(child.gameObject.tag.Equals("TreePink")){
                    if(ecoValue >= 100.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < 100.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeDefault")){
                    if(ecoValue >= -500.0f && ecoValue < 100.0f){
                        child.gameObject.SetActive(true);
                        Debug.Log("EcoValueOld in Treechangeables: "+ecoValueOld);
    	                if(ecoValueOld < -500.0f){
                            Debug.Log("In Method: "+hacken.activeSelf+" "+ausrufezeichen.activeSelf);
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= 100.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeYellow")){
                    if(ecoValue >= -1000.0f && ecoValue < -500.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -1000.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -500.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeDead")){
                    if(ecoValue >= -1500.0f && ecoValue < -1000.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -1500.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -1000.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeFallen")){
                    if(ecoValue >= -2000.0f && ecoValue < -1500.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -2000.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -1500.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeStump")){
                    if(ecoValue < -2000.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld > -2000.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }                        
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void IDUngerade(float ecoValue, float ecoValueOld){
        if(tag.Equals("Tree")){
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach(Transform child in children){
                if(child.gameObject.tag.Equals("TreePink")){
                    if(ecoValue >= 70.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < 70.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);    
                    }
                }
                else if(child.gameObject.tag.Equals("TreeDefault")){
                    if(ecoValue >= -600.0f && ecoValue < 70.0f){
                        child.gameObject.SetActive(true);
    	                if(ecoValueOld < -600.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= 70.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeYellow")){
                    if(ecoValue >= -1200.0f && ecoValue < -600.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -1200.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -600.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeDead")){
                    if(ecoValue >= -1700.0f && ecoValue < -1200.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -1700.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -1200.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeFallen")){
                    if(ecoValue >= -2300.0f && ecoValue < -1700.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld < -2300.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                hacken.SetActive(true);
                            }
                        }
                        else if(ecoValueOld >= -1700.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
                else if(child.gameObject.tag.Equals("TreeStump")){
                    if(ecoValue < -2300.0f){
                        child.gameObject.SetActive(true);
                        if(ecoValueOld > -2300.0f){
                            if(hacken.activeSelf == false && ausrufezeichen.activeSelf == false){
                                ausrufezeichen.SetActive(true);
                            }
                        }   
                    }
                    else{
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
