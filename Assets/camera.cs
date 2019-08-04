using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    public GameObject player;
    public float z = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (z != 0)
        {
            Vector3 vector = transform.position;
            vector.z = player.transform.position.z + z;
            transform.position  = vector;
        }
	}
}
