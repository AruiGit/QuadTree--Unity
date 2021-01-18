using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadTree
{
    Rectangle boundary;
    int capacity;
    List<Point> points;
    quadTree northWest, northEast, southWest, southEast;
    bool subdivided;
  public quadTree(Rectangle boundary, int capacity)
    {
        this.boundary = boundary;
        this.capacity = capacity;
        subdivided = false;
        points = new List<Point>();
    }

    void Insert(Point point)
    {

        if (!boundary.Cointains(point))
        { 
            return; 
        }

        if (points.Count < capacity)
        {
            points.Add(point);
        }
        else if(subdivided==false)
        {
            Subdivide();
        }

        northWest.Insert(point);
        northEast.Insert(point);
        southWest.Insert(point);
        southEast.Insert(point);
    }

    void Subdivide() 
    {
        Rectangle nw, ne, sw, se;
        nw = new Rectangle(boundary.x - boundary.width / 2, boundary.y + boundary.hight / 2, boundary.hight / 2, boundary.width / 2);
        northWest = new quadTree(nw, 4);
        ne = new Rectangle(boundary.x + boundary.width / 2, boundary.y + boundary.hight / 2, boundary.hight / 2, boundary.width / 2);
        northEast = new quadTree(ne, 4);
        sw = new Rectangle(boundary.x - boundary.width / 2, boundary.y - boundary.hight / 2, boundary.hight / 2, boundary.width / 2);
        southWest = new quadTree(sw, 4);
        se = new Rectangle(boundary.x + boundary.width / 2, boundary.y - boundary.hight / 2, boundary.hight / 2, boundary.width / 2);
        southEast = new quadTree(se, 4);
        subdivided = true;
    }
}
