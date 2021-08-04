using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TipText
{
    private string product;
    private string tip;
    private bool positive=false;
    private List<string> sectorList = new List<string>();

    public string Product {
        get { return product; }
        set { product = value; }
    }

    public string Tip
    {
        get { return tip; }
        set { tip = value; }
    }

    public bool Positive
    {
        get { return positive; }
        set { positive = value; }
    }

    public void addSector(string sector) {
        if(sectorList.Contains(sector) == false) {
            sectorList.Add(sector);
        }
    }

    public bool isSector(string sector) {
        return sectorList.Contains(sector);
    }

    public bool compareTips(TipText tipToCompare) {
        return product.Equals(tipToCompare.Product);
    }
}
