using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makemusic : MonoBehaviour
{

    NetworkTest networkTest;

    public AudioClip[] PaudioClip = new AudioClip[32];
    public AudioClip[] audioClip = new AudioClip[32];
    AudioClip[] soundsPlay1 = new AudioClip[4];
    AudioClip[] soundsPlay2 = new AudioClip[8];
    AudioClip[] soundsPlay3 = new AudioClip[16];
    AudioSource audioSource;

    float TimeCount = 0f;
    int Coun1 = 0;
    int Coun2 = 0;
    int Coun3 = 0;

    float Rtimer = 0f; //isyoku

    float freq = 1.0f;
    float notifire = 0.0f;
    float Rnotifire = 0.0f;

    int sendnum = 0;
    // Start is called before the first frame update
    void Start()
    {
        networkTest = GetComponent<NetworkTest>();//isyoku
        Debug.Log("start makemusic");
        //Debug.Log(PaudioClip.Length);
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < PaudioClip.Length; i++)
        {
            audioClip[i] = PaudioClip[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaT = Time.deltaTime;
        Rtimer += deltaT;//isyoku

        TimeCount += deltaT;
        if (TimeCount > notifire)
        {
            notifire += freq / 4;

            //if Coun1 is 0, it's gonna be 1.
            //if Coun1 is 1, it's gonna be 2.
            //if Coun1 is 2, it's gonna be 3.
            //if Coun1 is 3, it's gonna be 0.
            //Coun1 represents index of soundplay1[], as Coun2 and Coun3
            //

            if (Coun1 < 3)
            {
                Coun1++;
            }
            else
            {
                Coun1 = 0;
            }

            if (Coun2 < 7)
            {
                Coun2++;
            }
            else
            {
                Coun2 = 0;
            }

            if (Coun3 < 15)
            {
                Coun3++;
            }
            else
            {
                Coun3 = 0;
            }

            //Debug.Log("Every loop check : Coun3 = " + Coun3);

            if (soundsPlay1[Coun1] != null)
            {
                audioSource.PlayOneShot(soundsPlay1[Coun1]);
            }
            if (soundsPlay2[Coun2] != null)
            {
                audioSource.PlayOneShot(soundsPlay2[Coun2]);
            }
            if (soundsPlay3[Coun3] != null)
            {
                //Debug.Log("------- ---  PlayOneShot coun3 = " + Coun3);
                audioSource.PlayOneShot(soundsPlay3[Coun3]);
            }
            //if(Coun1 = 0 )network.reg

            //TimeCount = 0f;
            //Debug.Log(Coun1+";" + Coun2+";" + Coun3);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            int d1 = Random.Range(0, 3);
            int d2 = Random.Range(0, 32);
            MusicStore(d1, d2);

            // Debug.Log(2 +"::"+ d2);
        }

        if (Rtimer > Rnotifire)
        {


            Rnotifire += freq;
            networkTest.Regulate(sendnum);
            Debug.Log("sended num = " + sendnum);
            Debug.Log("Regulate ************************");
            //Debug.Log(Rtimer);
            if (sendnum < 3)
            {
                sendnum += 1;
            }
            else
            {
                sendnum = 0;
            }

        }
    }


    public void MusicStore(int D1, int D2)
    {


        if (D1 == 0)
        {
            soundsPlay1[(Coun1)] = audioClip[D2];//"+1%4"は踏んだ際に必ず先のサウンドポイントに音が保存されるように
                                                 //もしなければ踏んでから一周回った後に音が鳴る、あればCounが次に更新されたタイミングで鳴る 
        }
        else if (D1 == 1)
        {
            soundsPlay2[(Coun2)] = audioClip[D2];
        }
        else if (D1 == 2)
        {
            soundsPlay3[(Coun3)] = audioClip[D2];

            //Debug.Log("***** musicstore coun3 = " + Coun3);
        }
        audioSource.PlayOneShot(audioClip[D2]);

    }

}
