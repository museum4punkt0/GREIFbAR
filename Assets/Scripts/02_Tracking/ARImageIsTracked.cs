using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageIsTracked : MonoBehaviour
{
    [SerializeField]
    GameObject body;
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;
    [SerializeField]
    ARSession arSession;

    private void Start()
    {
        arSession.Reset();
    }
    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //When AR Image is tracked or removed
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            body.SetActive(false);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            body.SetActive(true);
            m_TrackedImageManager.trackedImagePrefab.SetActive(false);
        }
    }
}
