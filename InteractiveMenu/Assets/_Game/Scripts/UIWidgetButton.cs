using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Tween Library
using Lean.Transition;


public class UIWidgetButton : MonoBehaviour
{

    private bool isSelected = false;

    public RectTransform rectTransform = null;
    public Image widgetBackgroundImage = null;

    public GameObject panel = null;

    public Color backgroundColor = Color.gray;
    public Color backgroundColorSelected = Color.white;

    public float hoverAnimationDuration = 0.5f;

    public float widgetHeight = 150f;
    public float widgetHeightSelected = 250f;

    public float selectAnimationDuration = 0.5f;

    private void Start ( )
    {
        UpdateUISelected ( );
    }

    public void OnHoverEnter ( )
    {
        if ( isSelected )
            return;

        UpdateHoverState ( true );
    }

    public void OnHoverExit ( )
    {
        if ( isSelected )
            return;

        UpdateHoverState ( false );
    }

    public void OnClickDown ( )
    {
        isSelected = !isSelected;

        UpdateUISelected ( );
    }

    public void OnSelect ( )
    {
        isSelected = true;

        UpdateUISelected ( );
    }

    public void OnDeselect ( )
    {
        isSelected = false;

        UpdateUISelected ( );
    }

    private void UpdateUISelected ( )
    {
        rectTransform.sizeDeltaTransition ( 
            new Vector2 ( 
                rectTransform.sizeDelta.x, 
                ( isSelected ) ? widgetHeightSelected : widgetHeight ), 
            selectAnimationDuration, 
            LeanEase.Linear );

        panel.SetActive ( isSelected );
        UpdateHoverState ( isSelected );
    }

    private void UpdateHoverState ( bool hover )
    {
        widgetBackgroundImage.colorTransition ( 
            ( hover ) ? backgroundColorSelected : backgroundColor, 
            hoverAnimationDuration, 
            LeanEase.Linear );
    }

}
