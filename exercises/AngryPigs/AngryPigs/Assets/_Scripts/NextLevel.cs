using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject[] birds;
    public int scene;
    public score scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        birds = GameObject.FindGameObjectsWithTag("Bird");
        Debug.Log(birds.Length);
        if (birds.Length == 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(scene);

        }
        else
        {
            scoreManager.BirdHit();
        }
    }
}
