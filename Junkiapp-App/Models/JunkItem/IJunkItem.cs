using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.JunkItem
{
    public interface IJunkItem
    {
        Guid Id { get; }
        Tuple<double, double> Location { get; }
        Guid ImageId { get; }
        DateTime TimeUploaded { get; }
    }
}
