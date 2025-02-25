using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly POSDbContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(POSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentDto> AddAsync(PaymentDto paymentDto)
        {
            var paymentEntity = _mapper.Map<Payment>(paymentDto);
            await _context.Payments.AddAsync(paymentEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentDto>(paymentEntity);
        }

        public async Task<PaymentDto?> GetByIdAsync(string paymentId)
        {
            var paymentEntity = await _context.Payments
                .Include(p => p.UserPayments) // Include related entities if needed
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);
            return paymentEntity != null ? _mapper.Map<PaymentDto>(paymentEntity) : null;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var payments = await _context.Payments
                .Include(p => p.UserPayments)
                .ToListAsync();
            return _mapper.Map<List<PaymentDto>>(payments);
        }

        public async Task UpdateAsync(PaymentDto paymentDto)
        {
            var paymentEntity = await _context.Payments.FindAsync(paymentDto.PaymentId);
            if (paymentEntity == null) throw new KeyNotFoundException("Payment not found.");

            _mapper.Map(paymentDto, paymentEntity);
            await _context.SaveChangesAsync();
        }
    }
}
