using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegarderAvecLesPieds : MonoBehaviour {
    public Vector3 Referent;
    public float hauteurVoulue;
    public LayerMask masque = 1 << 8;
	// Update is called once per frame
	void Update () {
        var orientationLocale = transform.InverseTransformPoint(Referent);
        transform.Rotate(-Clamp(orientationLocale.z), 0, Clamp(orientationLocale.x));

        var rigidbody = GetComponent<Rigidbody>();
        //rigidbody.velocity += -transform.position.normalized * (Vector3.Distance(transform.position, Vector3.zero) - hauteurVoulue) * 0.1f;

        var gravite = (Referent - transform.position).normalized * 0.1f;
        if (Physics.Raycast(transform.position, gravite, hauteurVoulue,masque))
        {
            rigidbody.velocity -= gravite;
        }
        else
        {
            rigidbody.velocity += gravite*2f;
        }
    }
    private float Clamp(float value, float bounds = 1f)
    {
        return Mathf.Clamp(value, -bounds, bounds);
    }
}
