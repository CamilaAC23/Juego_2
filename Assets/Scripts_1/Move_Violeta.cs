using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_1 : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    private Vector3 playerInput;

    public CharacterController player;
    public float playerSpeed;
    public float gravity;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float sliceVelocity;
    public float slopeForceDown;

    //Variables animaciones
    public Animator playeranimatorController;

    // Cargamos el componente CharacterController en la variable player al iniciar el script
    void Start()
    {
        player = GetComponent<CharacterController>();
        playeranimatorController = GetComponent<Animator>();
    }

    // Bucle de juego que se ejecuta en cada frame
    void Update()
    {
        //Guardamos el valor de emtrada horizontal y vertical para el movimiento
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        playeranimatorController.SetFloat("PlayerWalkVelocity", playerInput.magnitude * playerSpeed);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * playerSpeed * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }

    void camDirection() 
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    //Función habilidades jugador
    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            playeranimatorController.SetTrigger("PlayerJump");
        }
    }
    //Función para la gravedad
    void SetGravity()
    {
        movePlayer.y = -gravity * Time.deltaTime;

        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            playeranimatorController.SetFloat("PlayerVerticalVelocity", player.velocity.y);
        }
        playeranimatorController.SetBool("IsGrounded", player.isGrounded);
        SlideDown();
    }

    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit && Vector3.Angle(Vector3.up, hitNormal) < 90 && player.isGrounded;
        Debug.Log("GRADOS SUELO" + Vector3.Angle(Vector3.up, hitNormal));

        if (isOnSlope)
        {
            movePlayer.x += ((1f - hitNormal.y) * hitNormal.x) * sliceVelocity;
            movePlayer.z += ((1f - hitNormal.y) * hitNormal.z) * sliceVelocity;

            movePlayer.y += slopeForceDown;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    private void OnAnimatorMove()
    {
         
    }
}
