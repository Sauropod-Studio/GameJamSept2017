using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontgolfiereRamasse : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;
    public Transform Crochet;
    public GameObject GrosseGoutteDEauPrefab;
    private bool _whantsToPick;
    private float _timeToPick;
    private bool _whantToDrop;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
    }

	void Update()
    {
        if (_whantToDrop)
        {
            Drop();
            _whantToDrop = false;
        }
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            if (Crochet.childCount == 0)
            {
                if (_whantsToPick == false)
                {
                    _whantsToPick = true;
                    _timeToPick = Time.time + 1.4f;
                }
            }
            else
                _whantToDrop = true;
	    }
        if (_whantsToPick && Time.time > _timeToPick)
        {
            Grab();
            _whantsToPick = false;
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
                if (dist < bestDistance && dist < 4f)
                {
                    bestDistance = dist;
                    bestObject = child;
                }
            }
            if (bestObject == null)
                return;
        }

        bestObject.SetParent(Crochet);
        var bounds = bestObject.GetComponent<Collider>().bounds;
        bestObject.localPosition = -Vector3.up * (bounds.max.y - bestObject.transform.position.y);
        if (bestObject.GetComponent<Rigidbody>())
            bestObject.GetComponent<Rigidbody>().isKinematic = true;
        Physics.IgnoreCollision(bestObject.GetComponent<Collider>(),GetComponentInParent<Collider>());
        //bestObject.GetComponent<Collider>().enabled = false;
    }

    bool IsOverWater()
    {
        var d = Planete.transform.position - transform.position;
        RaycastHit hit;
        return Physics.Raycast(new Ray(transform.position, d), out hit, d.magnitude, 1 << GameLayers.Ocean | 1 << GameLayers.Planete) && hit.transform.gameObject.layer == GameLayers.Ocean;
    }

    void Drop()
    {
        foreach (Transform child in Crochet)
        {
            child.SetParent(Planete.Objets);
            if (child.GetComponent<Rigidbody>())
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().velocity = GetComponentInParent<Rigidbody>().velocity;
                //child.GetComponent<Collider>().enabled = true;
                Physics.IgnoreCollision(child.GetComponent<Collider>(), GetComponentInParent<Collider>(),false);
            }
        }
    }
}
