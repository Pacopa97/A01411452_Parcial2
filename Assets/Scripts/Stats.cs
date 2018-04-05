
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int lives;
    public int score;
    public int coinCount;

    private static Stats instance = null;

    void Start()
    {
        lives = 3;
        score = 0;
        coinCount = 3;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}

