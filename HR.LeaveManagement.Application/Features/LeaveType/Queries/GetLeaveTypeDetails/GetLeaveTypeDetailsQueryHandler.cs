using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery,
    LeaveTypeDetailsDTO>
{
    public IMapper _mapper { get; }
    public ILeaveTypeRepository _leaveTypeRepository { get; }
    public GetLeaveTypeDetailsQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request,
        CancellationToken cancellationToken)
    {
        //Query the database
        var leaveType = await this._leaveTypeRepository.GetByIdAsync(request.Id);

        // verify that record exists
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        //Convert data object to DTO object
        var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveType);

        //Return DTO object
        return data;
    }
}
