using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour
{
    public Vector2 center;
    public Vector2 size;
    public static Vector2 sizeForOtherUse;
    private GameObject SpawnedAsteroid;
    public GameObject Asteroid_A;
    public GameObject Asteroid_B;
    public GameObject Asteroid_C;
    public GameObject Asteroid_D;
    public GameObject Asteroid_E;
    private GameObject[] Ast_A;
    private GameObject[] Ast_B;
    private GameObject[] Ast_C;
    private GameObject[] Ast_D;
    private GameObject[] Ast_E;
    private int AsteroidsOnScreen;
    public int NumberofAsteroids;
    private int AsteroidType;

    void CheckAsteroidsOnScreen()
    {
        Ast_A = GameObject.FindGameObjectsWithTag("Asteroid_A");
        Ast_B = GameObject.FindGameObjectsWithTag("Asteroid_B");
        Ast_C = GameObject.FindGameObjectsWithTag("Asteroid_C");
        Ast_D = GameObject.FindGameObjectsWithTag("Asteroid_D");
        Ast_E = GameObject.FindGameObjectsWithTag("Asteroid_E");
        AsteroidsOnScreen = Ast_A.Length + Ast_B.Length + Ast_C.Length + Ast_D.Length + Ast_E.Length;
    }

    private void Awake()
    {
        sizeForOtherUse = size;
    }

    public void Update()
    {
        CheckAsteroidsOnScreen();

        while (AsteroidsOnScreen < NumberofAsteroids)
        {
            AsteroidType = Random.Range(1, 101);
            if (AsteroidType >= 1 && AsteroidType <= 50)
            {
                SpawnedAsteroid = Asteroid_A;
            }
            if (AsteroidType >= 50 && AsteroidType <= 70)
            {
                SpawnedAsteroid = Asteroid_B;
            }
            if (AsteroidType >= 70 && AsteroidType <= 84)
            {
                SpawnedAsteroid = Asteroid_C;
            }
            if (AsteroidType >= 84 && AsteroidType <= 99)
            {
                SpawnedAsteroid = Asteroid_D;
            }
            if (AsteroidType == 100)
            {
                SpawnedAsteroid = Asteroid_E;
            }

            CheckAsteroidsOnScreen();
            
            Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
            Instantiate(SpawnedAsteroid, pos, Quaternion.identity);
        }
    }
}   

