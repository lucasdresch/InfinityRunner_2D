using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
    
    private Transform targetCamera;
    public float speedCam;
    public float offsetX;

    // Start is called before the first frame update
    void Start() {
        targetCamera = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        Vector3 newCamPos = new Vector3(targetCamera.position.x + offsetX, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, speedCam * Time.deltaTime);
    }
}
