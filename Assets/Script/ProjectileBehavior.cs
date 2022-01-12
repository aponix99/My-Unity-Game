using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4.5f;
    public float time = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        if (time <= 1000f)
            time++;
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
