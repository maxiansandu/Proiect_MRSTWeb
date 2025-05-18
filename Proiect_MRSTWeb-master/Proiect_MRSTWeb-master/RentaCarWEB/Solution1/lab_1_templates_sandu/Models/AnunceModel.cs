using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class AnunceModel
    {
        public int id {  get; set; }
        public string author { get; set; }

        public string Titlu { get; set; }

        public string img_1 { get; set; }
        public string img_2 { get; set; }
        public string img_3 { get; set; }
        public string img_4 { get; set; }
        public string img_5 { get; set; }

        public string Marca { get; set; }

        public string model { get; set; }

        public int an { get; set; }

        public int engine { get; set; }

        public string fuel { get; set; }

        public int price {  get; set; }

        public string location {  get; set; }

        public int phone {  get; set; }
        public string description { get; set; }
    }
}