using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSettings : MonoBehaviour
{
    [SerializeField] TextMeshPro TextField;
    string text_air_pos; 
    string text_air_neg; 
    string text_water_pos;
    string text_water_neg;
    string text_trash_pos;
    string text_trash_neg;
    string text_nature_pos;
    string text_nature_neg; 

    

    // Start is called before the first frame update
    void Start()
    {

        text_air_pos = "Der CO2-Gehalt in der Luft ist gesunken.";
        text_air_neg = "Der CO2-Gehalt in der Luft ist gestiegen.";
        text_nature_pos = "Die Bäume und das Gras konnten sich durch deine Einträge erholen.";
        text_nature_neg = "Die Bäume und das Gras haben unter deinem Verhalten gelitten.";
        text_trash_pos = "Dank dir ist weniger Müll in der Umwelt.";
        text_trash_neg = "Durch dein Verhalten ist Müll in der Umwelt gelandet.";
        text_water_pos = "Der Wasserstand deines Sees ist gestiegen.";
        text_water_neg = "Deinem See geht es schlechter.";
    }

    public void setText_air_pos()
    {
        TextField.text = text_air_pos;
    }
    public void setText_air_neg()
    {
        TextField.text = text_air_neg;
    }

    public void setText_nature_pos()
    {
        TextField.text = text_nature_pos;
    }
    public void setText_nature_neg()
    {
        TextField.text = text_nature_neg;
    }
    public void setText_trash_pos()
    {
        TextField.text = text_trash_pos;
    }
    public void setText_trash_neg()
    {
        TextField.text = text_trash_neg;
    }

    public void setText_water_pos()
    {
        TextField.text = text_water_pos;
    }
    public void setText_water_neg()
    {
        TextField.text = text_water_neg;
    }
}