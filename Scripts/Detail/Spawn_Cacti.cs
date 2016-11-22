using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Spawn_Cacti : MonoBehaviour {
    public GameObject cactus;
    public int number;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < number; i++)
        {
            Instantiate (cactus, new Vector3(Random.Range(-50,50), Random.Range(0,5), Random.Range(-50,50)), Quaternion.identity );
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
