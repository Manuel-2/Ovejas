using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int healt;
    [SerializeField] GameObject playerMovement;
    [SerializeField] MouseLook camara;
    [SerializeField] GameObject playerRagdoll;
    [SerializeField] Transform cameraPosition;

    public bool isAlive { get; private set; }

    private void Awake()
    {
        isAlive = true;
    }

    public void getDamage()
    {
        //retroceder



        healt--;
        if(healt<= 0)
        {
            playerDie();
        }
        //todo: llamar algunos efectos y darle feedback al jugador
    }

    void playerDie()
    {
        //activar ragdoll
        ActivatePlayerRagdoll();
        //TODO: desactivar el movimineto del jugador
        playerMovement.SetActive(false);
        //desactivar el movimineto de la camara
        camara.DeactivateCameraMovement();
        Debug.Log("el jugador perdio :(");
    }

    void ActivatePlayerRagdoll()
    {
        //Traer el ragdoll a la posicion exacta del jugador
        playerRagdoll.transform.position = this.transform.position;
        //colocar la camara en el Ragdoll;
        camara.transform.position = cameraPosition.transform.position;
        camara.transform.SetParent(playerRagdoll.transform);
        //lanzar al ragdoll
        playerRagdoll.GetComponent<Rigidbody>().AddForce((Vector3.up - transform.forward) * 5,ForceMode.Impulse);

        //desactivar al jugador
        this.gameObject.SetActive(false);


    }

}
