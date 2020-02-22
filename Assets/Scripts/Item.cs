using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Item : MonoBehaviour
{
    protected Material outlineMaterial;
    //public Material outlineMaterial;
    public float outlineWidth;
    public Material defaultMaterial;
    public float CHECK_DISTANCE = 1.0f;
    protected GameManager gameManager;
    protected GameObject player;
    protected bool canInteract;


    // Start is called before the first frame update
    void Awake()
    {
        outlineMaterial = GetComponent<SpriteRenderer>().material;
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.player;

        // block = new MaterialPropertyBlock();
        outlineMaterial.SetFloat("_Width", outlineWidth);
    }

    public virtual void Update()
    {
        canInteract = Mathf.Abs(player.transform.position.x - transform.position.x) <= CHECK_DISTANCE;
        ChangeMaterial(canInteract);
    }
    protected void ChangeMaterial(bool needChange)
    {
        GetComponent<SpriteRenderer>().material = needChange ? outlineMaterial : defaultMaterial;
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, CHECK_DISTANCE);
    }
}
