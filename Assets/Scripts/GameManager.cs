using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    PlayerBehavior playerBehavior;
    bool isAnimate;
    // Start is called before the first frame update
    void Start()
    {
        isAnimate = false;
        playerBehavior = player.GetComponentInChildren<PlayerBehavior>();

        var clickables = FindObjectsOfType<MonoBehaviour>().OfType<IClickable>();
        foreach (IClickable clickable in clickables)
        {

            clickable.onClicked += OnItemClicked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckItems();
        PlayerInput();
    }

    void CheckItems()
    {
      //  Debug.Log("CheckItems");
    }

    void PlayerInput()
    {
        
        if (Input.GetMouseButtonDown(0) && !isAnimate)
        {
            Debug.Log("PlayerInput");
            playerBehavior.SetTarget(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, player.transform.position.y));
        }
    }

    void OnItemClicked(object sender, EventArgs e)
    {
        // TODO: 處理事件
        isAnimate = true;
        Debug.Log(sender);
    }
}
