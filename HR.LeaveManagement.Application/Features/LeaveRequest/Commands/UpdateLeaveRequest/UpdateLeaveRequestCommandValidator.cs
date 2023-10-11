using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        Include(new BaseLeaveRequestValidator(_leaveTypeRepository)); //include BaseLeaveRequest rules

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveReqeuestMustExist)
            .WithMessage("{ProperyName} must be present");
    }

    private async Task<bool> LeaveReqeuestMustExist(int leaveRequestId, CancellationToken token)
    {
        var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(leaveRequestId);
        return leaveAllocation != null;
    }
}
