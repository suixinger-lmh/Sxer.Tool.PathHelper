﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = Sxer.Tool.PathHelper.TestApi();
        Debug.LogError( Sxer.Tool.PathHelper.TestApi());

        Debug.LogError(Sxer.Tool.PathHelper.GetProjectRoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
