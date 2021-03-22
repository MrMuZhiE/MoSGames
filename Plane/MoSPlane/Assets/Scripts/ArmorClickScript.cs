using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorClickScript : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.collider.gameObject);
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }
    }
}
