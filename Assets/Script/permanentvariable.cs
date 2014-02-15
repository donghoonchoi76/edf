using UnityEngine;
using System.Collections;

public static class permanentvariable {
    public static int currentStage;
    public static UnityEngine.Rect rtCameraBorder;

    public static void ToggleVisibility(Transform obj, bool bShow)
    {
        for (int i = 0; i < obj.childCount; i++)
        {
            if (obj.GetChild(i).renderer != null)
                obj.GetChild(i).renderer.enabled = bShow;

            if (obj.GetChild(i).guiTexture != null)
                obj.GetChild(i).guiTexture.enabled = bShow;

            if (obj.GetChild(i).guiText != null)
                obj.GetChild(i).guiText.enabled = bShow;
            
            if (obj.GetChild(i).childCount > 0)
            {
                ToggleVisibility(obj.GetChild(i), bShow);
            }
        }
    }
	
};
