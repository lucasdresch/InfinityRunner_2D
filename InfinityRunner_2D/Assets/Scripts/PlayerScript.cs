using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    private Rigidbody2D rig;
    public Animator anim;

    public float speed;
    public float jumpForce;

    private bool isJumping;
    

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
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("JumpingBool", true);
            isJumping = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.layer == 8) { 
            anim.SetBool("JumpingBool", false);
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {
            isJumping = true;
        }
    }
}
