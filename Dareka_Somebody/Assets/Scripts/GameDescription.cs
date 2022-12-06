using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject AboutMinigameUI;

    private void Start()
    {
        AboutMinigameUI.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        AboutMinigameUI.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        AboutMinigameUI.SetActive(false);
    }

}
