using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JunkItem
{
    public class JunkItem : IJunkItem
    {
        public Guid Id { get;  }

        public Tuple<double, double> Location { get; }

        public Guid ImageId { get; }

        public DateTime TimeUploaded { get; }
    }
}
