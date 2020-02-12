using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    const int STRUCTUE_HIT_POINT = 1;
    const int PIGGY_HIT_STRUCTURE_POINT = 5;
    const int BIRD_HIT = 2;
    private int scoreValue=0;
    public Text scoreDisplay;
    // Start is called before the first frame update
 public int getScore()
    {
        return scoreValue;
    }
    public void StructureColStructure()
    {
        scoreValue = scoreValue + STRUCTUE_HIT_POINT;
    }
    public void PiggyColStructure()
    {
        scoreValue = scoreValue + PIGGY_HIT_STRUCTURE_POINT;
    }
    public void BirdHit()
    {
        scoreValue = scoreValue + BIRD_HIT;
    }

    private void Update()
    {
        scoreDisplay.text = "Score:" + scoreValue.ToString();
    }
}
