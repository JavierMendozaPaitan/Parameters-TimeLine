using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Abstractions;
using TimeLine.Models.ViewModels;

namespace TimeLine.Services
{
    public class EntitiesTimeLineService : IEntitiesTimeLineService
    {
        private readonly ILogger<EntitiesTimeLineService> _logger;
        private readonly IDeviceTimeLineAction _deviceTimeLine;
        public EntitiesTimeLineService(
            ILogger<EntitiesTimeLineService> logger,
            IDeviceTimeLineAction deviceTimeLine
            )
        {
            _logger = logger;
            _deviceTimeLine = deviceTimeLine;
        }
        public Func<DeviceTimeLineViewModel> GetDeviceTimeLine => _deviceTimeLine.GetDeviceTimeLine;
		public Action<DeviceViewModel> CreateDevice => _deviceTimeLine.CreateDevice;
	}
}
