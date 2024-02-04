using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPref;
    public float spawnSpeed = 1f;
    public int bombChance = 20;
    public GameObject bombPref;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Spawn", 0f, spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        var prefab = Random.Range(0,100) > bombChance ? fruitPref : bombPref;

        var obj = Instantiate(prefab);
        var x = Random.Range(-5f, 5f);
        obj.transform.position = new Vector3(x, -5, 0);
    }
}
