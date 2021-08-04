using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInfoText : MonoBehaviour
{
    string btnName;
    public GameObject text;
    bool textVisible;
    

    // Start is called before the first frame update
    void Start()
    {
        textVisible = false;
        text.SetActive(false);

    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                switch (btnName)
                {
                    case "buttonTipp_water":
                        // load UI Tipps zum See
                        if (!textVisible)
                        {
                            text.SetActive(true);
                            textVisible = true;
                        }
                        else
                        {
                            text.SetActive(false);
                            textVisible = false;
                        }
                        break;
                    case "buttonTipp_trees":
                        // load UI Tipps zum Baum
                        break;
                    case "buttonTipp_air":
                        // load UI Tipps zum Luft
                        break;
                }
            }
        }

    }
}
