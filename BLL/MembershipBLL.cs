using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MembershipBLL
    {
        public List<Grade> GetGradeList()
        {
            MembershipDAL dal = new MembershipDAL();
            return dal.GetGradeList();
        }
    }
}
