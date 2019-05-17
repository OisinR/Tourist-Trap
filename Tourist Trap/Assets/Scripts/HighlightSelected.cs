﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSelected : MonoBehaviour
{

    public Material player, selected;
    public Renderer Selrenderer;


	public void Selected()                          //sets the circle under tourists to let the player know that they're selected
    {
        Selrenderer.material = selected;

    }

    public void UnSelected()
    {
        Selrenderer.material = player;
    }


}
