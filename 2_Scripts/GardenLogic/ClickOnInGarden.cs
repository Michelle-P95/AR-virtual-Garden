using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class ClickOnInGarden : MonoBehaviour
{
    GameObject tippUI;
    GameObject gardenUI;

    GameObject textFeldNature;
    GameObject textFeldWater;
    GameObject textFeldTrash;
    GameObject textFeldAir;

    bool textNatureActive = false;
    bool textWaterActive = false;
    bool textTrashActive = false;
    bool textAirActive = false;


    // Start is called before the first frame update
    void Start()
    {
        tippUI = GameObject.Find("UI_Tipp");
        gardenUI = GameObject.Find("UI_Garden");

        textFeldNature = GameObject.FindGameObjectWithTag("TextBubbleNature");
        textFeldWater = GameObject.FindGameObjectWithTag("TextBubbleWater");
        textFeldAir = GameObject.FindGameObjectWithTag("TextBubbleFog");
        textFeldTrash = GameObject.FindGameObjectWithTag("TextBubbleTrash");


        gardenUI.SetActive(true);
        tippUI.SetActive(false);

        textFeldNature.SetActive(false);
        textFeldWater.SetActive(false);
        textFeldAir.SetActive(false);
        textFeldTrash.SetActive(false);
       

    }

    public void openNatureSprechblase()
    {
        // Ausrufezeichen ODER Haken --> open Textfeld/Sprechblase
        if (textNatureActive)
        {
            textFeldNature.SetActive(false);
            textNatureActive = false;
        }
        else
        {
            textFeldNature.SetActive(true);
            textNatureActive = true;
        }
    }

    public void openWaterSprechblase()
    {
        if (textWaterActive)
        {
            textFeldWater.SetActive(false);
            textWaterActive = false;
        }
        else
        {
            textFeldWater.SetActive(true);
            textWaterActive = true;
        }
    }

    public void openTrashSprechblase()
    {
        if (textTrashActive)
        {
            textFeldTrash.SetActive(false);
            textTrashActive = false;
        }
        else
        {
            textFeldTrash.SetActive(true);
            textTrashActive = true;
        }
    }

    public void openAirSprechblase()
    {
        if (textAirActive)
        {
            textFeldAir.SetActive(false);
            textAirActive = false;
        }
        else
        {
            textFeldAir.SetActive(true);
            textAirActive = true;
        }
    }


    public void openUITipp()
    {
        // gelbes Schild --> open TIPPUI
        tippUI.SetActive(true);
    }

    public void CloseUITipp()
    {
        tippUI.SetActive(false);

        textFeldNature.SetActive(false);
        textFeldWater.SetActive(false);
        textFeldTrash.SetActive(false);
        textFeldAir.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
