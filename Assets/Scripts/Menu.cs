using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EscenaUno()
    {
        SceneManager.LoadScene("Personaje");
    }

    public void EscenaDos(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
