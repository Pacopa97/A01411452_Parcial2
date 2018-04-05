﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    public GameObject background;



	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x+offset.x, player.position.y+offset.y, offset.z);

        background.transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, 0);
	}
}
