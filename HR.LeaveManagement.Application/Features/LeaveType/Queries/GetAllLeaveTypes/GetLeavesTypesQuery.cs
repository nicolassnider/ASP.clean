using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeavesTypesQuery : IRequest<List<LeaveTypeDto>>
{
}
