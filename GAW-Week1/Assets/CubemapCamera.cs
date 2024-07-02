using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubemapCamera : MonoBehaviour {
    [SerializeField] Camera _cubemapCamera;
    [SerializeField] int _cubemapSize = 128;
    [SerializeField] bool _oneFacePerFrame = true;

    [SerializeField] RawImage renderTarget;
    
    RenderTexture renderTexture;
    RenderTexture eqiTexture;

    void Start() {
        renderTexture = new RenderTexture(_cubemapSize, _cubemapSize, 16);
        renderTexture.dimension = UnityEngine.Rendering.TextureDimension.Cube;
        renderTexture.filterMode = FilterMode.Point;

        eqiTexture = new RenderTexture(_cubemapSize, _cubemapSize, 16);
        eqiTexture.filterMode = FilterMode.Point;
        eqiTexture.format = RenderTextureFormat.RGB111110Float;
        renderTarget.texture = eqiTexture;
        eqiTexture.wrapMode = TextureWrapMode.Repeat;

        // render all six faces at startup
        UpdateCubemap(63);
    }

    void LateUpdate() {
        if (_oneFacePerFrame) {
            int faceToRender = Time.frameCount % 6;
            int faceMask = 1 << faceToRender;
            UpdateCubemap(faceMask);
        } else {
            UpdateCubemap(63); // all six faces
        }
    }

    void UpdateCubemap(int faceMask) {
        _cubemapCamera.RenderToCubemap(renderTexture, faceMask);
        renderTexture.ConvertToEquirect(eqiTexture, Camera.MonoOrStereoscopicEye.Mono);
    }
}