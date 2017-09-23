using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiloteDeMongolefiere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity += transform.forward * 0.5f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity += transform.forward * -0.5f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity += transform.right * -0.5f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity += transform.right * 0.5f;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity += transform.up * -0.5f;
        }
    }
}
