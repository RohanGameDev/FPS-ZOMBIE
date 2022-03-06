using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{

    public GameObject Flashlight;
    public bool isOn = false;
    public bool failsafe = false;
    private void Update()
    {
        if (Input.GetButtonDown("Fkey"))
        {
            if (isOn == false && failsafe == false)
            {
                failsafe = true;
                Flashlight.SetActive(true);
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failsafe == false)
            {
                failsafe = true;
                Flashlight.SetActive(false);
                isOn = false;
                StartCoroutine(FailSafe());
            }
           
        }
        
    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failsafe = false;
    }
}
