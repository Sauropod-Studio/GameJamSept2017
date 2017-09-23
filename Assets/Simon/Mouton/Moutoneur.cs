﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moutoneur : MonoBehaviour {
    public Transform anchor;
    public float distance;

	void Update () {
		foreach(Transform child in transform)
        {
            child.position = anchor.position + (child.position - anchor.position).normalized * distance;
        }
	}

}
