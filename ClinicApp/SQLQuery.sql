create database BonaDeaDB;
use BonaDeaDB;
CREATE TABLE Doctors (
    Id INT PRIMARY KEY IDENTITY,
    Firstname NVARCHAR(MAX),
    Lastname NVARCHAR(MAX),
    MedicalDepartment NVARCHAR(MAX)
);
CREATE TABLE Patients (
    Id INT PRIMARY KEY IDENTITY,
    Firstname NVARCHAR(MAX),
    Lastname NVARCHAR(MAX),
    Email NVARCHAR(MAX)
);
CREATE TABLE DoctorPatient (
    DoctorId INT,
    PatientId INT,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id)
);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Vernon', 'Kleinfeld', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Sidoney', 'Bengough', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Jana', 'Cottrell', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Redford', 'Nye', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Darleen', 'Lashmar', 2);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Edsel', 'Dorrins', 2);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Federico', 'Tongue', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Florentia', 'Mynett', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Ysabel', 'Befroy', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Bryon', 'Hearson', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Austen', 'Poetz', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Juditha', 'Solman', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Zita', 'Kubach', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Sean', 'Friese', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Ollie', 'Zavittieri', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Merrel', 'Doogue', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Georgia', 'Zuann', 1);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Glendon', 'Milverton', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Raina', 'Goney', 3);
insert into Doctors (Firstname, Lastname, MedicalDepartment) values ('Kissie', 'Nail', 2);
SELECT * FROM Doctors WHERE Doctors.MedicalDepartment = 3;
insert into Patients (Firstname, Lastname, Email) values ('Nancie', 'Andrus', 'nandrus0@thetimes.co.uk');
insert into Patients (Firstname, Lastname, Email) values ('Holly', 'Gramer', 'hgramer1@unesco.org');
insert into Patients (Firstname, Lastname, Email) values ('Dewain', 'McLeese', 'dmcleese2@spotify.com');
insert into Patients (Firstname, Lastname, Email) values ('Juanita', 'Labell', 'jlabell3@discuz.net');
insert into Patients (Firstname, Lastname, Email) values ('Jess', 'Figg', 'jfigg4@linkedin.com');
insert into Patients (Firstname, Lastname, Email) values ('Derrek', 'Draisey', 'ddraisey5@bandcamp.com');
insert into Patients (Firstname, Lastname, Email) values ('Ruperta', 'Neads', 'rneads6@opensource.org');
insert into Patients (Firstname, Lastname, Email) values ('Weston', 'Giraldon', 'wgiraldon7@sogou.com');
insert into Patients (Firstname, Lastname, Email) values ('Vinny', 'Malafe', 'vmalafe8@independent.co.uk');
insert into Patients (Firstname, Lastname, Email) values ('Ellerey', 'Ellesworthe', 'eellesworthe9@xing.com');
insert into Patients (Firstname, Lastname, Email) values ('Traci', 'Goering', 'tgoeringa@ucsd.edu');
insert into Patients (Firstname, Lastname, Email) values ('Milly', 'Kryzhov', 'mkryzhovb@seesaa.net');
insert into Patients (Firstname, Lastname, Email) values ('Muire', 'Churchlow', 'mchurchlowc@unesco.org');
insert into Patients (Firstname, Lastname, Email) values ('Burlie', 'Alliban', 'balliband@noaa.gov');
insert into Patients (Firstname, Lastname, Email) values ('Bab', 'Rewan', 'brewane@icq.com');
insert into Patients (Firstname, Lastname, Email) values ('Nappie', 'Fellowes', 'nfellowesf@prlog.org');
insert into Patients (Firstname, Lastname, Email) values ('Gaye', 'Poytres', 'gpoytresg@google.com');
insert into Patients (Firstname, Lastname, Email) values ('Bendite', 'Vasiljevic', 'bvasiljevich@cbslocal.com');
insert into Patients (Firstname, Lastname, Email) values ('Thomasa', 'Paraman', 'tparamani@bbc.co.uk');
insert into Patients (Firstname, Lastname, Email) values ('Ewan', 'Gaspar', 'egasparj@yahoo.com');
insert into Patients (Firstname, Lastname, Email) values ('Tore', 'Foucard', 'tfoucard0@arstechnica.com');
insert into Patients (Firstname, Lastname, Email) values ('Ginni', 'Trebbett', 'gtrebbett1@php.net');
insert into Patients (Firstname, Lastname, Email) values ('Madlen', 'Steggals', 'msteggals2@kickstarter.com');
insert into Patients (Firstname, Lastname, Email) values ('Marabel', 'Dudenie', 'mdudenie3@ow.ly');
insert into Patients (Firstname, Lastname, Email) values ('Amaleta', 'Cash', 'acash4@github.io');
insert into Patients (Firstname, Lastname, Email) values ('Nita', 'Borrow', 'nborrow5@auda.org.au');
insert into Patients (Firstname, Lastname, Email) values ('Maurice', 'Beyer', 'mbeyer6@hp.com');
insert into Patients (Firstname, Lastname, Email) values ('Gussie', 'Veltman', 'gveltman7@godaddy.com');
insert into Patients (Firstname, Lastname, Email) values ('Maitilde', 'Chiese', 'mchiese8@reference.com');
insert into Patients (Firstname, Lastname, Email) values ('Amaleta', 'Girardy', 'agirardy9@java.com');
insert into Patients (Firstname, Lastname, Email) values ('Crissie', 'Caspell', 'ccaspella@prlog.org');
insert into Patients (Firstname, Lastname, Email) values ('Giovanna', 'Clementucci', 'gclementuccib@seesaa.net');
insert into Patients (Firstname, Lastname, Email) values ('Ortensia', 'Rupel', 'orupelc@toplist.cz');
insert into Patients (Firstname, Lastname, Email) values ('Ailey', 'Lagde', 'alagded@trellian.com');
insert into Patients (Firstname, Lastname, Email) values ('Isobel', 'Crocumbe', 'icrocumbee@smugmug.com');
insert into Patients (Firstname, Lastname, Email) values ('Sydelle', 'Caplin', 'scaplin0@lycos.com');
insert into Patients (Firstname, Lastname, Email) values ('Seana', 'Szymanski', 'sszymanski1@irs.gov');
insert into Patients (Firstname, Lastname, Email) values ('Nikki', 'Burger', 'nburger2@springer.com');
insert into Patients (Firstname, Lastname, Email) values ('Emmerich', 'Ace', 'eace3@huffingtonpost.com');
insert into Patients (Firstname, Lastname, Email) values ('Westley', 'Janaway', 'wjanaway4@sogou.com');
insert into Patients (Firstname, Lastname, Email) values ('Vachel', 'Gildersleaves', 'vgildersleaves5@patch.com');
insert into Patients (Firstname, Lastname, Email) values ('Jillie', 'Swendell', 'jswendell6@google.pl');
insert into Patients (Firstname, Lastname, Email) values ('Olympia', 'Raper', 'oraper7@indiatimes.com');
insert into Patients (Firstname, Lastname, Email) values ('Ashely', 'Walles', 'awalles8@wikia.com');
insert into Patients (Firstname, Lastname, Email) values ('Rochell', 'Monnoyer', 'rmonnoyer9@creativecommons.org');
SELECT * FROM Patients;