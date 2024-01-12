using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour


{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void InitGameOver()
    {
        gameObject.SetActive(true);
    }
}