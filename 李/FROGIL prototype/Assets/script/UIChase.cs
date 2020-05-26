﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class UIChase : MonoBehaviour
{
 
    [SerializeField]
    public Transform targetObject;
    private RectTransform uiImage;
 
    void Start()
    {
        uiImage = GetComponent<RectTransform>();
    }
 
    void Update()
    {
        uiImage.position
            = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);
    }
}