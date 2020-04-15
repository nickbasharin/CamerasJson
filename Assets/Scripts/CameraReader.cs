using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CameraReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject camMesh;

    void Start()
    {
        var jsonParse = JSON.Parse(jsonFile.text);
        float px, py, pz, ox, oy, oz, ow;
        int camAmount = jsonParse[0]["reconstruction"]["images_number"].AsInt;
        for (int camNumber = 0; camNumber < camAmount; camNumber++)
        {
            px = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["position"][0].AsFloat;
            py = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["position"][1].AsFloat;
            pz = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["position"][2].AsFloat;
            ox = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["orientation"][0].AsFloat;
            oy = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["orientation"][1].AsFloat;
            oz = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["orientation"][2].AsFloat;
            ow = jsonParse[0]["reconstruction"]["images"][camNumber]["image"]["camera_description"]["orientation"][3].AsFloat;
            GameObject newCam = Instantiate(camMesh, transform);
            newCam.transform.localPosition = new Vector3(px, py, pz);
            newCam.transform.localRotation = new Quaternion(ox, oy, oz, ow);
            newCam.transform.localPosition = newCam.transform.InverseTransformPoint(new Vector3(0,0,0));
        }
    }
}
