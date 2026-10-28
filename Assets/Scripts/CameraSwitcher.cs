using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Virtual Cameras")]
    [SerializeField] private CinemachineCamera followCamera;
    [SerializeField] private CinemachineCamera stationaryCamera; 

    private bool isViewFixed = false;

    void Update()
    {
        if (KeyboardInput.IsCameraSwitchKeyPressed())
        {
            ToggleCameraView();
        }
    }

    private void ToggleCameraView()
    {

        if (isViewFixed)
        {
            followCamera.Priority = 2;
            stationaryCamera.Priority = 1;
            isViewFixed = false;
        }
        else
        {
            followCamera.Priority = 1;
            stationaryCamera.Priority = 2;
            isViewFixed = true;
        }
    }
}