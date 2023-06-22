using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    
    private float platformWidth;


    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    //public ObjectPooler theObjectPool;

    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[thePlatforms.Length];

        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
        }

    }

    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, thePlatforms.Length);

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);

            

            Instantiate (/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
            /*GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive (true);*/
            
        }
    }
}
