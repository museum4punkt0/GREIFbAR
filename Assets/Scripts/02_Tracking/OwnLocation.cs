using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
using ARLocation;

public class OwnLocation : MonoBehaviour
{
    float myLatValue = 48.0948f;
    float myLngValue = 11.586f;
    float myAltValue = 0;
    public float dist;
    public TMP_Text txt;
    public TMP_Text txt2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Get your own location
        var placeAtLocation = GetComponent<PlaceAtLocation>();

        dist = placeAtLocation.SceneDistance;
        txt.text = dist.ToString("F")+"m";
        txt2.text = "Entfernung: "+txt.text;
        if (dist < 0.8) { txt2.text = "Du stehst auf dem Punkt."; }
        else if (dist> 800) { txt2.text = "Ort ist zu weit weg."; }
    }
    public void UpdateLocation(string locValue)
    {
        // Updates your location
        var strings = locValue.Split(","[0]);
        if (strings[0] != null && strings[1] != null)
        {
            myLatValue = float.Parse(strings[0], CultureInfo.InvariantCulture);
            myLngValue = float.Parse(strings[1], CultureInfo.InvariantCulture);
        }
        else
        {

        }
        var newLocation = new Location()
        {
            // getting own location
            Latitude = myLatValue,
            Longitude = myLngValue,
            Altitude = myAltValue,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        var placeAtLocation = GetComponent<PlaceAtLocation>();
        placeAtLocation.Location = newLocation;
        dist = placeAtLocation.SceneDistance;
    }

    public void UpdateOwnLocation()
    {
        myLatValue = Input.location.lastData.latitude;
        myLngValue = Input.location.lastData.longitude;
        var newLocation = new Location()
        {
            Latitude = myLatValue,
            Longitude = myLngValue,
            Altitude = myAltValue,
            AltitudeMode = AltitudeMode.GroundRelative
        };

        var placeAtLocation = GetComponent<PlaceAtLocation>();
        placeAtLocation.Location = newLocation;
        dist = placeAtLocation.SceneDistance;
    }
}
