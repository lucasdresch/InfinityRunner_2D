using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

    public List<GameObject> platforms = new List<GameObject>();
    public GameObject plat;
    public float offset;

    // Start is called before the first frame update
    void Start() {
        for(int i = 0; i < platforms.Count; i++) {
            Instantiate(platforms[i], new Vector2(i * 30, 0), transform.rotation);
            offset += 30f;
        }
    }

    // Update is called once per frame
    void Update() {
        test();
    }
    public void Recycle(GameObject plats) {
        plats.transform.position = new Vector2(offset, 0f);
        offset += 30f;
    }
    public void test() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Recycle(plat);
        }
    }


}
