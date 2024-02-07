using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public  class FoodEntry
{
    public bool isBomb;
    public float x;
    public float fruitDelay;
    public bool isRandomPosition;
    public Vector2 velocity = new Vector2(0,10);
}

[System.Serializable]

public class Wave
{
    public List<FoodEntry> foods;
    
}

public class Spawner : MonoBehaviour
{
    public GameObject fruitPref;
    public float spawnSpeed = 1f;
    public int bombChance = 20;
    public GameObject bombPref;
    public GameObject bombParticles;

    public int currentWave;
    public List<Wave> waves;

    // Start is called before the first frame update
    async void Start()
    {

        //InvokeRepeating("Spawn", 0f, spawnSpeed);

        while (currentWave < waves.Count)
        {

            var wave = waves[currentWave];
            for(int i = 0; i < wave.foods.Count; i++)
            {
                var food = wave.foods[i];
                await new WaitForSeconds(food.fruitDelay);

                var prefab = food.isBomb ? bombPref : fruitPref;
                var go = Instantiate(prefab);
                var x = food.isRandomPosition ? Random.Range(-5f, 5f) : food.x;
                go.transform.position = new Vector3(x, -5, 0);
                go.GetComponent<Rigidbody2D>().velocity = food.velocity;
                
            }

                //var prefab = waves[currentWave].isBomb ? bombPref : fruitPref;
                //var obj = Instantiate(prefab);
                //var x = waves[currentWave].x;
                //obj.transform.position = new Vector3(x, -5, 0);
            
            
            await new WaitForSeconds(3f);
            currentWave++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        var prefab = Random.Range(0, 100) > bombChance ? fruitPref : bombPref;

        var obj = Instantiate(prefab);
        var x = Random.Range(-5f, 5f);
        obj.transform.position = new Vector3(x, -5, 0);
    }
}
