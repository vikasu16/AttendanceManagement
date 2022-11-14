using Attendance.Management.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Management.Data
{
    public class AttendanceSystemDataProvider : BaseSqlDataProvider
    {
        public AttendanceSystemDataProvider() : base(DatabaseNames.AttendanceSystem)
        {
        }
    }
}
