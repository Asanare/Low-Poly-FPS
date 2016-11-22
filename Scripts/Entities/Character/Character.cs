using UnityEngine;
using System.Collections;

public class Character : Entity {
    Camera main;
    public GameObject gun;
    public Character() : base(10,10, 10, false)
    {
       
    }
	// Use this for initialization
	void Start () {
        //main = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
    transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0));
	//Ray ray = main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
    //gun.transform.LookAt (main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)));
    //Debug.DrawRay(ray.origin, ray.direction , Color.red );
	}
}
