using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explodeParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, Random.Range(7f,13f));
        rb.angularVelocity = Random.Range(-360f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
     
        if (transform.position.y < -6)
        {
            Miss();
        }
    }

    void Miss()
    {
        print(":(");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var obj = Instantiate(explodeParticles);
        obj.transform.position = transform.position; 
        Destroy(gameObject);
    }
}
