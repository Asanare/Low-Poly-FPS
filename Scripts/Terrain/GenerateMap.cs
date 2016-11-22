using UnityEngine;
using System.Collections;
[RequireComponent (typeof(MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]

public  class GenerateMap : MonoBehaviour
{
    public Material mat;
    public int width;
    public int height;
    public Vector3[] vertices;
    void Awake()
    {
        Mesh mesh = GeneratePlane(height, width).CreateMesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<Renderer>().sharedMaterial = mat;
        
        Vector3[] verts = mesh.vertices;
        float[] heights = new float[verts.Length];
        for (int i = 0; i < verts.Length; i++)
        {
            for (int j = 0; j < verts.Length; j++)
            {
                heights[i] = Mathf.PerlinNoise(i*0.2f,j*0.2f)*10;
            }
        }
        for (int i = 0; i < verts.Length; i++)
        {
            if (heights[i] < 0.3f)
            {
                verts[i].y = 0.1f;
            }
            else
            {
                verts[i].y = 0.5f*heights[i];
            }
            
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
        vertices = verts;
        gameObject.AddComponent<MeshCollider>();
    }
    public static MeshData GeneratePlane(int height, int width)
    {
        MeshData meshData = new MeshData(width, height);
        int vertexIndex = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {

                meshData.vertices[vertexIndex] = new Vector3(x,0,y);
                meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);

                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                    meshData.AddTriangle(vertexIndex + width + 1, vertexIndex, vertexIndex + 1);
                }

                vertexIndex++;
            }
        }

        return meshData;

    }

}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    int triangleIndex;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }

}
