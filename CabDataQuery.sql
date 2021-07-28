use [YuHan.CabsBooking]
go
set identity_insert [dbo].[Places] on
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (1,'Fairfax')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (2,'Chantilly')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (3,'Centreville')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (4,'Manassas')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (5,'Springfield')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (6,'Arlington')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (7,'Alexandria')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (8,'Reston')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (9,'Tysons')
INSERT [dbo].[Places] ([PlaceId], [PlaceName]) VALUES (10,'Sterling')
set identity_insert [dbo].[Places] OFF
go
set identity_insert [dbo].[CabTypes] on

INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (1,'Toyota')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (2,'Honda')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (3,'Nissan')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (4,'Geely')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (5,'BYD')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (6,'Volvo')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (7,'BMW')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (8,'Buick')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (9,'Audi')
INSERT [dbo].[CabTypes] ([CabTypeId], [CabTypeName]) VALUES (10,'VW')
set identity_insert [dbo].[CabTypes] OFF
go

set identity_insert [dbo].[Bookings] on
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (1, '123@gmail.com', CAST('2021-07-26' AS Date), '16:17', 1, 10, 'Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '16:30', 1, '5177759999', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (2, 'abc@gmail.com', CAST('2021-07-27' AS Date), '01:17', 3, 8, 'delf drive', 'bank', CAST(N'2021-07-27' AS Date), '16:30', 1, '1398611471', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (3, '456@hotmal.com', CAST('2021-07-28' AS Date), '16:17', 2, 4, 'churchill rd', 'tree', CAST(N'2021-07-27' AS Date), '16:50', 1, '5177751234', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (4, 'xyz@qq.com', CAST('2021-07-29' AS Date), '02:17', 6, 7, 'thrasher rd', 'bus stop', CAST(N'2021-07-27' AS Date), '16:45', 1, '517775666', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (5, 'ppp@msu.edu', CAST('2021-07-30' AS Date), '12:17', 5, 9, 'outlet', 'kfc', CAST(N'2021-07-27' AS Date), '16:33', 1, '517775777', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (6, '123@gmail.com', CAST('2021-07-26' AS Date), '16:17', 1, 10, 'Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '16:30', 2, '5177759999', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (7, 'abc@gmail.com', CAST('2021-07-27' AS Date), '01:17', 3, 8, 'delf drive', 'bank', CAST(N'2021-07-27' AS Date), '16:30', 3, '1398611471', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (8, '456@hotmal.com', CAST('2021-07-28' AS Date), '16:17', 2, 4, 'churchill rd', 'tree', CAST(N'2021-07-27' AS Date), '16:50', 5, '5177751234', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (9, 'xyz@qq.com', CAST('2021-07-29' AS Date), '02:17', 6, 7, 'thrasher rd', 'bus stop', CAST(N'2021-07-27' AS Date), '16:45', 4, '517775666', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (10, 'ppp@msu.edu', CAST('2021-07-30' AS Date), '12:17', 5, 9, 'outlet', 'kfc', CAST(N'2021-07-27' AS Date), '16:33', 5, '517775777', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (11, '123@gmail.com', CAST('2021-07-26' AS Date), '16:17', 1, 10, 'Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '16:30', 6, '5177759999', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (12, 'abc@gmail.com', CAST('2021-07-27' AS Date), '01:17', 3, 8, 'delf drive', 'bank', CAST(N'2021-07-27' AS Date), '16:30', 7, '1398611471', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (13, '456@hotmal.com', CAST('2021-07-28' AS Date), '16:17', 2, 4, 'churchill rd', 'tree', CAST(N'2021-07-27' AS Date), '16:50', 8, '5177751234', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (14, 'xyz@qq.com', CAST('2021-07-29' AS Date), '02:17', 6, 7, 'thrasher rd', 'bus stop', CAST(N'2021-07-27' AS Date), '16:45', 9, '517775666', 'waiting')
INSERT [dbo].[Bookings] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status]) VALUES (15, 'ppp@msu.edu', CAST('2021-07-30' AS Date), '12:17', 5, 9, 'outlet', 'kfc', CAST(N'2021-07-27' AS Date), '16:33', 10, '517775777', 'waiting')

set identity_insert [dbo].[Bookings] OFF


SET IDENTITY_INSERT [dbo].[Bookings history] ON 

INSERT [dbo].[Bookings history] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (1, '123@gmail.com', CAST(N'2021-07-26' AS Date), '16:17', 1, 10, '3000 Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '16:30', 1, '517-775-1234', 'completed', '00:20', 25.00, 'nice driver')
INSERT [dbo].[Bookings history] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (2, 'abc@gmail.com', CAST(N'2021-07-26' AS Date), '01:17', 3, 8, 'delf drive', 'bank', CAST(N'2021-07-26' AS Date), '01:30', 5, '1398611471', 'completed', '00:15', 100.00, 'nice driver')
INSERT [dbo].[Bookings history] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (3, '456@hotmail.com', CAST(N'2021-07-26' AS Date), '16:17', 2, 4, '3000 Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '17:30', 7, '5177751234', 'completed', '00:50', 75.00, 'bad driver')
INSERT [dbo].[Bookings history] ([Id], [Email], [BookingDate], [BookingTime], [FromPlaceId], [ToPlaceId], [PickUpAddress], [Landmark], [PickupDate], [PickupTime], [CabTypeId], [ContactNo], [Status], [CompTime], [Charge], [Feedback]) VALUES (4, 'xyz@qq.com', CAST(N'2021-07-26' AS Date), '02:17', 6, 7, '3000 Tallow Tree Ct', 'Fairfax Church', CAST(N'2021-07-26' AS Date), '03:30', 9, '517775666', 'completed', '00:30', 52.00, 'bad driver')

SET IDENTITY_INSERT [dbo].[Bookings history] OFF
GO

