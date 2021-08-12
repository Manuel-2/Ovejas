using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MilkShake;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxHealt;
    int healt;
    [SerializeField] GameObject playerMovement;
    [SerializeField] MouseLook camara;
    [SerializeField] GameObject playerRagdoll;
    [SerializeField] Transform cameraPosition;
    [SerializeField] float timeToRecoverHealt;

    [Header("Damage Adminstration")]
    [SerializeField] Animator blink;
    [SerializeField] string triggerFallOfAnimation;

    [Header("CameraShake")]
    [SerializeField] Shaker shaker;
    [SerializeField] ShakePreset shakePreset;

    public bool isAlive { get; private set; }

    DamageEffect damageEffect;

    private void Awake()
    {
        isAlive = true;
        damageEffect = GameObject.Find("DamageEffect").GetComponent<DamageEffect>();
        healt = maxHealt;
    }

    public void getDamage()
    {
        //retroceder
        healt--;
        damageEffect.ActivateDamageEfect(healt);
        shaker.Shake(shakePreset);
        if (healt<= 0)
        {
            playerDie();
        }
        else if (healt > 0){
            //call a coroutine to start healing
            StartCoroutine("RecoverHealt");
        }
    }

    void playerDie()
    {
        //activar ragdoll
        ActivatePlayerRagdoll();
        //desactivar el movimineto del jugador
        playerMovement.SetActive(false);
        //desactivar el movimineto de la camara
        camara.DeactivateCameraMovement();
        // efecto de parpadear y dormir
        // al terminar la animacion esta llama un evento que reinicia la escena
        blink.SetTrigger(triggerFallOfAnimation);
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

    IEnumerator RecoverHealt()
    {
        yield return new WaitForSeconds(timeToRecoverHealt);
        damageEffect.RecoverHealt();
        yield return new WaitForSeconds(damageEffect.timeToDisapear);
        healt = maxHealt;
    }

}
