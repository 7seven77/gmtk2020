using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public bool hasKey;

    [SerializeField]
    TakeOverTarget objectID;

    int enemyType = -1;
    BurstRifle br;
    Pistol ps;
    Shotgun sg;

    float speed = 1;
    bool dead = false;

    [SerializeField]
    float lifeTime = 9999;

    [SerializeField]
    float minDistance = 2.5f;

    public GameObject highlightSquare;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        GetIndex();
        RetrieveTimer();

        dead = false;

        highlightSquare.SetActive(true);
        highlightSquare.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void GetIndex() 
    {
        enemyType = this.gameObject.GetComponent<UnitStore>().index;

        switch (enemyType) 
        {
            case 0:
                br = this.GetComponentInChildren<BurstRifle>();
                break;
            case 1:
                ps = this.GetComponentInChildren<Pistol>();
                break;
            case 2:
                sg = this.GetComponentInChildren<Shotgun>();
                break;
        }   
    }

    void FireByIndex() 
    {
        switch (enemyType)
        {
            case 0:
                br.Fire();
                break;
            case 1:
                ps.Fire();
                break;
            case 2:
                sg.Fire();
                break;
        }
    }

    void RetrieveTimer() 
    {
        switch (enemyType) 
        {
            case 0:
                lifeTime = 20;
                break;
            case 1:
                lifeTime = 15;
                break;
        }
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0) 
        {
            Death();
        }

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            FireByIndex();
        }

        transform.position = pos;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.LookRotation(mousePos);


        CheckForHighlights(new Vector2(mousePos.x, mousePos.y));

        if (Input.GetKeyDown(KeyCode.LeftControl) && objectID != null) 
        {
            if (Vector3.Distance(transform.position, objectID.transform.position) <= minDistance)
            {
                objectID.TakeOver();
                dead = true;
                StartCoroutine(HopDestroy());
            }
        }
    }

    void Death() 
    {
        print("dead");
    }

    IEnumerator HopDestroy() 
    {
        speed = 0;

        this.GetComponent<Animator>().SetTrigger("death");

        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
    }

    void CheckForHighlights(Vector2 mousePos)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward);

        if (hit.collider != null)
        {
            if (objectID != null && hit.collider != objectID.GetComponent<CircleCollider2D>() && hit.collider.tag == "Unit" && hit.collider.gameObject != this.gameObject)
            {
                objectID.TurnOffSquare();
            }
            objectID = hit.collider.GetComponent<TakeOverTarget>();
        }
    }
}