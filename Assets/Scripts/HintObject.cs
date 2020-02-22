using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintObject : Item
{
    public Text text;
    public float TEXT_OFFSET_Y = 1;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + TEXT_OFFSET_Y));
        text.rectTransform.position = screenPosition;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ShowText(Mathf.Abs(player.transform.position.x - transform.position.x) < CHECK_DISTANCE);      
    }

    void ShowText(bool isShow)
    {
        text.enabled = isShow;
    }
}
