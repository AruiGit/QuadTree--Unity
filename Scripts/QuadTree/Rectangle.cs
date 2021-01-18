using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle 
{

    public float x, y, height, width;

  public Rectangle(float x, float y, float height, float width)
    {
        this.x = x;
        this.y = y;
        this.height = height;
        this.width = width;
    }
   
    public bool Cointains(Point point)
    {
        if (point.x > x - width && point.x < x + width && point.y > y - height && point.y < y + height)
        {
            return true;
        }
        else return false;
    }
}
