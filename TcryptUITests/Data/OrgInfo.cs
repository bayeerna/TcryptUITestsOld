﻿namespace TcryptUITests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class OrgInfo : IEquatable<OrgInfo>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string  Hash { get; set; }
        public string Pin { get; set; }
        public string NameOfUser { get; set; }

        public static List<OrgInfo> GetOrgInfo()
        {
            var organizations = new List<OrgInfo>();
            organizations.Add(new OrgInfo()
            {
                FullName = "ООО «Знания»",
                Email = "uprobr_znaniya@mail.ru",
                Password = "12345678",
                Hash = "ADE33A9EEE7447E83AF2B276FC0EAED5082647C6",
                NameOfUser = "Саянова Кристина",
                Pin = "123",

            }); 

            organizations.Add(new OrgInfo()
            {
                FullName = "ООО «Дебет»",
                Email = "//",
                Password = "12345678",
                Hash = "FD27AA231B9ECD290D351D29D9C748A91D3FD10F",
                NameOfUser = "Ткаченко Афанасий",
                Pin = "123",

            });

            organizations.Add(new OrgInfo()
            {
                FullName = "ЗАО \"Фауст\"",

                Password = "12345678",
                Hash = "8EF41D65212722587C145A89F721B11FEA72A2E8",
                NameOfUser = "Ахметов Викентий",
                Pin = "123",

            });

            organizations.Add(new OrgInfo()
            {
                FullName = "ЗАО «Точка Зрения»",

                Password = "12345678",
                Hash = "F19AE1B1BE49233966E8B97F968ACDA742B451FD",
                NameOfUser = "Тестовый Абонент Иванович",
                Pin = "123",
            });

            organizations.Add(new OrgInfo()
            {
                FullName = "ЗАО «Точка Зрения»",

                Password = "12345678",
                NameOfUser = "Тестовый Абонент Петрович",
                Pin = "123",
            });

            organizations.Add(new OrgInfo()
            {
                FullName = "ЗАО «Точка Зрения»",

                Password = "12345678",
                Hash = "BBDC0697DF99B86D96BD0F36EA6448D1F95045DC",
                NameOfUser = "Ефимов Тихон Павлович",
                Pin = "123",
            });


            return organizations;

        }

        public bool Equals(OrgInfo other)
        {
            throw new NotImplementedException();
        }
    }
}
