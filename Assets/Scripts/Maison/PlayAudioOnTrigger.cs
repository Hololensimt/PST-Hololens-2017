using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    AudioSource impactAudioSource = null;
    public AudioClip clip;

    void Start()
    {

        impactAudioSource = GetComponent<AudioSource>();
    }

    // Occurs when this object starts colliding with another object
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cursor"))
            impactAudioSource.PlayOneShot(clip);



    }
}