using System.Collections;
using UnityEngine;

public class TrainCarScript : MonoBehaviour
{
    [SerializeField]
    GameObject trainCar;
    float speed = 10;

    int dirX = -1;
    int dirY = -1;
    Rigidbody2D rb2d;

    public GameObject asteroid;
    Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(trainCar.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        spawnPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
        rb2d.linearVelocity = new Vector2(dirX * speed, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            dirX = -dirX;
            if (trainCar.transform.position.y >= 6 || trainCar.transform.position.y <= -6)
            {
                dirY = -dirY;
                trainCar.transform.position = new Vector2(trainCar.transform.position.x,
                                               trainCar.transform.position.y + dirY);
            }
            else trainCar.transform.position = new Vector2(trainCar.transform.position.x,
                                               trainCar.transform.position.y + dirY);
        }
        if (collision.gameObject.tag == "bullet")
        {
            Instantiate(asteroid, spawnPoint.gameObject.transform);
            Destroy(collision.gameObject);
            trainCar.GetComponent<SpriteRenderer>().enabled = false;
            trainCar.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
