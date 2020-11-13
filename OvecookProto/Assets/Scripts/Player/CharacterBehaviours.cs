using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviours : MonoBehaviour
{

    public AudioClip PickSound;
    public AudioClip DropSound;
    AudioSource sounds;
    [SerializeField] private GameManager m_GameManager;

    [Space]
    [Header("turn")]
    [SerializeField] private float turnShmoothTime = 0.1f;
    [SerializeField] private float turnShmoothVelocity;

    [Space]
    [Header("Player Component")]
    [SerializeField] private CharacterController m_Controller;
    [SerializeField] private Camera cam;

    [Space]
    [Header("Environment Check Properties")]
    [Tooltip("Position of the gameObject who check if the player touch the ground")]
    public Transform groundCheck;

    [Tooltip("the layer of the ground")]
    public LayerMask groundMask;

    [Tooltip("how far the player can check beside his feet")]
    [SerializeField] private float groundDistance;

    [Tooltip("Boolean variable how indicate if the player touch the ground or not")]
    [SerializeField] private bool isGrounded;

    [Space]
    [Header("Movement Variable")]
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float speedMouvement;
    [SerializeField] private float m_JumpPower = 5f;
    [SerializeField] private float gravity = -9.81f;

    [Space]
    [Header("Interact")]
    [SerializeField] GameObject interactGO;
    [SerializeField] Transform interactTransform;
    [SerializeField] Vector3 castGizmoCube;
    [SerializeField] float castRadius;
    [SerializeField] LayerMask interactLayer;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        cam = Camera.main;
        m_Controller = GetComponent<CharacterController>();
        groundCheck = transform.GetChild(0);
    }
    GameObject inHand = null;
    // Update is called once per frame
    void Update()
    {
        PhysicsCheck();
        if (isGrounded)
        {
            PlayerMovement();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (interactGO != null)
            {
               
                if (inHand == null)
                {
                    Droppable droppableInHand = interactGO.GetComponent<ZoneController>().OnPick();
                    sounds.PlayOneShot(PickSound);
                    //interactGO.GetComponent<Collider>().enabled = false;
                    inHand = droppableInHand.gameObject;
                }
                else
                {
                    Droppable tempDrop = inHand.GetComponent<Droppable>();
                    interactGO.GetComponent<ZoneController>().OnDrop(tempDrop);
                    sounds.PlayOneShot(DropSound);
                    inHand = null;
                    
                }
            }
        }
    }

    void PlayerMovement()
    {

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        if(movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.gameObject.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnShmoothVelocity, turnShmoothTime);

            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            m_Controller.Move(moveDirection.normalized * speedMouvement * Time.deltaTime);
        }
        
        velocity.y += gravity * Time.deltaTime;
        m_Controller.Move(velocity * Time.deltaTime);
    }


    private void PhysicsCheck()
    {
        Collider[] listOfInteract = Physics.OverlapSphere(interactTransform.position, castRadius, interactLayer);
        if (listOfInteract.Length != 0)
        {
            
            interactGO = listOfInteract[0].gameObject;
        }
        else
        {
            interactGO = null;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1.5f;
        }
    }
}
