using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] private GameObject MenuePanel;

    public void ShowHideMenue()
    {
        if(MenuePanel != null) //chekci f we habve menue
        {
            Animator animator = MenuePanel.GetComponent<Animator>();
            if(animator != null) //check if we have aniamtor
            {   
                bool isOpen = animator.GetBool("isShowing");
                animator.SetBool("isShowing", !isOpen); //setze variable zum gegenteil was es war 
            }
        }
    }
}
