using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
namespace Transport
{
    
    public class Jetpack : MonoBehaviour
    {
        private Rigidbody rb;
        public bool isAllowedToFly = true;
        public bool isFlying = false;
		public bool isGrounded = true;
        public float fuel = 100f;
        public float maxFuel = 100f;
        //public ParticleSystem ps;   //FIXME
        //public float timer;
        public float vel;
        Transform tf;
        private RigidbodyFirstPersonController rfpc;
        // Use this for initialization
        void Start()
        {
            InvokeRepeating("UpdateFuel", 0f, 1f);
            
            if (GetComponent<RigidbodyFirstPersonController>() != null)
            {
                tf = transform;
                
                
            }
            else
            {
                tf = transform.parent.transform;
                
            }
            rfpc = tf.GetComponent<RigidbodyFirstPersonController>();
            rb = tf.GetComponent<Rigidbody>();
            //timer = 0.5f;
            
        }
        void OnCollisionEnter()
        {
            if (vel >= 50)
            {
                print("Dead");
            }
        }
        // Update is called once per frame
        void Update()
        {
            vel = rb.velocity.magnitude;
            //timer -= Time.deltaTime;
            //if (timer <= 0)
            //{
            //    isAllowedToFly = true;
            //}
            Debug.DrawRay(tf.position, Vector3.down, Color.red);
            if (Physics.Raycast(tf.position, Vector3.down, 1f))
            {
                isGrounded = true;
            }
            if (isGrounded )
            {
                rfpc.advancedSettings.airControl = true;
                isFlying = false;
            }

                

            if (Input.GetKey(KeyCode.F))
            {
                if (fuel > 0)
                {
                    if (isGrounded)
                    {
                        tf.position = new Vector3(tf.position.x, tf.position.y + 0.1f, tf.position.z);
                    }
                    if (isFlying == false)
                    {
                        float h = Input.GetAxis("Horizontal");
                        float v = Input.GetAxis("Vertical");
                        rb.AddRelativeForce(new Vector3(h * 40, 60, v * 40), ForceMode.Impulse);
                        rfpc.advancedSettings.airControl = false;
                        isFlying = true;
                        isGrounded = false;
                        fuel -= Time.deltaTime * 5;
                        //ps.Play();
                        //isAllowedToFly = false;
                    }
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                    {
                        float h = Input.GetAxis("Horizontal");
                        float v = Input.GetAxis("Vertical");
                        rb.AddRelativeForce(new Vector3(h * 60, 40, v * 60), ForceMode.Force);
                        //Physics.gravity = new Vector3(0, -13, 0);
                        fuel -= Time.deltaTime * 5;
                    }
                    if (isFlying)
                    {
                        float h = Input.GetAxis("Horizontal");
                        float v = Input.GetAxis("Vertical");
                        rb.AddRelativeForce(new Vector3(h, 50, v ), ForceMode.Force);
                        
                        //ps.Play();
                        fuel -= Time.deltaTime * 5;
                    }
                    
                }
            }

        }

        void UpdateFuel()
        {
            float amount = 0.5f;
            if (fuel < maxFuel)
            {
                fuel += amount;
            }
            
        }
    }
}