using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    [SerializeField] Animator endingAnimator;
    [SerializeField] string endTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endingAnimator.SetTrigger(endTrigger);
        }
    }
}
