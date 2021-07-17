using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int healt;


    public void getDamage()
    {
        healt--;
        //todo: llamar algunos efectos y darle feedback al jugador
    }

    void playerDie()
    {

    }

}
