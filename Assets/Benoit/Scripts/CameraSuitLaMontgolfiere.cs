using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSuitLaMontgolfiere : MonoBehaviour
{
    [HideInInspector]
    public Transform Planete;

    [HideInInspector]
    public Transform Montgolfiere;

    [HideInInspector]
    public Camera Camera;

    void Start()
    {
        Planete = GameObject.Find("Planete").transform;
        Montgolfiere = GameObject.Find("Montgolfiere").transform;
        Camera = GetComponent<Camera>();
    }

	void Update()
	{
	    transform.rotation = Quaternion.LookRotation(Montgolfiere.position - transform.position, Montgolfiere.up);
	}
}
