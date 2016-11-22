using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody ))]
public class Character_Controller : MonoBehaviour {
    private Rigidbody rb;
    public Camera cam;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //rotate camera and character
        float v = Mathf.Clamp(verticalSpeed * Input.GetAxis("Mouse Y"), -0.2f, 0.2f);
        print(v);
        transform.Rotate(-v, 0, 0);
        cam.transform.Rotate(-v, h, 0);
    }
}
