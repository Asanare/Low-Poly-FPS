using UnityEngine;
using System.Collections;

public class RemoveJunk : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity == Vector3.zero)
        {
            gameObject.GetComponent<MeshCollider>().convex = true;
            Destroy(rb);
            gameObject.GetComponent<MeshCollider>().convex = false;
            Destroy(this);
            
        }
        
	}
}
