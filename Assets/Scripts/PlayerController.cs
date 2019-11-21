using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private GameObject eraseGround;

	private float lastEscape;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
		lastEscape = Time.time;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical) * speed;

		rb.AddForce(movement);

		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			if( Time.time - lastEscape < 1.0 )
				Application.Quit();
			else
				lastEscape = Time.time;
		}

		if( transform.position.y < -15 )
			SceneManager.LoadScene(　SceneManager.GetActiveScene().name　);
	}

	private void OnTriggerEnter(Collider other)
	{
		if( other.gameObject.CompareTag("Pick Up") )
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	private void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if( GameObject.FindGameObjectsWithTag("Pick Up").Length == 0 )
		{
			winText.text = "You win!";
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Fall Ground"))
		{
			eraseGround = collision.gameObject;
			Invoke("EraseGround", 3);
		}
	}

	void EraseGround()
	{
		eraseGround.SetActive(false);
		Invoke("PutGround", 1);
	}

	void PutGround()
	{
		eraseGround.SetActive(true);
	}

}
