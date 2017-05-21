using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is in charge of playing music in the game
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// The clip to play in a menu.
    /// This field is private because it's not designed to be directly
    /// modified by other scripts, and tagged with [SerializeField] so that
    /// you can still modify it using the Inspector and so that Unity
    /// saves its value.
    /// </summary>
    [SerializeField]
    private AudioClip menuMusic;

    [SerializeField]
    private AudioClip winMusic;
    [SerializeField]
    private AudioClip loseMusic;

    /// <summary>
    /// The clip to play outside menus.
    /// </summary>
    [SerializeField]
    private AudioClip level1Music;

    [SerializeField]
    private AudioClip level2Music;

    [SerializeField]
    private AudioClip level3Music;

    [SerializeField]
    private AudioClip level4Music;

    [SerializeField]
    private AudioClip level5Music;
    //	[SerializeField]
    //	private AudioClip level4Music;
    //	[SerializeField]
    //	private AudioClip winMusic;

    [SerializeField]
    /// <summary>
    /// The component that plays the music
    /// </summary>
    private AudioSource source;

    /// <summary>
    /// This class follows the singleton pattern and this is its instance
    /// </summary>
    static private MusicPlayer instance;

    /// <summary>
    /// Awake is not public because other scripts have no reason to call it directly,
    /// only the Unity runtime does (and it can call protected and private methods).
    /// It is protected virtual so that possible subclasses may perform more specific
    /// tasks in their own Awake and still call this base method (It's like constructors
    /// in object-oriented languages but compatible with Unity's component-based stuff.
    /// </summary>
    protected virtual void Awake()
    {
        // Singleton enforcement
        if (instance == null)
        {
            // Register as singleton if first
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            // Self-destruct if another instance exists
            Destroy(this);
            return;
        }
    }

    protected virtual void Start()
    {
        // If the game starts in a menu scene, play the appropriate music
        PlayMenuMusic();
    }

    /// <summary>
    /// Plays the music designed for the menus
    /// This method is static so that it can be called from anywhere in the code.
    /// </summary>
    /// 
    static public void chooser(int name)
    {
        //print(name);
        if (name == 0)//Start
        {
            PlayMenuMusic();
        }
        else if (name == 1)//"Level_01"
        {
            PlayLevel1Music();
        }
        else if (name == 2)//"Level_02"
        {
            PlayLevel2Music();
        }
        else if (name == 3)//"Level_03"
        {
            PlayLevel3Music();
        }
        else if (name == 4)//"Level_04"
        {
            PlayLevel4Music();
        }
        else if (name == 5)//"Level_05"
        {
            PlayLevel5Music();
        }
        else if (name == SceneManager.GetSceneByName("Win").buildIndex)//Win
        {
            PlayWinMusic();
        }
    }
    static public void PlayMenuMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayWinMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.winMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayLoseMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.loseMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    /// <summary>
    /// Plays the music designed for outside menus
    /// This method is static so that it can be called from anywhere in the code.
    /// </summary>
    static public void PlayLevel1Music()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.level1Music;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayLevel2Music()
    {
        instance.source.Stop();
        instance.source.clip = instance.level2Music;
        instance.source.Play();
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.level2Music;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayLevel3Music()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.level3Music;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayLevel4Music()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.level4Music;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
    static public void PlayLevel5Music()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.level5Music;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MusicPlayer : MonoBehaviour {
//	static MusicPlayer instance = null;

//	void Awake () {
//		//Debug.Log ("Music player Awake ");
//		if (instance != null) {
//			Destroy (gameObject);
//		} else {
//			instance = this;
//			GameObject.DontDestroyOnLoad (gameObject);
//		}
//	}
//}