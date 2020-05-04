using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            
        DontDestroyOnLoad(gameObject );

        }
    }
    void Start ()
    {
        Invoke("LoadFirstScene", 2f);
	}
	
	// Update is called once per frame
	void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
	}
}
