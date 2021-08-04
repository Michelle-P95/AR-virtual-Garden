using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    GameObject cam;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("ARCamera");
        target = cam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // dreht komplett zum Screen
        //transform.LookAt(target);
        //transform.LookAt(target, Vector3.left);

        // dreht nur in Y axe zum Screen
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);
    }
}
