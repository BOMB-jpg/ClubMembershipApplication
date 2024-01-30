using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClubMembershipApplication.Models
{
    public class User
    {
        //数据模型的目的是提供一种清晰的方式来组织和操纵应用程序中的数据，
        //以便在编程中更轻松地处理相关的任务，如数据验证、存储和检索。通过使用数据模型
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //示这个标识符是通过数据库自动增长生成的
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string AddressFirstLine { get; set; }

        public string AddressSecondLine { get; set; }

        public string AddressCity { get; set; }

        public string PostCode { get; set; }

    }
}
