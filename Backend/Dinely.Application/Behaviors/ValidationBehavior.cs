using Dinely.Application.Authentication.Commands.Register;
using Dinely.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Dinely.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? _validator = null) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr

{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.Select(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage)).ToList();

        return (dynamic)errors;
    }
}
