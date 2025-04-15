using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class Block : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    //reference to Block Script for each sourounding block
    public Block blockScript1;
    public Block blockScript2;
    public Block blockScript3;

    public int blockCounter;


    // The color of the block when it is not hovered over
    public Color normalColor = Color.white;

    // The color of the block when it is hovered over
    public Color hoverColor;

    public Color hoverColorE = Color.green;
    public Color hoverColorM = Color.yellow;
    public Color hoverColorH = Color.red;

    public int newRange;




    // The sprite renderer component of the block
    public SpriteRenderer spriteRenderer;

    //set the blocks difficulty
    public void difficulty(int maxInt)
    {
        int randomDif = Random.Range(1, maxInt + 1);
        if (randomDif == 1)
        {
            hoverColor = hoverColorE;
            newRange = Random.Range(2, 4);
        }
        if (randomDif == 2)
        {
            hoverColor = hoverColorM;
            newRange = Random.Range(4, 6);
        }
        if (randomDif == 3)
        {
            hoverColor = hoverColorH;
            newRange = Random.Range(6, 8);
        }
    }


    private void Start()
    {
        difficulty(3);
    }



    public void OnPointerClick(PointerEventData pointerEventData)
    {

        Destroy(gameObject);

        // Using the Random.Range method to load random scenes
        int index = newRange;
        //Swap to the Scene thats been randomly chosen
        SceneManager.LoadScene(index);

        //count blocks taken
        blockCounter = PlayerPrefs.GetInt("BlockCounter");
        blockCounter++;
        PlayerPrefs.SetInt("BlockCounter", blockCounter);
    }


    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {



        //used https://docs.unity3d.com/2017.4/Documentation/ScriptReference/EventSystems.IPointerEnterHandler.html
        // Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        try
        {
            if (blockScript1 == null && blockScript3 == null)
            {
                blockScript1.enabled = false;
                blockScript3.enabled = false;
            }
            if (blockScript2 == null)
            {
                blockScript1.enabled = false;
                blockScript3.enabled = false;
            }
            if (blockScript1 == null || blockScript3 == null)
            {
                blockScript2.enabled = false;
                blockScript2.hoverColor = normalColor;

            }

        }
        catch
        {
        }

        if (blockScript1 != null && blockScript2 != null && blockScript3 != null || blockScript1 != null && blockScript2 != null || blockScript3 != null && blockScript2 != null)
        {
            spriteRenderer.color = hoverColor;
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // Change the color of the block to the normal color
        spriteRenderer.color = normalColor;
    }
}
