using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    public score scoreManager;
    const int TIME_TO_RESET = 10;
    Vector3 originalPosition;
    Transform parent;
    public Scene scene;
    public int pigCount = 3;
    public Text numPigs;
    private void Start()
    {
        originalPosition = transform.localPosition;
        parent = transform.parent;
        scene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("ResetPig", TIME_TO_RESET);
        if (collision.gameObject.tag != "Floor")
        {
            scoreManager.PiggyColStructure();
            Debug.Log("Score:"+scoreManager.getScore());
            
        }
    }
    void ResetPig()
    {
        pigCount--;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity =new Vector2(0,0);
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        transform.parent = parent;
        transform.localPosition = originalPosition;
        Camera.main.GetComponent<CameraFollow>().resetCameraPosition();
    }
    private void Update()
    {
        numPigs.text = "Pigs: " + pigCount.ToString();
        if (pigCount <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}
