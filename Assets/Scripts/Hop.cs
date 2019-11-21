using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Space) )
		{
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.AddForce(0,10.0f,0,ForceMode.Impulse);
		}
	}
}
