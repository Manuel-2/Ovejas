using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Pillow config")]
    [SerializeField] GameObject Pillow;
    bool hasPillow = false;
    [SerializeField] GameObject PillowPrefab;
    [SerializeField] float launchForce;
    [SerializeField] Transform launchPoint;

    [Header("Movement Things")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField][Range(0,100)] int playerSpeedPercentageModification;

    [Header("Animations")]
    [SerializeField] Animator playerAnim;
    [Space]
    [SerializeField] string launchPillowTrigger;
    [SerializeField] string atackPillowTrigger;

    public bool isAtacking;

    private void Awake()
    {
        isAtacking = false;
    }

    private void Update()
    {

        if (hasPillow)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerAnim.SetTrigger(atackPillowTrigger);
                isAtacking = true;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                //la animacion se encarga de ejecutar la fucnion de lanzar la almohada
                playerAnim.SetTrigger(launchPillowTrigger);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pillow"))
        {
            if(hasPillow == false)
            {
                TakePillow(other.gameObject);
            }
        }
    }

    private void TakePillow(GameObject pillow)
    {
        playerMovement.pillowSpeedModifier = playerSpeedPercentageModification / 100f;

        playerAnim.ResetTrigger(launchPillowTrigger);

        hasPillow = true;
        Pillow.SetActive(hasPillow);
        
        Destroy(pillow);
    }

    private void TrowPillow()
    {
        //elimina la restriccion de velocidad y permite al jugador moverse a su 100%
        playerMovement.pillowSpeedModifier = 1f;

        hasPillow = false;
        Pillow.SetActive(hasPillow);

        //intanciar una nueva almohada
        GameObject lauchedPillow = Instantiate(PillowPrefab, launchPoint.position,launchPoint.rotation);
        //ejercer un impulso a esa almohada
        lauchedPillow.GetComponent<Rigidbody>().AddForce(launchPoint.forward * launchForce,ForceMode.Impulse);

    }

    private void endAttack()
    {
        isAtacking = false;
    }

}
