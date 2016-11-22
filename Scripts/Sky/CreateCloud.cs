using UnityEngine;
using System.Collections;

public class CreateCloud : MonoBehaviour {
    MeshFilter mf;
    Mesh mesh;
    Vector3[] vertices;
	// Use this for initialization
	void Start () {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(17f, 17F, 50);
        sphere.transform.localScale = new Vector3(5, 5, 5);
        mf = sphere.GetComponent<MeshFilter>();
        mesh = mf.mesh;
        vertices = mesh.vertices;
        for (int i = 0; i < 20; i++)
        {
            int pos = Random.Range(0, vertices.Length - 1);
            Vector3 vertex = vertices[pos];
            vertex.y = Random.Range(0, 2f);
            vertices[pos] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
