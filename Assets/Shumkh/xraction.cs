using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class xraction : MonoBehaviour
{


    public InputActionProperty xr;
    public Camera camera;
    public GameObject Keyboard;
    public string fileName = "CameraView.png";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (xr.action.WasPressedThisFrame())
        {

            Capture();

        }
    }

    public void Capture()
    {
        RenderTexture rt = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 24);
        camera.targetTexture = rt;
        camera.Render();

        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes(Path.Combine(Application.dataPath, "..", fileName), bytes);
        Debug.Log("Captured camera view saved to: " + fileName);

        // cleanup
       Object.Destroy(rt);
       Object.Destroy(tex);

        Keyboard.SetActive(true);
    }
}
    
