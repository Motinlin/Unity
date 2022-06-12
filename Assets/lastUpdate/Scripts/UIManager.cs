using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class UIManager : MonoBehaviour
{   
    // Start is called before the first frame update
    private bool mbpause;
    void Start()
    {
        
    }
    public void GamePause()
    {
        Debug.Log("Pause");
        if (!mbpause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        mbpause = !mbpause;
    }
    public void GameVolumeChange(float Volume)
    {
        Debug.Log(Volume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
