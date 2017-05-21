using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static int lives = 0;
    private int nextLevel;
    public void LoadNextLevel () {
        //Debug.Log(SceneManager.sceneCount);
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
        MusicPlayer.chooser(nextLevel);
        lives += 3;
        

    }

	public void LoadLevel (string name) {
		//Debug.Log (name);
		lives = 0;
		SceneManager.LoadScene (name);
	}
	public void QuitGame () {
		//Debug.Log ("Quit Game Requested");
		Application.Quit ();
	}
	public void BrickDestoyed() {
		if (Brick.breakableCount <= 0){
			LoadNextLevel ();
		}
	}
}
