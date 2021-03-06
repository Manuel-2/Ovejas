using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Animations System")]
    [SerializeField] Animator animator;
    [SerializeField] string attackParameterName;
    [SerializeField] float attackAnimationDuration;
    [SerializeField] string movementParameterName;
    bool isMoving;

    [Header("Movement and IA System")]
    [SerializeField] NavMeshAgent agent;
    Transform target;
    bool isFollowingPlayer;

    [Header("Tags an layers needed")]
    [SerializeField] string playerTag;
    [SerializeField] LayerMask playerLayerMask;

    [Header("Pillow things")]
    [SerializeField] GameObject pillowWeapon;
    [SerializeField] GameObject pillowPrefab;
    [SerializeField] Transform pillowExitPoint;
    [SerializeField] float dropForce;

    [Header("Attack configuration")]
    [SerializeField] float attackDistance;
    [SerializeField] float attackRadius;

    [Header("Ragdoll and Physics")]
    Rigidbody[] rigidbodies;
    [SerializeField] Rigidbody body;
    [SerializeField] CapsuleCollider collider;

    public bool isAttacking { get; private set; }
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        isAlive = true;
        isFollowingPlayer = false;
       
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);

        isMoving = false;
    }

    private void Update()
    {
        //ir a la posicion del jugador cuando este esta en un dermenidado rango
        if (isAlive && isFollowingPlayer)
        {
            agent.SetDestination(target.position);
        }

        //detectar si el jugador esta dentro del rago de ataque
        if (isAttacking == false && PlayerInAttackRank())
        {
            isFollowingPlayer = false;
            isAttacking = true;
            animator.SetTrigger(attackParameterName);
            //este invoque restablece las variables de ataque y hace que el enemigo regrese al estado de persecusión;
            Invoke("AttackEnded", attackAnimationDuration);

            //el ataque en si es mover la almohada para que colisione con el jugador, una vez que eso ocurra al final de la animacino llamar un evento para que regrese al estado originial la varible isAttacking
        }


        animator.SetBool(movementParameterName, isMoving);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive && other.CompareTag(playerTag))
        {
            target = GameObject.FindGameObjectWithTag(playerTag).transform;
            isFollowingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isAlive && other.CompareTag(playerTag))
        {
            target = transform;
            isFollowingPlayer = false;
            isMoving = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isAlive && other.CompareTag(playerTag))
        {
            isMoving = true;
        }
    }


    private bool PlayerInAttackRank()
    {
        RaycastHit hit;
        if (Physics.SphereCast(this.transform.position, attackRadius, transform.forward, out hit, attackDistance, playerLayerMask.value))
        {
            return true;
        }
        return false;
    }

    private void AttackEnded()
    {
        isAttacking = false;
        isFollowingPlayer = true;
    }
    //true para activar el ragdoll y false para desactivar
    private void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }
        animator.enabled = !enabled;
    }

    public void EnemyDie(Vector3 launch)
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag(playerTag).transform.position;
        isAlive = false;

        //deja de segir al jugador y desactiva el componente de agente
        isFollowingPlayer = false;
        agent.enabled = false;

        //transformar el hitbox(colider) en un triger
        collider.isTrigger = true;
        //activa el ragdoll
        SetEnabled(true);

        //ocultar la almohada que tiene equipada
        pillowWeapon.SetActive(false);

        //instanciar una nueva almohada que el jugador pueda recojer
        GameObject pillowDroped = Instantiate(pillowPrefab, pillowExitPoint.transform.position, Quaternion.identity);

        //lanzar almohada con direcion al jugador
        Vector3 launchDirection = new Vector3(playerPosition.x - this.transform.position.x, 2f, playerPosition.z - this.transform.position.z);
        launchDirection = launchDirection.normalized * dropForce;
        launchDirection.y = dropForce * 2;
        pillowDroped.GetComponent<Rigidbody>().AddForce(launchDirection, ForceMode.Impulse);

        //lanzar
        StartCoroutine(launchWatanoge(launch));
    }


    IEnumerator launchWatanoge(Vector3 launch)
    {
        yield return new WaitForSeconds(0.1f);
        body.AddForce(launch, ForceMode.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.forward * attackDistance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * attackDistance, attackRadius);
    }
}
