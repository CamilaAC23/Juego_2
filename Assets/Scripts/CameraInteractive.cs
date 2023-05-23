using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    
    public string nextScene; // Nombre de la escena a la que deseas cambiar

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

                ObjectDestroy objectDestroy = hit.transform.GetComponent<ObjectDestroy>();
                Button button = hit.transform.GetComponent<Button>();

                if (objectDestroy != null)
                {
                    objectDestroy.Interact(); // Llama al método Interact del ObjectDestroy
                    objectsDestroyed++; // Incrementa el contador de objetos eliminados
                    Debug.Log("Objetos eliminados: " + objectsDestroyed);
                    displayText.text = "Score: " + objectsDestroyed + "/12";

                }
                else if (button != null)
                {
                    button.Interact(); // Llama al método Interact del Button

                    // Si el objeto interactivo es el que deseas utilizar para cambiar de escena
                    if (button.ShouldChangeScene())
                    {
                        // Cambiar a la siguiente escena
                        SceneManager.LoadScene(nextScene);
                    }
                }
                else
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                }

            }
        }
    }
}
