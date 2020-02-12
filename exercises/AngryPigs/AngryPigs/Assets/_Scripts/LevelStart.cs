using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public int scene;
    public SpriteRenderer s;
    private void OnMouseEnter()
    {
        s.color = Color.green;
    }
    private void OnMouseExit()
    {
        s.color = Color.white;
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene(scene);
    }
}
