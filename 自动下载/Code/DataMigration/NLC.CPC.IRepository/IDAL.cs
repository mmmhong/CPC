using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.IRepository
{
    public interface IDAL
    {
        void GetDataById(string id);
        void GetFieldRelation();
    }
}
