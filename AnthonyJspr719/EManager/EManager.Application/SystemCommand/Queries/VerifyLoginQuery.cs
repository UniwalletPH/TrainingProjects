using EManager.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EManager.Application.SystemCommand.Queries
{
    public class VerifyLoginQuery : IRequest<UserVM>
    {
        public LoginVM User { get; set; }
        public class VerifyLoginQueryHandler : IRequestHandler<VerifyLoginQuery, UserVM>
        {
            private readonly IEManagerDbContext dbContext;
            private readonly IMediator mediator;
            public VerifyLoginQueryHandler(IEManagerDbContext dbContext, IMediator mediator)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
            }

            public async Task<UserVM> Handle(VerifyLoginQuery request, CancellationToken cancellationToken)
            {
                var _retVal = dbContext.EmployeeInformation
                    .Where(a => a.Username == request.User.Username
                    && a.Password == request.User.Password).SingleOrDefault();


                if (_retVal != null)
                {
                    UserVM _user = new UserVM
                    {

                        ID = _retVal.ID,
                        Firstname = _retVal.FirstName,
                        Lastname = _retVal.LastName,
                        Address = _retVal.Address,
                        Username = _retVal.Address,
                        Password = _retVal.Password,
                        Role = _retVal.Role,
                    };

                    return _user;
                }
                else
                {
                    return null;
                }

               
            }
        }
    }
}
