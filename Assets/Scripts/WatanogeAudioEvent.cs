using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatanogeAudioEvent : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] AudioSource soundEfect;
    bool wasPlayed;

    private void Awake()
    {
        wasPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag) && wasPlayed == false)
        {
            wasPlayed = true;
            soundEfect.Play();
        }
    }
}
