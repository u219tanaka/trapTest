using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
	public int trapType = 1;

	void OnCollisionEnter(Collision collision)
	{
		if( collision.gameObject.CompareTag("Player") )
		{
			switch( trapType )
			{
				case 1:
					Invoke("Deactivate", 1.5f);
					break;

				case 2:
					collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
					break;

			}
		}
	}

	void Deactivate()
	{
		gameObject.SetActive(false);
		Invoke("Recover", 1);
	}

	void Recover()
	{
		gameObject.SetActive(true);
	}

}
