using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButtonController : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("HelloAR");
        Debug.Log("I was clicked!");
    }
}
