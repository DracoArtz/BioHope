using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }
    private void Update()
    {
        scoreText.SetText("Score: " + score.ToString());
    }
    // Update is called once per frame
    public void UpdateScore(int value)
    {
        score = score + value;
    }
}
