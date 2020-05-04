using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class collisionhandler : MonoBehaviour {

   [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
   [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()  // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
