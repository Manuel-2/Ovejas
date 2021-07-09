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
        else if (collision.gameObject.CompareTag("Enemy") && isGrounded == false)
        {
            //pasarle como parametros el vector con el cual sera disparado

            Vector3 launch = new Vector3((collision.transform.position.x - this.transform.position.x),2f, (collision.transform.position.z - this.transform.position.z));
            launch = launch.normalized * launchForce;
            //Vector3 launch = (collision.transform.position - this.transform.position).normalized * 20;
            collision.gameObject.GetComponent<DukeController>().EnemyDie(launch);

            
            

            /*
            //TODO: agregar una condicional que evite que esto se ejecute si el enemigo ya se murio 
            //TODO: obtener el componente controlador del enemigo y llamar un metodo para que este muera

            Debug.Log("se ataco a un enemigo");
            //pasar a un rigibody normal desactivado el kinematic
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            //efectuar una fuerza en foma de impulso
            rigidbody.AddForce(,ForceMode.Impulse);
            */
        }
    }

}
