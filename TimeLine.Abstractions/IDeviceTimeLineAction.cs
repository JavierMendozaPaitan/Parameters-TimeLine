﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Models.ViewModels;

namespace TimeLine.Abstractions
{
    public interface IDeviceTimeLineAction
    {
        DeviceTimeLineViewModel GetDeviceTimeLine();
        void CreateDevice(DeviceViewModel device);
    }
}
