update Abouts set RoomCount=(Select Count(*) from Rooms),StaffCount=(Select Count(*) from Staffs),CustomerCount=(Select Count(*) from Guests)
select * from Abouts