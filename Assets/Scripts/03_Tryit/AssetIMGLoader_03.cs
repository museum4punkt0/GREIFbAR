using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class AssetIMGLoader_03 : MonoBehaviour
{
    
    [SerializeField]
    private GameObject objManager;
	public GameObject ARIMG;
	public GameObject ARVID;
	private MeshRenderer ARRenderer;
    // Start is called before the first frame update
    public void LoadImage(int maxSize)
    {
        ARIMG.SetActive(true);
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// Create Texture from selected image
				Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}

                ARRenderer = ARIMG.GetComponent<MeshRenderer>();
                Material ARmaterial = ARRenderer.material;
                ARmaterial.mainTexture = texture;
                ARIMG.transform.localScale =  new Vector3(0.1f * ((float)texture.width/(float)texture.height),0.1f,0.1f);
		        Debug.Log("Size: " + texture.width/texture.height);
                
                objManager.SetActive(true);
                objManager.GetComponent<ARObjManager_03>().loadedOBJ=ARIMG;
			}
		}, "Select a PNG image", "image/png");

		Debug.Log("Permission result: " + permission);

    }

    public void LoadVideo()
	{
        ARVID.SetActive(true);
		NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
		{
			Debug.Log("Video path: " + path);
			if (path != null)
			{
                
			    //Debug.Log("Video width: " + NativeGallery.GetVideoProperties(path).width);
                VideoPlayer vidPlayer = ARVID.GetComponent<VideoPlayer>();
                vidPlayer.url = path;
                ARVID.transform.localScale =  new Vector3(0.19f,0.1f,0.1f);
                
                objManager.SetActive(true);
                objManager.GetComponent<ARObjManager_03>().loadedOBJ=ARVID;
			}
		}, "Select a video");

		Debug.Log("Permission result: " + permission);
	}
}
