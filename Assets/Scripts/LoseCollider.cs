using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;
	public Ball ball;

	void OnTriggerEnter2D (Collider2D trigger) {
		//print ("Trigger");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (LevelManager.lives <= 1) {
			SceneManager.LoadScene ("Lose");
            MusicPlayer.PlayLoseMusic();
            Brick.breakableCount = 0;
		} else {
			LevelManager.lives--;
			//print (LevelManager.lives);
			Ball.hasStarted = false;
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		//print ("Collision");
	}
}
