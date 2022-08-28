using UnityEngine;

public class WarninTextureController : MonoBehaviour
{
    [SerializeField] private GameObject danger;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;
    [SerializeField] private RocketClonerController _rocketClonerController;
    [HideInInspector] public float turningOnTime = 3f;
    [HideInInspector] public float turningOnMoment;
    private SpriteRenderer dangerRenderer;
    private SpriteRenderer arrowRenderer;
    private bool moveAtoB = true;
    private bool moveBtoA;
    private int index;

    private float timerForOpen;
    private float timerForClose;
    private bool isTurnedOn;
    private bool isTurnedOff = true;

    void Start()
    {
        turningOnMoment = _rocketClonerController._timeLimit - turningOnTime;
        dangerRenderer = danger.GetComponent<SpriteRenderer>();
        arrowRenderer = arrow.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        ArrowMovement();
        CheckTurnOnTiming();
    }

    private void ArrowMovement()
    {
        if (moveAtoB)
        {
            arrow.transform.Translate(Vector3.right * (speed * Time.deltaTime));

            if (Vector3.Distance(arrow.transform.position, pointB.transform.position) <= 0.1f)
            {
                moveBtoA = true;
                moveAtoB = false;
            }
        }
        
        else if (moveBtoA)
        {
            arrow.transform.Translate(Vector3.left * (speed * Time.deltaTime));

            if (Vector3.Distance(arrow.transform.position, pointA.transform.position) <= 0.1f)
            {
                moveAtoB = true;
                moveBtoA = false;
            }
        }
    }


    private void WarningMessageTurnOn()
    {
        dangerRenderer.enabled = true;
        arrowRenderer.enabled = true;
    }

    private void WarningMessageTurnOff()
    {
        dangerRenderer.enabled = false;
        arrowRenderer.enabled = false;
    }

    private void CheckTurnOnTiming()
    {
        if (isTurnedOff)
        {
            if (timerForOpen >= turningOnMoment)
            {
                WarningMessageTurnOn();
                timerForOpen = 0f;
                isTurnedOn = true;
                isTurnedOff = false;
            }
        
            timerForOpen += Time.deltaTime;
        }
        
        else if (isTurnedOn)
        {
            if (timerForClose >= turningOnTime)
            {
                WarningMessageTurnOff();
                timerForClose = 0f;
                isTurnedOff = true;
                isTurnedOn = false;
            }
        
            timerForClose += Time.deltaTime;
        }

    }
}
