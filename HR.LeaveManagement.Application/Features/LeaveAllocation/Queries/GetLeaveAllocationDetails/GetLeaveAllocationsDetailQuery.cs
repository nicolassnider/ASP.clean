using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationsDetailQuery:IRequest<LeaveAllocationDetailsDto>
{
    public string Id { get; set; }
}
