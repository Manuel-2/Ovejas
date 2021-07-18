using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int healt;


    public void getDamage()
    {
        healt--;
        if(healt<= 0)
        {
            playerDie();
        }
        //todo: llamar algunos efectos y darle feedback al jugador
    }

    void playerDie()
    {
        //Todo: lanzar al jugador y activar su ragdoll
        Debug.Log("el jugador perdio :(");
    }

}
