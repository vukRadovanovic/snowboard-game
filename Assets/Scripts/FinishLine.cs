using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Debug.Log("Finish!!!");
            GetComponent<AudioSource>().Play();
            finishEffect.Play();
            Invoke("ReloadScene", finishDelay);
        }
    }

    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
