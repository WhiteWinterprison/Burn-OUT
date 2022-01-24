using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour

{
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // oder unten bei void anim? 

    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("BoolBigger");
    }
}
