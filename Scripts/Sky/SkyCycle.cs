using UnityEngine;
using System.Collections;

public class SkyCycle : MonoBehaviour
{
    //public Gradient color;
    public GameObject sun;              //Sun prefab
    public GameObject moon;             //Moon prefab
    public ParticleSystem stars;        //Stars PS
    public Gradient skyTintGradient;    //SkyTint Gradient
    public AnimationCurve exposureCurve;   //Exposure curve
    public AnimationCurve atmosCurve;       //Atmospheric thickness curve
    public float cycleTimeMinutes = 10; //Number of minutes one game day is
    public float percentOfDay;           //The percentage of the in game day that has passed
    private Light sunLight;             
    private float sunPos;
    private float moonPos;
    private float percentOfDayPerSecond; //The percentage of the in game day per second
    
    void Start()
    {
        percentOfDayPerSecond = 360 / (cycleTimeMinutes * 60);
        percentOfDay  = 0;
        sunLight = sun.GetComponent<Light>();
        
    }
    void OnDestroy() {
        RenderSettings.skybox.SetColor("_SkyTint", Color .white);
        RenderSettings.skybox.SetFloat("_Exposure", 2f);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", 0.4f);
    }

    void Update()
    {
        //sunLight.color = color.Evaluate(Mathf.Sin(Time.time));
        percentOfDayPerSecond = 360 / (cycleTimeMinutes * 60);
        percentOfDay  += Time.deltaTime  / (cycleTimeMinutes * 60);
        RenderSettings.skybox.SetColor("_SkyTint", skyTintGradient.Evaluate(percentOfDay));
        RenderSettings.skybox.SetFloat("_Exposure", exposureCurve.Evaluate(percentOfDay ));
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", atmosCurve.Evaluate(percentOfDay));
        MoveSky(sun, moon);
    }


    void MoveSky(GameObject Sun, GameObject Moon)
    {
        if (percentOfDay < 0.5)
        {
            Sun.SetActive(true);
            Moon.SetActive(false);
            stars.Stop();
            RenderSettings.ambientLight = sunLight.color;
            RenderSettings.ambientIntensity = 1f;
        }
        else
        {
            Moon.SetActive(true);
            Sun.SetActive(false);
            stars.Play();
        }
        if (Sun.transform.rotation == Quaternion .identity )
        {
            print(Time.time);
            percentOfDay  = 0;
        }

        Sun.transform.RotateAround(Vector3.zero, Vector3.right, percentOfDayPerSecond * Time.deltaTime);
        Sun.transform.LookAt(Vector3.zero);
        sunPos = Sun.transform.position.y;
    }

}
