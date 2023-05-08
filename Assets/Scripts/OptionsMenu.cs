using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public Animator UIAnimator;

    public void Openwindow()
    {

        UIAnimator.SetTrigger("Open");

    }

    public void Closewindow()
    {

        UIAnimator.SetTrigger("Close");

    }

}



