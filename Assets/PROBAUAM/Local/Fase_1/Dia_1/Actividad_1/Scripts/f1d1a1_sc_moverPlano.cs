using UnityEngine;
using UnityEngine.UI;

public class f1d1a1_sc_moverPlano : MonoBehaviour
{
    public Rigidbody body;
    private float fuerza = 50;
    private  bool bandera= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(0, 0, -fuerza * Time.deltaTime);
    }

    public void Parar()
    {
        body.isKinematic = true;
    }
}
