using UnityEngine;
using System.Collections;

public class Height : MonoBehaviour {
    public float[] heights;
    
	// Use this for initialization
	void Start () {
        updateMesh();
        
	}
	
	// Update is called once per frame
	void Update () {
        updateMesh();
	}

    float Noise(int x, int y, int seed)
    {
        //Random.seed = seed;
        //float val = Mathf.Clamp(Random.value, 0, 100);
        return Mathf.PerlinNoise (x*0.2f, y*0.2f);
    }
    void updateMesh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;
        heights = new float[verts.Length];
        for (int i = 0; i < verts.Length; i++)
        {
            for (int j = 0; j < verts.Length; j++)
            {
                heights[i] = Noise(i, j, i) * 3;
            }
        }

        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].y = heights[i];
        }
        mesh.vertices = verts;
        mesh.RecalculateNormals();
    }
}
