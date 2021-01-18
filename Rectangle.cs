using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle 
{

    public int x, y, hight, width;

  public Rectangle(int x, int y, int hight, int width)
    {
        this.x = x;
        this.y = y;
        this.hight = hight;
        this.width = width;
    }
   
    public bool Cointains(Point point)
    {
        if (point.x > x - width && point.x < x + width && point.y > y - hight && point.y < y + hight)
        {
            return true;
        }
        else return false;
    }
}
