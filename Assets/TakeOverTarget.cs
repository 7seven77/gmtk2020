using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOverTarget : MonoBehaviour
{

    SpriteRenderer sr;

    public GameObject highlightSquare;

    bool highlighted;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        sr.color = Color.yellow;
        highlightSquare.SetActive(true);
    }

    private void OnMouseExit()
    {
        sr.color = Color.red;
    }

    public void TurnOffSquare() 
    {
        highlightSquare.SetActive(false);
    }

    public void TakeOver() 
    {
        this.gameObject.AddComponent<TestPlayerMovement>();
        this.gameObject.GetComponent<TestPlayerMovement>().highlightSquare = highlightSquare;
        Destroy(this);
    }
}