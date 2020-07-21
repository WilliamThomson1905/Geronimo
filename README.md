# Geronimo - Hotel Booking System

## Introduction

Geronimo Hotel is a fictitious international hotel with resorts distributed in Glasgow, Amsterdam, London, Paris, and New York. 
A new image for the hotel will be created. This will require the creation of a dynamic web application with an online booking system integrated. Each hotel also has a restaurant, where a user will be able to make a booking through the online booking system. 
Each of the five locations will have a combination of:
1.	Rooms 
2.	Gym
3.	Spa 
4.	Events 
5.	Dining (restaurant)

Based on what options are available for a specific hotel, the user should be able to add any combination of these as additions to their room booking. 

**The scope of the project:** A fully functional online booking system is required. User should be able to visit the website and view current data regarding hotels, the room availability of those hotels, the availability of tables at the restaurant. Bookings will need to be made to the available rooms/tables.  

**Assumptions:** Booking rooms can be done through main website or over the phone (not an app). Both options must update the system with current data. 


**Known risks and issues:** Creating a system that can be easily extended if an app was ever to be created. 


## Requirements Engineering
System requirements will belong to one of the following three categories: 
1.	Functional: What the system will do? 
2.	Non-functional: Quality Attributes that will be focused on to achieve functional requirements. 
3.	Constraints: Pre-made design decisions that must be factored into the overall design. 

### Functional Requirements


| #             | Requirement | Potential QA |
| ------------- | ------------- | ------------- |
| FR001  | The user shall be able to VIEW details for all hotels.   |Usability,  |
| FR002  | The user shall be able to SEARCH details for all hotels.  | Usability, Performance, Reliability |
| FR003  | The user shall be able to view the details of a specific hotel – the one they will probably book from.  |  |
| FR004  | The user shall be able to search availability of all hotels. |  |
| FR005  | The user shall be able to VIEW information pertaining to the areas of the hotels: Rooms, Gym, Spa, Events, Dining |  
|  | **General - Booking/Reserving a Room/Table** | |
| FR006  | The user shall be able to book a room – from a specific hotel.  | Usability, Security |
| FR007  | The user shall be able to book a table – from a specific hotel.  | Usability, Security |
| FR008  | The user shall be able to book a room/table using either PayPal or Credit Card.  | Usability, Security |
| FR009  | The user shall be able to view room availability of a specific hotel.  | Usability, Performance, Reliability |
| FR010  | The user shall be able to view table availability of a specific hotel.  | Usability, Performance, Reliability   |
| | **Admin- Hotel** | |
| FR011  | The user shall be able to CREATE a new hotel.  | Security, Manageability, reliability |
| FR012  | The user shall be able to manage all/specific hotel information – general information, not booking information.  | Security |
| FR013 | The user shall be able to ADD/EDIT/DELETE a location for a hotel.  | Security |
| FR014  | The user shall be able to UPLOAD/VIEW/DELETE document attachments to a hotel.  | Performance  |
| | **Admin - Rooms** | |
| FR015  | The user shall be able to ADD/EDIT/DELETE Rooms to a specific hotel.  | |
| | **Admin - Dining** | |
| FR016  | The user shall be able to ADD/EDIT/DELETE Tables to a specific hotel/restaurant.  | |
| FR017  | The user shall be able to ADD/EDIT/DELETE information pertaining to the Eat & Drink of a specific hotel. | |
| | **Admin - Events** | |
| FR017  | The user shall be able to ADD/EDIT/DELETE Locations in specific hotels for Events within a specific hotel.  | |
| | **Admin - Gym** | |
| FR018  | The user shall be able to ADD/EDIT/DELETE information pertaining to the Gym.  | |
| | **Admin - Spa** | |
| FR019  | The user shall be able to ADD/EDIT/DELETE information pertaining to the Spa of a specific hotel.  | |
| | **Admin - Events** | |
| FR020  | | |
| FR021  | | |


## Overarching Quality Attributes to Consider
Design Qualities 
QA’s that define restrictions to how the system will be developed. 

1.	Maintainability
2.	Reusability 

Run-Time Qualities
QA’s that are a factor when the application is running. 

1.	Performance 
2.	Reliability 
3.	Security 

System Qualities
1.	Testability
 
User Qualities
1.	Usability 



## Functionality (Modules) and User Types  
Subsystems and user types where identified from the initial requirements analysis. The following modules and user types have been identified for the system: 

### Modules – Subsystems:
Below is a list of the subsystems identified within the system. These will be further analysed later: 
1.	**CBS - Customer Booking System** – System which allows customers to book rooms/tables. System will maintain the availability of rooms/tables/etc and only display the appropriate information when customer is going through the booking process. 
2.	**CRMS - Customer Relationship Management System** – Handling customer information: bookings (tables and rooms), events, update customer database, browse customer database, view booking history view total spend profile, favourite (most visited) hotel, manage customer account (suspend, remove), 
3.	**CMS - Content Management System (Hotel)** – Used to maintain information on system.	
4.	**RGS - Report Generation System** – https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ee658105%28v%3dpandp.10%29#logging-and-instrumentation


### Users Types:
Administrator, Manager, Staff, Guest, and Customer  
	

| User Type  | User Subsystem Interaction |
| ------------- | ------------- |
| Administrator  | CMS – CRMS – RGS |
| Manager  | CMS (ONLY their Hotel) – CRMS – RGS (ONLY their Hotel) |
| Staff  | CBS (booking in Customers) |
| Customer/Guest  | CBS |


### Classes (Users and their Permissions)
**Admin** – Be able to manage information pertaining to all hotels and staff. 
**Manager** – Be able to manage all information pertaining to the hotel and staff that they manage. 
**Staff** – Staff of various types (reception, cleaner, etc) will have varying levels of access (permissions) into the system. 
**Customer/Guest** – Will be an account holder. 



*NB:Since information can be managed from multiple sources – might be a good idea to log the changes. The Admin user will be able to view this information. – Could influence Performance, having to log specific changes in the system...not every change.*



## Non-Functional Requirements
*NB: https://docs.microsoft.com/en-us/previous-versions/msp-np/ee658094(v=pandp.10)?redirectedfrom=MSDN
NB: Non-Functional Requirements: Scenario Profile – Quality requirements are difficult to understand without their being situated within a specific system scenario. So, a profile is developed of a set of scenarios, each scenario having its own relative importance value.* 


The following non-functional requirements have been identified for the system. 

### Non-Functional Requirements 
| # | NF Description | QA |
|-----|-----|-----|
| NF001 | The system shall be secure when managing customer bank details and personal information. | Security |
| NF002 | 	The systems frontend shall be fully responsive. | Usability |
| NF003 | The system shall have a good response time – 1 second for read responses – 3 seconds for write responses. | Performance |
| NF004 | The system shall respond to incorrect input from user and act accordingly. | Reliability |
| NF005 | The system shall provide accurate information regarding content available on the system. | Reliability, Performance, |


### Constraints 
*NB: Both internal and external stakeholders/systems could provide constraints to the systems requirements engineering.*

What constraints exist for the system?
|# | 	Constraints |	Source|
|-----|-----|-----|
|C001 | 	Development stack will be Asp.net MVC. Programming language: C#. Frontend: HTML5, CSS3. | Internal | 
|C002 | The staff of Geronimo must be able to make bookings from the reception – either through a face-to-face customer discussion or a telephone discussion. | Client | 






## Ideas for Features
1. When a gym class is cancelled everyone who was supposed to be attending gets a notification - publish/subscribe pattern. 




