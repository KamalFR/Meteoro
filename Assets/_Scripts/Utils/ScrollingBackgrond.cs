using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackgrond : MonoBehaviour
{
    [SerializeField] Vector2 scollingVelocity;
    [SerializeField] Sprite _defaultBackground;
    [SerializeField] Sprite _chuvaDeMeteoro;
    [SerializeField] Sprite _meteoroArmado;
    [SerializeField] Sprite _meteoroTeleguiado;

    private RawImage rawImageComponent;
    private void Awake()
    {
        rawImageComponent = GetComponent<RawImage>();
    }
    public void ChangeBackgrond(SpecialEvent specialEvent)
    {
        switch(specialEvent)
        {
            case SpecialEvent.NONE:
                rawImageComponent.texture = _defaultBackground.texture;
                break;
            case SpecialEvent.METEOROS_ARMADOS:
                rawImageComponent.texture = _meteoroArmado.texture;
                break;
            case SpecialEvent.METEOROS_TELEGUIADOS:
                rawImageComponent.texture = _meteoroTeleguiado.texture;
                break;
            case SpecialEvent.CHUVA_DE_METEORO:
                rawImageComponent.texture = _chuvaDeMeteoro.texture;
                break;

        }
    }

    private void Update()
    {
        rawImageComponent.uvRect = new Rect(rawImageComponent.uvRect.position + scollingVelocity * Time.deltaTime, rawImageComponent.uvRect.size);
    }


}
