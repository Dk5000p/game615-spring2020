using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScore : MonoBehaviour
{
    public score scoreManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {

            scoreManager.StructureColStructure();
            Debug.Log("Score:" +scoreManager.getScore());
        
    }
}
