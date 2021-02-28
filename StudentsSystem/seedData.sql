-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: student_system
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- DB
--
create database student_system;
use student_system;

--
-- Table structure for table `disciplines`
--

DROP TABLE IF EXISTS `disciplines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disciplines` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `ProfessorName` varchar(45) NOT NULL,
  `SemesterId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_semester_discipline` (`SemesterId`),
  CONSTRAINT `fk_semester_discipline` FOREIGN KEY (`SemesterId`) REFERENCES `semesters` (`Id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disciplines`
--

LOCK TABLES `disciplines` WRITE;
/*!40000 ALTER TABLE `disciplines` DISABLE KEYS */;
INSERT INTO `disciplines` (`Id`, `Name`, `ProfessorName`, `SemesterId`) VALUES (1,'Agile Business Management','Chuck Cobb',1),(2,'Application Development on Microsoft Azure','Patrick Neborg',3),(3,'Advanced Machine Learning on Google Cloud','Google Cloud',1),(5,'AWS Big Data','Kim Schmidt',2),(6,'Android Development with Kotlin','Jim Wilson',2),(7,' Domain-Driven Design','Matthew Renze',4),(8,'Building Data Pipelines in Microsoft Azure','Michael Bender',3),(9,' Data Science Literacy','Janani Ravi',2),(10,'Angular','Deborah Kurata',2),(11,'Building Web Applications with Django','Saravanan Dhandapani',4),(12,'Building Web Apps with Ruby On Rails','Ashutosh Singh',4),(13,' Entity Framework Core','Kevin Dockx',3),(14,'Google Cloud Functions','Ervis Trupja',1);
/*!40000 ALTER TABLE `disciplines` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `semesters`
--

DROP TABLE IF EXISTS `semesters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `semesters` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `semesters`
--

LOCK TABLES `semesters` WRITE;
/*!40000 ALTER TABLE `semesters` DISABLE KEYS */;
INSERT INTO `semesters` (`Id`, `Name`, `StartDate`, `EndDate`) VALUES (1,'First Semester','2000-01-02','2000-04-02'),(2,'Second Semester','2000-04-02','2020-08-01'),(3,'Third Semester','2021-02-01','2021-02-02'),(4,'Fourth Semester','2001-05-01','2001-09-01');
/*!40000 ALTER TABLE `semesters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Surname` varchar(45) NOT NULL,
  `DOB` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'student_system'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-28 20:18:04
