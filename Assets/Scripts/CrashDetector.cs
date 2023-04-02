using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadSceneDelay = 1.0f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool m_hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Ground" && !m_hasCrashed)
        {
            m_hasCrashed = true;
            FindObjectOfType<PlayerController>().disableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("reloadScene", reloadSceneDelay);
        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
