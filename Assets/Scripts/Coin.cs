using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    protected Stats stats;
    public int scoreEarned;

    private int hit=1;

    void Start()
    {
        stats = GameObject.Find("Stats").GetComponent<Stats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            if (hit == 1)
             {
                hit--;
                stats.score = stats.score + scoreEarned;
                GameObject.Find("Stats").GetComponent<Stats>().coinCount--;
                if (GameObject.Find("Stats").GetComponent<Stats>().coinCount == 0)
                {
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadNextLevel();
                }
                Destroy(gameObject);

            }
        }
    }
}
