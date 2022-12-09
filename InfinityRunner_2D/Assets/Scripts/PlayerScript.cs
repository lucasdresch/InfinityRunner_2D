using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D rig;
    public float speed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }
    // Update is called once per frame
    void Update() {
        Jump();
    }
    public void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

}
