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

        public DeviceTimeLineAction(
            ILogger<DeviceTimeLineAction> logger,
            IJsonSerialization jsonSerialization
            )
        {
            _logger = logger;
            _jsonSerialization = jsonSerialization;
        }
        public DeviceTimeLineViewModel GetDeviceTimeLine()
        {
            try
            {
                var viewModel = new DeviceTimeLineViewModel
                {
                    DeviceTimeLine = new List<DeviceViewModel>()
                };
                viewModel.DeviceTimeLine.Add(new DeviceViewModel
                {
                    SerialNumber = "MT12344",
                    Status = DeviceStatus.Unknown,
                    StartDate = DateTime.Now.AddDays(-4),
                    EndDate = DateTime.Now.AddDays(-2),
                    StartDateString = DateTime.Now.AddDays(-4).ToString("yyyy-MM-ddTHH:mm:ss"),
                    EndDateString = DateTime.Now.AddDays(-2).ToString("yyyy-MM-ddTHH:mm:ss")
                });
                viewModel.DeviceTimeLine.Add(new DeviceViewModel
                {
                    SerialNumber = "MT12344",
                    Status = DeviceStatus.Active,
                    StartDate = DateTime.Now.AddDays(-2),
                    EndDate = DateTime.Now.AddDays(-1),
                    StartDateString = DateTime.Now.AddDays(-2).ToString("yyyy-MM-ddTHH:mm:ss"),
                    EndDateString = DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss")
                }) ;
                viewModel.DeviceTimeLine.Add(new DeviceViewModel
                {
                    SerialNumber = "MT12344",
                    Status = DeviceStatus.DueBack,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now,
                    StartDateString = DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss"),
                    EndDateString = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                });
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
