using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject piggie;
    public float power = 100f;
    private Rigidbody2D piggyBody;
    public AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        piggyBody = piggie.GetComponent<Rigidbody2D>();
        piggyBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        //Debug.Log(Input.mousePosition.x + Input.mousePosition.y);
        //Debug.Log(mouseInWorld);
        Vector3 direction = mouseInWorld - transform.position;
        float cosAlpha = Vector3.Dot(Vector3.right, direction.normalized);//cos alpha
        float alpha = Mathf.Acos(cosAlpha);
        transform.rotation = Quaternion.Euler(0, 0, alpha*Mathf.Rad2Deg);
        if (Input.GetMouseButtonDown(0)&&piggie.transform.parent)
        {
            piggie.transform.parent = null;
            piggyBody.AddForce(direction*power);
            piggyBody.gravityScale = 1;
            bang.Play();
            
        }
        
    }
}
