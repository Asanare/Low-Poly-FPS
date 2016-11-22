using UnityEngine;
using System.Collections;
public class Low_Poly_Water1 : MonoBehaviour {
    private MeshFilter mf;
    [Range(0, 1)]
    public float newSpeed;
    [Range(0,10)]
    public float heightMultiplier = 1;
    public float currentSpeed;
    public Mesh mesh;
    public Vector3[] vertices;
    public GameObject water_controller;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CheckForNewSpeed", 0, 60f);
        water_controller = GameObject.Find("Water_Controller");
        mf = GetComponent<MeshFilter>();
        mesh = mf.mesh;
        vertices = mesh.vertices;
        newSpeed = water_controller.GetComponent <Water_Controller>().speed;
        currentSpeed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Destroy(gameObject.GetComponent<MeshCollider>());
        int i = 0;
        while (i < vertices.Length)
        {
            //float lerpToSpeed = Mathf.Lerp(currentSpeed, newSpeed, 0.05f);
            float height = (Mathf.PerlinNoise((transform.position.x +vertices[i].x   + Time.time) * newSpeed   , (transform.position.y + vertices[i].y + Time.time) * newSpeed   ));
            vertices[i].z = 0;
            vertices[i].z += height * heightMultiplier;
            i++;
        }
        currentSpeed = newSpeed;
        mesh.vertices = vertices;
        gameObject.AddComponent<MeshCollider>();
        mesh.RecalculateNormals();
	}
    void CheckForNewSpeed()
    {
        newSpeed = water_controller.GetComponent<Water_Controller>().speed;
    }
}
