using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouleHeight : MonoBehaviour
{
    public MeshFilter MeshFilter;
    public float NoiseFrequency = 1f;
    public bool generate;
    public bool autoGenerate;

    void Update()
    {
        if (generate || autoGenerate)
        {
            generate = false;
            Generate();
        }
    }

    void Generate()
    {
        var mesh = MeshFilter.mesh;
        if (mesh == null) mesh = new Mesh();
        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        const int N = 20;
        for (var j = 0; j <= N / 2; j++)
            for (var i = 0; i <= N; i++)
            {
                var b = (i/(float) N) * Mathf.PI*2;
                var a = Mathf.Lerp(-Mathf.PI/2, Mathf.PI/2, (j/(float) (N/2)));
                var v = new Vector3(Mathf.Cos(a)*Mathf.Cos(b), Mathf.Sin(a), Mathf.Cos(a)*Mathf.Sin(b));
                var rnd = Mathf.PerlinNoise((i % N / (float)N) * NoiseFrequency, (j % (N / 2) / (float)(N / 2)) * NoiseFrequency);
                v *= Mathf.Lerp(0.9f, 1.1f, rnd);
                var vi = vertices.Count;
                vertices.Add(v);
                if (i < N && j < N/2)
                    triangles.AddRange(new[] { vi, vi+1, vi+N+1, vi, vi+N+1,vi+1, vi+1, vi+N+1, vi+N+2, vi+1, vi+N+2, vi+N+1 });
            }
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        MeshFilter.mesh = mesh;
    }
}
