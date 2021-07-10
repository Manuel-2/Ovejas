using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CapsuleCollider collider;
    [SerializeField] Rigidbody body;

    [SerializeField] GameObject pillowWeapon;
    [SerializeField] Transform player;
    [SerializeField] GameObject pillowPrefab;
    [SerializeField] float dropForce;
    [SerializeField] Transform pillowExitPoint;

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

        //ocultar la almohada que tiene equipada
        pillowWeapon.SetActive(false);

        //instanciar una nueva almohada que el jugador pueda recojer
        GameObject pillowDroped =  Instantiate(pillowPrefab, pillowExitPoint.transform.position,Quaternion.identity);
        //lanzar almohada con direcion al jugador

        Vector3 launchDirection = new Vector3(player.position.x - this.transform.position.x, 2f,player.position.z - this.transform.position.z);
        launchDirection = launchDirection.normalized * dropForce;
        launchDirection.y = dropForce * 2;
        pillowDroped.GetComponent<Rigidbody>().AddForce(launchDirection,ForceMode.Impulse);

        //lanzar
        StartCoroutine(launchWatanoge(launch));
    }

    
    IEnumerator launchWatanoge(Vector3 launch)
    {
        yield return new WaitForSeconds(0.1f);
        body.AddForce(launch, ForceMode.Impulse);
    }

}

