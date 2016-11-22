using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
    static float baseDefense;
    static float baseDamage;
    static float baseHealth;
    static bool isAlive;
    static bool isEnemy;

    public Entity(float pBaseDefense, float pBaseDamage, float pBaseHealth, bool pIsEnemy)
    {
        baseDefense = pBaseDefense;
        baseDamage = pBaseDamage;
        baseHealth = pBaseHealth;
        isAlive = true;
        isEnemy = pIsEnemy;
    }


	void Start () {
	
	}
	

	void Update () {
	
	}
}
