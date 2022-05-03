
using UnityEngine;
using TriLibCore.General;
using TriLibCore.Extensions;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
namespace TriLibCore.General{
public class Assetloader_03 : MonoBehaviour
{
    [SerializeField]
    private GameObject objManager;
    public GameObject loadedObject;
    public GameObject arObject;
    [SerializeField]
    private Button loadingBTTN;
    [SerializeField]
    private TMP_Text progressTXT;

        public void LoadModel()
        {
            var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
            var assetLoaderFilePicker = AssetLoaderFilePicker.Create();
            assetLoaderFilePicker.LoadModelFromFilePickerAsync("Select a Model file", OnLoad, OnMaterialsLoad, OnProgress, OnBeginLoad, OnError, null, assetLoaderOptions);
        }
        private void OnLoad(AssetLoaderContext assetLoaderContext)
        {
            if (loadedObject != null)
            {
                Destroy(loadedObject);
            }
            loadedObject = assetLoaderContext.RootGameObject;
            if (loadedObject != null)
            {
                //Camera.main.FitToBounds(assetLoaderContext.RootGameObject, 2f);
            }
        }
        
        private void OnBeginLoad(bool filesSelected)
        {
            loadingBTTN.interactable = !filesSelected;
            progressTXT.enabled = filesSelected;
        }

        private void OnError(IContextualizedError obj)
        {
            Debug.LogError($"An error occurred while loading your Model: {obj.GetInnerException()}");
        }
        
        private void OnProgress(AssetLoaderContext assetLoaderContext, float progress)
        {
            progressTXT.text = $"Progress: {progress:P}";
        }

        private void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {
            if (assetLoaderContext.RootGameObject != null)
            {
                progressTXT.text="Model is loaded.";
            }
            else
            {
                progressTXT.text="Model could not be loaded.";
            }
            loadingBTTN.interactable = true;
            progressTXT.enabled = false;
            loadedObject.name = "loadedOBJ";
            loadedObject.transform.parent = arObject.transform;
            objManager.SetActive(true);
            objManager.GetComponent<ARObjManager_03>().loadedOBJ=loadedObject;
        }
    }
}
