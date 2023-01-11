using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public static Animation instance;

    [SerializeField]
    GameObject grid, gridFeed, time, gameOver, hungry, pet;

    private void Awake()
    {
        if (Animation.instance == null)
        {
            Animation.instance = this;

        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(grid, -2126f, 0f);
        LeanTween.moveLocalY(gridFeed, -2126f, 0f);
        LeanTween.moveLocalY(grid, -1293.861f, 1.5f);        
        time.SetActive(false);
        gameOver.SetActive(false);
        hungry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonFeed()
    {
        LeanTween.moveLocalY(grid, -2126f, 1.5f);
        LeanTween.moveLocalY(gridFeed, -1293.861f, 2f);
        time.SetActive(true);
    }

    public void PantallaInicial()
    {
        LeanTween.moveLocalY(gridFeed, -2126f, 1.5f);
        LeanTween.moveLocalY(grid, -1293.861f, 2f);
        time.SetActive(false);
    }
    
    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        gameOver.SetActive(false);
        LovePoints.instance.NewGame();
    }
    
    public void IsHungry(bool isHungry)
    {
        if (isHungry)
        {
            hungry.SetActive(true);
        }
        else
        {
            hungry.SetActive(false);
        }        
    }

    public void CanPetText(bool canPet)
    {
        if (canPet)
        {
            pet.SetActive(true);
        }
        else
        {
            pet.SetActive(false);
        }
    }
}