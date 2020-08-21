using UnityEngine;
using UnityEngine.UI;

public class DisplayMode : MonoBehaviour
{
    public void OrbitModeUpdated(int newMode) {
        GetComponent<Text> ().text = newMode.ToString();
    }
}