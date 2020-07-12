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
        highlightSquare.GetComponent<SpriteRenderer>().color = new Color(255, 0, 158);
    }

    public void TurnOffSquare() 
    {
        sr.color = Color.white;
        highlightSquare.SetActive(false);
    }

    public void TakeOver() 
    {
        this.gameObject.AddComponent<TestPlayerMovement>();
        this.gameObject.GetComponent<TestPlayerMovement>().highlightSquare = highlightSquare;
        Destroy(this);
    }
}