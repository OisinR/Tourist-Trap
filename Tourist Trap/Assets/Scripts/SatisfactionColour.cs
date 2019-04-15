using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatisfactionColour : MonoBehaviour
{
    public Gradient gradient;
    Satisfaction satScript;
    float colourchange;
    Renderer pRenderer;
    void Awake()
    {
        satScript = GetComponentInParent<Satisfaction>();
        pRenderer = GetComponent<Renderer>();
        colourchange = satScript.satisfaction;
        pRenderer.material.color = ColourFromGradient(colourchange);
    }

    void Update()
    {
        colourchange = satScript.satisfaction / 100;

        pRenderer.material.color = ColourFromGradient(colourchange); 
    }


    Color ColourFromGradient(float value)  
    {
        return gradient.Evaluate(value);
    }
}
