using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        Rectangle rootRectangle = new Rectangle(200,200,200,200);
        quadTree qt = new quadTree(rootRectangle, 4);
       

        for(int i=0; i < 10; i++)
        {
            Point p = new Point(Random.Range(0, 400), Random.Range(0, 400));

        }
    }

}
