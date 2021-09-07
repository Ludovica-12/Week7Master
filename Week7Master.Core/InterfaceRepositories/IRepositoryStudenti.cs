using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.Core.InterfaceRepositories
{
    public interface IRepositoryStudenti : IRepository<Studente>
    {
        public Studente GetById(int id);
    }
}
