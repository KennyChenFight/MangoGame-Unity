using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class petEat : MonoBehaviour {

    private Animator animator;//(1)
    public Text t;





    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    
    }
	
	// Update is called once per frame
	void Update () {
        if (t.text=="1")
        {
            animator.SetFloat("PetEat", 2);//(5)

        }
        else if (t.text == "0")
        {
            animator.SetFloat("PetEat", -1);//(5)
        }
   

        


    }




}
