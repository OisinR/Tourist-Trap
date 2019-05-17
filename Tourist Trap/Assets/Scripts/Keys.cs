using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    List<int> keylist = new List<int>();
    bool generateKey;

    public void NewTourist(GameObject Tourist)              //gives each group a random key, which they compare when colliding into each other
                                                            //This makes sure that members of the same group colliding dont trigger a game over
    {
        generateKey = false;
        while (!generateKey)
        {
            int newKey = Random.Range(0, 50);
            if(!keylist.Contains(newKey))
            {
                generateKey = true;
                keylist.Add(newKey);
            }

        }
    }

}
