using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void HandleDeath()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponsSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void OnCollisionEnter(Collision collisionInfo)
    {
        
        if (collisionInfo.collider.tag == "Last")
        {
            SceneManager.LoadScene("End-Screen");
            Debug.Log("Last");
        }
    }
}
