using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CameraInteractive : MonoBehaviour
{
    // [SerializeField]
    public TextMeshProUGUI displayText; // O Text si est�s utilizando el componente Text

    public Transform _object;
    public float rayDistance = 2.0f;
    string filtro = "Interactable";
    private int objectsDestroyed = 0; //CONTADOR
    void Start()
    {
      //  camera = transform.Find("Camera");
    }
   
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
                //hit.transform.GetComponent<Interactable>().Interact();

                //Interactable interactable = hit.transform.GetComponent<Interactable>();
                //if (interactable != null)
                //{
                //   interactable.Interact();
                //    objectsDestroyed++; // Incrementa el contador de objetos eliminados
                //    Debug.Log("Objetos eliminados: " + objectsDestroyed);
                //}

                ObjectDestroy objectDestroy = hit.transform.GetComponent<ObjectDestroy>();
                if (objectDestroy != null)
                {
                    objectDestroy.Interact(); // Llama al m�todo Interact del ObjectDestroy
                    objectsDestroyed++; // Incrementa el contador de objetos eliminados
                    Debug.Log("Objetos eliminados: " + objectsDestroyed);
                    displayText.text = "Score: " + objectsDestroyed + "/12";

                }
                else
                {
                    // Aqu� puedes agregar cualquier acci�n adicional para los objetos que no se eliminan
                    // Por ejemplo, puedes llamar a un m�todo espec�fico en el objeto colisionado
                    hit.transform.GetComponent<Interactable>().Interact();
                }

            }
        }
    }
}
