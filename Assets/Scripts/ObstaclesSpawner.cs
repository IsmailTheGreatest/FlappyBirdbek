using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public float waitTime = 3.0f;
    private float time = 0f;
    public GameObject obstaclesGO;
     private List<GameObject> spawnedObjects = new List<GameObject>();
   
    public Player player;

    public float direction;
    // Update is called once per frame
    void Update()
    { if(!player.isDead){
   
        if(time > waitTime){
            GameObject go = Instantiate(obstaclesGO);
            go.transform.position = transform.position + new Vector3(0f, 
            Random.Range(-direction, direction), 0f);
            time = 0f;
            spawnedObjects.Add(go);

            Destroy(go, 10);//destroys after 5 seconds
        }
        time += Time.deltaTime;
    }
    else { foreach (GameObject obj in spawnedObjects){
        if(obj!=null){
            obj.GetComponent<Obstacles>().enabled = false;
        }
    }
    }
    }
}
