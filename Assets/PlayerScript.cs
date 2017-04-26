using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	private int count;
	public Text CountText;
	public Text WinText;
	public float Speed;
	private Rigidbody rb;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		WinText.text = string.Empty;
	}

	// Update is called once per frame
	void FixedUpdate () {
		var moveHorizontal = Input.GetAxis ("Horizontal");
		var moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * Speed);
	} 

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("pickup")) {
			count++;
			SetCountText ();
			Destroy (other.gameObject);	
		}

	}

	private void SetCountText(){
		CountText.text = "Count: " + count.ToString ();
		if (count >= 5) {
			WinText.text = "You win";
		}
	}
} 
