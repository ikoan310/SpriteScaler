using UnityEngine;

[ExecuteInEditMode]
public class SpriteScaler : MonoBehaviour 
{
    [SerializeField] float targetScreenHeight = 1334f;
    [SerializeField] float targetScreenWidth = 750f;

    private void OnEnable()
	{
        if (targetScreenWidth <= 0f || targetScreenHeight <= 0f)
            return;

        float screenAspect = Screen.height / Screen.width;
        float targetAspect = targetScreenHeight / targetScreenWidth;
        float targetHeight = targetScreenHeight;

        // 想定画面より縦長の場合
        if(screenAspect>targetAspect)
        {
            targetHeight *= Screen.height / (targetScreenHeight * Screen.width / targetScreenWidth);
        }

        float size = 2f / targetHeight;
        Vector3 currentScale = transform.localScale;
        if (!(Mathf.Abs(currentScale.x - size) <= float.Epsilon) ||
            !(Mathf.Abs(currentScale.y - size) <= float.Epsilon) ||
            !(Mathf.Abs(currentScale.z - size) <= float.Epsilon))
        {
            transform.localScale = new Vector3(size, size, size);
        }
	}
}
