using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float secs;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
