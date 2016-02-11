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
        public ITransport insertRecord(IModel model);
        public ITransport deleteRecordById(int model);
        public ITransport editRecordById(int model);
        public ITransport updateRecordById(int id, IModel newModel);
    }
}
