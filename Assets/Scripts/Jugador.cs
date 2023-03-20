using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//cinemachine
public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController _jugador;//Mover
    private float _velocidad;//Mover
    private Vector3 _moveAxis;//Mover

    private Vector3 _camForward, _camRight, _direccion; //Camara
    private Camera _camera; //Camara

    [SerializeField] private float _gravity;
    [SerializeField] private float _fallVelocity;
    [SerializeField] private float _jumpForce;

    ////bala
    //public Transform _setPoint;
    //public GameObject _bala;

    private void Awake()
    {
        _jugador = GetComponent<CharacterController>();//Mover
        _velocidad = 20f;//Mover
        _camera = Camera.main; //Camara
        _gravity = 60f; //9.8 
        _jumpForce = 10f;       
    }

    // Update is called once per frame
    void Update()
    {
         //Gun();
        _moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Mover
       

        if (_moveAxis.magnitude > 1)//Mover
            _moveAxis = _moveAxis.normalized * _velocidad;//Mover
        else//Mover
            _moveAxis = _moveAxis * _velocidad;//Mover


        cameraDirection();

        _direccion = _moveAxis.x * _camRight + _moveAxis.z * _camForward; //Camara

        transform.LookAt(transform.position + _direccion);
        
        Gravedad();
        Jump();
        _jugador.Move(_direccion * Time.deltaTime);//Mover

    }

    private void cameraDirection() //Camara
    {
        _camForward = _camera.transform.forward.normalized;
        _camRight = _camera.transform.right.normalized;
        _camForward.y = 0;
        _camRight.y = 0;
        
    }

    private void Gravedad()
    {
        if (_jugador.isGrounded)
        {
            _fallVelocity = -_gravity * Time.deltaTime;
        }
        else
        {
            _fallVelocity -= _gravity * Time.deltaTime;
        }
        _direccion.y = _fallVelocity;
    }

    private void Jump()
    {
        if (_jugador.isGrounded && Input.GetKey(KeyCode.Space))
        {
            _fallVelocity = _jumpForce;
            _direccion.y = _fallVelocity;
        }
    }
    //private void Gun()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        Instantiate(_bala, _setPoint.transform.position, _setPoint.transform.rotation);

    //    }

    //}
}
