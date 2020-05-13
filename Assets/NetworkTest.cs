using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
public class NetworkTest : MonoBehaviour
{
    private long lastTimeStamp;
    // Use this for initialization


    void Start()
    {
        OSCHandler.Instance.serverInit();
        lastTimeStamp = -1;
        OSCHandler.Instance.clientInit2("client1", "192.168.100.160");
        OSCHandler.Instance.clientInit2("client2", "192.168.100.161");
    }
    // Update is called once per frame
    void Update()
    {
        //  受信データの更新
        OSCHandler.Instance.UpdateLogs();
        //  受信データの解析
        foreach (KeyValuePair<string, ServerLog> item in OSCHandler.Instance.Servers)
        {
            for (int i = 0; i < item.Value.packets.Count; i++)
            {
                if (lastTimeStamp < item.Value.packets[i].TimeStamp)
                {
                    lastTimeStamp = item.Value.packets[i].TimeStamp;
                    //  OSCアドレスを取得
                    string address = (string)item.Value.packets[i].Address;
                    //  受信データを取得
                    int data0 = (int)item.Value.packets[i].Data[0];
                    Debug.Log("アドレスが" + address + " data0 " + data0);

                    int num = Random.Range(0, 32);
                    GetComponent<makemusic>().MusicStore(data0, num);


                }
            }
        }
    }
    public void Regulate(int num)
    {
        List<object> temp = new List<object>();
        temp.Add(num);

        OSCHandler.Instance.SendMessageToClient("client1", "/vvp", temp);
        OSCHandler.Instance.SendMessageToClient("client2", "/vvp", temp);
    }
}
