using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialTextScript : MonoBehaviour
{
    public TMP_Text tutorialText;
    public GameObject train;
    string[] tutorialCaptions = {
        "Hello, and welcome to BIOHOPE!",
        "Looks like you need to learn",
        "how to move your ship!",
        "This is simple. Just use W, A, S, and D!",
        "Great! Now for your weapons system.",
        "For this, you just need to press SPACE to shoot.",
        "Perfect. Now for a test.",
        "This is one of BioHope's deadly bioweapon carriers.",
        "Shoot it to blow it up.",
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
            Vector3 trainPos = new Vector3(2, 2, 0);
            Quaternion trainRot = new Quaternion(0, 0, 0, 0);
            var st = Instantiate(train, trainPos, trainRot);
            trainSpawned = true;
        }
        if (!train.activeInHierarchy)
        {
            learnedTest = true;
            Debug.Log("Killed Train");
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
