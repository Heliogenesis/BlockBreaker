using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Paddle paddle;
	public LoseCollider loseCollider;
	public LevelManager levelManager;
	public static bool hasStarted;
	private Vector3 paddleToBallVector;


	// Use this for initialization
	void Start () {

		paddleToBallVector = this.transform.position - paddle.transform.position;
		paddle = GameObject.FindObjectOfType<Paddle> ();
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelManager.lives <= 0) {
			hasStarted = false;
			//print (LevelManager.lives);
		}

		//print (hasStarted);
		if (!hasStarted) {
			
			if (Input.GetMouseButtonDown (0)) {
				//print ("Mouse Clicked");
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 12f);
			}
			
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
        Vector2 tweak;
        if (collision.gameObject.isStatic)
        {
            tweak = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        } 
        else
        {
            tweak = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        

		if (hasStarted) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}

