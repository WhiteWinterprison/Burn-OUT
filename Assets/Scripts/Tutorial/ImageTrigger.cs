using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTrigger : MonoBehaviour
{
    public Image image;

    public void TriggerImage()
    {
        FindObjectOfType<ImageManager>().StartImage(image);
    }
}
