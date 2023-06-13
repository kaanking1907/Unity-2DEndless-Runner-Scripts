using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObejct platformDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObejct.Find ("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
           Destroy (gameObejct); 
        }
    }
}
