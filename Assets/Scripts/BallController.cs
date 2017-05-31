using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public Rigidbody2D myRigidbody;
	public float speed;
	//public float checkBallPos = 3,ballFarkX,ballFarkY, tolerans = 0.8f;
	public int playerNo;
	public int PS1 = 0, PS2 = 0; // Player 1&2 Score
	public Text PT1,PT2,Winner;
	public SpriteRenderer rrenderer;
	public GameObject theButton;
	//public Vector2 ballPos, ballPos2;


	public Material ballMaterial;
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
		//Player Score > 10
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
		// Top rengi için
		if (playerNo == 1) {			
			rrenderer.color = new Color(3f/256, 28f/256, 178f/256, 1f); // Mavi
		} else if (playerNo == 2) {
			rrenderer.color = new Color (114f/256,255f/256,0f/256); // Yeşil
		}
		//Skor metinleri için
		PT1.text = "" + PS1;
		PT2.text = "" + PS2;
		BallStuck ();
		//Fazla takılmayı engellemek için
	/*	if(Time.time < checkBallPos)
		ballPos = transform.position;

		if (Time.time > checkBallPos + 3f) {
			ballPos2 = transform.position;

			ballFarkX = ballPos.x - ballPos2.x; // ilk durum - son durum 3 saniye farkla
			ballFarkY = ballPos.y - ballPos2.y;

			if (ballFarkX < tolerans && ballFarkY < tolerans) {
				myRigidbody.velocity = Vector2.right * 7;
				Debug.Log ("Çift Tolerans");
			} else if (ballFarkX < tolerans) { // Eğer sadece Y ekseninde gidip geliyorsa, Yani X'si sabıtse
				myRigidbody.velocity = Vector2.right * 7;
				Debug.Log ("Yalnız X");
			} else if (ballFarkY < tolerans) { // Eğer sadece X ekseninde gidip geliyorsa , Y'si sabitse
				myRigidbody.velocity = Vector2.up * 7;
				Debug.Log ("Yalnız Y");
			}
			checkBallPos += 3;
		}*/


	}
	void OnCollisionEnter2D(Collision2D collider){
		// Eğer top çarparsa
		if (collider.gameObject.name == "Player1") {
			myRigidbody.velocity = Vector2.one * 7;
			playerNo = 1; // En son 1'e dokunmuş
			ballMaterial.SetColor("_TintColor", new Color (0f/256,192f/256,255f/256)); //Trail Renderer Renk Mavi
		} else if (collider.gameObject.name == "Player2") {
			myRigidbody.velocity = Vector2.one * 7;
			playerNo = 2;  // En son 2'ye dokunmuş
			ballMaterial.SetColor("_TintColor", new Color (177f/256,255f/256,0f/256)); //Trail Renderer Renk Yeşil
		} else if (collider.gameObject.name == "WallRight") {
			Score ();
		} else if (collider.gameObject.name == "WallLeft") {
			Score ();
		}
	}
	void Score(){
		// Çarpılan kenara göre skor ekleme
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
		// Oyunu yeniden başlat
		SceneManager.LoadScene ("MainScene");

	}

	void BallStuck(){
		


	}
}
