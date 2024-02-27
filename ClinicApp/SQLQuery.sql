create database BonaDeaDB;
use BonaDeaDB;
CREATE TABLE Doctors (
    Id INT PRIMARY KEY IDENTITY,
    FIN NVARCHAR(7),
    Firstname NVARCHAR(MAX),
    Lastname NVARCHAR(MAX),
    MedicalDepartment NVARCHAR(MAX),
	CONSTRAINT DK_FIN UNIQUE(FIN)
);
CREATE TABLE [MedicalReceptionists] (
    [Id] int PRIMARY KEY identity,
    [Email] nvarchar(max),
    [Name] nvarchar(max),
    [Surname] nvarchar(max),
    [Password] nvarchar(max)
)
CREATE TABLE Patients (
    Id INT PRIMARY KEY IDENTITY,
    FIN NVARCHAR(7),
    Firstname NVARCHAR(MAX),
    Lastname NVARCHAR(MAX),
    Email NVARCHAR(MAX),
	CONSTRAINT PT_FIN UNIQUE(FIN)
);
CREATE TABLE DoctorPatient (
    DoctorId INT,
    PatientId INT,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id)
);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('12KK54J', 'Carena', 'Warcop', 3);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('100K54J', 'Web', 'Kay', 1);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('126YU4J', 'Aliza', 'Underhill', 2);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('33RK54J', 'Nada', 'Rudgerd', 3);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('12KHB4J', 'Guido', 'Rivelin', 1);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('5KK5001', 'Arte', 'Fetherston', 2);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('255K54J', 'Pail', 'Schiefersten', 1);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('9KIU34J', 'Hilde', 'Deener', 3);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('99KJF4J', 'Hector', 'Roseby', 1);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('10PPZ4J', 'Priscilla', 'Marrett', 1);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('Q12D44J', 'Bronnie', 'Fifoot', 3);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('45UK54J', 'Euell', 'Gorring', 2);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('1KL3R4J', 'Sherm', 'Pevsner', 2);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('00ASV4J', 'Guendolen', 'Kitchen', 2);
insert into Doctors (FIN, Firstname, Lastname, MedicalDepartment) values ('POL4K4J', 'Hayley', 'Ayris', 2);
SELECT * FROM Doctors;
insert into Patients (FIN, Firstname, Lastname, Email) values ('MKBUA7I', 'Deloris', 'Dudman', 'ddudman0@sina.com.cn');
insert into Patients (FIN, Firstname, Lastname, Email) values ('V9M8G65', 'Rutherford', 'Osband', 'rosband1@exblog.jp');
insert into Patients (FIN, Firstname, Lastname, Email) values ('VELL1V1', 'Johnette', 'Meneer', 'jmeneer2@studiopress.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('KMGG4WM', 'Michal', 'Harden', 'mharden3@economist.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('B8S9W0R', 'Deny', 'Budgett', 'dbudgett4@home.pl');
insert into Patients (FIN, Firstname, Lastname, Email) values ('31C91VN', 'Evangelia', 'Woodbridge', 'ewoodbridge5@infoseek.co.jp');
insert into Patients (FIN, Firstname, Lastname, Email) values ('UDUQ021', 'Pamelina', 'Lewnden', 'plewnden6@google.nl');
insert into Patients (FIN, Firstname, Lastname, Email) values ('FX001HY', 'Gerhardine', 'Trase', 'gtrase7@twitpic.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('1AZYIRX', 'Nana', 'Adanez', 'nadanez8@hugedomains.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('6TM3Q1V', 'Kathrine', 'Schmidt', 'kschmidt9@fotki.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('L8KPMX8', 'Manya', 'Lightwood', 'mlightwooda@epa.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('4O80WA5', 'Yank', 'Hulburt', 'yhulburtb@mail.ru');
insert into Patients (FIN, Firstname, Lastname, Email) values ('XRTCZJW', 'Colene', 'Bollum', 'cbollumc@irs.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('RSJIIRZ', 'Rocky', 'McFeat', 'rmcfeatd@imdb.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('HYHFJ2A', 'Conrade', 'De Zuani', 'cdezuanie@yahoo.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('2TZN7KW', 'Clay', 'Bracchi', 'cbracchif@edublogs.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('25YUXRD', 'Georgeanne', 'Lovejoy', 'glovejoyg@taobao.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('U5592WH', 'Mohandis', 'Galland', 'mgallandh@nih.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('6J369CU', 'Carlotta', 'Skully', 'cskullyi@unesco.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('CP51G09', 'Arleta', 'Sucre', 'asucrej@wikipedia.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('B4H1ZUT', 'Forest', 'Arons', 'faronsk@fc2.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('NQFT7T2', 'Jarvis', 'Cavee', 'jcaveel@dyndns.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('IZKIY3C', 'Editha', 'de Clerq', 'edeclerqm@adobe.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('JCGAC1L', 'Chris', 'Croson', 'ccrosonn@unc.edu');
insert into Patients (FIN, Firstname, Lastname, Email) values ('N7L6T7Y', 'Karna', 'Nightingale', 'knightingaleo@state.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('QKV935P', 'Elihu', 'Easseby', 'eeassebyp@amazon.co.uk');
insert into Patients (FIN, Firstname, Lastname, Email) values ('5ETWL4J', 'Latrena', 'Shorton', 'lshortonq@baidu.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('A1HZ4EK', 'Yale', 'Pierrepoint', 'ypierrepointr@networkadvertising.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('GBYSQ35', 'Tamqrah', 'Abisetti', 'tabisettis@ca.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('8YY7AT8', 'Fayre', 'Verissimo', 'fverissimot@mit.edu');
insert into Patients (FIN, Firstname, Lastname, Email) values ('MU8C0FD', 'Odelia', 'Royson', 'oroysonu@mit.edu');
insert into Patients (FIN, Firstname, Lastname, Email) values ('L5VDWCT', 'Murvyn', 'Fitchet', 'mfitchetv@princeton.edu');
insert into Patients (FIN, Firstname, Lastname, Email) values ('T9PP7NX', 'Tybie', 'Chipperfield', 'tchipperfieldw@mapy.cz');
insert into Patients (FIN, Firstname, Lastname, Email) values ('5JAWCKQ', 'Wilt', 'Silverlock', 'wsilverlockx@biglobe.ne.jp');
insert into Patients (FIN, Firstname, Lastname, Email) values ('5STV1SV', 'Leola', 'Varfalameev', 'lvarfalameevy@guardian.co.uk');
insert into Patients (FIN, Firstname, Lastname, Email) values ('CKANI0U', 'Jan', 'Simenet', 'jsimenetz@earthlink.net');
insert into Patients (FIN, Firstname, Lastname, Email) values ('CZDBAGD', 'Xerxes', 'Kubes', 'xkubes10@ifeng.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('7CB6CG0', 'Leanora', 'Ganders', 'lganders11@unesco.org');
insert into Patients (FIN, Firstname, Lastname, Email) values ('U8STHEI', 'Livvyy', 'Kerby', 'lkerby12@gizmodo.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('B2CKUVR', 'Rachele', 'Scyner', 'rscyner13@jimdo.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('FCNWGT9', 'Reggie', 'Phipson', 'rphipson14@booking.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('C32FHM2', 'Faustina', 'Grimsdith', 'fgrimsdith15@amazonaws.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('96D0F8U', 'Timi', 'Ableson', 'tableson16@aboutads.info');
insert into Patients (FIN, Firstname, Lastname, Email) values ('HZG8P8A', 'Ingar', 'Attwoull', 'iattwoull17@ow.ly');
insert into Patients (FIN, Firstname, Lastname, Email) values ('U2GKKMA', 'Carri', 'Reisk', 'creisk18@ycombinator.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('7W3F69S', 'Dermot', 'McMorran', 'dmcmorran19@mit.edu');
insert into Patients (FIN, Firstname, Lastname, Email) values ('RXGMEYE', 'Noelyn', 'Borgars', 'nborgars1a@whitehouse.gov');
insert into Patients (FIN, Firstname, Lastname, Email) values ('ST7F32P', 'Donnell', 'Yourell', 'dyourell1b@google.pl');
insert into Patients (FIN, Firstname, Lastname, Email) values ('CMHRXQR', 'Rutledge', 'Reilly', 'rreilly1c@slate.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('D6QE9BJ', 'Clayson', 'Oldale', 'coldale1d@bigcartel.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('IQ7U4XI', 'Timmy', 'Lockwood', 'tlockwood1e@dropbox.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('QLBIGNU', 'Frank', 'Benwell', 'fbenwell1f@wix.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('MCLS7RI', 'Johna', 'Duiged', 'jduiged1g@google.co.uk');
insert into Patients (FIN, Firstname, Lastname, Email) values ('WPL2KXW', 'Alexis', 'McDonnell', 'amcdonnell1h@google.es');
insert into Patients (FIN, Firstname, Lastname, Email) values ('I5W34YY', 'Sebastien', 'Safont', 'ssafont1i@squidoo.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('S8MZ3R0', 'Tove', 'Shillitto', 'tshillitto1j@yandex.ru');
insert into Patients (FIN, Firstname, Lastname, Email) values ('S01KPWR', 'Devon', 'Gert', 'dgert1k@state.tx.us');
insert into Patients (FIN, Firstname, Lastname, Email) values ('JHS6S4B', 'Carroll', 'Esson', 'cesson1l@howstuffworks.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('QXLM6W3', 'Abner', 'Mc Mechan', 'amcmechan1m@theglobeandmail.com');
insert into Patients (FIN, Firstname, Lastname, Email) values ('VDTJYP5', 'Cary', 'Routley', 'croutley1n@house.gov');
SELECT * FROM Patients;
CREATE TABLE [MedicalReceptionists] (
    [Id] int PRIMARY KEY identity,
    [Email] NVARCHAR(MAX),
    [Firstname] NVARCHAR(MAX),
    [Lastname] NVARCHAR(MAX),
    [Password] NVARCHAR(MAX)
)
insert into [MedicalReceptionists]([Email], [Firstname], [Lastname], [Password])
values('xas.zab.kam@gmail.com', 'Zabil', 'Khasayli', 'qwerty123')