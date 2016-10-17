using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentals.Models;
using Rentals.DTOs;


namespace Rentals.Models
{
    public class CustomerManager
    {
        public static void AddCustomer(CustomerDto customerDto)
        {
            var db = new CustomersEntities();
            var entityCustomer = convertToEntity(customerDto);
            db.Customers.Add(entityCustomer);
            db.SaveChanges();

        }

        public static List<CustomerDto> GetCustomers()
        {
            var db = new CustomersEntities();
            var customers = new List<CustomerDto>();
            foreach (var customer in db.Customers)
            {
                var customerDto = convertToDto(customer);
                customers.Add(customerDto);
            }
            return customers;
        }

        private static CustomerDto convertToDto(Customer entityCustomer)
        {
            var customerDto = new CustomerDto();

            customerDto.Address = entityCustomer.Address;
            customerDto.CustomerId = entityCustomer.CustomerId;
            customerDto.Email = entityCustomer.Email;
            customerDto.Films = entityCustomer.Films;
            customerDto.Name = entityCustomer.Name;
            customerDto.Password = entityCustomer.Password;
            customerDto.Phone = entityCustomer.Phone;

            return customerDto;

        }

        private static Customer convertToEntity(CustomerDto cusomterDto)
        {
            var entityCustomer = new Customer();
            entityCustomer.Address = cusomterDto.Address;
            entityCustomer.CustomerId = cusomterDto.CustomerId;
            entityCustomer.Email = cusomterDto.Email;
            entityCustomer.Name = cusomterDto.Name;
            entityCustomer.Password = cusomterDto.Password;
            entityCustomer.Phone = cusomterDto.Phone;

            return entityCustomer;
        }


        
    }
}