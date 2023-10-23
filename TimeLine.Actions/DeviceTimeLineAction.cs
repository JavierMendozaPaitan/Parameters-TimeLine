using DataProvider.Abstractions;
using DataProvider.Models.Contoso;
using DataProvider.Models.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeLine.Abstractions;
using TimeLine.Models.ViewModels;

namespace TimeLine.Actions
{
    public class DeviceTimeLineAction : IDeviceTimeLineAction
    {
        private readonly ILogger<DeviceTimeLineAction> _logger;
        private readonly IJsonSerialization _jsonSerialization;
        private readonly IDeviceRepository _deviceRepository;

        public DeviceTimeLineAction(
            ILogger<DeviceTimeLineAction> logger,
            IJsonSerialization jsonSerialization,
            IDeviceRepository deviceRepository
            )
        {
            _logger = logger;
            _jsonSerialization = jsonSerialization;
            _deviceRepository = deviceRepository;
        }

		public void CreateDevice(DeviceViewModel device)
		{
			try
			{
                var deviceRepository = new Device
				{
                    SerialNumber = device.SerialNumber,
                    Status = device.Status,
                    StartDate = device.StartDate,
                    EndDate = device.EndDate
				};
                _deviceRepository.InsertDevice(deviceRepository);
			}
			catch (Exception ex)
            {
                _logger.LogError($"Problems creating device: {ex.Message}", ex.StackTrace);
                throw;
            }
		}

		public DeviceTimeLineViewModel GetDeviceTimeLine()
        {
            try
            {
                var viewModel = new DeviceTimeLineViewModel
                {
                    DeviceTimeLine = new List<DeviceViewModel>()
                };
                var devices = _deviceRepository.GetDevices();
				foreach (var device in devices)
				{
                    viewModel.DeviceTimeLine.Add(new DeviceViewModel
					{
                        SerialNumber = device.SerialNumber,
                        Status = device.Status,
                        StartDate = device.StartDate,
                        EndDate = device.EndDate,
                        StartDateString = device.StartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                        EndDateString = device.EndDate.ToString("yyyy-MM-ddTHH:mm:ss")
					});
				}
                viewModel.SerializedData = _jsonSerialization.Serialize(viewModel.DeviceTimeLine);

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems returning list: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
