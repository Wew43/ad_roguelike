using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2Int myPosition;
    public Sprite[] roomSprites;
    public GameObject roomSpritePrefab;
    public SpriteRenderer roomIcon;
    void Start()
    {
        
    }

    public void SpawnRoom()
    {
        
        var a = Instantiate(roomSpritePrefab);
        a.transform.parent = this.transform;
        a.transform.localPosition = new Vector2(0, 0);
        roomIcon = a.GetComponent<SpriteRenderer>();
        roomIcon.sprite = roomSprites[Random.Range(0, roomSprites.Length)];
        roomIcon.sortingOrder = 2;

        
    }

    public void SpawnRoom(int n)
    {
        var a = Instantiate(roomSpritePrefab);
        a.transform.parent = this.transform;
        a.transform.localPosition = new Vector2(0, 0);
        roomIcon = a.GetComponent<SpriteRenderer>();
        roomIcon.sprite = roomSprites[n];
        roomIcon.sortingOrder = 2;
    }

    public void RedactRoomIcon(int n)
    {
        roomIcon.sprite = roomSprites[n];
    }
    public void MakeIconRed()
    {
        roomIcon.color = Color.red;
    }
}
