using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BasicModels;

namespace Models.JunkItem
{
    public interface IJunkItem
    {
        Guid Id { get; }
        Location Location { get; }
        Guid ImageId { get; }
        DateTime TimeUploaded { get; }
    }
}
