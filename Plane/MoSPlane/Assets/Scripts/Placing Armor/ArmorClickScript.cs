using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorClickScript : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    public GameObject armorButtonsPNL;
    public GameObject armorPlate;
    
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
                hit.collider.gameObject.SetActive(false);
                ArmorClicked();
                
                // the object identified by hit.transform was clicked
                // do whatever you want
            }
        }

        if (armorPlate.activeSelf == false && armorButtonsPNL.activeSelf == false)
        {
            armorPlate.SetActive(true);
        }
    }

    public void ArmorClicked()
    {
        armorButtonsPNL.SetActive(true);
    }
}
