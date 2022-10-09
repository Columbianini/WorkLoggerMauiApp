using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdnWorkLog.Services;

namespace AdnWorkLog.Test.Services
{
    public class FileAccessHelper_CheckWhereIsDatabasePath
    {
        [Fact(Skip = "https://github.com/jamesmontemagno/DeviceInfoPlugin/issues/20")]
        public void GetLocalFilePath_InputHaha_ReturnIsNotNull()
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("Haha");
            Assert.NotNull(dbPath);
        }
    }
}
