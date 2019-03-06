using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 4;
    private Rigidbody2D rb;
    private Collider2D cd;

    public int l;
    public Vector2 a;

    public Vector2 b;


    void OnTriggerEnter2D(Collider2D other)
    {
        ContactPoint2D[] c = new ContactPoint2D[10];
        if (other.gameObject.tag == "Ground")
        {
            a = other.Distance(cd).pointB;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
            b = hit.normal;
            print(hit.transform);
            print(b);
            //Destroy(this.gameObject);
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {

        ContactPoint2D[] c = new ContactPoint2D[10];
        print("Hit");
        if (collision.gameObject.tag == "Ground")
        {
            collision.GetContacts(c);
            print(c[0].normal);

        }
    }*/
        


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
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
