using UnityEngine;
using UnityEngine.UI;
namespace Cosmos6
{
    public class SpeedDisplay : MonoBehaviour
    {
        public Text speedText; // the text component to display the speed

        public void DisplaySpeed(float speed)
        {
            speedText.text = "Speed: " + speed.ToString("F1") + " m/s";
        }
    }
}