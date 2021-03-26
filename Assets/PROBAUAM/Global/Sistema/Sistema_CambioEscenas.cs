using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sistema_CambioEscenas : MonoBehaviour
{
    public static void CambioEscena(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena, LoadSceneMode.Single);
    }
}
