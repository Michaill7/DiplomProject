using DiplomProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiplomProject.Models
{
    internal class DataBaseClassWorker
    {
        private const string connectionstring = "Data Source=DESKTOP-STGMEUB;Initial Catalog='Boycev Test';Integrated Security=True";
        private static SqlConnection con = new SqlConnection(connectionstring);
        public static List<string> Tables()
        {
            var TablesList = new List<string>() { };
            var sda = new SqlDataAdapter("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", con);
            var dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TablesList.Add(dt.Rows[i].Field<string>("TABLE_NAME"));
            }
            return TablesList;
        }
        public static List<List<string>> StatusCreater(string status)
        {
            if (status == "Автомобиль") return ShowListElents(new Cars());
            else if (status == "Клиент") return ShowListElents(new Clients());
            else return ShowListElents(new Elements());
        }
        public static List<List<string>> ShowListElents(Cars status)
        {
            var VinList = new List<string>() { };
            var MarkaList = new List<string>() { };
            var ModelList = new List<string>() { };
            var YearList = new List<string>() { };
            var sda = new SqlDataAdapter("SELECT VIN_номер, Марка, Модель, Год FROM [Автомобиль]", con);
            var dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VinList.Add(dt.Rows[i].Field<string>("Vin_номер"));
                MarkaList.Add(dt.Rows[i].Field<string>("Марка"));
                ModelList.Add(dt.Rows[i].Field<string>("Модель"));
                YearList.Add(Convert.ToString(dt.Rows[i].Field<Int32>("Год")));
            }
            return new List<List<string>>() { VinList, MarkaList, ModelList, YearList };
        }
        public static List<List<string>> ShowListElents(Clients status)
        {

            var SurnameList = new List<string>() { };
            var FirstNameList = new List<string>() { };
            var LastNameList = new List<string>() { };
            var PhoneNumberList = new List<string>() { };
            var sda = new SqlDataAdapter("SELECT [Фамилия], [Имя], [Отчество], [Номер_телефона] FROM [Клиент]", con);
            var dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SurnameList.Add(dt.Rows[i].Field<string>("Фамилия"));
                FirstNameList.Add(dt.Rows[i].Field<string>("Имя"));
                LastNameList.Add(dt.Rows[i].Field<string>("Отчество"));
                PhoneNumberList.Add(dt.Rows[i].Field<string>("Номер_телефона"));
            }
            return new List<List<string>>() { SurnameList, FirstNameList, LastNameList, PhoneNumberList };
        }
        public static List<List<string>> ShowListElents(Elements status)
        {
            var ArticulList = new List<string>() { };
            var NameDetaillList = new List<string>() { };
            var PurchasePriceList = new List<string>() { };
            var SalePriceList = new List<string>() { };
            var sda = new SqlDataAdapter("SELECT АРТИКУЛ, НАИМЕНОВАНИЕ, Цена_покупки, Цена_продажи FROM Позиция", con);
            var dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ArticulList.Add(dt.Rows[i].Field<string>("Артикул"));
                NameDetaillList.Add(dt.Rows[i].Field<string>("НАИМЕНОВАНИЕ"));
                PurchasePriceList.Add(dt.Rows[i].Field<double>("Цена_покупки").ToString());
                SalePriceList.Add(dt.Rows[i].Field<double>("Цена_продажи").ToString());
            }
            return new List<List<string>>() { ArticulList, NameDetaillList, PurchasePriceList, SalePriceList };
        }
        public static DataTable ShowDataToDataGrid(string table, int Id)
        {
            SqlDataAdapter sda;
            if (table == "Клиент")
                sda = new SqlDataAdapter($"Select * from Заказ where ID_заказа IN (Select ID_заказа FROM Заказ_клиент WHERE ID_клиента = {Id})", con);
            else if (table == "Автомобиль")
                sda = new SqlDataAdapter($"Select * from Заказ where ID_заказа IN (Select ID_заказа FROM Заказ_клиент where ID_клиента IN (Select ID_Автомобиля from Автомобиль where ID_Автомобиля = {Id}))", con);
            else
                sda = new SqlDataAdapter($"Select * from Заказ where ID_заказа = (SELECT ID_заказа FROM Позиция WHERE ID_позиции ={Id})", con);
            var dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static List<Accounting> ShowAccountingSales()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Дата_продажи, sum(Цена_продажи) as" + " Цена_продажи " + "from Бухгалтерский_учет Group by Дата_продажи Order by 1;", con);
            var dt = new DataTable();
            sda.Fill(dt);
            var ActualAccountingList = new List<Accounting>() { };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActualAccountingList.Add
                    (
                        new Accounting
                        {
                            SalePrice = dt.Rows[i].Field<double>("Цена_продажи"),
                            SaleDate = dt.Rows[i].Field<DateTime>("Дата_продажи")
                        }
                    );
            }
            return ActualAccountingList;
        }

        public static List<Accounting> ShowAccountingPurchase()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Дата_покупки, sum(Цена_покупки)" + " Цена_покупки " + "from Бухгалтерский_учет Group by Дата_покупки Order by 1;", con);
            var dt = new DataTable();
            sda.Fill(dt);
            var ActualAccountingList = new List<Accounting>() { };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ActualAccountingList.Add
                    (
                        new Accounting
                        {
                            PurchasePrice = dt.Rows[i].Field<double>("Цена_покупки"),
                            PurchaseDate = dt.Rows[i].Field<DateTime>("Дата_покупки"),
                        }
                    );
            }
            return ActualAccountingList;
        }

        public static List<Cars> ShowActualListOfCars()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select VIN_номер, Марка, Модель, Год from Автомобиль ORDER BY 1", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            var actualCarsList = new List<Cars>() { };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                actualCarsList.Add
                    (
                        new Cars
                        {
                            ID = i,
                            VIN = dt.Rows[i].Field<string>("Vin_номер"),
                            Marka = dt.Rows[i].Field<string>("Марка"),
                            Model = dt.Rows[i].Field<string>("Модель"),
                            Year = dt.Rows[i].Field<int>("Год")
                        }
                    );
            }
            return actualCarsList;
        }

        public static List<Clients> ShowActualListOfClients()
        {
            var sda = new SqlDataAdapter("select Фамилия, Имя, Отчество, Номер_телефона from Клиент Order by 4;", con);
            var dt = new DataTable();
            sda.Fill(dt);
            var actualClientsList = new List<Clients>() { };
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                actualClientsList.Add
                    (
                        new Clients
                        {
                            ID = i,
                            Surname = dt.Rows[i].Field<string>("Фамилия"),
                            FirstName = dt.Rows[i].Field<string>("Имя"),
                            LastName = dt.Rows[i].Field<string>("Отчество"),
                            PhoneNumber = dt.Rows[i].Field<string>("Номер_телефона"),
                        }
                    );
            }
            return actualClientsList;
        }

        public static void AddDataAboutNewClientToDataBase(string surname, string firstName, string lastName, string phoneNumber) 
        {
            var sda = new SqlDataAdapter($"INSERT INTO Клиент(Фамилия, Имя, Отчество, Номер_телефона) VALUES('{surname}', '{firstName}', '{lastName}', '{phoneNumber}')", con);
            MessageBox.Show("");
            var dt = new DataTable();
            sda.Fill(dt);
        }

        public static void AddDataAboutNewCarToDB(string Vin, string marka, string model, string Year) 
        {
            var sda = new SqlDataAdapter($"SELECT ID_клиента FROM Клиент where Номер_телефона = '{NewOfferWindowViewModel.choosedClientPhoneNumberForTransfer}'", con) ;
            var dt = new DataTable();
            sda.Fill(dt);
            var currentClientID = dt.Rows[0].Field<int>("ID_клиента");
            sda = new SqlDataAdapter($"INSERT INTO Автомобиль(VIN_номер, Марка, Модель, Год, ID_Клиента) values ('{Vin}', '{marka}','{model}', CAST('{Year}' AS INT), {currentClientID})", con);
            dt = new DataTable();
            sda.Fill(dt);
        }

        public static void AddDataAboutNewOrder() 
        {
            var sda = new SqlDataAdapter($"INSERT INTO Заказ(Сумма, Дата, Срок_доставки_в_днях, Комментарий) VALUES({NewOfferWindowViewModel.orderSumForTransfer}, Cast({NewOfferWindowViewModel.orderDateForTransfer.ToString()} as date), {NewOfferWindowViewModel.orderDaysCountForTransfer}, '{NewOfferWindowViewModel.orderCommentForTransfer}')", con);
            sda = new SqlDataAdapter($"INSERT INTO Заказ_клиент(ID_клиента, ID_заказа) VALUES((SELECT ID_клиента FROM Клиент WHERE Номер_телефона = '{NewOfferWindowViewModel.choosedClientPhoneNumberForTransfer}'),(SELECT ID_Заказа FROM Заказ WHERE ID_заказа = (SELECT MAX(ID_заказа) FROM Заказ)))", con);
            string actualSQLDataSetOfPositions = "";
            foreach (var item in NewOfferWindowViewModel.actualElementsOfPositions)
                actualSQLDataSetOfPositions += '(' + $"'{item.Articul}', " + $"'{item.Name}', " + $"CAST({item.PurchasePrice} AS float), " + $"CAST({item.SalePrice} AS float), " + "(SELECT ID_заказа From Заказ where ID_заказа = (select max(ID_заказа) from Заказ)" + "), ";
            actualSQLDataSetOfPositions = actualSQLDataSetOfPositions.Substring(0, actualSQLDataSetOfPositions.Length-2);
            sda = new SqlDataAdapter("INSERT INTO Позиция(Артикул, Наименование, Цена_закупки, Цена_продажи, ID_заказа) VALUES"+actualSQLDataSetOfPositions, con);
        }
    }
}
