using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_1 : MonoBehaviour
{
    public void EscenaUno()
    {
        SceneManager.LoadScene("Low Poly City Mega Pack Free");
    }

    public void EscenaDos(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void Salir_1()
    {
        Application.Quit();
    }
}