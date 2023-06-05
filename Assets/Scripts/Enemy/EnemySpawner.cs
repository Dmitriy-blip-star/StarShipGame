using UnityEngine;


[RequireComponent(typeof(BackgroundLoader))]

public class EnemySpawner : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] BackgroundLoader backgroundLoader;

    //public GameObject enemy;
    //public GameObject bossEnemy;
    float curentTime = 0;
    [SerializeField] float minTimer;
    [SerializeField] float maxTimer;
    
    float bossTime = 0;
    public float bossTimer = 10;

    float rndX;

    private void Awake()
    {
        if (backgroundLoader == null) backgroundLoader = GetComponent<BackgroundLoader>();
    }
    //private void BossEnemyGenerator()
    //{
    //    bossTime -= Time.deltaTime;
    //    if (bossTime <= 0)
    //    {
    //        bossTime = bossTimer;
    //        Instantiate(bossEnemy, new Vector2(rndX, 4f), transform.rotation);
    //    }
    //}

    private void EnemyGenerator()
    {
        rndX = Random.Range(-2.15f, 2.15f);

        GameObject enemy = backgroundLoader.GetRandomBackground();

        curentTime -= Time.deltaTime;
        if (curentTime <= 0)
        {
            curentTime = Random.Range(minTimer, maxTimer);
            Instantiate(enemy, new Vector3(rndX,6f), Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        EnemyGenerator();
        //BossEnemyGenerator();
    }

    public void DeleteEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
