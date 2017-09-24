using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;

public class GenerateTerrainTypes : MonoBehaviour
{
    public MeshFilter TargetMesh;
    public float NoiseFrequency1 = 1;

    [Serializable]
    public class TerrainVariation
    {
        public string Name;
        public Color Color;
        public float Chance = 1f;
    }
    public TerrainVariation[] TerrainVariationColors;

    private Mesh _mesh;

    [HideInInspector]
    public List<int>[] VertexToSimilarVertices;
    [HideInInspector]
    public int[] VertexToTriangleIndex;

    public bool ForceRegenerate;

    void BuildMeshLookupData(Vector3[] vertices, int[] triangles)
    {
        var t2ts = new List<int>[vertices.Length];
        for (var i = 0; i < vertices.Length; i++)
        {
            t2ts[i] = new List<int>();
            for (var j = 0; j < vertices.Length; j++)
                if ((vertices[i] - vertices[j]).sqrMagnitude < 1E-8)
                    t2ts[i].Add(j);
        }
        var v2t = new int[vertices.Length];
        for (var i = 0; i < triangles.Length; i += 3)
            v2t[triangles[i]] = i / 3;

        VertexToSimilarVertices = t2ts;
        VertexToTriangleIndex = v2t;
    }

    void Awake()
    {
        var mesh = TargetMesh.sharedMesh;
        var normals = mesh.normals;
        var tangents = mesh.tangents;
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
        var uv = mesh.uv;
        var radius = mesh.bounds.size.x / 2;

        _mesh = new Mesh()
        {
            vertices = vertices,
            triangles = triangles
        };

        if (normals != null && normals.Length == mesh.vertexCount) _mesh.normals = normals;
        if (tangents != null && tangents.Length == mesh.vertexCount) _mesh.tangents = tangents;
        if (uv != null && uv.Length == mesh.vertexCount) _mesh.uv = uv;

        var colors = new Color[mesh.vertexCount];

        if (ForceRegenerate || !File.Exists("TerrainColors.dat"))
        {
            GenerateColors(vertices, colors, radius);
            var bytes = new byte[colors.Length*3];
            for (var i = 0; i < colors.Length; i++)
            {
                var c = (Color32) colors[i];
                bytes[i*3 + 0] = c.r;
                bytes[i*3 + 1] = c.g;
                bytes[i*3 + 2] = c.b;
            }
            File.WriteAllBytes("TerrainColors.dat", bytes);
        }
        else
        {
            var bytes = File.ReadAllBytes("TerrainColors.dat");
            for (var i = 0; i < colors.Length; i++)
            {
                var c = new Color32(255, 255, 255, 255);
                c.r = bytes[i * 3 + 0];
                c.g = bytes[i * 3 + 1];
                c.b = bytes[i * 3 + 2];
                colors[i] = c;
            }
        }

        _mesh.colors = colors;
        TargetMesh.sharedMesh = _mesh;

        new Thread(() => BuildMeshLookupData(vertices, triangles)).Start();
    }

    void GenerateColors(Vector3[] vertices, Color[] colors, float radius)
    {
        var chanceTotale = TerrainVariationColors.Sum(v => v.Chance);
        for (var i = 0; i < colors.Length; i++)
        {
            var v = vertices[i];
            var noise = Noise(v / radius);
            var chance = noise * chanceTotale;
            for (var j = 0; j < TerrainVariationColors.Length; j++)
                if (chance <= TerrainVariationColors[j].Chance || j == TerrainVariationColors.Length - 1)
                {
                    colors[i] = TerrainVariationColors[j].Color;
                    break;
                }
                else
                {
                    chance -= TerrainVariationColors[j].Chance;
                }
            //colors[i] = TerrainVariationColors[Mathf.Clamp(Mathf.FloorToInt(noise * TerrainVariationColors.Length), 0, TerrainVariationColors.Length - 1)].Color;
        }
    }

    float Noise(Vector3 p)
    {
        var pTheta = Mathf.Atan2(p.z, p.x) / (Mathf.PI * 2);
        var pPhi = Mathf.Asin(p.y) / Mathf.PI + 0.5f;

        const float noiseStartX = 0.37f;
        const float noiseStartY = 0.28f;
        var noise1 = Mathf.PerlinNoise(noiseStartX + pTheta * NoiseFrequency1, noiseStartY + pPhi * NoiseFrequency1);
        var noise1EdgeX = Mathf.PerlinNoise(noiseStartX, noiseStartY + pPhi * NoiseFrequency1);
        var noise1EdgeY = Mathf.PerlinNoise(noiseStartX + pTheta * NoiseFrequency1, noiseStartY);
        var noise1EdgeXY = Mathf.PerlinNoise(noiseStartX, noiseStartY);

        var noiseX = Mathf.Lerp(noise1, noise1EdgeX, pTheta*pTheta);
        var noiseY = Mathf.Lerp(noiseX, noise1EdgeY, pPhi*pPhi);
        return Mathf.Lerp(noiseY, noise1EdgeXY, pTheta*pPhi);
    }

    void OnDestroy()
    {
        Destroy(_mesh);
        _mesh = null;
    }
}
