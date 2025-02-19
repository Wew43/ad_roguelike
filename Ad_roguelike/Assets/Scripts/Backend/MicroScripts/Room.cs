using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2Int myPosition;
    public Sprite[] roomSprites;
    public GameObject roomSpritePrefab;
    void Start()
    {
        var a = Instantiate(roomSpritePrefab);
        a.transform.parent = this.transform;
        a.transform.localPosition = new Vector2(0, 0);
        a.GetComponent<SpriteRenderer>().sprite = roomSprites[Random.Range(0, roomSprites.Length)];
    }
    void Update()
    {
        
    }
}
