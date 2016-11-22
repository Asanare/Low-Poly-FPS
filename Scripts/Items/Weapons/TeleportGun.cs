using UnityEngine;
using System.Collections;

public class TeleportGun : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject projectile;
    public float fireRate = 0.1f;
    private float timer = 0;
    void Start () {
        Cursor.visible = true;
        timer = fireRate;
    }

    //public GameObject projectile;
    //public Transform shotPos;
    //public float shotForce = 1000f;
    //public float moveSpeed = 10f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (muzzle != null && projectile != null && timer <= 0)
            {
                GameObject shot = Instantiate(projectile, muzzle.transform.position + new Vector3(0, 0,0.2f), muzzle.transform.rotation) as GameObject;
                timer = fireRate;
            }
        }

    }
    //void Update ()
    //{

    //    if(Input.GetButtonUp("Fire1"))
    //    {
    //        Rigidbody shot = Instantiate(projectile, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2)), shotPos.rotation) as Rigidbody;
    //        shot.AddForce(shotPos.forward * shotForce);
    //    }
    //}
    //void OnCollisionEnter(Collision col)
    //{
    //    player.transform.position = transform.position;
    //    Destroy(this);
    //}
}

