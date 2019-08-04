using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {
    public GameObject light, dark , edge , thorn , fly;
    public map map;
    void Aword()
    {
    }
    // Use this for initialization
    void Start () {
        Cube cube = new Cube {
            light_cube = light,
            dark_cube = dark,
            edge_cube = edge,
            fly_trap = fly,
            thorn_trap = thorn,
        };
        map = new map(cube);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            map.Del();
        }
        if (Input.GetKey(KeyCode.X))
        {
            map.NewLine(true);
        }
    }


}
