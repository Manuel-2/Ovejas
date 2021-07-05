using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowController : MonoBehaviour
{
    [SerializeField] float canRecolectDelay;


    private void Awake()
    {
        GetComponent<SphereCollider>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CanBeRecolected",canRecolectDelay);
    }

    void CanBeRecolected()
    {
        GetComponent<SphereCollider>().enabled = true;
    }
}
