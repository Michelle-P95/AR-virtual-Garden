using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFloatingBehaviour : MonoBehaviour
{
    private Vector3 originalPos;
    private float randomOffset;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.localPosition;
        randomOffset = Random.value;
        Vector3 bounds = GetComponent<Collider>().bounds.size;
        volume = bounds.x * bounds.y * bounds.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = originalPos + new Vector3(0,(0.05f + Mathf.Min((volume*0.05f),0.15f)) * Mathf.Sin(randomOffset + Time.realtimeSinceStartup * Mathf.Max((5.0f - (volume/2)),2.5f)),0);
    }
}
