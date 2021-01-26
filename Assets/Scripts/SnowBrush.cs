using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBrush : MonoBehaviour
{
    [SerializeField] private CustomRenderTexture snowHeightMap;
    [SerializeField] private Material heightMapUpdate;

    [SerializeField] private GameObject tire;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool onSnow;
    [SerializeField] private List<Transform> transformPoints;

    private static readonly int DrawPosition = Shader.PropertyToID(name: "_DrawPosition");
    private static readonly int DrawAngle = Shader.PropertyToID(name: "_DrawAngle");
    void Start()
    {
        snowHeightMap.Initialize();
    }
    void FixedUpdate()
    {
        //if(Input.GetMouseButton(0))

        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(tire.transform.position, Vector3.down);

            if(Physics.Raycast(ray, out RaycastHit hit,layerMask))
            {
            Vector2 hitTextureCoord = hit.textureCoord;
            float angle = tire.transform.rotation.eulerAngles.y;

            if (hit.collider.gameObject.name == "Plane_Road_Snow") { onSnow = true; } else onSnow = false;
                heightMapUpdate.SetVector(name: "_DrawPosition", hitTextureCoord);
                heightMapUpdate.SetFloat(name: "_DrawAngle", value: angle * Mathf.Deg2Rad);

            }
     }
    public bool GetOnSnow(){ return onSnow;}
    
}
