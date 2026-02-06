using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialTextScript : MonoBehaviour
{
    public TMP_Text tutorialText;
    public GameObject train;
    public GameObject asteroid;
    string[] tutorialCaptions = {
        "Hello, and welcome to BIOHOPE!", //0
        "Looks like you need to learn",
        "how to move your ship!",
        "This is simple. Just use W, A, S, and D!",
        "Great! Now for your weapons system.",
        "For this, you just need to press SPACE to shoot.",//5
        "Perfect. Now for a test.",
        "This is one of BioHope's deadly bioweapon carriers.",
        "Shoot it to blow it up.",
        "You are almost ready.",
        "Trains turn into debris when destroyed.", //10
        "Debris and asteroids can be destroyed, too.",
        "Shoot the debris.",
        "You are ready.",
        "Don't let the train hit you, it is dangerous.",
        "Beware of it's erratic movement.", //15
        "It will dodge asteroids and debris to reach you qucker.", 
        "Prepare to save countless lives, and countless ecosystems.",
        "(Click the menu button in the bottom left to exit tutorial)",
    };
    int captionValue = 1;
    bool wKey = false;
    bool aKey = false;
    bool sKey = false;
    bool dKey = false;
    bool learnedMove = false;
    bool learnedShoot = false;
    bool learnedTest = false;
    bool trainSpawned = false;
    bool learnedDebris = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialText.text = tutorialCaptions[0];
        StartCoroutine(UpdateText(captionValue));
    }

    // Update is called once per frame
    void Update()
    {
        if(captionValue == 4 && !learnedMove)
        {
            StopAllCoroutines();
            TutorialMove();
        }
        if(captionValue == 6 && !learnedShoot)
        {
            StopAllCoroutines();
            TutorialShoot();
        }
        if(captionValue == 8 && !learnedTest)
        {
            StopAllCoroutines();
            TutorialTest();
        }
        if(captionValue == 12 && !learnedDebris)
        {
            StopAllCoroutines();
            TutorialDebris();
        }
        if(captionValue == 19)
        {
            StopAllCoroutines();
        }
    }
    private void TutorialMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            wKey = true;
            Debug.Log("W key");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aKey = true;
            Debug.Log("A key");
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            sKey = true;
            Debug.Log("S key");
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        { 
            dKey = true;
            Debug.Log("D key");
        }
        if(wKey && aKey && sKey && dKey)
        {
            learnedMove = true;
            StartCoroutine(UpdateText(captionValue));
            Debug.Log("Tutorial Move Complete");
        }
        Debug.Log("tutorial move");
    }

    private void TutorialShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            learnedShoot = true;
            Debug.Log("Space key");
            StartCoroutine(UpdateText(captionValue));
        }
        
    }
    private void TutorialTest()
    {

        if (!trainSpawned)
        {
            Vector3 trainPos = new Vector3(1, 1, 0);
            Quaternion trainRot = new Quaternion(0, 0, 0, 0);
            var st = Instantiate(train, trainPos, trainRot);
            trainSpawned = true;
        }
        if (!train.activeInHierarchy && trainSpawned == true)
        {
            learnedTest = true;
            Debug.Log("Killed Train");
            StartCoroutine(UpdateText(captionValue));
        }
        
    }
    private void TutorialDebris()
    {
        if(!asteroid.activeInHierarchy && trainSpawned == true && !train.activeInHierarchy)
        {
            learnedDebris = true;
            Debug.Log("Destroyed Debris");
            StartCoroutine(UpdateText(captionValue));
        }
    }

IEnumerator UpdateText(int value)
    {
        yield return new WaitForSeconds(3);
        tutorialText.text = tutorialCaptions[value];
        captionValue = captionValue + 1;
        StartCoroutine(UpdateText(captionValue));
    }
}
