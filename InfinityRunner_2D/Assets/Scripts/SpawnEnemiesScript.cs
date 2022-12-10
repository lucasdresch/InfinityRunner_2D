using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesScript : MonoBehaviour {
    public List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    public float spawnTime;
    public float minPosY, maxPosY;
    private float posY;
    
    //enemy index
    //type of enemy
    private bool enemyFly;

    // Start is called before the first frame update
    void Start() {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update() {
        timeCount += Time.deltaTime;
        if(timeCount >= spawnTime) {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void RandomNum(float num1, float num2, float res) {
        res = Random.Range(num1, num2);
    }

    void SpawnEnemy() {
        //check enemy type index
            //get enemy type
        //if enemyFly true
            RandomNum(minPosY, maxPosY, posY);
            Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0f, posY, 0f), transform.rotation);
        //if enemyFly false
            //code
    }
}
