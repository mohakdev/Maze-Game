using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public Text Label;
    Animator Anim;
    bool LoadingFinished = false;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        StartCoroutine(BeginLoading());

        Printer.PrintMsg("Triggered");
    }
    private void Update()
    {
        if (LoadingFinished)
        {
            Anim.SetTrigger("StartTransition");
            StartCoroutine(DeleteObject());
        }
    }
    IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(5);
        Printer.PrintMsg("Object Deleted");
        Destroy(gameObject);
    }
    IEnumerator BeginLoading()
    {
        for (int i = 0; i < 2; i++)
        {
            Label.text = "LOADING.";
            yield return new WaitForSeconds(1);
            Label.text = "LOADING..";
            yield return new WaitForSeconds(1);
            Label.text = "LOADING...";
            yield return new WaitForSeconds(1);
        }
        LoadingFinished = true;
    }
}
