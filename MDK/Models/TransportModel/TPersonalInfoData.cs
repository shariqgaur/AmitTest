﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TransportModel
{
   public class TPersonalInfoData:TransportData
    {
       public PersonalInfoModel tPersonalInfoData;
       public IEnumerable<PersonalInfoModel> allRecords;
    }
}
