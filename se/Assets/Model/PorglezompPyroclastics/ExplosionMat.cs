using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode()]  

public class ExplosionMat : MonoBehaviour {
	
	private string[] qualitySel = new[] {"QUALITY_LOW", "QUALITY_MED", "QUALITY_HIGH"};
	bool doUpdate = true;
	float _radius;
	
	public Texture2D _ramp;
	public Texture2D _noise;
	public Material ExplosionMaterial;
	
	public float _heat = 1;
	float useheat = 1;
	public float _alpha = 1;
	float usealpha = 1;
	public float _scrollSpeed = 1;	
	float usescroll = 1;
	public float _frequency = 1;
	float usefreq = 1;
	
	public bool _scattering = true;
	bool usescatter = true;
	public int _octaves = 4;
	int useoctaves = 4;
	public int _quality = 2;
	int usequality = 2;

    float timeSpan;  //경과 시간을 갖는 변수
    float checkTime;  // 특정 시간을 갖는 변수
                      // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = new Material(ExplosionMaterial);
		UpdateShaderProperties();
        timeSpan = 0.0f;
        checkTime = 1f;  // 특정시간을 지정
    }

    // Update is called once per frame
    void Update()
    {


        if (doUpdate)
        {
            Material rsm = GetComponent<Renderer>().sharedMaterial;
            float minscale = Mathf.Min(transform.lossyScale.x, Mathf.Min(transform.lossyScale.y, transform.lossyScale.z));
            // If anything has changed, update that property.
            if (minscale != _radius)
            {
                _radius = minscale;
                rsm.SetFloat("_Radius", _radius / 2.03f - 2);
            }
            if (useheat != _heat)
            {
                useheat = _heat;
                rsm.SetFloat("_Heat", _heat);
            }
            if (usealpha != _alpha)
            {
                usealpha = _alpha;
                rsm.SetFloat("_Alpha", _alpha);
            }
            if (usescroll != _scrollSpeed)
            {
                usescroll = _scrollSpeed;
                rsm.SetFloat("_ScrollSpeed", _scrollSpeed);
            }
            if (usefreq != _frequency)
            {
                usefreq = _frequency;
                rsm.SetFloat("_Frequency", _frequency);
            }
            if (usescatter != _scattering || useoctaves != _octaves || usequality != _quality)
            {
                usescatter = _scattering;
                useoctaves = _octaves;
                usequality = _quality;
                SetShaderKeywords();
            }
        }
        timeSpan += Time.deltaTime;  // 경과 시간을 계속 등록
        if (timeSpan > checkTime)  // 경과 시간이 특정 시간이 보다 커졋을 경우
        {
            Destroy(gameObject);
            timeSpan = 0;
        }
    }
	public void UpdateShaderProperties() {
		Material rsm = GetComponent<Renderer>().sharedMaterial;
		rsm.SetTexture("_RampTex", _ramp);
		rsm.SetTexture("_MainTex", _noise);
		rsm.SetFloat("_Heat", _heat);
		rsm.SetFloat("_Alpha", _alpha);
		rsm.SetFloat("_ScrollSpeed", _scrollSpeed);
		rsm.SetFloat("_Frequency", _frequency);
		SetShaderKeywords();
	}
	
	void SetShaderKeywords () {
		var newKeywords = new List<string> {_scattering ? "SCATTERING_ON" : "SCATTERING_OFF", "OCTAVES_" + _octaves, qualitySel[_quality]};
        GetComponent<Renderer>().sharedMaterial.shaderKeywords = newKeywords.ToArray();
	}
}
