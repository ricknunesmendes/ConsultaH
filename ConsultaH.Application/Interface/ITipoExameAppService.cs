﻿using ConsultaH.Domain.Entities;

namespace ConsultaH.Application.Interface
{
    public interface ITipoExameAppService : IAppServiceBase<TipoExame>
    {
        bool CanDelete(int tipoExameId);
    }
}
