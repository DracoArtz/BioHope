using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField]
    GameObject asteroid;

    public Player player;

    public ScoreScript scoreScript;
    //Sprites
    public Sprite[] asteroidsSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AsteriodSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(asteroid);
            //meant to update score but doesn't
            scoreScript.UpdateScore(10);
        }
    }
    public void AsteriodSprite()
    {
        int spriteCount = asteroidsSprites.Length;
        int choosenSprite = Random.Range(0, spriteCount);
        asteroid.GetComponent<SpriteRenderer>().sprite = asteroidsSprites[choosenSprite];
    }
}
