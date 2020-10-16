using UnityEngine;

public class Character : MonoBehaviour
{
    public Texture2D[] normals;
    public Texture2D[] withGuns;

    public TMPro.TMP_Text text;

    private int index = 0;

    public void RandomIndex()
    {
        var lastIndex = index;

        while(index == lastIndex)
        {
            index = Random.Range(0, normals.Length);
        }
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void StartTimer()
    {
        FindObjectOfType<Timer>().enabled = true;
    }

    public void SetTexture(int withGun)
    {
        var renderer = GetComponent<Renderer>();
        if(withGun == 0)
        {
            renderer.sharedMaterial.SetTexture("_MainTex", normals[index]);
        }
        else 
        {
            renderer.sharedMaterial.SetTexture("_MainTex", withGuns[index]);
        }
    }
}
