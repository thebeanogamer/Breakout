using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	private Rigidbody2D rb2d;
	public float speed;
	public Text countText;
	private int count;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = 0;

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce(movement * 3);
		
		//Ensure the block does not move vertically
		rb2d.transform.position = (new Vector3( rb2d.position.x, -4, 0));
		
		//Ensuree the block does not rotate
		transform.Rotate(new Vector3(0,0,0));
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("PickUp"))
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

			//Add one to the current value of our count variable.
			count = count + 1;

			//Update the currently displayed count by calling the SetCountText function.
			SetCountText();
		}
	}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText()
	{
		//Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
		countText.text = "Count: " + count.ToString();
	}
}