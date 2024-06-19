# Near carpark (Macau)

This project is aim to use car park data from Macau open data platform to help use find available carpark near user. And also carpark analyst data with routing map to help user plan their trip.

## Dependencies
1. .NET 8.0 - ASP.NET Core Web API
2. MS SQL Server 2022 
3. Mongodb 
4. Vue3
5. Macau open data 

## Features
1. Find nearest and available carpark near user according to user's latlng and car type
2. Background service to collect carpark analyst data
3. Routing map for way points and use first feature to find near carpark
4. Insert, update, delete location for routing map
5. Bulk insert, update, delete locations (Ongoing)
6. The background service for collecting carpark analyst data is isolate from web API which they can run independently 

## Usage

1.
![Find near Carpark](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/NearCarPark.png?token=GHSAT0AAAAAACSUBTS646RZ5E6Y65M37FZOZTSJ3ZA)
2.
![Carpark list](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/list.png?token=GHSAT0AAAAAACSUBTS6IR6WWYEH56OFXZC2ZTSJ43Q)
3.
![Carpark analyst](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/anaylst.png?token=GHSAT0AAAAAACSUBTS6FJFKZ2NUTWEDW33AZTSJ5KQ)
4.
![Routing map](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/routing.png?token=GHSAT0AAAAAACSUBTS7DPNJWWAMBFRVHRM6ZTSJ56Q)
5.
![CRUD location](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/CRUDSingle.png?token=GHSAT0AAAAAACSUBTS7TYXPMXEZIYDTBZC2ZTSJ6XA)
