﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    private string bin;

    // Start is called before the first frame update
    void Start()
    {
        bin = transform.parent.gameObject.name;
        //bin = "Trash" or "Recycling" or "Compost"
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemController>().info.type == bin)
        {
            gameManager.GetComponent<Trash>().score += 20;
        }
        else
        {
            if (bin == "Compost" || bin == "Recycling")
            {
                gameManager.GetComponent<Trash>().endGame();
                Destroy(this);
            }
            else if (bin == "Trash")
            {
                gameManager.GetComponent<Trash>().score -= 5;
            }
            else
            {
                Debug.Log("u named something wrong, check if 'recycling' is named correctly dude");
            }
        }

        //print("TRASHED " + collision.gameObject.name);
        Destroy(collision.gameObject, 0.5f);
    }
}
