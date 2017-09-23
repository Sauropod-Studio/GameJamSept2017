using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontgolfiereRamasse : MonoBehaviour
{
    [HideInInspector]
    public Transform Planete;
    public Transform Crochet;

    void Start()
    {
        Planete = GameObject.Find("Planete").transform;
    }

	void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        if (Crochet.childCount == 0)
	            Grab();
	        else
	            Drop();
	    }
	}

    void Grab()
    {
        Transform bestObject = null;
        var bestDistance = Mathf.Infinity;
        foreach (Transform child in Planete)
        {
            if (child == transform) continue;
            var dist = Vector3.Distance(child.position, transform.position);
            if (dist < bestDistance)
            {
                bestDistance = dist;
                bestObject = child;
            }
        }
        bestObject.SetParent(Crochet);
        bestObject.localPosition = -Vector3.up * bestObject.GetComponent<Collider>().bounds.size.y / 2;
    }

    void Drop()
    {
        foreach (Transform child in Crochet)
        {
            child.SetParent(Planete);
        }
    }
}
