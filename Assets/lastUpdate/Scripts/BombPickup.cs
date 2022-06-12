using UnityEngine;
using System.Collections;

public class BombPickup : MonoBehaviour
{
	public AudioClip pickupClip;        // Sound for when the bomb crate is picked up.

	PickupSpawner pickupSpawner;
	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.


	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
		pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
	}


    void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{	
			// Destroy the crate.
			Destroy(transform.root.gameObject);
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);

			// Increase the number of bombs the player has.
			other.GetComponent<LayBombs>().bombCount++;

			

		}
		// Otherwise if the crate lands on the ground...
		else if(other.tag == "ground" && !landed)
		{
			// ... set the animator trigger parameter Land.
			anim.SetTrigger("Landing");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;		
		}
	}
}
