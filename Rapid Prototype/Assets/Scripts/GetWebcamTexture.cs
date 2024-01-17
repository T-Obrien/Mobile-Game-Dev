using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetWebcamTexture : MonoBehaviour
{
    public GameObject selfObject;
    public WebCamTexture camTexture;
    public string path;
    public RawImage displayedImage;
    public Button photoButton;
    public Texture2D takenPhoto;
    public Material takenMaterial;
    public GameObject gameSphere;
    private Renderer renderSphere;
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        camTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = camTexture;
        camTexture.Play();

        photoButton.onClick.AddListener(CatchTexture);
        renderSphere = gameSphere.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MakeTexture()
    { 
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(camTexture.width, camTexture.height);
        photo.SetPixels(camTexture.GetPixels());
        photo.Apply();

        byte[] bytes = photo.EncodeToPNG();

        //File.WriteAllBytes(Application.dataPath + "/photo.png", bytes);
        takenPhoto = new Texture2D(1, 1);
        takenPhoto.LoadImage(bytes);
        renderSphere.material.mainTexture = takenPhoto;
        takenMaterial.mainTexture = renderSphere.material.mainTexture;
        selfObject.transform.position = new Vector3(127f, 0f, -250f);
        camTexture.Stop();
         
    }

    public void CatchTexture()
    {
        StartCoroutine("MakeTexture");

        //this.enabled = false;
        //camTexture.Stop();
        //Renderer rend = GetComponent<Renderer>();
        //rend.material = new Material()
        //takenMaterial.SetTexture("PhotoTexture", takenPhoto);
        //renderSphere.material.SetTexture("_MainTex", takenPhoto);
    }
}
