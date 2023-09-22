using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for changing the color of players formulas
public class CarChanger : MonoBehaviour
{

    public Image imageToChangeP1; //Sets the image component of the GUI for player 1
    public Image imageToChangeP2; //Sets the image component of the GUI for player 2
    public Sprite[] sprites; //Array of sprites to use as images in the GUI
    int currentCarP1Index = 3; //Starting color for player 1
    int currentCarP2Index = 0; //Starting color for player 2
    public GameObject CarP1; //For instantiating the car for Player 1
    public GameObject CarP2; //For instantiating the car for Player 2
    public Material[] newMaterialP1; //Material array for player 1 for chainging the color of the car
    public Material[] newMaterialP2; //Material array for player 2 for chainging the color of the car

    //Player 1 go to next car
    public void ChangeCarP1Next()
    {
        currentCarP1Index++;
        if (currentCarP1Index >= sprites.Length)
        {
            currentCarP1Index = 0;
        }
        imageToChangeP1.sprite = sprites[currentCarP1Index];
    }

    //Player 1 go to previous car
    public void ChangeCarP1Previous()
    {
        if (currentCarP1Index <= 0)
        {
            currentCarP1Index = sprites.Length - 1;
        }
        else
        {
            currentCarP1Index -= 1;
        }
        imageToChangeP1.sprite = sprites[currentCarP1Index];
    }

    //Player 2 go to next car
    public void ChangeCarP2Next()
    {
        currentCarP2Index++;
        if (currentCarP2Index >= sprites.Length)
        {
            currentCarP2Index = 0;
        }
        imageToChangeP2.sprite = sprites[currentCarP2Index];
    }

    //Player 2 go to previous car
    public void ChangeCarP2Previous()
    {
        if (currentCarP2Index <= 0)
        {
            currentCarP2Index = sprites.Length - 1;
        }
        else
        {
            currentCarP2Index -= 1;
        }
        imageToChangeP2.sprite = sprites[currentCarP2Index];
    }

    //selects the material for players based on the selected car 
    public void PickColors()
    {
        CarP1.GetComponent<Renderer>().material = newMaterialP1[currentCarP1Index];
        CarP2.GetComponent<Renderer>().material = newMaterialP2[currentCarP2Index];
    }
}