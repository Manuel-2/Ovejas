using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatanogeController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody body;

    Rigidbody[] rigidbodies;

    private void Awake()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    private void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }
        animator.enabled = !enabled;
    }

    public void EnemyDie(Vector3 launch)
    {
        //activa el ragdoll
        SetEnabled(true);

        //lanzar al ragdoll
        StartCoroutine(launchWatanoge(launch));
    }

    IEnumerator launchWatanoge(Vector3 launch)
    {
        yield return new WaitForSeconds(0.1f);
        body.AddForce(launch, ForceMode.Impulse);
    }

}
