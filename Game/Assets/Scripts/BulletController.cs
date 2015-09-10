using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    Vector3 direction;
	// Use this for initialization
	void Start () {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player1");
        direction = players[0].transform.forward;
        Destroy(gameObject, 2.0f);
        GetComponent<Rigidbody>().AddRelativeForce(direction * 450);
	}
	
	void FixedUpdate () {
	    
	}
}
