using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rig;
    public float spdEnemy;
    public float enemyLifeTime;
    //create a type of enemies

    
    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, enemyLifeTime);
    }

    // Update is called once per frame
    void FixedUpdate() {
        rig.velocity = Vector2.left * spdEnemy;
    }
}
