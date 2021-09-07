using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.Core.InterfaceRepositories
{
    public interface IRepositoryDocenti : IRepository<Docente>
    {
        public Docente GetById(int id);
        //public Docente GetByEmail(string email);
    }
}
