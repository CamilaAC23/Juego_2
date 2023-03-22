using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractive : MonoBehaviour
{
    // Start is called before the first frame update
   // 
   // [SerializeField]
    public Transform _object;
    public float rayDistance = 2.0f;
    string filtro = "Interactable";
    void Start()
    {
      //  camera = transform.Find("Camera");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.DrawRay(_object.position, _object.forward * rayDistance, Color.blue);

    //    if (Input.GetKeyDown(KeyCode.Mouse1))
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(_object.position, _object.forward, out hit, rayDistance, LayerMask.GetMask(filtro)))
    //        {
    //            Debug.Log(hit.transform.name);
    //            hit.transform.GetComponent<Interactable>().Interact();
    //        }
    //    }
    //}
   
    void Update()
    {
        Debug.DrawRay(_object.position, _object.forward * rayDistance, Color.blue);

        // Verifica si se presion� la tecla "E"
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Realiza el Raycast y verifica si colision� con alg�n objeto en la capa especificada
            RaycastHit hit;
            if (Physics.Raycast(_object.position, _object.forward, out hit, rayDistance, LayerMask.GetMask(filtro)))
            {
                // Imprime informaci�n en la consola
                Debug.Log("Direcci�n del Raycast: " + _object.forward);
                Debug.Log("Posici�n del objeto de origen: " + _object.position);
                Debug.Log("Capa del Raycast: " + LayerMask.GetMask(filtro));
                Debug.Log("Objeto colisionado: " + hit.transform.name);

                // Realiza la acci�n de Interact en el objeto colisionado
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }




}
