using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


 
public class PictureTrigger : MonoBehaviour
{
    public Image picture;

    public void TriggerImage()
    {
        FindObjectOfType<PictureManager>().StartPicture(picture);
    }
}
