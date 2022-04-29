using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    //GameManager gameManager;

    //WaveManagerScript waveManager;

    //PotionScript potionScript;

    //public List<Color> colors = new List<Color>();

    ////variables for the calculation of the movement of the slime using it's rigidbody and addforce
    //public float moveAmountX;
    //public float moveAmountY;
    //public float startSpeed;

    ////variables that are set at Start and hold the position and rotation of the slime. can be used later when implementing multiple slime spawns
    //Vector3 slimePosition;
    //Quaternion slimeRotation;

    ////the rigidbody
    //Rigidbody rb;

    ////variables for the timer that controls the impulse boost that makes the slime jiggle
    //public float timerCount;
    //public float pulseTimer;

    ////the direction that the slime will move in
    //Vector3 moveDirection;

    //Material mat;

    //[SerializeField]
    //int randomInt;

    //public bool canShift = true;

    //[SerializeField]
    //int vulnerability;

    //void Start()
    //{
    //    gameManager = GameManager.Instance;
    //    waveManager = WaveManagerScript.Instance;

    //    mat = GetComponent<Renderer>().material;

    //    colors.Add(new Color32(255, 0, 0, 170)); //red
    //    colors.Add(new Color32(0, 0, 255, 170)); //blue
    //    colors.Add(new Color32(255, 255, 0, 170)); //yellow
    //    colors.Add(new Color32(0, 255, 0, 170)); //green
    //    colors.Add(new Color32(255, 128, 0, 170)); //orange
    //    colors.Add(new Color32(128, 0, 255, 170)); //purple

    //    rb = GetComponent<Rigidbody>();//sets the rigidbody

    //    slimePosition = GetComponent<Transform>().position;// sets the position
    //    slimeRotation = GetComponent<Transform>().rotation;// sets the rotation

    //    moveAmountX = startSpeed; //ensures that the movement always starts on the X-axis
    //    moveAmountY = 0; //ensures that the movement never starts on the Y-axis       

    //    ChangeColour();
    //}

    //private void ChangeColour()
    //{
    //    if (gameObject != null && canShift)
    //    {
    //        canShift = false;

    //        switch (gameManager.gameStage)
    //        {
    //            case GameStage.EarlyGame:

    //                randomInt = Random.Range(0, 3);
    //                break;

    //            case GameStage.MidGame:

    //                randomInt = Random.Range(0, 6);
    //                break;

    //            case GameStage.LateGame:

    //                randomInt = Random.Range(3, 6);
    //                break;
    //        }
    //    }
    //}

    //private void Update()
    //{
    //    switch (randomInt)
    //    {
    //        case 0:
    //            {
    //                gameObject.tag = "RedSlime";
    //                mat.color = colors[0];
    //                vulnerability = 0;
    //            }
    //            break;

    //        case 1:
    //            {
    //                gameObject.tag = "BlueSlime";
    //                mat.color = colors[1];

    //                vulnerability = 1;
    //            }
    //            break;

    //        case 2:
    //            {
    //                gameObject.tag = "YellowSlime";
    //                mat.color = colors[2];

    //                vulnerability = 2;
    //            }
    //            break;

    //        case 3:
    //            {
    //                gameObject.tag = "GreenSlime";
    //                mat.color = colors[3];

    //                vulnerability = 3;
    //            }
    //            break;

    //        case 4:
    //            {
    //                gameObject.tag = "OrangeSlime";
    //                mat.color = colors[4];

    //                vulnerability = 4;
    //            }
    //            break;

    //        case 5:
    //            {
    //                gameObject.tag = "PurpleSlime";
    //                mat.color = colors[5];

    //                vulnerability = 5;
    //            }
    //            break;
    //    }

    //    ChangeColour();
    //}


    //private void FixedUpdate() //fixedupdate is used for phsyics based movements given it's regular intervals, rather than based on framerate
    //{
    //    pulseTimer += Time.fixedDeltaTime; //timer that counts up based on fixedDeltatime

    //    if (pulseTimer > timerCount)
    //    {
    //        pulseTimer *= 0; //when the timere exceeds the timerCount, it is multiplied by 0. I have had issues in the past where timer = 0 causes it to stick.

    //        StartCoroutine(MovePulse()); //the coroutine that causes the boost of speed
    //    }

    //    moveDirection = new Vector3(-moveAmountX, 0, moveAmountY); //the vector that designates the direction the object moves in

    //    rb.AddForce(moveDirection); //the application of force to the rigidbody
    //}

    //private IEnumerator MovePulse() //this creates a pulse of movement that allows for constant movement. addforce with an impulse type would allows for a slide motion, but not movement
    //{
    //    moveAmountX *= 2f; //multiplies moveamount by 2
    //    moveAmountY *= 2f; //multiplies moveamount by 2

    //    yield return new WaitForSeconds(.5f); //the reason I use a coroutine instead of a regular method with another timer is that it can be simply built in to the delay

    //    moveAmountX /= 2f; //divides moveamount by 2
    //    moveAmountY /= 2f; //divides moveamount by 2
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Potion"))
    //    {
    //        potionScript = other.gameObject.GetComponent<PotionScript>();

    //        if (vulnerability == potionScript.potionValue && !potionScript.isCarried) //ensures that the potion has been thrown
    //        {
    //            moveAmountX = startSpeed;
    //            moveAmountY = 0;
    //            pulseTimer = 0;
    //            canShift = true;                
    //            waveManager.customerCount--;
    //            gameObject.SetActive(false); //disables the object, allowing it to be called again by the object pooler
    //        }
    //    }

    //    if (other.CompareTag("RotateNode")) //detects if it has hit the rotate node collider
    //    {
    //        moveAmountY = moveAmountX;//this sets the vertical movement to the same as the X-axis movement, causing it to move the same amount on the Y-axis
    //        moveAmountX = 0; //stops all X-axis related movement
    //    }
    //}
}
