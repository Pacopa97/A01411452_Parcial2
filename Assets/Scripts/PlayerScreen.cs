using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScreen : MonoBehaviour {

    public Text score;

    protected Stats stats;

	// Use this for initialization
	void Start () {
        stats = GameObject.Find("Stats").GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = stats.score.ToString();
    }
}
