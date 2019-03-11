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


    Vector2 RayC()
    {
        if (transform.rotation.z == 0)
        {
            return new Vector2(1, 0);
        }
        else if (transform.rotation.z == 45)
        {
            return new Vector2(1, 1);
        }
        else if (transform.rotation.z == 90)
        {
            return new Vector2(0, 1);
        }
        else if (transform.rotation.z == 135)
        {
            return new Vector2(-1, 1);
        }
        else if (transform.rotation.z == 180)
        {
            return new Vector2(-1, 0);
        }
        else if (transform.rotation.z == 225)
        {
            return new Vector2(-1, -1);
        }
        else if (transform.rotation.z == 270)
        {
            return new Vector2(0, -1);
        }
        else
        {
            return new Vector2(1, -1);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        ContactPoint2D[] c = new ContactPoint2D[10];
        if (other.gameObject.tag == "Ground")
        {
            a = other.Distance(cd).pointB;

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), RayC());
            b = hit.normal;
            float ag = Mathf.Atan(b.y / b.x) * Mathf.Rad2Deg;
            print(b);
            print(ag);

            //Destroy(this.gameObject);
        }
    }


        


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
