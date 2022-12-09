using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    GameObject grid, gridFeed;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(grid, -2126f, 0f);
        LeanTween.moveLocalY(gridFeed, -2126f, 0f);
        LeanTween.moveLocalY(grid, -1293.861f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonFeed()
    {
        LeanTween.moveLocalY(grid, -2126f, 1.5f);
        LeanTween.moveLocalY(gridFeed, -1293.861f, 2f);
    }

    public void PantallaInicial()
    {
        LeanTween.moveLocalY(gridFeed, -2126f, 1.5f);
        LeanTween.moveLocalY(grid, -1293.861f, 2f); 
    }
}
