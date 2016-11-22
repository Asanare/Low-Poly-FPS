using UnityEngine;
using System.Collections;

public class Cloud_Spawner : MonoBehaviour {
    public GameObject[] clouds;
    public Material material;
    public int minX = -100;
    public int maxX = 100;
    public int minY = 500;
    public int maxY = 700;
    public int minZ = -100;
    public int maxZ = 100;
    public int numberOfClouds = 50;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfClouds; i++)
        {
            GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length-1)], new Vector3(Random.Range(minX, maxX ), Random.Range(minY, maxY), Random.Range(minZ , maxZ)), Quaternion.identity ) as GameObject ;
            cloud.GetComponent<Renderer>().material = material;
            cloud.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            cloud.transform.localScale = new Vector3(Random.Range(200, 400), Random.Range(50, 150), Random.Range(200, 400));
            cloud.transform.parent = GameObject.Find("Clouds").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
