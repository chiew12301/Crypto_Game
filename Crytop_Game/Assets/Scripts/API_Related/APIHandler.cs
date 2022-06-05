using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProgC
{
    #region API_DATA

    [System.Serializable]
    public struct SCRYPTODATA
    {
        public string id;
        public int rank;
        public string symbol;
        public string name;
        public float supply;
        public float maxSupply;
        public float marketCapUsd;
        public float volumeUsd24Hr;
        public float priceUsd;
        public float changePercent24Hr;
        public float vwap24Hr;
    }

    [System.Serializable]
    public class CryptoDataList
    {
        public List<SCRYPTODATA> data;
    }

    #endregion API_DATa

    public class APIHandler : MonoBehaviour
    {
        #region SINGLETON

        public static APIHandler instance;

        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null) //For Multiple Scene Purpose
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);
        }

        #endregion SINGLETON

        public APIUIHandler apiUIHandler = null;

        public CryptoDataList apiCryptoDataList = new CryptoDataList();

        private const string API_ENDPOINT = "api.coincap.io/v2/assets";

        public void UpdateData()
        {
            this.RequestFromAPI();
        }

        private void RequestFromAPI()
        {
            WWW request = new WWW(API_ENDPOINT);
            this.StartCoroutine(this.OnAPIResponse(request));
        }

        private IEnumerator OnAPIResponse(WWW req)
        {
            while(!req.isDone)
            {
                yield return null;
            }

            if(req.error != null)
            {
                Debug.Log("ERROR: " + req.error);
                yield return null;
            }
            else
            {
                this.apiCryptoDataList = JsonUtility.FromJson<CryptoDataList>(req.text);

                this.apiUIHandler.UpdateCryptoDataVisual();

                yield return req; //Success
            }
        }

    }

}