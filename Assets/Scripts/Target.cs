
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float healt;

    public void TakeDamage()
    {
        transform.localScale = transform.localScale * 0.95f;
        //Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    
}
