using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontgolfiereSeDeplace : MonoBehaviour
{
    [HideInInspector]
    public Transform Planete;
    [HideInInspector]
    public float Radius;

    public float HauteurMin = 1;
    public float HauteurMax = 4;
    public float VitesseDeMontee = 2f;
    public float VitesseDeDescente = 1f;

    void Start()
    {
        Planete = GameObject.Find("Planete").transform;
        Radius = Planete.localScale.x / 2;
    }

    void Update()
    {
	    if (Input.GetKey(KeyCode.LeftArrow))
	    {
	        transform.position += Time.deltaTime * -transform.right;
	    }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Time.deltaTime * -transform.forward;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            var up = (transform.position - Planete.position).normalized;
            transform.position += Time.deltaTime * VitesseDeMontee * up;
            transform.rotation = Quaternion.LookRotation(transform.forward - Vector3.Project(transform.forward, up), up);
        }
        else
        {
            var up = (transform.position - Planete.position).normalized;
            transform.position -= Time.deltaTime * VitesseDeDescente * up;
            transform.rotation = Quaternion.LookRotation(transform.forward - Vector3.Project(transform.forward, up), up);
        }

        var hauteur = (transform.position - Planete.position).magnitude - Radius;
        hauteur = Mathf.Clamp(hauteur, HauteurMin, HauteurMax);
        transform.position = GetPointSurTerre(transform.position, hauteur);
    }

    public Vector3 GetPointSurTerre(Vector3 pointDansLEspace, float hauteur)
    {
        var v = pointDansLEspace - Planete.position;
        var up = v.normalized;
        v = up * (Radius + hauteur);
        return Planete.position + v;
    }
}
