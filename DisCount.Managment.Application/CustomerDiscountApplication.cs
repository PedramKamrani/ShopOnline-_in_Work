using _0_FramWork.Application;
using Discount.Managment.Application.Contract.Discount.Managment.DTO;
using DisCount.Manangment.Domain.CustomerDiscounts;
using System;
using System.Collections.Generic;

namespace DisCount.Managment.Application
{
   public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscount _repository;
        public CustomerDiscountApplication(ICustomerDiscount repository)
        {
            _repository = repository;
        }
        public OperationResult Create(CreateCustomerDiscountDTO command)
        {

            OperationResult opreation = new OperationResult();
            if (_repository.Exsists(x => x.DiscounRate == command.DiscounRate && x.ProductId != command.ProductId))
                return opreation.Failed(ApplicationMessage.DuplicatedRecord);
            DateTime Startdate = command.StartDate.ToGeorgianDateTime();
            DateTime Enddate = command.EndDate.ToGeorgianDateTime();
            var entity = new CustomerDiscount(command.ProductId, command.DiscounRate, Startdate, Enddate, command.Reason);
            _repository.Create(entity);
            _repository.SaveChanges();
            return opreation.Success();
        }

        public OperationResult Edit(EditCustomerDisCountDTO command)
        {
            OperationResult opreation = new OperationResult();
            var entity = _repository.Get(command.Id);
            if (entity == null)
                return opreation.Failed(ApplicationMessage.RecordNotFound);
            if (_repository.Exsists(x => x.DiscounRate == command.DiscounRate && x.ProductId == command.ProductId && x.Id != command.Id))
                return opreation.Failed(ApplicationMessage.DuplicatedRecord);
            DateTime Startdate = command.StartDate.ToGeorgianDateTime();
            DateTime Enddate = command.EndDate.ToGeorgianDateTime();
            entity.Edit(command.ProductId, command.DiscounRate, Startdate, Enddate, command.Reason);
            _repository.SaveChanges();
            return opreation.Success();
        }

        public EditCustomerDisCountDTO GetDetails(long Id)
        {
            return _repository.GetDetails(Id);
        }

        public List<DiscountCustomerDTO> Search(CustomerDiscountSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
