using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject toastParent;
    public Text toastText;

    private Vector3 toastParentLerpPosition;

    void Start()
    {
        toastParentLerpPosition = toastParent.transform.localPosition;
    }

    private void Update()
    {
        toastParent.transform.localPosition = Vector3.Lerp(toastParent.transform.localPosition, toastParentLerpPosition, 0.2f);
    }

    public void ShowToast(string _text)
    {
        toastText.text = _text;
        toastParentLerpPosition = new Vector3(000, 50, 0);
        Invoke("HideToast", 2f);
    }

    public void HideToast()
    {
        toastParentLerpPosition = new Vector3(000, -150, 0);
    }
}
