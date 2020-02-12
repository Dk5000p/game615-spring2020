using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oink_play : MonoBehaviour
{
    public AudioSource oink;
    private void OnMouseEnter()
    {
        oink.Play();
    }
    private void OnMouseExit()
    {
        oink.Stop();
    }
}
