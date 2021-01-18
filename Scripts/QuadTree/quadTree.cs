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

    public void Insert(Point point)
    {

        if (!boundary.Cointains(point))
        { 
            return; 
        }

        if (points.Count <= capacity-1)
        {
            points.Add(point);
            return;
        }
        else {

            if (subdivided == false)
            {
                Subdivide(point);
            }

            northWest.Insert(point);
            northEast.Insert(point);
            southWest.Insert(point);
            southEast.Insert(point);


        } 
    }

    void Subdivide(Point point) 
    {
        Rectangle nw, ne, sw, se;
        nw = new Rectangle(boundary.x - boundary.width / 2, boundary.y + boundary.height / 2, boundary.height / 2, boundary.width / 2);
        northWest = new quadTree(nw, 4);
        foreach (Point p in points)
        {
            if (nw.Cointains(point))
            {
                northWest.Insert(p);
               // points.Remove(p);
            }

        }
        
        ne = new Rectangle(boundary.x + boundary.width / 2, boundary.y + boundary.height / 2, boundary.height / 2, boundary.width / 2);
        northEast = new quadTree(ne, 4);
        foreach (Point p in points)
        {
            if (ne.Cointains(point))
            {
                northEast.Insert(p);
               // points.Remove(p);
            }

        }

        sw = new Rectangle(boundary.x - boundary.width / 2, boundary.y - boundary.height / 2, boundary.height / 2, boundary.width / 2);
        southWest = new quadTree(sw, 4);
        foreach (Point p in points)
        {
            if (sw.Cointains(point))
            {
                southWest.Insert(p);
              //  points.Remove(p);
            }

        }

        se = new Rectangle(boundary.x + boundary.width / 2, boundary.y - boundary.height / 2, boundary.height / 2, boundary.width / 2);
        southEast = new quadTree(se, 4);
        foreach (Point p in points)
        {
            if (se.Cointains(point))
            {
                southEast.Insert(p);
              // points.Remove(p);
            }

        }

        subdivided = true;
    }

    public void Show(Texture2D tex)
    {

        for (float x = 0; x < boundary.width * 2; x++)
        {
            tex.SetPixel((int)(boundary.x + x - boundary.width), (int)(boundary.y - boundary.height - 1), Color.red);
            tex.SetPixel((int)(boundary.x + x - boundary.width), (int)(boundary.y + boundary.height), Color.green);
        }
        for (float y = 0; y < boundary.height * 2; y++)
        {
            tex.SetPixel((int)(boundary.x - boundary.width - 1), (int)(boundary.y + y - boundary.height), Color.blue);
            tex.SetPixel((int)(boundary.x + boundary.width), (int)(boundary.y + y - boundary.height), Color.gray);
        }


        if (subdivided == true)
        {
            northEast.Show(tex);
            northWest.Show(tex);
            southEast.Show(tex);
            southWest.Show(tex);
        }


        for (int i = 0, length = points.Count; i < length; i++)
        {
            tex.SetPixel((int)points[i].x, (int)points[i].y, Color.white);
        }
    }
 }
