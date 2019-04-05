using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooplandGameDataParser.Core.Models
{
    public class GameInfoModel
    {
        public string Name { get; set; }
        public string Release { get; set; }
        public string Developer { get; set; }
        public string Genre{ get; set; }
        public string Platform { get; set; }
        public string Language { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }
    }
}
