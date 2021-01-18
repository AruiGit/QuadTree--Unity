using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    float x, y, width, height;
    public Renderer rend;
    Texture2D text;
    quadTree qt;

    Color32[] resetColorArray;
    Color32 resetColor = new Color32(0, 0, 0, 255);

    void Start()
    {
        Rectangle rootRectangle = new Rectangle(256/2, 256/2, 256/2, 256/2);
        qt = new quadTree(rootRectangle, 4);
       

        

        text = new Texture2D(256, 256, TextureFormat.RGB24, false);
        text.filterMode = FilterMode.Point;

        resetColorArray = text.GetPixels32();
        ClearTexture(text);
        text.Apply(false);
        rend.material.mainTexture = text;
        qt.Show(text);

       /* for (int i = 0; i < 25; i++)
        {
            Point p = new Point(Random.Range(0, 256), Random.Range(0, 256));
            qt.Insert(p);
            qt.Show(text);
            text.Apply(false);
        }*/
    }

    void Update()
    {
        // click with mouse to add points
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float x = hit.textureCoord.x * text.width;
                float y = hit.textureCoord.y * text.height;

                var p = new Point((int)x, (int)y);
                qt.Insert(p);

                qt.Show(text);
                text.Apply(false);
            }
        }
    }

    void ClearTexture(Texture2D tex)
    {
        for (int i = 0, len = resetColorArray.Length; i < len; i++)
        {
            resetColorArray[i] = resetColor;
        }
        tex.SetPixels32(resetColorArray);
    }

}
