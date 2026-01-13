using System.Collections;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    [SerializeField]
    GameObject trainCar;
    [SerializeField]
    float difficultyModifier = 1.0f;

    float size = 10;
    bool isSpawning = false;

    Transform spawnpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpoint = transform;
        size = size * difficultyModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(size >= 1 && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnPart());
            size = size - 1;
        }
    }
    IEnumerator SpawnPart()
    {

        yield return new WaitForSeconds(.25f);
        var fb = Instantiate(trainCar, spawnpoint.position, spawnpoint.rotation);
        isSpawning = false;
    }
}
