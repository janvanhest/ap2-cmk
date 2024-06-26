# Changelog

## 17 juni. 
- First final version. 
- Algorithm for learningstreaks is implemented.
### 18 juni. 
- Updated technical en functional design with latest changes. 
- implemented dashboard service
- implemented streak calculation strategy
- implemented streak calculator
- implemented progress repo
- implemented progress service
- updated for each entity a service and a repo. 
- Updated uml diagram in documentation.

### 30 mei. 
- Removed API layer. 
- Made intention with writing a DashBoardService. 
- Added ProgressRepo
- Injected ProgressRepo
- Made a start with
  - DashboardService
  - IStreakCalculationStrategy 
  - StreakCalculationStrategy
  - AdvancedCalculationStrategy
  - BasicStreakCalculationStrategy
  - Created StreakCalculator
- Created CalculateTotalScore for streaks. 
- created function GetLastStreak
- created function GetFirstStreak
- GetProgressRecordsByUser
- CalculateStreaks
- Updated progress entity with date fields. 
- Updated script.sql to reflect changes. 
- Updated Domainlayer to reflect changes. 

### 27 mei. 
- Added 

### 24 mei. 
- Added simple test for Adminstration. 
- Added diagrams as an svg instead of an png. 
- Added # Functioneel Ontwerp "LingoPartner" Taal Leer App
- Added Documentation with latest info and diagrams. 
  - Functional design. 
  - Technical design. 
- Added new chapter with user acceptance tests.

## 24 mei Versie 0.4 
- Most important entities are added with repos so most important algorithms can be implemented. 
  - User
  - Progress
  - LearningModule
  - Learning Activities
  - etc. 
- Alle entities have a repository and are supported by simple interface options for showing and storing data.
  - Show Users
  - Show User by Role. 
  - Show Learning Modules
  - Show Learning Activities

### 24 mei. 
- Created a progress repo
- Few fixes
  - Typo's
  - Naming Conventions. 
  - Parameter handling. 
  - Adding returntypes instead of using void. (void is not so meaningfull for the view layer)
- Added soms console fluf with rainbow colors and type animations
- Added to Console helper
  - ConsoleColor[] RainbowColors and ConsoleColor[] AllColors
  - DisplayTypingAnimation(), DisplayMessage()
  - GetLearningActivityType(), GetIntInput()
- Updated program.cs
  - Updated ConfigureTrace. 
  - Added Authenticate(), ReadPassword() 
  - Cleanup
- Created LearningActivityAdd for adding learning activities in console/view
- Updated menu.cs with
  - Adding new learning activity
- Updated UserList.show(UserRole? role=null) to show all users or only users with a specific role and not using a string anymore but a UserRole enum.
- Created IProgressRepository and ProgressRepository for storing and retrieving progress data.
- Updated AddLearningActivity in Administration to support adding learning activities.
- Updated Progress.cs with use of UserId and LearningActivityId instead of User and LearningActivity.
- Bugfix LearningActivityRepository.
- Updated sql script for progress. 

### 22 mei. 
- created simple user login functionality. 
- Created simple login functionality for user. (though no salting of password yet). 
- Created simple plantuml diagram for user login functionality.

### 19 mei Major update. 
- merged with main because of implementation of repository pattern and reversed dependency injection.
- created shared layer.
- changed references. Console/View and infrastructure are now referencing the domain layer.
- All layers point to shared layer.
- Created interfaces for user reposotories.
- Repository pattern implemented for user, learningModule implemented with corresponding interfaces.
- 
### 19 mei dev updates.
- created shared layer. 
- changed references. Console/View and infrastructure are now referencing the domain layer.
- All layers point to shared layer.
- Created interfaces for user reposotories. 
- Repository pattern implemented for user, learningModule implemented with corresponding interfaces.
- Added a helper class for infrastructure layer to create a connection string. 
- Added a helper class for infrastructure layer to check if database is available. 
- Added several helper functions for input validation. 
- Added trace functionality. 
  - Trace functionality automiticall logs all actions to a file and to the console.
- Added a helper class in the shared layer with a method for logging.
- Updated script for database user and userlearningmodule tables and some test data.
- Updated docker-compose file to include the database.

### 19 mei Major update. 
- merged with main because of implementation of repository pattern and reversed dependency injection.

### 19 mei. 
- created shared layer. 
- changed references. Console/View and infrastructure are now referencing the domain layer.
- All layers point to shared layer.
- Created interfaces for user reposotories. 
- Repository pattern implemented for user, learningModule implemented with corresponding interfaces.
- Added a helper class for infrastructure layer to create a connection string. 
- Added a helper class for infrastructure layer to check if database is available. 
- Added several helper functions for input validation. 
- Added trace functionality. 
  - Trace functionality automiticall logs all actions to a file and to the console.
- Added a helper class in the shared layer with a method for logging.
- Updated script for database user and userlearningmodule tables and some test data.
- Updated docker-compose file to include the database.
- Added database.puml to the repository with a diagram of the database.

### 10 mei.
- Storing and retrieving of User and learningModule entities is succesfull. `
>>>>>>> dev

### Zondag 24 maart. 
- Updated the class diagram with the correct relations.
  - Also changed the protection level of several properties to public/protected.
- 

### 17 maart. 
- Added final version of the class diagram. 
- Added pdf version of the class diagram for examenation by teacher.
- added html version of the class diagram for examenation by teacher.

### 14 maart
- Added final usecase diagram. 
- Added conceptueel model.

### 11 maart efteling usecase. 
- Added usecase diagram for efteling.

### 26 feb
- Added pitch/showcase to documentation

### 27 feb
- Added reference to readme.md for later use
- Added initial setup for project
- merged main with dev branch
- added sln file. 
- added LingoPartnerApi webapi template to solution
- added LingoPartnerConsole console templategit to solution

### 27 feb. 
- Merging again main with dev branch. Hopefully now the project is initialized correctly

## references

https://youtu.be/PmDJIooZjBE?si=6jwojAC2ss44tyl_
