using UnityEngine;

public class CameraManager : GlobalReference<CameraManager>
{
    [SerializeField] private Camera mainCam;
    public static Camera MainCam => Instance.mainCam;

}