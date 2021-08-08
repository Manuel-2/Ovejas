using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowMeleAtack : MonoBehaviour
{
    [SerializeField] string enemyTag;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] float launchForce;

    bool canHit;

    private void Start()
    {
        canHit = true;
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("dañado al enemigo");
        }

        if ( canHit && other.gameObject.CompareTag(enemyTag) && playerInventory.isAtacking)
        {
            canHit = false;
            Vector3 launch = new Vector3((other.transform.position.x - playerInventory.transform.position.x), 2f, (other.transform.position.z - this.transform.position.z));
            launch = launch.normalized * launchForce;
            other.gameObject.GetComponent<EnemyController>().EnemyDie(launch);
            Invoke("CanHit",0.2f);
        }
    }
    */

    private void CanHit()
    {
        canHit = true;
    }

}
