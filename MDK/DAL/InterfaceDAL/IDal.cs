using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.TransportModel;

namespace DAL.InterfaceDAL
{
    public interface IDal
    {
        ITransport insertRecord(IModel model);
        ITransport deleteRecordById(int model);
        ITransport editRecordById(int model);
        ITransport updateRecordById(int id, IModel newModel);
         
     }
}
