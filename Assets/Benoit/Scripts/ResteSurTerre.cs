using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ResteSurTerre : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;

    [HideInInspector]
    public Rigidbody Rigidbody;

    [HideInInspector]
    public Collider Collider;

    public float Profondeur = 0.1f;
    public float DistanceAcceptable = 0.1f;
    public float Gravite = 1f;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (transform.parent != Planete.Objets)
        {
            return;
        }

        if (!ToucheAuSol())
        {
            var delta = (transform.position - Planete.transform.position);
            Rigidbody.velocity = Gravite*-delta.normalized;
            return;
        }

        Vector3 up;
        transform.position = Planete.GetPointSurTerre(transform.position, out up, -Profondeur);
        transform.rotation = Quaternion.LookRotation(transform.forward - Vector3.Project(transform.forward, up), up);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }

    public bool ToucheAuSol()
    {
        var d = (transform.position - Planete.transform.position);
        //return Collider.bounds.Contains(Planete.RadiusAt(transform.position));
        var dMax = (Planete.RadiusAt(transform.position) + DistanceAcceptable);
        return d.sqrMagnitude <= dMax*dMax;
    }
}
