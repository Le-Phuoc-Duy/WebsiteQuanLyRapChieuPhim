﻿using Cinema.Helper;
using Cinema.Model;
using System.Data;

namespace Cinema.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Roles.Any())
            {
                dataContext.Roles.AddRange(new RoleModel[]
                {
                    new RoleModel() {Name = "ADMIN"},
                    new RoleModel() {Name = "STAFF"},
                    new RoleModel() {Name = "USER"},
                });
                dataContext.SaveChanges();
            }
            if (!dataContext.Accounts.Any())
            {
                dataContext.Accounts.AddRange(new AccountModel[]
                {
                    new AccountModel() {Email = "User@gmail.com", Password = HashPassword.HashByPBKDF2("user123"), AccountStatus = Enum.AccountStatus.ACTIVATED, RoleId = Convert.ToInt32(dataContext.Roles.Where(p => p.Name == "USER").Select(p => p.Id).Single())},
                    new AccountModel() {Email = "Admin@gmail.com", Password = HashPassword.HashByPBKDF2("admin123"), AccountStatus = Enum.AccountStatus.ACTIVATED, RoleId = Convert.ToInt32(dataContext.Roles.Where(p => p.Name == "ADMIN").Select(p => p.Id).Single())},
                    new AccountModel() {Email = "Staff@gmail.com", Password = HashPassword.HashByPBKDF2("staff123"), AccountStatus = Enum.AccountStatus.ACTIVATED, RoleId = Convert.ToInt32(dataContext.Roles.Where(p => p.Name == "STAFF").Select(p => p.Id).Single())},
                });
                dataContext.SaveChanges();
            }
            if (!dataContext.Users.Any())
            {
                dataContext.Users.AddRange(new UserModel[]
                {
                    new UserModel() {Name = "User", Birth = new DateTime(1999,02,09) ,Phone = "0866926124", AccountId = Convert.ToInt32(dataContext.Accounts.Where(p => p.Email == "User@gmail.com").Select(p => p.Id).Single())},
                    new UserModel() {Name = "Admin", Birth = new DateTime(2000,05,10) ,Phone = "0523456741", AccountId = Convert.ToInt32(dataContext.Accounts.Where(p => p.Email == "Admin@gmail.com").Select(p => p.Id).Single())},
                    new UserModel() {Name = "Staff", Birth = new DateTime(2000,10,10) ,Phone = "0145656852", AccountId = Convert.ToInt32(dataContext.Accounts.Where(p => p.Email == "Staff@gmail.com").Select(p => p.Id).Single())},
                });
                dataContext.SaveChanges();
            }
            if(!dataContext.SeatTypes.Any())
            {
                dataContext.SeatTypes.AddRange(new SeatTypeModel[]
                {
                    new SeatTypeModel() {Name = "VIP", Cost = 50000,},
                    new SeatTypeModel() {Name = "Đôi", Cost = 70000,},
                    new SeatTypeModel() {Name = "Thường", Cost = 40000,},
                });
                dataContext.SaveChanges();
            }
            if (!dataContext.Rooms.Any())
            {
                dataContext.Rooms.AddRange(new RoomModel[]
                {
                    new RoomModel() {Row = 1, Col = 2, RoomStatus = Enum.RoomStatus.READY, Name = "Phòng 1"},
                    new RoomModel() {Row = 1, Col = 1, RoomStatus = Enum.RoomStatus.READY, Name = "Phòng 2"},
                    new RoomModel() {Row = 2, Col = 3, RoomStatus = Enum.RoomStatus.READY, Name = "Phòng 3"},
                });
                dataContext.SaveChanges();
            }
            if (!dataContext.Seats.Any())
            {
                dataContext.Seats.AddRange(new SeatModel[]
                {
                    new SeatModel() {Position = "1-1", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 1").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "Thường").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "1-2", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 1").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "VIP").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "1-1", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 2").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "Đôi").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "1-1", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "Thường").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "1-2", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "Thường").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "1-3", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "Thường").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "2-1", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "VIP").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "2-2", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "VIP").Select(p => p.Id).Single()},
                    new SeatModel() {Position = "2-3", RoomId = dataContext.Rooms.Where(p => p.Name == "Phòng 3").Select(p => p.Id).Single(), SeatTypeId = dataContext.SeatTypes.Where(p => p.Name == "VIP").Select(p => p.Id).Single()},

                });
                dataContext.SaveChanges();
            }
            if (!dataContext.Genres.Any())
            {
                dataContext.Genres.AddRange(new GenreModel[]
                {
                    new GenreModel() { Name = "Hành động" },
                    new GenreModel() { Name = "Tình cảm" },
                    new GenreModel() { Name = "Kinh dị" },
                    new GenreModel() { Name = "Viễn tưởng" },
                    new GenreModel() { Name = "Hoạt hình" },
                    new GenreModel() { Name = "Bắn súng" },
                    new GenreModel() { Name = "Phiêu lưu" },
                    new GenreModel() {Name = "Hài"},
                    new GenreModel() {Name = "Tội phạm"},
                    new GenreModel() {Name = "Tâm lý"},
                    new GenreModel() {Name = "Âm nhạc"},
                    new GenreModel() {Name = "Lãng mạn"},
                    new GenreModel() {Name = "Gia đình"},
                    new GenreModel() {Name = "Thần thoại"},
                    new GenreModel() {Name = "Siêu anh hùng"},
                    new GenreModel() {Name = "Tài liệu"},
                    new GenreModel() {Name = "Khoa học"},
                    new GenreModel() {Name = "Chiến tranh"},
                    new GenreModel() {Name = "Thể thao"},
                    new GenreModel() {Name = "Lịch sử"},
                    new GenreModel() {Name = "Kiếm hiệp"},

                });
                dataContext.SaveChanges();
            }
            if(!dataContext.Foods.Any())
            {
                dataContext.Foods.AddRange(new FoodModel[]
                {
                    new FoodModel {Name = "Bắp", Description = "Size M", Cost = 20000},
                    new FoodModel {Name = "Nước Cola", Description = "Size M", Cost = 15000},
                    new FoodModel {Name = "Combo bắp nước", Description = "1 Bắp size M + 1 Cola size M", Cost = 30000},
                    new FoodModel {Name = "Combo cặp đôi", Description = "2 Bắp size M + 2 Cola size M", Cost = 50000}
                });
                dataContext.SaveChanges();
            }
        }
    }
}
