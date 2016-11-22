using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    private float speed = 5f;
	// Use this for initialization
	void Start () {
        Invoke("DestroyThis", 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, 8 * Time.deltaTime * 2));
	}

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col){
        print("Collision");
    }
}
