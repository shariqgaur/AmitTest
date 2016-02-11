﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace DAL.Admin
{
   public class BASEDal
    {
     protected  MDKDBMLDataContext _dataContext = null;
     protected JavaScriptSerializer _serializer = null;

       public BASEDal()
       {    
           _dataContext = new MDKDBMLDataContext();
           _serializer = new JavaScriptSerializer();
       }
    }
}
