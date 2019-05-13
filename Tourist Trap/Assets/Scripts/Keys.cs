using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{

    List<int> keylist = new List<int>();
    bool generateKey;

    void Start()
    {
        
    }




	void Update()
    {
        
    }

    public void NewTourist(GameObject Tourist)
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

    public void DeleteTourist(GameObject Tourist)
    {

    }

}
