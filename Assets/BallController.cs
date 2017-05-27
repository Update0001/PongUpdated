using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public Rigidbody2D myRigidbody;
	public float speed;
	public int playerNo;
	public int PS1 = 0, PS2 = 0;
	public Text PT1,PT2,Winner;
	public SpriteRenderer rrenderer;
	public GameObject theButton;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		theButton.SetActive (false);

		Winner.gameObject.SetActive (false);
		myRigidbody.velocity = Vector2.down * 2;
		rrenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PS1 == 10) {
			Time.timeScale = 0f;
			theButton.SetActive (true);
			Winner.gameObject.SetActive (true);
			Winner.text = "Blue Wins";
		} else if (PS2 == 10) {
			theButton.SetActive (true);
			Time.timeScale = 0f;
			Winner.gameObject.SetActive (true);
			Winner.text = "Green Wins";
		}

		if (playerNo == 1) {
			
			rrenderer.color = new Color(3f/256, 28f/256, 178f/256, 1f);
		} else if (playerNo == 2) {
			rrenderer.color = new Color (65f/256,200f/256,83f/256);
		}
		PT1.text = "" + PS1;
		PT2.text = "" + PS2;
	}
	void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.name == "Player1") {
			myRigidbody.velocity = Vector2.one * 7;
			playerNo = 1;
		} else if (collider.gameObject.name == "Player2") {
			myRigidbody.velocity = Vector2.one * 7;
			playerNo = 2;
		} else if (collider.gameObject.name == "WallRight") {
			Score ();
		} else if (collider.gameObject.name == "WallLeft") {
			Score ();
		}
	}
	void Score(){
		if (playerNo == 1) {
			PS1 += 1;
		} else if (playerNo == 2) {
			PS2 += 1;
		}
		//gameObject.SetActive (false);
		PT1.text = "" + PS1;
		PT2.text = "" + PS2;
	}
	public void ResetButton(){
		SceneManager.LoadScene ("MainScene");

	}
}
