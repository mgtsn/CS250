using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 4;
    private Rigidbody2D rb;

    public int l;
    public Vector3 a;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }


        //length = collision.contacts.Length;
        //a = collision.contacts[0].normal;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(new Vector2(speed * Time.deltaTime, 0)); 


 
    }
}
