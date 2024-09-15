using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FireBaseManager : MonoBehaviour
{
   
    protected bool firebaseInitialized = false;

    private static FireBaseManager instance;
    public static FireBaseManager Instance { get { return instance; } }

    void Awake ()
	{
        if (FindObjectsOfType(typeof(AdsControl)).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); 
    }
	// Use this for initialization
	void Start ()
	{

      
    }
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    // Handle initialization of the necessary firebase modules:
    void InitializeFirebase()
    {
        firebaseInitialized = true;
    }

    public void AnalyticsLogin()
    {
        // Log an event with no parameters.
       
    }

    public void AnalyticsProgress()
    {
        // Log an event with a float.
      
    }

    public void AnalyticsScore()
    {
        // Log an event with an int parameter.

    }

    public void AnalyticsGroupJoin()
    {
        // Log an event with a string parameter.
       
      
    }

    public void AnalyticsLevelUp()
    {
        // Log an event with multiple parameters.
       
    
    }

    // Reset analytics data for this app instance.
    public void ResetAnalyticsData()
    {
       
       
    }

    public void LogScreen(string _log)
    {
        //FirebaseAnalytics.LogEvent(_log);
    }

    public void LogLevelUp(int _level)
    {
      
    }
    public void LogLevelEnd(int _level)
    {
       
    }

}
