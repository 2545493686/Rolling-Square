using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_t : MonoBehaviour {
    public GameObject ci;

    bool up = false;
    bool down = true;
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void ToUp()
    {
        up = true;
    }
    void ToDown()
    {
        down = true;
    }
	void Update () {
        if (down)
        {
            ci.transform.Translate(Vector3.down * 0.1f,Space.Self);
            if (ci.transform.position.y <= 0.6)
            {
                down = false;
                Invoke("ToUp", 2);
            }
        }
        if (up)
        {
            ci.transform.Translate(Vector3.up * 0.1f, Space.Self);
            if (ci.transform.position.y >= 1.4)
            {
                up = false;
                Invoke("ToDown", 2);
            }
        }
    }
}
