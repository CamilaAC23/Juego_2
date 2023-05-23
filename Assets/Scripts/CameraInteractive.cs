using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CameraInteractive : MonoBehaviour
{
    // [SerializeField]
    public TextMeshProUGUI displayText; // O Text si estás utilizando el componente Text

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

        // Verifica si se presionó la tecla "E"
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Realiza el Raycast y verifica si colisionó con algún objeto en la capa especificada
            RaycastHit hit;
            if (Physics.Raycast(_object.position, _object.forward, out hit, rayDistance, LayerMask.GetMask(filtro)))
            {
                // Imprime información en la consola
                Debug.Log("Dirección del Raycast: " + _object.forward);
                Debug.Log("Posición del objeto de origen: " + _object.position);
                Debug.Log("Capa del Raycast: " + LayerMask.GetMask(filtro));
                Debug.Log("Objeto colisionado: " + hit.transform.name);

                // Realiza la acción de Interact en el objeto colisionado
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
                    objectDestroy.Interact(); // Llama al método Interact del ObjectDestroy
                    objectsDestroyed++; // Incrementa el contador de objetos eliminados
                    Debug.Log("Objetos eliminados: " + objectsDestroyed);
                    displayText.text = "Score: " + objectsDestroyed + "/12";

                }
                else
                {
                    // Aquí puedes agregar cualquier acción adicional para los objetos que no se eliminan
                    // Por ejemplo, puedes llamar a un método específico en el objeto colisionado
                    hit.transform.GetComponent<Interactable>().Interact();
                }

            }
        }
    }
}
