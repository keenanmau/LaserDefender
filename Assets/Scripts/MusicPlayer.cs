using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

    public AudioClip startClip, gameClip, endClip;

    private AudioSource music;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
		}

		
	}

     void OnLevelWasLoaded(int level)
    {
        Debug.Log("Music player: loaded level" + level);
        music.Stop();
        switch (level)
        {
            case 0:
                music.clip = startClip;
                break;
            case 1:
                music.clip = gameClip;
                break;
            case 2:
                music.clip = endClip;
                break;
            default:
                Debug.Log("Level variable broke");
                music.clip = startClip;
                break;
        }
        music.loop = true; 
        music.Play();
    }
}
