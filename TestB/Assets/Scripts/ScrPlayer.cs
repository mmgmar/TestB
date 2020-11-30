using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{
    [SerializeField]
    float forsa = 3;
    float x, y;  // variables per guardar lectura dels cursors

    // Per accedir al component RigidBody:
    Rigidbody2D rb; 
    ScrPickup scrP;
    AudioSource a; // per accedir a l'àudio

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ara rb apunta al component rigidBody del player
        a = GetComponent<AudioSource>(); 
        // print("En aquesta escena: " + ScrControlGame.pickups);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");  // llegim moviment horitzontal
        y = Input.GetAxis("Vertical");    // llegim moviment vertical
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(x*forsa, y*forsa));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print(collision.name);
        // if (collision.tag == "pickup") Destroy(collision.gameObject);
        if (collision.CompareTag("pickup"))
        {
            AudioSource audioP; // per accedir a l'àudio del pickup

            audioP = collision.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioP.clip, Camera.main.transform.position);


            scrP = collision.GetComponent<ScrPickup>();
            ScrControlGame.punts += scrP.valor;
            Destroy(collision.gameObject);
            ScrControlGame.pickups--;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        a.Play();
    }
}
