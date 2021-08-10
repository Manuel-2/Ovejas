using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float minDelay, MaxDelay;
    float timeDelay;
    bool isFlikering;

    private void Update()
    {
        if(isFlikering == false)
        {
            StartCoroutine("flikering");
        }
    }

    IEnumerator flikering()
    {
        isFlikering = true;
        light.enabled = false;
        timeDelay = Random.Range(minDelay,MaxDelay);
        yield return new WaitForSeconds(timeDelay);
        light.enabled = true;
        timeDelay = Random.Range(minDelay, MaxDelay);
        yield return new WaitForSeconds(timeDelay);
        isFlikering = false;

    }

}
