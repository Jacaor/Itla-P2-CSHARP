using CallCenter.domain.Entityes;
using CallCenter.infretruture.Core;
using CallCenter.infretruture.DBContex;
using CallCenter.infretruture.Interfaces;

namespace CallCenter.infretruture.Repositories
{
    public class ManagerRepositorie : Baserepositorie<Manager>, IManager
    {
        public ManagerRepositorie(CallCenterAPIContex contex) : base(contex)
        {
        }
    }
}
