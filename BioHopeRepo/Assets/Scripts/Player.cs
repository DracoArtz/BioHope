using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;
    public int score;

    [SerializeField]
    GameObject ship;
    float moveInputX;
    float moveInputY;
    float moveSpeed = 14.0f;
    Rigidbody2D rb2d;

    [SerializeField]
    GameObject bullet;

    public Transform spawnPoint;
    bool fired = false;

    [SerializeField]
    float bulletSpeed = 18.0f;

    int lives = 3;
    public GameObject[] livesIMG;
    bool canTakeDamage = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spawnPoint = transform;
        score = 0;
    }
    private void Update()
    {
        if (lives == 3) { }
        else if (lives == 2)
        {
            livesIMG[2].SetActive(false);
        }
        else if (lives == 1)
        {
            livesIMG[1].SetActive(false);
        }
        //else sceneManager.loadscene("GameOver")
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        moveInputX = ctx.ReadValue<Vector2>().x;
        moveInputY = ctx.ReadValue<Vector2>().y;
    }
    private void FixedUpdate()
    {

        if (ship.transform.position.y < 0 || moveInputY < 0) rb2d.linearVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);
        else rb2d.linearVelocity = new Vector2(moveInputX * moveSpeed, 0 * moveSpeed);
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (!fired) StartCoroutine(FireProjectile());
    }
    IEnumerator FireProjectile()
    {
        fired = true;
        var fb = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        fb.GetComponent<Rigidbody2D>().AddForce(spawnPoint.up * bulletSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.15f);
        fired = false;
    }
    IEnumerator TakeDamage()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            lives = lives - 1;
        }
        yield return new WaitForSeconds(2);
        canTakeDamage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TrainCars")
        {
            StartCoroutine(TakeDamage());
        }
    }
    //public void SetScore()
    //{
    //    scoreText.text = "Score:" + score.ToString();
    //}
}
