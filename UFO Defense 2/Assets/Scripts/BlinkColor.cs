using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkColor : MonoBehaviour
{
    public Color startColor;    
    public Color endColor;
   
    Material mat;


    // Start is called before the first frame update
    void Start()
    {
      mat = GetComponent<Renderer>().material;
      InvokeRepeating("ColorChange",1,0.5f);  
    }
    void ColorChange()
    {
        if(mat.color == startColor)
        {
            mat.color = endColor;
        }
        else
        {
            mat.color = startColor;
        }
    }
}
