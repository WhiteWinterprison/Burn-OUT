using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{

    private Queue<GameObject> marvins; //lets try this out
   

    // Start is called before the first frame update
    void Start()
    {
        marvins = new Queue<GameObject>();
    }


    public void StartPicture(Image picture)
    {
        marvins.Clear(); //clear any marvins from the previous tutorial runthrough


        Debug.Log("starting marvins");
        // foreach (GameObject marvin in image.marvins)
        // {
        //     marvins.Enqueue(marvin);
        // }
        // DisplayNextMarvin();
    }


    public void DisplayNextMarvin()
    {
        if (marvins.Count == 0) //if we reached end of queue (all the sentences of the tutorial)
        {
            EndDialogue();
            return;
        }

        GameObject marvin = marvins.Dequeue();

        //for the ones that skip lez not make the letters animate when skipping
        //StopAllCoroutines(); may need again
        //dialogueText.text = sentence; //would just call the text at once but lez make it more fancy
        //StartCoroutine(TypeSentence(sentence));
    }

    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //        wanna pause the game during dialogue
    //        yield return new WaitForSecondsRealtime(typingSpeed);
    //    }
    //}
    //IEnumerator DisplayMarvin(GameObject marvin)
    //{
    //    imageImage.text = "";
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        //yield return null;
    //        //wanna pause the game during dialogue
    //        yield return new WaitForSecondsRealtime(typingSpeed);
    //    }
    //}

    void EndDialogue()
    {
        //Time.timeScale = 1;
        //animator.SetBool("IsOpen", false);
        Debug.Log("End of MarvinTurorial");
        
    }
}
