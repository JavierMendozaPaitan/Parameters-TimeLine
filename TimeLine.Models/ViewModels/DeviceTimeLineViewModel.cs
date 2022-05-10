using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Models.ViewModels
{
    public class DeviceTimeLineViewModel
    {
        public List<DeviceViewModel> DeviceTimeLine { get; set; }
        public string SerializedData { get; set; }
    }
}
