using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oiseau : MonoBehaviour {
    public float acceleration;
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity += transform.forward * acceleration;
        if(Random.value < 0.01)
        {
            GetComponent<Rigidbody>().angularVelocity += transform.up * (Random.value - 0.5f) * 2f;
        }
    }
}
