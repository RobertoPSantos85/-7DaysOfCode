using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio7DaysOfCode.APIService
{
    public class CatModel
    {
        public string id { get; set; }

        public string sub_id = "rbt-2022";
        public string name { get; set; }
        public string temperament { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public string reference_image_id { get; set; }

    }

    public class PostCatModel
    {

        public string id { get; set; }
        public string sub_id { get; set; }

        public string image_id { get; set; }

    }


}

