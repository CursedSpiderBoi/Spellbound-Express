using UnityEngine;

public class AutoParallax : MonoBehaviour
{
    public float scrollSpeed = 1f; // Negative value for leftward motion
    private float spriteWidth;
    private Transform[] children;

    void Start()
    {
        SpriteRenderer sr = GetComponentsInChildren<SpriteRenderer>()[0];
        spriteWidth = sr.bounds.size.x;

        children = new Transform[2];
        children[0] = transform.GetChild(0);
        children[1] = transform.GetChild(1);
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        for (int i = 0; i < children.Length; i++)
        {
            Transform child = children[i];
            if (child.position.x < Camera.main.transform.position.x - spriteWidth)
            {
                float rightmostX = GetRightmostChildX();
                child.position = new Vector3(rightmostX + spriteWidth, child.position.y, child.position.z);
            }
        }
    }

    float GetRightmostChildX()
    {
        float maxX = float.MinValue;
        foreach (Transform child in children)
        {
            if (child.position.x > maxX)
                maxX = child.position.x;
        }
        return maxX;
    }
}
