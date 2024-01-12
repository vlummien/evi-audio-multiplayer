using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameOver gameOver;

    public void EndGame()
    {
        gameOver.InitGameOver();
    }
}
