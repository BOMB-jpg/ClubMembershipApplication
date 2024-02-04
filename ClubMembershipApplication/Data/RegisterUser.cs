using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ClubMembershipApplication.FieldValidators;
using System.Linq;
//运用了 EntityFrameWork的CodeFirst模式来将用户信息插入到数据库中 
namespace ClubMembershipApplication.Data
{
    public class RegisterUser : IRegister   //实现接口的  的两根书
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using (var dbContext = new ClubMembershipDbContext())   //创建并使用
            {
                emailExists = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            
            通过 LINQ 查询，检查 Users 表中是否存在与给定的电子邮件地址匹配的用户。.Any() 方法用于判断是否存在满足条件的任何记录。
            在这里，通过比较用户表中的 EmailAddress 属性与给定的 emailAddress 是否相等，不区分大小写和前后空格。
            
            
            
            }
            return emailExists;    //是否存在具有相同电子邮件地址的用户记录
        }

        public bool Register(string[] fields)   //在这里完成了对象关系映射ORM
        {
            using (var dbContext = new ClubMembershipDbContext())
          //利用dbContext 与数据库进行交互
              //保证离开块时 释放资源
            
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode]

                };

                dbContext.Users.Add(user);   //将新创建的 User 对象添加到数据库上下文的 Users 集合中。这表示一个将要插入到数据库的新用户。

                dbContext.SaveChanges();  //保存对数据库所做的更改。在这个情境中，它将执行插入操作，将新用户数据存储到数据库中。
            }
            return true;
        }
    }
}
