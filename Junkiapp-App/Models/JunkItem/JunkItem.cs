using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BasicModels;

namespace Models.JunkItem
{
    public class JunkItem : IJunkItem
    {
        public Guid Id { get; set; }

        public Location Location { get; set; }

        public Guid ImageId { get; set; }

        public DateTime TimeUploaded { get; set; }
    }


}
