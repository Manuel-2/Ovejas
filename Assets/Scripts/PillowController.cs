using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowController : MonoBehaviour
{
    [SerializeField] float canRecolectDelay;
    [SerializeField] float launchForce;
    bool isGrounded;

    private void Awake()
    {
        GetComponent<SphereCollider>().enabled = false;
        isGrounded = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CanBeRecolected",canRecolectDelay);
        isGrounded = false;
    }

    void CanBeRecolected()
    {
        GetComponent<SphereCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
        else if (isGrounded == false && collision.gameObject.CompareTag("Enemy"))
        {
            //pasarle como parametros el vector con el cual sera disparado

            Vector3 launch = new Vector3((collision.transform.position.x - this.transform.position.x),2f, (collision.transform.position.z - this.transform.position.z));
            launch = launch.normalized * launchForce;
            
            //NOTA: cuando el enemigo muere se Desactiva el collider que detecta los daños.
            collision.gameObject.GetComponent<EnemyController>().EnemyDie(launch);

        }
    }

}
