using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProgC
{
    public class CryptoContainer : MonoBehaviour
    {
        public TextMeshProUGUI id_Text = null;
        public TextMeshProUGUI rank_Text = null;
        public TextMeshProUGUI name_Text = null;
        public TextMeshProUGUI price_Text = null;
        public TextMeshProUGUI percentage_Text = null;

        public void Init(string id, string rank, string name, string price, string percentage)
        {
            this.id_Text.text = "ID:" + id;
            this.rank_Text.text = "Rank: " + rank;
            this.name_Text.text = "Name: " + name;
            this.price_Text.text = "Price: " + price;
            this.percentage_Text.text = "Percentage Change 24 Hours: " + percentage;
        }

        public void UpdateValue(string price, string percentage)
        {
            this.price_Text.text = "Price: " + price;
            this.percentage_Text.text = "Percentage Change 24 Hours: " + percentage;
        }

    }
}