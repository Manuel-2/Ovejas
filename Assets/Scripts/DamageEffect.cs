using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] Image damageImage;
    //1 == half life | 2 == player die
    [SerializeField] Color[] colors = new Color[2];
    public float timeToDisapear;

    private void Awake()
    {
        damageImage.color = new Color(damageImage.color.r, damageImage.color.g, damageImage.color.b, 0);
    }

    public void ActivateDamageEfect(int playerHealt)
    {
        switch (playerHealt)
        {
            case 1:
                damageImage.color = colors[0];
                break;
            case 0:
                damageImage.color = new Color(colors[1].r, colors[1].g, colors[1].b, 1);
                break;
        }
    }

    public void RecoverHealt()
    {
        damageImage.DOFade(0f, timeToDisapear);
    }
}
