using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorSelectionGameStart : MonoBehaviour
{
 public int scene=1;
 public void chooseBlack()
    {
        GameState.playerColor = "Black";
        AI.ai_player = "White";
        InputController.playerColor = "Black";
    }
 public void chooseWhite()
    {
        GameState.playerColor = "White";
        AI.ai_player = "Black";
        InputController.playerColor = "White";
    } 
public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }
}
