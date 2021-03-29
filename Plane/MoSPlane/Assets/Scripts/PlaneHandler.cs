using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHandler : MonoBehaviour
{

    public int[] armorArray = new int[10]; //This armor array will keep track of where the armor has been placed. This will impact the probability that the plane is being shot down. 
                                           //https://drive.google.com/file/d/1qvycwF34yzFbsOf40-u97HuM0XQ3fR4d/view?usp=sharing
                                           //1 = 0, 2 = 1, etc
    public GameObject armorButtonsPNL;
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 50; i++)
        //{
        //    AddArmor(Random.Range(0, 10));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddArmor(int armorPosition)
    {
        armorArray[armorPosition] += 1;
        Debug.Log(armorArray[armorPosition]);
        armorButtonsPNL.SetActive(false);
    }
}
