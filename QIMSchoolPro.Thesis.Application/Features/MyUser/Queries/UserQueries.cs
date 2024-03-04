﻿using MediatR;
using QIMSchoolPro.Thesis.Processors.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Application.Features.MyUser.Queries
{
    public static class GetLoginUser
    {
        public class Query : IRequest<UserViewModel>
        {
            //public string AppName { get; set; }

            public Query()
            {
              
            }
        }

        public class Handler : IRequestHandler<Query, UserViewModel>
        {
            private readonly UserProcessor _userProcessor;

            public Handler(UserProcessor userProcessor)
            {
                _userProcessor = userProcessor;
            }

            public async Task<UserViewModel> Handle(Query request,
                CancellationToken cancellationToken)
            {
                return await _userProcessor.GetLoginUser();
            }
        }


    }
}
