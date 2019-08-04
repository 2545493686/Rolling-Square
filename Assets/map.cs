using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Cube
{
    public GameObject light_cube;
    public GameObject dark_cube;
    public GameObject edge_cube;
    public GameObject fly_trap;
    public GameObject thorn_trap;
    public GameObject null_cube;
}

public class map : MonoBehaviour
{
    Cube cube = new Cube();

    GameObject[] lightArray;
    GameObject[] darkArray;

    double z_l = 0;
    double z_d = b / 2;
    public int number = 0;
    public int delNumber = 0;

    static double b = Mathf.Pow(2, 0.5f); //根号2

    public map(Cube _cube)
    {
        cube = _cube;
        lightArray = new GameObject[] { cube.light_cube, cube.light_cube, cube.light_cube, cube.thorn_trap, cube.null_cube };
        darkArray = new GameObject[] { cube.dark_cube, cube.dark_cube, cube.dark_cube,cube.thorn_trap, cube.null_cube };

        for (int i = 0; i < 10; i++)
        {
            NewLine(false);
        }
    }

    public void NewLine(bool isRandom)
    {
        for (double x = 0; x < b * 6; x += b)
        {
            if (x == 0 || x == b * 5)
            {
                Clone(x, 2, z_l, cube.edge_cube);
            }
            else
            {
                if (isRandom)
                {
                    GameObject @object = lightArray[Random.Range(0, lightArray.Length)];
                    if (@object == cube.thorn_trap)
                    {
                        Clone(x, 0.5, z_l + b/2, @object);
                    }
                    else 
                    {
                        Clone(x, 1, z_l, @object);
                    }
                }
                else
                {
                    Clone(x, 1, z_l, cube.light_cube);
                }
            }
        }
        for (double x = -b / 2; x < -b / 2 + b * 7; x += b)
        {
            if (x == -b / 2 || x == -b / 2 + b * 6)
            {
                Clone(x, 2, z_d, cube.edge_cube);
            }
            else
            {
                if (isRandom)
                {
                    GameObject @object = darkArray[Random.Range(0, darkArray.Length)];
                    if (@object == cube.thorn_trap)
                    {
                        Clone(x, 0.5, z_d + b / 2, @object);
                    }
                    else
                    { 
                        Clone(x, 1, z_d, @object);
                    }
                }
                else
                {
                    Clone(x, 1, z_d, cube.dark_cube);
                }
            }
        }

        z_l += b;
        z_d += b;
    }

    void Clone(double x, double y, double z, GameObject gameObject)
    {
        GameObject @object = Instantiate(gameObject);
        @object.transform.position = new Vector3((float)x, (float)y, (float)z);
        @object.transform.Rotate(new Vector3(0, 45, 0));
        @object.SetActive(true);
        @object.name = number.ToString();
        number += 1;
    }

    public void Del()
    {
        Object @object = GameObject.Find(delNumber.ToString()).AddComponent<Rigidbody>();
        delNumber += 1;
    }
    public void Over()
    {
        GameObject.Find(delNumber.ToString()).SetActive(false);
        delNumber += 1;
    }
}
