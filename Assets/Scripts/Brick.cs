using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public float volume;
	public static int breakableCount = 0;
	public GameObject particle1;
	public GameObject particle2;

	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		

		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D (Collision2D col) {
		
		if (isBreakable) {
			HandleHits ();
			AudioSource.PlayClipAtPoint (crack, transform.position, volume);
		}
	}

	void HandleHits () {
		timesHit++;
		if (timesHit >= hitSprites.Length + 1) {
			breakableCount--;
			levelManager.BrickDestoyed ();
			GameObject particle = Instantiate (particle1, gameObject.transform.position, Quaternion.identity);
			ParticleSystem.MainModule main = particle.GetComponent<ParticleSystem> ().main;
			main.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
		} else {
			GameObject particle3 = Instantiate (particle2, gameObject.transform.position, Quaternion.identity);
			ParticleSystem.MainModule main = particle3.GetComponent<ParticleSystem> ().main;
			main.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			LoadSprites ();
			////PARTICALE3 REFERS TO PARTICLE 2

		}
	}
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}
