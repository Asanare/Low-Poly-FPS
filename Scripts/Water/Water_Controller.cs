using UnityEngine;
using System.Collections;
public class Water_Controller : MonoBehaviour
{
    public Transform WaterPrefab;
    public float speed;
    public float yValue;
    //public Transform Water;
    // Use this for initialization
    void Start()
        
    {
        InvokeRepeating("updateSpeed", 0, 60f);
        speed = Random.Range(0.6f, 1);
        for (int i = -20; i < -18; i++)
        {
            for (int j = -20; j < -18; j++)
            {
                //GameObject WaterObject = Instantiate(WaterPrefab, new Vector3(i * 10, yValue , j * 10), Quaternion.identity) as GameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateSpeed()
    {
        speed = Random.Range(0.1f, 1);
    }
}