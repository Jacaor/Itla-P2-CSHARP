using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.infretruture.Core;
using CallCenter.infretruture.DBContex;
using CallCenter.infretruture.Model;

namespace CallCenter.infretruture.Repositories
{
    public class ManagerRepositorie: Baserepositorie<ManagerModel>

    {
        
        public ManagerRepositorie(CallCenterAPIContex contex) : base(contex)
        {
          
        }

    }
}