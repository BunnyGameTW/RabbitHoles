using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayableDirector timeline;
    public GameObject rabbit;
    public Image fadeImage;
    public Text clearText;
    PlayerBehavior playerBehavior;
    bool isAnimate, isFadeOut;
    float scale = 0;
    const float FADE_SPEED = 10;
    // Start is called before the first frame update
    void Start()
    {
        isAnimate = isFadeOut = false;
        playerBehavior = player.GetComponentInChildren<PlayerBehavior>();

        var clickables = FindObjectsOfType<MonoBehaviour>().OfType<IClickable>();
        foreach (IClickable clickable in clickables)
        {
            clickable.onClicked += OnItemClicked;
        }
        fadeImage.GetComponent<Image>().material.SetFloat("_Scale", 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        PlayerInput();
        if (isFadeOut)
        {
            scale += Time.deltaTime * FADE_SPEED;
            if (scale > 3) isFadeOut = false;
            fadeImage.GetComponent<Image>().material.SetFloat("_Scale", scale);
            clearText.enabled = true;
            clearText.GetComponent<Animation>().Play();
        }
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

        isAnimate = true;
        timeline.Play();
        Debug.Log(sender);
    }

    public void SpawnRabbit(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(rabbit, new Vector3(0, player.transform.position.y, 0), transform.rotation);

        }
    }

    public void SetFadeOutPosition()
    {

        Vector3 pos = Camera.main.WorldToScreenPoint(player.transform.position);
        pos.x = -pos.x / Screen.width + 0.5f;
        pos.y = -pos.y / Screen.height + 0.5f;
        fadeImage.GetComponent<Image>().material.SetVector("_Position", new Vector4(pos.x, pos.y));

        isFadeOut = true;
    }
}
