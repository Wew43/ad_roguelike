using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject RoomPrefab, CorridorPrefab;
    Dictionary<Vector2Int, GameObject> rooms = new Dictionary<Vector2Int, GameObject>();
    List<GameObject> Rooms;
    void Start()
    {
        Rooms = new List<GameObject>();
        rooms.Add(new Vector2Int(0, 0), Instantiate(RoomPrefab, new Vector3(0, 0, 0), Quaternion.identity));
        rooms[new Vector2Int(0, 0)].transform.parent = this.transform;
        int LastX = 0, LastY = 0; 

        for (int i = 0; i < 15; i++)
        {
            int x = 0, y = 0;
            bool genered = true;

            int timer = 0;

            while (genered) 
            {
                int o = Random.Range(0, 4);
                switch (o)
                {
                    case 0:
                        x = LastX + 1;
                        y = LastY;
                        break;
                    case 1:
                        x = LastX - 1;
                        y = LastY;
                        break;
                    case 2:
                        x = LastX;
                        y = LastY + 1;
                        break;
                    case 3:
                        x = LastX;
                        y = LastY - 1;
                        break;
                }

                if (!rooms.ContainsKey(new Vector2Int(x, y)))
                {
                    genered = false;
                    var g = Instantiate(RoomPrefab, new Vector3(x * 7, y * 7, 0), Quaternion.identity);
                    g.transform.parent = transform;
                    Rooms.Add(g);
                    g.GetComponent<Room>().myPosition = new Vector2Int(x, y);
                    rooms.Add(new Vector2Int(x, y), g);
                    switch (o)
                    {
                        case 0:
                            Instantiate(CorridorPrefab, new Vector3(7 * (x), 7 * (y), 0), Quaternion.Euler(0, 0, 180)).transform.parent = this.transform;
                            break;
                        case 1:
                            Instantiate(CorridorPrefab, new Vector3(7 * (x), 7 * (y), 0), Quaternion.Euler(0, 0, 0)).transform.parent = this.transform;
                            break;
                        case 2:
                            Instantiate(CorridorPrefab, new Vector3(7 * (x), 7 * (y), 0), Quaternion.Euler(0, 0, -90)).transform.parent = this.transform;
                            break;
                        case 3:
                            Instantiate(CorridorPrefab, new Vector3(7 * (x), 7 * (y), 0), Quaternion.Euler(0, 0, 90)).transform.parent = this.transform;
                            break;
                    }
                    
                    LastX = x;
                    LastY = y;

                    int p = Random.Range(0, Rooms.Count);
                    LastX = Rooms[p].GetComponent<Room>().myPosition.x;
                    LastY = Rooms[p].GetComponent<Room>().myPosition.y;
                }
                else
                {
                    timer++;
                }

                if(timer >= 12)
                {
                    int p = Random.Range(0, Rooms.Count);
                    LastX = Rooms[p].GetComponent<Room>().myPosition.x;
                    LastY = Rooms[p].GetComponent<Room>().myPosition.y;
                    continue;

                }
                    
            }
            
        }
    }

    void Update()
    {
        
    }
}
