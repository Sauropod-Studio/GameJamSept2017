using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResteSurTerre : MonoBehaviour
{
    [HideInInspector]
    public Transform Planete;
    [HideInInspector]
    public float Radius;

    public float Profondeur = 0.1f;

    void Start()
    {
        Planete = GameObject.Find("Planete").transform;
        Radius = Planete.localScale.x/2;
    }

    void Update()
    {
        if (transform.parent != Planete)
            return;

        Vector3 up;
        transform.position = GetPointSurTerre(transform.position, out up);
        transform.rotation = Quaternion.LookRotation(transform.forward - Vector3.Project(transform.forward, up), up);
    }

    public Vector3 GetPointSurTerre(Vector3 pointDansLEspace)
    {
        Vector3 up;
        return GetPointSurTerre(pointDansLEspace, out up);
    }

    public Vector3 GetPointSurTerre(Vector3 pointDansLEspace, out Vector3 up)
    {
        var v = pointDansLEspace - Planete.position;
        up = v.normalized;
        v = up * (Radius - Profondeur);
        return Planete.position + v;
    }

    public static Vector3 GetPointSurTerre(Transform planete, float radius, Vector3 pointDansLEspace)
    {
        var v = pointDansLEspace - planete.position;
        var up = v.normalized;
        v = up * radius;
        return planete.position + v;
    }
}
