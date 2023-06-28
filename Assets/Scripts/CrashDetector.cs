using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "LevelGeom")
        {
            Debug.Log("fuggg");
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene", crashDelay);
        }
    }

    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
