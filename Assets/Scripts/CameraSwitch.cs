using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject Camera;
    public GameObject TopCamera;

    AudioListener CameraAudioLis;
    AudioListener TopCameraAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        CameraAudioLis = Camera.GetComponent<AudioListener>();
        TopCameraAudioLis = TopCamera.GetComponent<AudioListener>();

        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            Camera.SetActive(true);
            CameraAudioLis.enabled = true;

            TopCameraAudioLis.enabled = false;
            TopCamera.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            TopCamera.SetActive(true);
            TopCameraAudioLis.enabled = true;

            CameraAudioLis.enabled = false;
            Camera.SetActive(false);
        }

    }
}
