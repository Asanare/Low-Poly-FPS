using UnityEngine;
using System.Collections;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {
    GameObject player;
    float moveSpeed = 10f;
    NavMeshAgent pathfinder;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        pathfinder = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        pathfinder.SetDestination(player.transform.position);
	}
}
