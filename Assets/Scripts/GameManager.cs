using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    const float SPEED = 10.0f;
    const float CHECK_DISTANCE = 0.1f;
    Vector2 targetPosition;
    PlayerBehavior playerBehavior;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = player.transform.position;
        playerBehavior = player.GetComponentInChildren<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ;
            targetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x , player.transform.position.y);
            Debug.Log(targetPosition);
        }
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 playerPosition = player.transform.position;
        if (Mathf.Abs(targetPosition.x - playerPosition.x) > CHECK_DISTANCE)
        {
            playerBehavior.SetState(PlayerBehavior.STATE.MOVE);
            player.transform.position = Vector2.MoveTowards(playerPosition, targetPosition, Time.deltaTime * SPEED);
        }
        else
        {

        }
    }
}
