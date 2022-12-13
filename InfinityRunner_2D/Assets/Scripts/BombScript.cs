using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    private Rigidbody2D rig;
    public float forceX, forceY;

    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    void Update() {
        
    }
    void Fire() {
        rig.AddForce(new Vector2(forceX * -1, forceY), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }

}
