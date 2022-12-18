using UnityEngine;
using System.Collections;
using TMPro;

public class TestLocationService : MonoBehaviour
{
    public TextMeshProUGUI lati, longi, tmp_isGPSon;

    private static bool isGPSon = false;
    private static LocationInfo location;

    private static WaitForSeconds second;

    IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("cant");
            yield break;
        }

        // Starts the location service.
        Input.location.Start(5f);
        tmp_isGPSon.text = "GPS ON";
        PlayerData.isGPSOn = true;
        Debug.Log("location");
        lati.text = "-";
        longi.text = "-";

        location = Input.location.lastData;

        PlayerData.curLati = location.latitude * 1.0d;
        PlayerData.curLongi = location.longitude * 1.0d;
        lati.text = PlayerData.curLati + "";
        longi.text = PlayerData.curLongi + "";
        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            lati.text = Input.location.lastData.latitude + "";
            longi.text = Input.location.lastData.longitude + "";
            isGPSon = true;

            while (isGPSon)
            {
                location = Input.location.lastData;
                PlayerData.curLati = location.latitude * 1.0d;
                PlayerData.curLongi = location.longitude * 1.0d;
                lati.text = PlayerData.curLati + "";
                longi.text = PlayerData.curLongi + "";
                yield return second;
            }
        }
        if (!isGPSon)
        {
            tmp_isGPSon.text = "GPS OFF MODE";
        }
    }

    public static void StartGPS()
    {
        
    }

    public static void StopGPS()
    {
        if (Input.location.isEnabledByUser)
        {
            isGPSon = false;
            PlayerData.isGPSOn = false;
            Input.location.Stop();
        }
    }
}