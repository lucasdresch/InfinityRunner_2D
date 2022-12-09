using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
    [Tooltip("Lista dos prefabs de plataformas")]
    public List<GameObject> platforms = new List<GameObject>();
    [SerializeField, Tooltip("Lista de Transforms das plataformas instanciadas na cena")]
    private List<Transform> currentPlatforms = new List<Transform>();

    private Transform player;
    private Transform currentPlatformsPoint;
    private int platformIndex;


    public GameObject plat;
    public float offset;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < platforms.Count; i++) {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, 0), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30f;
        }
        CurrentPlatPoint();
    }

    void CurrentPlatPoint() {
        currentPlatformsPoint = currentPlatforms[platformIndex].GetComponent<PlatformScript>().FinalPoint; //accessa a variavel do compnente (do tipo script) anexado ao objeto
    }
    // Update is called once per frame
    void Update() {
        Move();
    }
    public void Recycle(GameObject plats) {
        plats.transform.position = new Vector2(offset, 0f);
        offset += 30f;
    }
    void Move() {
        float distance = player.position.x - currentPlatformsPoint.position.x; //pega distancia entre o player e o finalPoint da plataforma atual
        if (distance >= 1) {
            Debug.Log("Passou pela plataforma " + currentPlatforms[platformIndex].name);
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;
            if(platformIndex > currentPlatforms.Count - 1) {
                platformIndex = 0;
            }
                CurrentPlatPoint();
        }
    }



}
