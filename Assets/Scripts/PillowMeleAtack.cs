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

    private void OnTriggerEnter(Collider other)
    {
        if ( canHit && other.gameObject.CompareTag(enemyTag) && playerInventory.isAtacking)
        {
            canHit = false;
            Debug.Log("se detecto colicion");
            //xd
            Vector3 launch = new Vector3((other.transform.position.x - playerInventory.transform.position.x), 2f, (other.transform.position.z - this.transform.position.z));
            launch = launch.normalized * launchForce;
            other.gameObject.GetComponent<DukeController>().EnemyDie(launch);
            Invoke("CanHit",0.2f);
        }
    }

    private void CanHit()
    {
        canHit = true;
    }

}
