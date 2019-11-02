using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class Test : MonoBehaviour
{
    public Animator animator;
    public Animation animation;

    void Awake()
    {
        //Debug.Log(UnityEngine.SceneManagement.SceneManager.sceneCount);
        //Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        //SceneManagement.

        //Animation ani;
        //ani.Play
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(1);
            animator.Play("Attack_Animation");
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(2);
            //animation.Play();
            animator.StartPlayback();


        }
    }


}
