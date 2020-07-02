using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetSelection : MonoBehaviour
{
    //public GameObject[] petPrefabs; //用于存放宠物数组
    //private int selectedIndex = 0; //创建选择索引的变量
    //public static GameObject selectedPet;



    //// Start is called before the first frame update
    //void Start()
    //{
    //    petShow();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void petShow()
    //{
    //    petPrefabs[selectedIndex].SetActive(true);
    //    selectedPet = petPrefabs[selectedIndex];
    //    Debug.Log("PetShow: "+selectedIndex.ToString());
    //    for (int i = 0; i < petPrefabs.Length; i++)
    //        if (i != selectedIndex)
    //            petPrefabs[i].SetActive(false);
    //}



    //public void onLeftButtonClick()
    //{
    //    selectedIndex--;
    //    if (selectedIndex == -1)
    //        selectedIndex = petPrefabs.Length - 1;
    //    petShow();
    //    Debug.Log("Left was clicked!");
    //}

    //public void onRightButtonClick()
    //{
    //    selectedIndex++;
    //    selectedIndex %= petPrefabs.Length;
    //    petShow();
    //    Debug.Log("Right was clicked!");
    //}

    private int startNumberOfModel = 1;
    private int endNumberOfModel = 4;
    private static int allNumberOfModel = 8;
    
    private int selectedIndex;
    public GameObject selectedPet;
    private GameObject modelRoot;

    private GameObject indexImageRoot;
    private GameObject selectedIndexImage;
    private GameObject UIRoot;
    void Start()
    {
        //Object.DontDestroyOnLoad(gameObject);
        modelRoot = GameObject.Find("cat_model_root");
        indexImageRoot = GameObject.Find("catIndex");
        UIRoot = GameObject.Find("UI Root");
        Debug.Log("modelRoot: " + modelRoot.name);

        selectedIndex = startNumberOfModel;
        selectedPet = modelRoot.transform.Find("cat_model " + selectedIndex.ToString()).gameObject;
        selectedIndexImage = indexImageRoot.transform.Find("Index" + (selectedIndex%4).ToString()).gameObject;
        Debug.Log("PetShow: " + selectedPet.name);
        showPet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showPet()
    {
        selectedPet.SetActive(false);
        selectedPet = modelRoot.transform.Find("cat_model " + selectedIndex.ToString()).gameObject;
        selectedPet.SetActive(true);
        Debug.Log("PetShow: " + selectedIndex.ToString());
    }

    void showIndexImage()
    {
        selectedIndexImage.SetActive(false);
        selectedIndexImage = indexImageRoot.transform.Find("Index" + (selectedIndex % 4).ToString()).gameObject;
        selectedIndexImage.SetActive(true);
    }
    public void onLeftButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == startNumberOfModel-1)
            selectedIndex = endNumberOfModel;
        showPet();
        showIndexImage();
        Debug.Log("Left was clicked!");
    }

    public void onRightButtonClick()
    {
        selectedIndex++;
        if (selectedIndex == endNumberOfModel+1)
            selectedIndex = startNumberOfModel;
        showPet();
        showIndexImage();
        Debug.Log("Right was clicked!");
    }
    public void OnConfirmButtonClick()
    {
        selectedPet = modelRoot.transform.Find("cat_model " + selectedIndex.ToString()).gameObject;
        selectedPet.SetActive(false);
        PlayerPrefs.SetInt("selectedIndex", selectedIndex);
        GameObject.Find("Button").SetActive(false);
        GameObject.Find("cat_model_root").SetActive(false);
        GameObject.Find("catIndex").SetActive(false);
        UIRoot.transform.Find("Label").gameObject.SetActive(false);
        UIRoot.transform.Find("loadingText").gameObject.SetActive(true);
        SceneManager.LoadScene("HelloAR");
        Debug.Log("I was clicked!");
    }
    public void OnRerollButtonClick()
    {
        if(endNumberOfModel != allNumberOfModel)
        {
            startNumberOfModel += 4;
            endNumberOfModel += 4;
        }
        else
        {
            startNumberOfModel = 1;
            endNumberOfModel = 4;
        }
        selectedIndex = startNumberOfModel;
        
        System.Threading.Thread.Sleep(1000);
        showPet();
        showIndexImage(); 
    }
}
