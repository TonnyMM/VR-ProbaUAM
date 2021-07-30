using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class global_sc_Contador : MonoBehaviour
{
    private int contador = 0;
    public TextMeshProUGUI TextScore;
    
    // Start is called before the first frame update
    void Start()
    {

      //  TextScore = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
   public void suma()
    {
        contador++;
        if (TextScore!=null) {
            TextScore.text = "Score: " + contador.ToString();
        }
       // Debug.Log("Aciertos: "+contador);
    }
    public void resta()
    {
        contador--;
        if (TextScore != null)
        {
            TextScore.text = "Score: " + contador.ToString();
        }
        // Debug.Log("Aciertos: "+contador);
    }
    public int getContador() {
        return contador;
    }



}
