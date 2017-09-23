using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseAuSolEnFlaqueDEau : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;

    [HideInInspector]
    public ResteSurTerre ResteSurTerre;

    public Color CouleurFlaque;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
        ResteSurTerre = GetComponent<ResteSurTerre>();
    }

    void Update()
    {
        if (ResteSurTerre.ToucheAuSol())
        {
            var p = transform.position;
            Destroy(gameObject);

            var hit = Planete.RaycastTerrain(p);
            var mesh = (hit.collider as MeshCollider).sharedMesh;
            
            var colors = mesh.colors;
            if (colors == null || colors.Length != mesh.vertexCount)
                colors = new Color[mesh.vertexCount];
            
            var t = hit.triangleIndex;
            colors[t*3 + 0] = CouleurFlaque;
            colors[t*3 + 1] = CouleurFlaque;
            colors[t*3 + 2] = CouleurFlaque;

            mesh.colors = colors;
        }
    }
}
