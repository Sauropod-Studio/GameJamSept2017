using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiloteDeMongolefiere : MonoBehaviour {
    public float acceleration;
    public GameObject PivotDeCamera;
    private RegarderAvecLesPieds _pieds;

    private void Start()
    {
        _pieds = GetComponent<RegarderAvecLesPieds>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity += transform.forward * acceleration;
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity += transform.forward * -acceleration;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity += transform.right * -acceleration;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity += transform.right * acceleration;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity += transform.up * -acceleration;
        }

        RaycastHit hit;
        var gravite = (_pieds.Referent - transform.position).normalized;
        if (Physics.Raycast(transform.position, gravite, out hit, _pieds.hauteurVoulue))
        {
            PivotDeCamera.transform.position = transform.position + gravite * hit.distance;
        }
    }
}
