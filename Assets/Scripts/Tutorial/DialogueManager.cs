using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //for reappearing after tutorial

    public GameObject leaf;
    public GameObject abyss;
    //public GameObject roomScann;
    public Text DebugInTheWay;
    public GameObject lastImage;

    //__________________________________________________________________

    public Text nameText;
    public Text dialogueText;
    

    float typingSpeed = 0.02f; //how fast letters come

    public Animator animator;

    private Queue<string> sentences;

    //private Queue<GameObject> marvins; //lets try this out

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //marvins = new Queue<GameObject>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        

        animator.SetBool("IsOpen", true);

         //for when soemone else talks to us we have the option to make it another name

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        //Time.timeScale = 0;
        


        //marvins.Clear(); //clear any marvins from the previous tutorial runthrough

        //foreach (GameObject marvin in dialogue.marvins)
        //{
        //    marvins.Enqueue(marvin);
        //}
        //DisplayNextMarvin();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) //if we reached end of queue (all the sentences of the tutorial)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //for the ones that skip lez not make the letters animate when skipping
        StopAllCoroutines();
        //dialogueText.text = sentence; //would just call the text at once but lez make it more fancy
        StartCoroutine(TypeSentence(sentence));
    }

    //public void DisplayNextMarvin()
    //{
    //    if (marvins.Count == 0) //if we reached end of queue (all the sentences of the tutorial)
    //    {
    //        EndDialogue();
    //        return;
    //    }

    //    GameObject marvin = marvins.Dequeue();

    //    //for the ones that skip lez not make the letters animate when skipping
    //    StopAllCoroutines();
    //    //dialogueText.text = sentence; //would just call the text at once but lez make it more fancy
    //    //StartCoroutine(TypeSentence(sentence));
    //}

    //to make it fancy by letting each letter appear by itself
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return null;
            //wanna pause the game during dialogue
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void EndDialogue()
    {
        Time.timeScale = 1;
        animator.SetBool("IsOpen", false);

        // lastImage.SetActive(false);
        // leaf.SetActive(true); //make a reference to the button component and set it inactive instead
        // abyss.SetActive(true);//can't make the abyss not work its so hard to break this mechanic damn probs to you izzy D:
        //roomScann.SetActive(true); //since abyss should appear b4 for the story to make sense
        //DebugInTheWay.SetActive(true);

    }
}
