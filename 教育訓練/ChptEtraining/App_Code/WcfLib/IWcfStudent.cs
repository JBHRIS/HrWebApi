﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService"。
[ServiceContract]
public interface IWcfStudent
{

    [OperationContract]
    List<WcfCourseDto> GetByNobrDateRange(string Anobr, DateTime AdatetimeB, DateTime AdatetimeE,bool Apass);

}
