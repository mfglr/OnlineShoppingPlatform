using Core.Abstracts;
using MediatR;

namespace Application.PipelineBehaviors
{
    internal class UnitOfWorkPipelineBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next(cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
