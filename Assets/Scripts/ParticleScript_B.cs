using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript_B : MonoBehaviour
{
    public float WaitTime;
    public GameObject Enemy_A;

    private void Start()
    {
        StartCoroutine(WaitForParticle());
    }

    private IEnumerator WaitForParticle()
    {
        yield return new WaitForSecondsRealtime(WaitTime);
        Instantiate(Enemy_A, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}