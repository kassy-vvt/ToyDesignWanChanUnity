using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manage : MonoBehaviour
{

    NetworkTest networkTest;

    // Start is called before the first frame update
    void Start()
    {
        networkTest = GetComponent<NetworkTest>();//isyoku

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UnityEngine.Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }

    }


    public void OnClick0()
    {
        SceneManager.LoadScene(0);
        Reset();
    }
    public void OnClick1()
    {
        Debug.Log("onClick1");

        SceneManager.LoadScene(1);
        Reset();
    }
    public void OnClick2()
    {
        SceneManager.LoadScene(2);
        Reset();
    }
    public void OnClick3()
    {
        SceneManager.LoadScene(3);
        Reset();
    }
    public void OnClick4()
    {
        SceneManager.LoadScene(4);
        Reset();
    }
    public void OnClick5()
    {
        SceneManager.LoadScene(5);
        Reset();
    }
    public void OnClick6()
    {
        SceneManager.LoadScene(6);
        Reset();
    }
    public void OnClick7()
    {
        SceneManager.LoadScene(7);
        Reset();
    }
    public void OnClick8()
    {
        SceneManager.LoadScene(8);
        Reset();
    }
    public void OnClick9()
    {
        SceneManager.LoadScene(9);
        Reset();
    }
    public void OnClickReset()
    {
        SceneManager.LoadScene(0);
        Reset();
    }

    public void Reset()
    {
        List<object> temp = new List<object>();
        temp.Add(9);

        OSCHandler.Instance.SendMessageToClient("client1", "/vvp", temp);
        OSCHandler.Instance.SendMessageToClient("client2", "/vvp", temp);
    }

}

