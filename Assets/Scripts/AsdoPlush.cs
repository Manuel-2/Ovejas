using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsdoPlush : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] string playerTag, pillowTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            audioSource.Play();
        }
    }
}
