using UnityEngine;

public class Planete : MonoBehaviour
{
    public Transform Boule;
    public Transform Objets;

    public Vector3 GetPointSurTerre(Vector3 pointDansLEspace, float hauteur = 0)
    {
        Vector3 up;
        return GetPointSurTerre(pointDansLEspace, out up, hauteur);
    }

    public Vector3 GetPointSurTerre(Vector3 pointDansLEspace, out Vector3 up, float hauteur = 0)
    {
        var centre = transform.position;
        var v = pointDansLEspace - centre;
        up = v.normalized;
        v = up * (RadiusAt(pointDansLEspace) + hauteur);
        return centre + v;
    }

    public float RadiusAt(Vector3 p)
    {
        RaycastHit hit;
        var d = p - transform.position;
        var dFar = d*100;
        var pFar = transform.position + dFar;
        if (Physics.Raycast(new Ray(pFar, -dFar), out hit, dFar.magnitude, 1 << GameLayers.Planete))
            return dFar.magnitude - hit.distance;
        return 0;
    }

    public RaycastHit RaycastTerrain(Vector3 p)
    {
        RaycastHit hit;
        var d = p - transform.position;
        var dFar = d * 100;
        var pFar = transform.position + dFar;
        Physics.Raycast(new Ray(pFar, -dFar), out hit, dFar.magnitude, 1 << GameLayers.Planete);
        return hit;
    }
}
