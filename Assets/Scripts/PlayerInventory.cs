using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject Pillow;
    bool hasPillow = false;

    [SerializeField] GameObject PillowPrefab;
    [SerializeField] float launchForce;
    [SerializeField] Transform launchPoint;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasPillow)
        {
            TrowPillow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pillow"))
        {
            //checks if currently the player as a pillow equiped if he hasn't takes the pillow for the groud
            if(hasPillow == false)
            {
                TakePillow(other.gameObject);
            }
        }
    }

    private void TakePillow(GameObject pillow)
    {
        hasPillow = true;
        Pillow.SetActive(hasPillow);
        
        Destroy(pillow);
    }

    private void TrowPillow()
    {
        hasPillow = false;
        Pillow.SetActive(hasPillow);

        //intanciar una nueva almohada
        GameObject lauchedPillow = Instantiate(PillowPrefab, launchPoint.position,launchPoint.rotation);
        //ejercer un impulso a esa almohada
        lauchedPillow.GetComponent<Rigidbody>().AddForce(launchPoint.forward * launchForce,ForceMode.Impulse);

    }

}
