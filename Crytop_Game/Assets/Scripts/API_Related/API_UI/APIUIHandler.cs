using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProgC
{
    public class APIUIHandler : MonoBehaviour
    {
        public RectTransform group_display = null;
        public RectTransform crypto_Container_Spawner = null;
        public CryptoContainer crypto_Container_Prefab = null;

        public bool canUpdate = true;

        private List<CryptoContainer> m_spawnedCryptoList = new List<CryptoContainer>();
        private float currentTime = 60.0f;
        private float updatePerMinute = 60.0f;


        // Start is called before the first frame update
        void Start()
        {
            this.group_display.gameObject.SetActive(false);
            this.UpdateCryptoData();
        }

        // Update is called once per frame
        void Update()
        {
            if (!this.canUpdate)
                return;

            this.UpdateCryptoData();
        }

        private void UpdateCryptoData()
        {
            if (this.currentTime <= this.updatePerMinute)
            {
                this.currentTime += Time.deltaTime;
                return;
            }

            this.currentTime = 0.0f;
            APIHandler.instance.UpdateData();
        }

        public void UpdateCryptoDataVisual()
        {
            if (this.m_spawnedCryptoList.Count <= 0) //never spawn before
            {
                for(int i = 0; i < APIHandler.instance.apiCryptoDataList.data.Count; i++)
                {
                    CryptoContainer spawnedContainer = Instantiate(this.crypto_Container_Prefab, this.crypto_Container_Spawner);
                    spawnedContainer.Init(APIHandler.instance.apiCryptoDataList.data[i].id, APIHandler.instance.apiCryptoDataList.data[i].rank.ToString(), 
                        APIHandler.instance.apiCryptoDataList.data[i].name, APIHandler.instance.apiCryptoDataList.data[i].priceUsd.ToString(), 
                        APIHandler.instance.apiCryptoDataList.data[i].changePercent24Hr.ToString());

                    this.m_spawnedCryptoList.Add(spawnedContainer);
                }
            }
            else // spawned before
            {
                for (int i = 0; i < APIHandler.instance.apiCryptoDataList.data.Count; i++)
                {
                    this.m_spawnedCryptoList[i].UpdateValue(APIHandler.instance.apiCryptoDataList.data[i].priceUsd.ToString(),
                        APIHandler.instance.apiCryptoDataList.data[i].changePercent24Hr.ToString());
                }
            }
        }

        public void TurnUIState(bool state)
        {
            this.group_display.gameObject.SetActive(state);
        }
    }
}