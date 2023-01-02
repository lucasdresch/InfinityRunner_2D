using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesScript : MonoBehaviour {
    public List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    public float spawnTime;
    public float minPosY, maxPosY;
    private float posY;
    private BoxCollider2D bc2d;
    [SerializeField]
    private Transform spawnPlatPos;
    
    //enemy index
    //type of enemy
    private bool enemyFly;

    // Start is called before the first frame update
    void Start() {
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        SpawnEnemy();
        timeCount = timeCount - 10.0f;
    }

    // Update is called once per frame
    void Update() {
        timeCount += Time.deltaTime;
        if(timeCount >= spawnTime) {
        //    SpawnEnemy();
            timeCount = 0f;
        }
    }

    void RandomNum(float num1, float num2, float res, bool isInt) {
        res = Random.Range(num1, num2);
        float rest;
        if (isInt == true) {
            rest = res % 1;
            res = res - rest;
        }
    }
    void SpawnEnemy() {
        RandomNum(minPosY, maxPosY, posY, false);
        //check enemy type index
        int indexEnemy = 0;
        RandomNum(0, enemiesList.Count, indexEnemy, true);
        //get enemy type
        enemyFly = enemiesList[indexEnemy].GetComponent<EnemyScript>().enemyTypeFly;
        //if enemyFly true
        if (enemyFly == true) {
            Instantiate(enemiesList[indexEnemy], transform.position + new Vector3(0f, posY, 0f), transform.rotation);
        } else if (enemyFly == false) { //if enemyFly false
//            enemiesList[indexEnemy].GetComponent<EnemyScript>().spawnPosition.transform.position = spawnPlatPos.position;
            //instantiate in spawnPlatForEnemy position
            Instantiate(enemiesList[indexEnemy], spawnPlatPos.position, enemiesList[indexEnemy].transform.rotation);
        }

    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.name);

        if(collision.gameObject.layer == 8) {
            spawnPlatPos = collision.gameObject.GetComponent<PlatformScript>().SpawnEnemy[Random.Range(0,1)];
        }
    }
}
