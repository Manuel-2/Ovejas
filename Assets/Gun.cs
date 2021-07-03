using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    float nextTimeToFire;

    [SerializeField] GameObject impactEfect;
    [SerializeField] float impactForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage();
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce( (hit.point - this.transform.position).normalized * impactForce,ForceMode.Impulse);
            }

            GameObject hitEfect = Instantiate(impactEfect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitEfect, 1f);
            
        }
    }
}
