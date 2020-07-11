using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public bool hasKey;

    [SerializeField]
    TakeOverTarget objectID;

    [SerializeField]
    float minDistance = 1;

    public GameObject highlightSquare;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().color = Color.green;

        highlightSquare.SetActive(true);
        highlightSquare.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += 1 * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= 1 * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += 1 * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= 1 * Time.deltaTime;
        }

        transform.position = pos;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - pos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        CheckForHighlights(new Vector2(mousePos.x, mousePos.y));

        if (Input.GetKeyDown(KeyCode.LeftControl) && objectID != null) 
        {
            if (Vector3.Distance(pos, objectID.transform.position) <= minDistance)
            {
                objectID.TakeOver();
                Destroy(this.gameObject);
            }
        }
    }

    void CheckForHighlights(Vector2 mousePos)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward);

        if (hit.collider != null)
        {
            if (objectID != null && hit.collider != objectID.GetComponent<CircleCollider2D>() && hit.collider.tag == "Unit")
            {
                objectID.TurnOffSquare();
            }
            objectID = hit.collider.GetComponent<TakeOverTarget>();
        }
    }
}