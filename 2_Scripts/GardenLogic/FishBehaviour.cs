using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField]
    private int fishCount = 8;

    [SerializeField]
    private float boundingSphereLenghtX = 12.9f;
    [SerializeField]
    private float boundingSphereHeightY = 3.16f;
    [SerializeField]
    private float boundingSphereWidthZ = 10.96f;
    [SerializeField]
    private Vector3 centerBoundingSphere = new Vector3(-7.34f,-1.595f,-10.8f);
    [SerializeField]
    public float waterLevel = 0.0f;


    public GameObject fish1;

    private GameObject[] fishList;
    private Vector3[] startPoint;
    private Vector3[] endPoint;
    private float[] swimProgress;


    private Vector3 randomPointInBoundingSphere() {
        Vector3 randPoint = Random.insideUnitSphere;

        float x = randPoint.x * (boundingSphereLenghtX/2) + centerBoundingSphere.x;
        float y = -1 * Mathf.Abs(randPoint.y) * ((boundingSphereHeightY/2) + waterLevel - 0.2f) + (centerBoundingSphere.y + waterLevel - 0.2f);
        float z = randPoint.z * (boundingSphereWidthZ/2) + centerBoundingSphere.z;

        Vector3 position = new Vector3(x,y,z);
        return position;
    }

    // Start is called before the first frame update
    void Start()
    {
        fishList = new GameObject[fishCount];
        startPoint = new Vector3[fishCount];
        endPoint = new Vector3[fishCount];
        swimProgress = new float[fishCount];
        gameObject.SetActive(false);
    }

    private void initializeFishes() {
        fishList = new GameObject[fishCount];
        startPoint = new Vector3[fishCount];
        endPoint = new Vector3[fishCount];
        swimProgress = new float[fishCount];

        for(int i=0;i<fishCount;i++) {
            Vector3 start = randomPointInBoundingSphere();
            fishList[i] = Instantiate(fish1, start, new Quaternion(0, 1 , 0, 0), gameObject.transform);
            float randomSizeFactor = Random.Range(-1.0f,1.0f);
            fishList[i].transform.localScale = new Vector3(fishList[i].transform.localScale.x + randomSizeFactor,
                                                        fishList[i].transform.localScale.y + randomSizeFactor,
                                                        fishList[i].transform.localScale.z + randomSizeFactor);
            startPoint[i] = start;
            endPoint[i] = randomPointInBoundingSphere();
            swimProgress[i] = 0.0f;
        }
    }

    public void setFishCount(int count) {
        for(int i=0; i<fishCount; i++) {
            Destroy(fishList[i]);
        }
        if(count<=0) {
            fishCount = 0;
        } else {
            fishCount = count;
        }
        initializeFishes();
    }

    public void setFishesVisible() {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


        for(int i=0;i<fishCount;i++) {
            GameObject fish = fishList[i];
            if(swimProgress[i] <= 1.0f) {
                fish.transform.localPosition = Vector3.Lerp(startPoint[i], endPoint[i], swimProgress[i]);
                Quaternion lookRotation = Quaternion.LookRotation(endPoint[i] - fish.transform.localPosition, Vector3.up);
                fish.transform.localRotation = Quaternion.Slerp(fish.transform.localRotation, lookRotation, Time.deltaTime);
                swimProgress[i] += 0.6f * (1/Vector3.Distance(startPoint[i], endPoint[i])) * Time.deltaTime;
            } else {
                startPoint[i] = fish.transform.localPosition;
                endPoint[i] = randomPointInBoundingSphere();
                swimProgress[i] = 0.0f;
            }
        }
    }
}
