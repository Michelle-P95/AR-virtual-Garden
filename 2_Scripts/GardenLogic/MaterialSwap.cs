using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{

    public GameObject blaetter = null;

    public string[] bedingung = { "gut", "mittel", "schlecht" };
    public bool[] bedingungBool = { true, false, false };
    public Material[] material = { null, null, null };

    Renderer rend;
    public int testzahl = 2;

    // Start is called before the first frame update
    void Start()
    {

        // BEDINDUNGS STUFEN
        for (int x = 0; x < bedingung.Length; x++)
        {
            Debug.Log("Bedinung " + x + " = " + bedingung[x]);
        }

        // BEDINUNG & BOOLEAN KOPPELN
        Dictionary<string, bool> map = new Dictionary<string, bool>();

        for (int x = 0; x < bedingung.Length; x++)
        {
            map.Add(bedingung[x], bedingungBool[x]);
        }

        foreach (var pair in map)
        {
            string key = pair.Key;
            bool value = pair.Value;

            Debug.Log("Map : " + key + " = " + value.ToString());
        }

        //// IST WERT ENTHALTEN ?
        //if (map.TryGetValue("gut", out bool test))
        //{
        //    Debug.Log("erfolgreich");
        //}
        //else
        //{
        //    Debug.Log("fehlgeschlagen");
        //}

        // MATERIALIEN
        for (int x = 0; x < material.Length; x++)
        {
            Debug.Log("Material " + x + " = " + material[x]);
        }

        // MATERIAL AENDERN
        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        // ZUSTAND UND WERTE DAZU AUS DATENBANK SCORE -> Wechselt zu entsprechendem Material
        // GUT = 0 - 2
        if (testzahl <= 2)
        {
            //bedingungBool[0] = true;
            //changeMaterial();
            //bedingungBool[0] = false;
            blaetter.SetActive(true);
            changeMaterialTo(0);

        }
        // MITTEL = 3 - 4
        else if (testzahl > 2 && testzahl <= 4 )
        {
            blaetter.SetActive(true);
            changeMaterialTo(1);
        }
        // SCHLECHT = 5 - 6
        else if (testzahl > 4 && testzahl <= 6)
        {
            blaetter.SetActive(true);
            changeMaterialTo(2);
            bedingungBool[0] = true;
        }
        else if (testzahl > 6)
        {
            blaetter.SetActive(false);
        }
        

        // -- VS --

        // TRUE -> WIRD ZU DEM MATERIAL GEWECHSELT      & Werte/Score wird in extra methode gecheckt
        if (bedingungBool[0] || bedingungBool[1] || bedingungBool[2])
        {
          //  changeMaterial();
        }
        
    }

    
    public void changeMaterialTo(int bedingungAktiv)
    {
        rend.sharedMaterial = material[bedingungAktiv];

        Debug.Log("Material hat sich veraendert zu " + material[bedingungAktiv] + " da der Zustand des Objekt jetzt " + bedingung[bedingungAktiv] + " ist");
    }

    public void changeMaterial()
    {
        if (bedingungBool[0])
        {
            rend.sharedMaterial = material[0];
            bedingungBool[0] = false;
        }
        else if (bedingungBool[1])
        {
            rend.sharedMaterial = material[1];
            bedingungBool[1] = false;
        }
        else if (bedingungBool[2])
        {
            rend.sharedMaterial = material[2];
            bedingungBool[2] = false;
        }
       
    }
}
