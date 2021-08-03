using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] EnemyController enemyController;
    [SerializeField] float attackDuration;

    bool canHit;

    private void Start()
    {
        canHit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canHit && other.gameObject.CompareTag(playerTag) && enemyController.isAttacking)
        {
            canHit = false;
            //llamar el metodo del jugador para quitarle vida
            other.gameObject.GetComponent<PlayerController>().getDamage();
            Invoke("CanHit", attackDuration);
        }
    }

    private void CanHit()
    {
        canHit = true;
    }
}
