using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGenerator : MonoBehaviour
{
    public playerController playerController;

    public bool isMoving = false;
    public float worldSpeedMultiplier;
    public float maxWorldSpeed;
    public Sprite[] backgroundSpriteList;

    private bool canCreate = true;
    private float playerSpeed;
    private float speed;

    void Start()
    {
        CreateWorld();
    }

    void Update()
    {
        ///GetPlayerSpeed & SetWorldSpeed///
        playerSpeed = playerController.mouseHold;
        speed = playerSpeed * worldSpeedMultiplier;

        if (speed > maxWorldSpeed)
        {
            speed = maxWorldSpeed;
        } 
      
        ///Create New Tile///
        Transform worldTitleTransfrom = gameObject.GetComponent<Transform>().transform.GetChild(0).GetComponent<Transform>();
   
        ///Move Tile///
        if (isMoving)
        {
            worldTitleTransfrom.position += -transform.up * speed * Time.deltaTime;
        }
        ///Dstroy Current Tile And Create A New One///
        if (backgroundSpriteList.Length == 1)
        {
            if (worldTitleTransfrom.position.y < -gameObject.GetComponent<Transform>().transform.GetChild(0)
                .GetComponent<Transform>().transform.GetChild(0).GetComponent<SpriteRenderer>().size.y)
            {
                Destroy(worldTitleTransfrom.gameObject);
                canCreate = true;
                CreateWorld();
            }
        }
        if (backgroundSpriteList.Length > 1)
        {
            if (worldTitleTransfrom.position.y < (-gameObject.GetComponent<Transform>().transform.GetChild(0)
                .GetComponent<Transform>().transform.GetChild(0).GetComponent<SpriteRenderer>().size.y * backgroundSpriteList.Length))
            {
                Destroy(worldTitleTransfrom.gameObject);
                canCreate = true;
                CreateWorld();
            }
        }
    }

    public void CreateWorld()
    {
        if (canCreate)
        {
            GameObject worldTile = new GameObject("World_Tile");
            worldTile.transform.parent = gameObject.transform;

            for (int i = 0; i < backgroundSpriteList.Length; i++)
            { 
                GameObject spriteClone = new GameObject($"Sprite_Tile-{i}");
                spriteClone.transform.parent = worldTile.transform;
                spriteClone.AddComponent<SpriteRenderer>();
                spriteClone.GetComponent<SpriteRenderer>().sprite = backgroundSpriteList[i];

                if (i > 0)
                {
                    spriteClone.transform.position = new Vector2(0, spriteClone.GetComponent<SpriteRenderer>().size.y * i);
                }
            }
            GameObject spriteClone1 = new GameObject("Sprite_Tile-last");
            spriteClone1.transform.parent = worldTile.transform;
            spriteClone1.AddComponent<SpriteRenderer>();
            spriteClone1.GetComponent<SpriteRenderer>().sprite = backgroundSpriteList[0];
            spriteClone1.transform.position = new Vector2(0, spriteClone1.GetComponent<SpriteRenderer>().size.y * backgroundSpriteList.Length);

            canCreate = false;
        }
    }
}
