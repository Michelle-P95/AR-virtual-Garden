using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TipTextManager : MonoBehaviour
{

    private List<TipText> tipTextList = new List<TipText>();

    public void addTipText(TipText text) {
        bool isInList = false;
        foreach(TipText tip in tipTextList) {
            if(String.Equals(text.Product,tip.Product)) {
                isInList = true;
            }
        }
        if (isInList == false)
        {
            tipTextList.Add(text);
        }
    }

    public List<TipText> getTipsOfSector(string sector) {
        List<TipText> currentSectorTips = new List<TipText>();
        foreach(TipText text in tipTextList) {
            if(text.isSector(sector)) {
                currentSectorTips.Add(text);
            }
        }

        return currentSectorTips;
    }
}
