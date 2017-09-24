using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploseAuSolEnFlaqueDEau : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;

    [HideInInspector]
    public ResteSurTerre ResteSurTerre;

    public float ToleranceCouleur = 0.1f;

    [HideInInspector]
    public Color CouleurHerbe;
    public GameObject PrefabArbre;

    [HideInInspector]
    public Color CouleurDesert;

    public int SpreadCount = 10;

    [HideInInspector]
    public GenerateTerrainTypes GenerateTerrainTypes;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
        ResteSurTerre = GetComponent<ResteSurTerre>();
        GenerateTerrainTypes = FindObjectOfType<GenerateTerrainTypes>();

        CouleurDesert = GenerateTerrainTypes.TerrainVariationColors[0].Color;
        CouleurHerbe = GenerateTerrainTypes.TerrainVariationColors[1].Color;
    }

    void Update()
    {
        if (ResteSurTerre.ToucheAuSol())
        {
            var p = transform.position;
            Destroy(gameObject);

            var hit = Planete.RaycastTerrain(p);
            var mesh = (hit.collider.GetComponent<MeshFilter>()).sharedMesh;
            
            var colors = mesh.colors;
            /*if (colors == null || colors.Length != mesh.vertexCount)
            {
                var normals = mesh.normals;
                var tangents = mesh.tangents;
                var uv = mesh.uv;

                mesh = new Mesh()
                {
                    vertices = mesh.vertices,
                    triangles = mesh.triangles
                };

                if (normals != null && normals.Length == mesh.vertexCount) mesh.normals = normals;
                if (tangents != null && tangents.Length == mesh.vertexCount) mesh.tangents = tangents;
                if (uv != null && uv.Length == mesh.vertexCount) mesh.uv = uv;

                colors = new Color[mesh.vertexCount];
                for (var i = 0; i < colors.Length; i++)
                    colors[i] = new Color(1f, 0.5f, 0.5f);
            }*/
            var triangles = mesh.triangles;

            var t = hit.triangleIndex;
            if (IsHerbe(colors[triangles[t*3 + 0]]))
            {
                Instantiate(PrefabArbre, hit.point,
                    Quaternion.FromToRotation(Vector3.up, (hit.point - Planete.transform.position).normalized), Planete.Objets);
            }
            else if (IsDesert(colors[triangles[t * 3 + 0]]))
            {
                SpreadFlaque(triangles, t, mesh.vertices, colors);
            }

            mesh.colors = colors;
            (hit.collider.GetComponent<MeshFilter>()).sharedMesh = mesh;
        }
    }

    bool IsHerbe(Color c)
    {
        return Mathf.Abs(CouleurHerbe.r - c.r) + Mathf.Abs(CouleurHerbe.g - c.g) + Mathf.Abs(CouleurHerbe.b - c.b) <= ToleranceCouleur;
    }

    bool IsDesert(Color c)
    {
        return Mathf.Abs(CouleurDesert.r - c.r) + Mathf.Abs(CouleurDesert.g - c.g) + Mathf.Abs(CouleurDesert.b - c.b) <= ToleranceCouleur;
    }

    void SpreadFlaque(int[] triangles, int t0, Vector3[] vertices, Color[] colors)
    {
        GenerateTerrainTypes = FindObjectOfType<GenerateTerrainTypes>();
        
        // Watch out for threading
        if (GenerateTerrainTypes.VertexToSimilarVertices == null || GenerateTerrainTypes.VertexToTriangleIndex == null)
            return;

        var colored = new HashSet<int>();
        var newColored = new HashSet<int>();
        SetFlaque(triangles, t0, colors, colored);

        var spread = SpreadCount-1;
        while (spread > 0)
        {
            bool worked = false;
            foreach (var t in colored)
            {
                foreach (var t2 in GenerateTerrainTypes.VertexToSimilarVertices[t])
                {
                    if (IsDesert(colors[t2]))
                    {
                        newColored.Add(t2);
                    }
                    else
                    {
                        SetFlaque(triangles, GenerateTerrainTypes.VertexToTriangleIndex[t2] / 3 * 3, colors, newColored);
                        worked = true;
                        if (--spread <= 0)
                            break;
                    }
                }
            }
            if (!worked)
                break;
            foreach (var t in newColored)
                colored.Add(t);
        }
    }

    void SetFlaque(int[] triangles, int ti, Color[] colors, HashSet<int> colored)
    {
        colors[triangles[ti * 3 + 0]] = CouleurHerbe;
        colors[triangles[ti * 3 + 1]] = CouleurHerbe;
        colors[triangles[ti * 3 + 2]] = CouleurHerbe;
        colored.Add(triangles[ti * 3 + 0]);
        colored.Add(triangles[ti * 3 + 1]);
        colored.Add(triangles[ti * 3 + 2]);
    }
}
