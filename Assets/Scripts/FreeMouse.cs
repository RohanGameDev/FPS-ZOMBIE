using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMouse : MonoBehaviour
{

    private void Start()
    {
        UnlockMouse();
    }
    void Update()
    {

    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
