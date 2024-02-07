using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        rb.MovePosition(worldPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(":)");
        var food = collision.gameObject.GetComponent<Food>();
        food.Slice();
    }
}
