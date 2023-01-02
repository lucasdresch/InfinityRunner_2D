using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    private Rigidbody2D rig;
    public float spdEnemy;
    public float enemyLifeTime;
    //create a type of enemies
    public bool enemyTypeFly;
 //   public Transform spawnPosition;
    private int flip = 1;
    public GameObject fireObj, firePos;

    
    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, enemyLifeTime);
        Fire();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //check enemy type

        //if typeFly = true
        if (enemyTypeFly == true) {
            rig.velocity = new Vector2(1 * spdEnemy, rig.velocity.y);
        } else if (enemyTypeFly == false) {
            //if flip
            rig.velocity = new Vector2(1 * spdEnemy * flip, rig.velocity.y);
        }
        //else if typeFly = false
        //code
    }
    void Fire() {
        Instantiate(fireObj, firePos.transform.position, transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (enemyTypeFly == false && collision.gameObject.layer == 9) {
            flip = flip * -1;
        }
    }

}
