using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scored : MonoBehaviour {

    public Text scored;

	// Use this for initialization
	void Start () {

        scored.text = GameObject.Find("Stats").GetComponent<Stats>().score.ToString();
        GameObject.Find("Stats").GetComponent<Stats>().score=0;
    }
	
	}
