using UnityEngine;

public class ParticleScript_A : MonoBehaviour
{
    public float destroyRate;

    void Start()
    {
        Destroy(gameObject, destroyRate);
    }
}
