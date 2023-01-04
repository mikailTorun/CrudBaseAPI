using MediatR;
using Microsoft.AspNetCore.Identity;
using StockMonitor.Application.Abstruction.Services.Identity;
using User = StockMonitor.Domain.Entities.Common;

namespace StockMonitor.Application.Features.Identity.AppUser.Commads.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        private readonly IAppUserService _appUserService;

        public CreateAppUserCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _appUserService.CreateUser(request);
        }
    }
}
