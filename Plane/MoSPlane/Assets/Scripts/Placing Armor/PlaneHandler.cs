using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHandler : MonoBehaviour
{

    public int[] armorArray = new int[10]; //This armor array will keep track of where the armor has been placed. This will impact the probability that the plane is being shot down. 
                                           //https://drive.google.com/file/d/1qvycwF34yzFbsOf40-u97HuM0XQ3fR4d/view?usp=sharing
                                           //1 = 0, 2 = 1, etc
    private float[] damageArray = new float[10];

    public GameObject armorButtonsPNL;
    public int chanceToGetHit = 1, rollMax = 2; //chanceToGetHit is the number that has to be beaten by the generator in order for the plane to calculate a hit
                                                //rollMax is the maximum number the generator can roll (the random.range runs on the top number being exclusive so if the numbers are 0,2 it can generate 1 or 0, but not 2)

    public int damageChance = 2; //this is the number you add in order to calculate if the plane takes damage during a hit. Currently it adds to the amount of armor the plane has in the random.range function
                                 //making the top number X bigger than the amount of armor. If the number generated is bigger than the amount of armor it takes damage. 
    public int damageMultiplier = 10;
    public float damageForNonCrit = 1;
    public float damageForCrit = 5;
    public int killNum = 15;
    public bool hasStarted = false;
    public int roundsSurvived = 0;
    public int testerNum = 0;
    public bool startTest = false;
    public int totalRounds = 0;
    public bool hasShownAverage = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (testerNum < 100 && hasStarted == false && startTest == true)
        {
            hasStarted = true;
            testerNum++;
        }
        if (hasStarted == true)
        {
            FlightCalculator();
        }
        if (testerNum == 100)
        {
            int average = totalRounds / 100;
            Debug.Log("This configurations average was " + average);

        }
    }

    public void AddArmor(int armorPosition)
    {
        armorArray[armorPosition] += 1;
        Debug.Log(armorArray[armorPosition]);
        armorButtonsPNL.SetActive(false);
    }

    public void FlightCalculator()
    {
        roundsSurvived++;
        int randHit = Random.Range(0, rollMax);
        int randHitArea = Random.Range(0, armorArray.Length);
        int randDamage = Random.Range(0, armorArray[randHitArea] + damageChance);
        //if (randHit >= chanceToGetHit)
        //{
        //    if (armorArray[randHitArea] < randDamage)
        //    {
        //        if (armorArray[randHitArea] == 0)
        //        {
        //            damageArray[randHitArea] += damageForNonCrit;
        //        }
        //        else
        //        {
        //            damageArray[randHitArea] += (damageForNonCrit / armorArray[randHitArea]);
        //        }
        //    }
        //}

        if (randHit >= chanceToGetHit)
        {
            if (armorArray[randHitArea] == 0 && randHitArea != 0 && randHitArea != 2/*has no armor && is not critical*/)
            {
                //Take normal damage
                damageArray[randHitArea] += damageForNonCrit;
            }
            else if (/*has no armor && is critical*/armorArray[randHitArea] == 0 && (randHitArea == 0 || randHitArea == 2))
            {
                //Take enhanced damage
                damageArray[randHitArea] += damageForCrit;
            }
            else if (/*is not critical*/randHitArea != 0 && randHitArea != 2)
            {
                //Take normal damage divided by amount of armor
                damageArray[randHitArea] += (damageForNonCrit / armorArray[randHitArea]); 
            }
            else if (/*is critical*/randHitArea == 0 || randHitArea == 2)
            {
                //Take enhanced damage divided by armor
                damageArray[randHitArea] += (damageForCrit / armorArray[randHitArea]);
            }
        }

        float dmgNum = 0;

        for (int i = 0; i < damageArray.Length; i++)
        {
            Debug.Log("location " + i + " has taken " + damageArray[i] + " damage");
            dmgNum += damageArray[i];          
        }

        if (dmgNum > killNum)
        {

            //for (int i = 0; i < damageArray.Length; i++)
            //{
            //    Debug.Log("location " + i + " has taken " + damageArray[i] + " damage");
            //}
            DamageArrayResetter();
            hasStarted = !hasStarted;
            Debug.Log(roundsSurvived);
            totalRounds += roundsSurvived;
            roundsSurvived = 0;
        }

    }

    public void DamageTester()
    {
        if (/*gets hit*/true)
        {
            if (/*has no armor && is not critical*/true)
            {
                //Take normal damage
            }
            else if (/*has no armor && is critical*/true)
            {
                //Take enhanced damage
            }
            else if (/*is not critical*/true)
            {
                //Take normal damage divided by amount of armor
            }
            else if (/*is critical*/true)
            {
                //Take enhanced damage divided by armor
            }
        }

        for (int i = 0; i < /*armor locations aka 10*/10; i++)
        {
            //Add amount of damage taken to a total num
        }

        if (/*amount of damage taken is greated than killNum, plane crashes*/true)
        {

        }
    }

    public void DamageArrayResetter()
    {
        for (int i = 0; i < damageArray.Length; i++)
        {
            damageArray[i] = 0;
        }
    }

    public void HasStartedSwitcher()
    {
        hasStarted = !hasStarted;
    }

    public void StartTestSwitcher()
    {
        startTest = !startTest;
    }
}
