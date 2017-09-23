using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontgolfiereRamasse : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;
    public Transform Crochet;
    public GameObject GrosseGoutteDEauPrefab;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
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

        if (IsOverWater())
        {
            bestObject = Instantiate(GrosseGoutteDEauPrefab).transform;
        }
        else
        {
            var bestDistance = Mathf.Infinity;
            foreach (Transform child in Planete.Objets)
            {
                if (child == transform) continue;
                var dist = Vector3.Distance(child.position, transform.position);
                if (dist < bestDistance)
                {
                    bestDistance = dist;
                    bestObject = child;
                }
            }
        }

        bestObject.SetParent(Crochet);
        bestObject.localPosition = -Vector3.up * bestObject.GetComponent<Collider>().bounds.size.y / 2;
    }

    bool IsOverWater()
    {
        var d = Planete.transform.position - transform.position;
        return Physics.Raycast(new Ray(transform.position, d), d.magnitude, 1 << LayerMask.NameToLayer("Water"));
    }

    void Drop()
    {
        foreach (Transform child in Crochet)
        {
            child.SetParent(Planete.Objets);
        }
    }
}
