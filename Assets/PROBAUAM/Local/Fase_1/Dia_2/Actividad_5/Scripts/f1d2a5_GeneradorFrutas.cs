using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f1d2a5_GeneradorFrutas : MonoBehaviour
{
    private GameObject frutas, Limite;
    public Transform Camera;
    public bool validador;
    private float speed, aumento = 10;
    private GameObject clon;
    public GameObject detector;
    private GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(1, 7);
        frutas = GameObject.Find("Fruta" + a);
        validador = false;
        clon = Instantiate(frutas);
        clon.transform.localScale = new Vector3(10, 10, 10);
        clon.transform.position = frutas.transform.position;
        Limite = GameObject.Find("Limite");
        Score = GameObject.Find("Text (TMP)");

    }

    // Update is called once per frame
    void Update()
    {

        if (validador == true)
        {

            int a = Random.Range(1, 7);
            frutas = GameObject.Find("Fruta" + a);
            clon = Instantiate(frutas);
            clon.transform.localScale = new Vector3(10, 10, 10);
            clon.transform.position = frutas.transform.position;

           // Debug.Log(frutas.name);
            validador = false;
        }
        else
        {
            if (Limite.GetComponent<f1d2a5_ChoquePlayer>().perdio == false)
            {
                //caso que no haya perdido
                clon.transform.localScale = new Vector3(aumento + 0.2f, aumento + 0.2f, aumento + 0.2f);
                if (Score.GetComponent<global_sc_Contador>().getContador()>=20) {
                    speed = Random.Range(2.2f, 4.3f);
                }
                else {speed = Random.Range(0.3f, 1.9f); }
                
                clon.GetComponent<MeshCollider>().isTrigger = true;
                clon.transform.position = Vector4.Lerp(clon.transform.position, Camera.transform.position, Time.deltaTime * speed);
            }
            else {
                Destroy(clon.transform.gameObject); 
                validador = true;
                GetComponent<f1d2a5_GeneradorFrutas>().enabled = false;
                detector.SetActive(true);
                Limite.GetComponent<f1d2a5_ChoquePlayer>().perdio = false;

            }
        }
    }
  
}
