using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider collider;
    [SerializeField] Rigidbody body;

    Rigidbody[] rigidbodies;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }

    //true para activar el ragdoll y false para desactivar
    private void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }
        animator.enabled = !enabled;
    }

    public void EnemyDie(Vector3 launch)
    {
        //desactiva transformar el hitbox en un triger
        collider.isTrigger = true;
        //usa esta funcion para adminsitrar todo el proceso por ahora usala de forma rapida para aplicar las mecanicas 
        SetEnabled(true);

        //lanzar
        StartCoroutine(launchWatanoge(launch));
    }

    void LaunchBody(Vector3 launch)
    {
        Debug.Log("Lanzando");
        body.AddForce(launch, ForceMode.Impulse);
    }
    
    IEnumerator launchWatanoge(Vector3 launch)
    {
        yield return new WaitForSeconds(0.1f);
        LaunchBody(launch);
    }

}

