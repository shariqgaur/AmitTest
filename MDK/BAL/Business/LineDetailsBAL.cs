using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Business;
using Models;
using Models.TransportModel;

namespace BAL.Business
{
    public class LineDetailsBAL
    {
        LineDetailsDAL lineDetailsDAL = null;

        public LineDetailsBAL()
        {
            lineDetailsDAL = new LineDetailsDAL();
        }

        public TLineDetails getLineDetails(string businessGUID)
        {
            return lineDetailsDAL.getLineDetails(businessGUID);
        }
    }
}
