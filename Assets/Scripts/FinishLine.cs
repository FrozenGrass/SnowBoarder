using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
	[SerializeField] float reloadSceneDelay = 1.0f;
	[SerializeField] ParticleSystem finishEffect;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
	  {
			finishEffect.Play();
			GetComponent<AudioSource>().Play();
		  Invoke("reloadScene", reloadSceneDelay);
		}
	}
	
	void reloadScene()
	{
		SceneManager.LoadScene(0);
	}

}
