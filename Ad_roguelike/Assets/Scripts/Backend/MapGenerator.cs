using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject RoomPrefab, CorridorPrefab;
    public Dictionary<Vector2Int, GameObject> rooms = new Dictionary<Vector2Int, GameObject>();
    public List<Vector2Int> transitions1, transitions2;
    List<GameObject> Rooms;
    int LastX = 0, LastY = 0;
    void Start()
    {
        Rooms = new List<GameObject>();
        var s = Instantiate(RoomPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        s.GetComponent<Room>().SpawnRoom(1);
        rooms.Add(new Vector2Int(0, 0), s);
        rooms[new Vector2Int(0, 0)].transform.parent = this.transform;

        

        for (int i = 0; i < 12; i++)
        {
            GenerateRoom();
        }

        transform.localScale = new Vector3(0.35f, 0.35f, 1);
        transform.localPosition = new Vector3(-370, -370, 0);

        //постоянный магазин
        int rnd1 = Random.Range(1, Rooms.Count - 1);
        Rooms[rnd1].GetComponent<Room>().RedactRoomIcon(2);
        //магазин с 20% шансом
        if(Random.Range(0, 100) < 20)
        {
            int rnd2 = Random.Range(1, Rooms.Count - 1);
            Rooms[rnd2].GetComponent<Room>().RedactRoomIcon(2);
        }

        //Сокровищница
        int rnd3 = Random.Range(1, Rooms.Count - 1);
        Rooms[rnd3].GetComponent<Room>().RedactRoomIcon(3);

        //boss
        Rooms[Rooms.Count - 1].GetComponent<Room>().RedactRoomIcon(0);
        Rooms[Rooms.Count - 1].GetComponent<Room>().MakeIconRed();
    }

    void GenerateRoom()
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



            if ((x > 3 || x < 0 || y > 3 || y < 0) || (y == 3 && x == 3))
            {
                timer++;
                continue;
            }

            if (!rooms.ContainsKey(new Vector2Int(x, y)))
            {
                genered = false;
                var g = Instantiate(RoomPrefab, new Vector3(x * 7, y * 7, 0), Quaternion.identity);
                g.transform.parent = transform;
                Rooms.Add(g);
                g.GetComponent<Room>().myPosition = new Vector2Int(x, y);
                g.GetComponent<Room>().SpawnRoom(0);
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
                transitions1.Add(new Vector2Int(LastX, LastY));
                transitions2.Add(new Vector2Int(x, y));
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

            //Всё что ниже, должно быть ниже!!!
            if (timer >= 12)
            {
                int p = Random.Range(0, Rooms.Count);
                LastX = Rooms[p].GetComponent<Room>().myPosition.x;
                LastY = Rooms[p].GetComponent<Room>().myPosition.y;
                timer = 0;
                continue;

            }

        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GenerateRoom();
        }
    }
}
