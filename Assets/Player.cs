using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float velocity;
    static float b = Mathf.Pow(2, 0.5f);
    bool isLook = true;
    bool goR = false;
    bool goL = false;
    int goRi = 0;
    int goLi = 0;
    Cube cube;
    public GameObject light, dark, edge, thorn, fly ,nul;
    map map;

    Vector3 vector = new Vector3();

    // Use this for initialization
    void Start () {
        cube = new Cube
        {
            light_cube = light,
            dark_cube = dark,
            edge_cube = edge,
            fly_trap = fly,
            thorn_trap = thorn,
            null_cube = nul
        };
        map = new map(cube);
        transform.position = new Vector3(3.535534f, 2, 4.949748f); //初始化位置
        transform.Rotate(new Vector3(0, 45, 0));
        //3.546116,16.63684,6.88186
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(3.546116f, 16.63684f, 6.88186f);
        camera.GetComponent<camera>().z = camera.transform.position.z - transform.position.z;

        InvokeRepeating("Old",0.1f,0.1f);
    }
    void Old()
    {
        map.Del();
    }
    void Update()
    {
        if (Mathf.Repeat(Time.time, 0.5f) >= 0.49f)
        {
            map.NewLine(true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            map.Del();
        }
        if (Input.GetKey(KeyCode.X))
        {
            map.NewLine(true);
        }

        if (Input.GetKey(KeyCode.D) && isLook)
        {
            isLook = false;
            goR = true;
            goRi = 0;
            vector = transform.position;
            transform.RotateAround(new Vector3(vector.x + b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, -1), 6);
        }
        if (goR)
        {
            goRi += 6;
            if (goRi < 90)
            {
                //Debug.Log(transform.eulerAngles.x);
                transform.RotateAround(new Vector3(vector.x + b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, -1), 6);
            }
            else
            {
                isLook = true;
                goR = false;
                goRi = 0;
            }
        }

        if (Input.GetKey(KeyCode.A) && isLook)
        {
            isLook = false;
            goL = true;
            vector = transform.position;
            transform.RotateAround(new Vector3(vector.x - b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, 1), 6);
        }
        if (goL)
        {
            goLi += 6;
            if (goLi < 90)
            {
                //Debug.Log(goLi);
                transform.RotateAround(new Vector3(vector.x - b / 4, 1.5f, vector.z + b / 4), new Vector3(1, 0, 1), 6);
            }
            else
            {
                isLook = true;
                goL = false;
                goLi = 0;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "CI")
        {
            Debug.Log("CI");
            for (int i = map.delNumber; i < map.number; i++)
            {
                map.Over();
            }
            map = new map(cube);

            Invoke("NewGame", 0.5f);

        }
    }
    void NewGame()
    {
        transform.position = new Vector3(3.535534f, 2, 4.949748f); //初始化位置
        //transform.Rotate(new Vector3(0, 45, 0));
    }
}
