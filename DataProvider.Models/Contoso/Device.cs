using DataProvider.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Models.Contoso
{
	public class Device
	{
		public int Id { get; set;}
		public string SerialNumber { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
	}
}
