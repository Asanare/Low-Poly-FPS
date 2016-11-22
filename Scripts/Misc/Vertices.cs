using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Vertices : MonoBehaviour {
    public Vector3 [] verts;
    public int[] triangles;
    Mesh mesh;
	// Use this for initialization
	void Start () {
        mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
        verts = mesh.vertices;
        triangles = mesh.triangles;
	}
	
	// Update is called once per frame
	void Update () {
        mesh.vertices = verts;
        mesh.triangles = triangles;
	}
}
