using UnityEngine;
using UnityEngine.UI;

public class f1d1a1_sc_Puntaje : MonoBehaviour
{
    public int contador = 0;
    public Text TextScore;

    // Update is called once per frame
    public void suma()
    {
        contador++;
        if (TextScore != null)
        {
            TextScore.text = "Puntos: " + contador.ToString();
        }
    }
}
