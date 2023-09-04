# MyCms Web API


The Appointment Scheduler Project is a web application that allows users to schedule and manage appointments. It provides features for both administrators and users to create, view, and manage appointments efficiently.

## Table of Contents

- [Introduction](#Introduction)
- [Features](#Features)
- [Getting Started](#Getting_Started)
- [API Endpoints](#API_Endpoints)
- [Contributing](#Contributing)
- [Installation](#Installation)
- [License](#License)


## Introduction

MyCms Web API is a robust Content Management System (CMS) backend built with .NET Core. It provides a scalable and flexible solution for managing news, comments, images, and more.

## Features
**User Authentication**: Secure JWT-based authentication.\
**News Management**: Add, edit, and manage news articles.\
**Comment Management**: Add and manage comments on news articles.\
**Image Management**: Upload and manage images.\
**Role-based Access Control**: Different roles for admin and users.

## Technologies
- .NET Core 6.0
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT for authentication
- other libraries 

## Getting Started

Prerequisites 
- .NET Core SDK 
- SQL Server

## Installation
1- Clone the repository
```bash 
git clone https://github.com/danialRf/MyCms_Web-API.git
```
2- Navigate to the project directory
```bash 
cd MyCms_Web-API
```
3 - Restore packages
```bash 
dotnet restore
```
4- Run the application
```
dotnet run
```
## API Endpoints
- **POST /api/auth/register** : Register a new user.
- **POST /api/auth/login** : Authenticate a user.
- **POST /api/news**: Add a new news article.
- **GET /api/news**: Get all news articles.
- **PUT /api/news/{id}**: Update a news article.\
For more details, refer to the API documentation.
## Contributing
If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.
## License
Distributed under the MIT License. See LICENSE for more information.
