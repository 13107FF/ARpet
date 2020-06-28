using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject moodPanel;
    public GameObject foodPanel;
    public GameObject walkPanel;
    private GameObject currentPanel;
    private GoogleARCore.Examples.HelloAR.HelloARController ARController;
    // Start is called before the first frame update
    void Start()
    {
        homePanel.SetActive(true);
        currentPanel = homePanel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onHomeFoodButtonClicked()
    {
        currentPanel.SetActive(false);
        foodPanel.SetActive(true);
        currentPanel = foodPanel;
    }

    public void onHomeMoodButtonClicked()
    {
        currentPanel.SetActive(false);
        moodPanel.SetActive(true);
        currentPanel = moodPanel;
    }

    public void onHomeWalkButtonClicked()
    {
        currentPanel.SetActive(false);
        walkPanel.SetActive(true);
        currentPanel = walkPanel;
    }

    public void onHomeHouseButtonClicked()
    {
        //啥啊这
    }

    public void onFoodFoodButtonClicked()
    {
        ARController = GameObject.Find("HelloAR Controller").GetComponent<GoogleARCore.Examples.HelloAR.HelloARController>();
        ARController.SetModel = "food";
        Debug.Log("eating clicked");
    }

    public void onMoodMoodButtonClicked()
    {
        ARController = GameObject.Find("HelloAR Controller").GetComponent<GoogleARCore.Examples.HelloAR.HelloARController>();
        ARController.SetModel = "toy";
        Debug.Log("playing clicked");
    }

    public void onbackButtonClilcked()
    {
        currentPanel.SetActive(false);
        homePanel.SetActive(true);
        currentPanel = homePanel;
    }
}
