﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoFSBR.Infra.Integration.Uow
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}