using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatyText : MonoBehaviour {
    public Text text;
    public Image image;

    public float DisplayTime = 3.0f;

    public bool Float = true;
    public float FloatSpeed = 0.5f;
    public Vector3 FloatVector = new Vector3(0, 0, 1);

    public bool FadeOut = false;
    public float FadeStartTime = 2.0f;

    public bool Shrink;
    public float ShrinkSpeed;

    private float startTime = 0.0f;

    RectTransform thisTransform;
    
    void Awake()
    {
        thisTransform = GetComponent<RectTransform>();
        StartCoroutine(Move());
    }

	public void Init(Vector2 location, string txt)
    {
        text.text = txt;
        thisTransform.position = location;
    }

    IEnumerator Move()
    {
        while(true)
        {
            thisTransform.rotation = Camera.main.transform.rotation;
            startTime += Time.deltaTime;

            if (Float)
            {
                Vector3 f = FloatVector * (FloatSpeed * Time.deltaTime);
                Vector3 currentPosition = thisTransform.localPosition;
                currentPosition += f;
                thisTransform.localPosition = currentPosition;
            }

            if (FadeOut && startTime > FadeStartTime)
            {
                float a = 1- (startTime - FadeStartTime) / (DisplayTime - FadeStartTime);
                Color c = text.color;
                c.a = a;
                text.color = c;

                if(image != null)
                {
                    c = image.color;
                    c.a = a;
                    image.color = c;
                }
            }

            if (Shrink)
            {
                thisTransform.localScale = thisTransform.localScale - (new Vector3(1, 1, 1) * ShrinkSpeed * Time.deltaTime);
            }

            if (startTime > DisplayTime)
            {
                StopAllCoroutines();
                Destroy(gameObject);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
