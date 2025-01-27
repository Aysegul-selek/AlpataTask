﻿using System.Collections.Generic;
using System.Linq;
using AlpataCore.Entities.Concrete;
using AlpataData.Abstract;
using AlpataData.Concrete.Context.DataAccess.Concrete.EntityFramework.Contexts;
using AlpataEntities.Concrete;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;

public class EfUserDal : EfEntityRepoSitoryBase<User, AlpataContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new AlpataContext())
        {
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
