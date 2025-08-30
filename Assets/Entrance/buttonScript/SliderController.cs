using UnityEngine;

public class SliderController : MonoBehaviour
{
    public GameObject sliderObj;

    public void ToggleSlider()
    {
        if (sliderObj != null)
        {
          
            sliderObj.SetActive(!sliderObj.activeSelf);
        }
    }
}