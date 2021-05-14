using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_s_LinePoiner : MonoBehaviour
{

    public float defaultLength = 5.0f;

    public GameObject dot;

    private LineRenderer lineRenderer = null;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine(){
        float targetLength = defaultLength;
        //RaycastHit hit = CreateRaycast(targetLength);
        Vector3 endPosition = transform.position + (transform.forward * targetLength);
        //Debug.Log("transform.position " + transform.position + "\n" + "transform.forward " + transform.forward + "\n" + "targetLength " + targetLength + "\n"+ "endPosition " + endPosition);
        /*if(hit.collider !=null){
            endPosition = hit.point;
        }*/
        dot.transform.position = endPosition;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
