using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmontTextScript : MonoBehaviour
{
    public Text[] armorAmountText = new Text[10];
    public PlaneHandler ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = FindObjectOfType<PlaneHandler>();

        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTexts()
    {
        for (int i = 0; i < armorAmountText.Length; i++)
        {
            armorAmountText[i].text = ph.armorArray[i] + "";
        }
    }
}
