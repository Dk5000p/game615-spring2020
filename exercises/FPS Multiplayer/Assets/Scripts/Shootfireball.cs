using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootfireball : MonoBehaviour
{
    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateFireball", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateFireball()
    {
        Instantiate(fireball, transform.position, fireball.transform.rotation);
    }
}
