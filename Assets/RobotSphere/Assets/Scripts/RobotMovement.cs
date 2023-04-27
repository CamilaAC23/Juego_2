using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonGracePeriod;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    public Transform _object;
    public float rayDistance = 7.0f;
    string filtro = "Interactable";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //Normaliza la magnitud del vector de moviemiento para  que se ajuste según la velocidad del personaje
        //para evitar que el personaje se mueva más rápido en diagonal
        // Mathf.Clamp01 --> Si el valor es negativo, se devuelve cero. Si el valor es mayor que uno, se devuelve uno.
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        Debug.DrawRay(_object.position,_object.forward*rayDistance,Color.red);
        //se calcula la velocidad en el eje Y del personaje en función de la gravedad y el tiempo
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit hit;
            if (Physics.Raycast(_object.position, _object.forward, out hit, rayDistance, LayerMask.GetMask(filtro)))
            {

                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }

        //Luego se verifica si el personaje está en contacto con el suelo o no, y se actualiza "lastGroundedTime" si lo está.
        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }
        //Si se presiona el botón de salto, se actualiza "jumpButtonPressedTime"
        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;

        }

        //Si ha pasado menos tiempo que el periodo de gracia desde el último contacto con el suelo y desde la última vez
        //que se presionó el botón de salto, se ajusta la velocidad en el eje Y del personaje para saltar
        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;


            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;

            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("Walk_Anim", true);
            //animator.SetBool("Roll_Anim", true);
            //Crea una rotación con las direcciones en X,Y,Z.
            // eje Z se alineará con forward, el eje X se alineará con el producto cruz entre forward y up, y el eje Y se alineará con el producto cruzado entre Z y X.
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //Gira la matriz de transformación un paso más cerca de la del objetivo
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Roll_Anim", false);
           
        }

     
    }
}
