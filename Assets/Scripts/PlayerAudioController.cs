using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public static PlayerAudioController sharedInstance;

    [SerializeField] AudioSource playerAudioSource;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySoundEffect(AudioClip sound)
    {
        playerAudioSource.PlayOneShot(sound);
    }
}
