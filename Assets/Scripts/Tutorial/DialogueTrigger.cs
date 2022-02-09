using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{
    public GameObject bubble;
    public GameObject leaf;
    public GameObject abyss;
    public GameObject roomScann;
    public GameObject tutorialButton;
    public GameObject marvin;


    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TurnOff() //turn off button and all the things to tap on screen (bubble,leafs,spawn abyss) //guess itll be easier to just make a state 
    {

        bubble.SetActive(false);
        leaf.SetActive(false); //make a reference to the button component and set it inactive instead
        abyss.SetActive(false);//can't make the abyss not work its so hard to break this mechanic damn probs to you izzy D:
        roomScann.SetActive(false);
        tutorialButton.SetActive(false);
        marvin.SetActive(true);
    }
}
