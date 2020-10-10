using UnityEngine;

public class ChangeActiveChild : MonoBehaviour
{
    public KeyCode keyCode;
    public int activeChild = 0;

    private void OnEnable()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        activeChild = Mathf.Min(activeChild, transform.childCount - 1);
        transform.GetChild(activeChild).gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            transform.GetChild(activeChild).gameObject.SetActive(false);
            activeChild = (activeChild + 1) % transform.childCount;
            transform.GetChild(activeChild).gameObject.SetActive(true);
        }
    }
}
