using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BasicModels;
using Models.JunkItem;

namespace Services.Services
{
    public interface IJunkService
    {
        IJunkItem GetJunkItem(Guid junkId);
        List<Guid> GetJunkIdsByLocationAndRadius(Location location, double radius);
        void UploadJunkItem(IJunkItem junkItem);
        void DeleteJunkItem(Guid junkId);
    }
}
