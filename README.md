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
5. Bulk insert, update, delete locations (Not done)
6. The background service for collecting carpark analyst data is isolate from web API which they can run independently 

## Usage

1. User can select type of their vehicle from car or motorcycle and find the available carparks near.
![Find near Carpark](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/NearCarPark.png?token=GHSAT0AAAAAACSUBTS7QDKRQVK2TUB5KADEZTSK4HQ)

2. In this page user can check the analyst carpark data to better plan their trip.
![Carpark list](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/list.png?token=GHSAT0AAAAAACSUBTS74LKM5LML2QMCVYKWZTSQCWA)

Here user can find the available slot for each time interval.
![Carpark analyst](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/anaylst.png?token=GHSAT0AAAAAACSUBTS7KKGMKELMSIRIUQGSZTSK4UA)

3. In this page use can add location in routing map and click the marker button to check available carpark near that location.
![Routing map](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/routing.png?token=GHSAT0AAAAAACSUBTS7IB7ZGDKP47XNFB7QZTSK5AA)

# Location Management 
- Following two page is for manage locations for routing map.
4.  Here can Insert, update and delete location.
![CRUD location](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/CRUDSingle.png?token=GHSAT0AAAAAACSUBTS6WETMPB57HQXCYC32ZTSKYLA)

5. This page is for upload .csv file to perform bulk insert, update, delete.
![Upload location](https://raw.githubusercontent.com/billy0204/NearCarPark/master/img/upload.png?token=GHSAT0AAAAAACSUBTS6CRHNXWKZ6BK4EBGQZTSK5RA)
