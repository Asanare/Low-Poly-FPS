using UnityEngine;
using System.Collections;

public class PlacePrefabs : MonoBehaviour
{
    public GameObject prefab;
    public int numOfPrefabs;
    public float distanceBetween;
    public bool onGround;
    public bool blenderImport;
    public bool rigidBody;
    public bool freezeRotation;
    public bool randomRotation;
    public Vector3 min;
    public Vector3 max;
    private ArrayList positions;
    GameObject spawnedObject;

    //A Blender import must be the child of an empty object.
    void Start()
    {
        positions = new ArrayList();
        GameObject parent = new GameObject("Objects - " + prefab.name);
        for (int i = 0; i < numOfPrefabs; i++)
        {
            Vector3 position = generateNewPosition();
            Vector3 rotation = Vector3.zero;

            if (blenderImport && randomRotation)
            {
                rotation = new Vector3(0, Random.Range(0, 360));
            }
            else if (blenderImport && !randomRotation)
            {
                rotation = new Vector3(0, -90, 0);
            }
            else if (!blenderImport && randomRotation)
            {
                rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            }

            if (positions.Count > 0)
            {
                foreach (GameObject spawned in positions)
                {
                    while (Vector3.Distance(position, spawned.transform.position) < distanceBetween)
                    {
                        position = generateNewPosition();
                    }

                }
                spawnedObject = Instantiate(prefab, position, Quaternion.Euler(rotation)) as GameObject;
            }
            else
            {
                spawnedObject = Instantiate(prefab, position, Quaternion.Euler(rotation)) as GameObject;
            }

            if (!onGround)
            {
                if (spawnedObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>() != null)
                {
                    Destroy(spawnedObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>());
                }
            }
            spawnedObject.transform.parent = parent.transform;
            positions.Add(spawnedObject.transform.GetChild(0).gameObject);
            if (spawnedObject.transform.GetChild(0).gameObject.GetComponent<MeshCollider>() != null)
            {
                spawnedObject.transform.GetChild(0).gameObject.GetComponent<MeshCollider>().convex = true;
            }
            else
            {
                spawnedObject.transform.GetChild(0).gameObject.AddComponent<MeshCollider>().convex = true;
            }
            if (onGround && blenderImport && freezeRotation)
            {
                if (spawnedObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>() != null)
                {
                    spawnedObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().freezeRotation = true;
                }
                else
                {
                    spawnedObject.transform.GetChild(0).gameObject.AddComponent<Rigidbody>().freezeRotation = true;
                }
            }
            else if (onGround && blenderImport && !freezeRotation)
            {
                if (spawnedObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>() == null)
                {
                    spawnedObject.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
                }
            }
            spawnedObject.transform.GetChild(0).gameObject.GetComponent<MeshCollider>().convex = true;
            if (!rigidBody)
            {
                spawnedObject.transform.GetChild(0).gameObject.AddComponent<RemoveJunk>();
            }


        }

    }
    Vector3 generateNewPosition()
    {
        float rndX = Random.Range(min.x, max.x);
        float rndY = Random.Range(min.y, max.y);
        float rndZ = Random.Range(min.z, max.z);
        Vector3 position = new Vector3(rndX, rndY, rndZ);
        return position;
    }

    void Update()
    {

    }
}
