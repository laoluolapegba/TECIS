-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: tecis
-- ------------------------------------------------------
-- Server version	5.5.5-10.0.17-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(100) CHARACTER SET utf8 NOT NULL,
  `ContextKey` varchar(200) CHARACTER SET utf8 NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`MigrationId`,`ContextKey`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201510170942308_InitialCreate','TECIS.Data.Identity.ApplicationDbContext','‹\0\0\0\0\0\0Ý\\[oã¸~/Ðÿ è±ÈZ¹tÓÀÞEÖIÚ`\'Œ3‹¾\rh‰v„‘H­Deýe}èOê_è¡DÝxÑÅVlg±À\"Éï~$çÿùïô§—0°žqœø”Ìì“É±maâRÏ\'ë™²ÕŸìŸ~üóŸ¦W^øbýZÔ;ãõ %IföcÑ¹ã$îQ2	}7¦	]±‰KCyÔ9=>þ›srâ`€°Ë²¦_RÂüg?àçœG,EÁ-õpˆïP²ÈP­;â$B.žÙWó›Åä14¹ñ0À°WÛº|ª,p°²-Deˆ¢ç_¼`1%ëEPðø\Za¨·BA‚EÎ«ê}ûr|ÊûâT\r(7M\ržœ	ã8róLl—Æó]eöá½ÎL8³“}¡@x>b^yfß–\".’è³ÒÖ“ò:¸ßiü}RG<²z·;*Ét:9æÿYó4`iŒg§,FÁ‘õ.ßý¿>Òï˜ÌÎN–«³O>\"ïìã_ñÙ‡zO¡¯P¯ñ>=Ä4Â1è†WeÿmËi¶sä†e³Z›Ü*À%˜¶u‹^>c²fO0cN?ÙÖµÿ‚½â‹ ×WâÃ4‚F,Náç]\Zhà²Üi•Éÿß\"õôÃÇQ¤Þ¡g\r½$&NœØÖd¥É“åÓ«1ÞßDµë˜†üw“_yé·Mc—w†\Z«<¢xYS»©S‘·¥9Ôø´.PŸÚ\\S•ÞÚª¼C›Ì„BÄ®gC¡ïÛÊíÍ¸‹(‚ÁË¨Å-ÒF8Ín5‘šYU¥Š:\'}©C Kä•ð*D~0ÂRØC\n¸!+?qÙËŸ)‘Á:? $•ÀûJžZT‡?GP}Ý4^-\n£7—öðD	¾KÃ%çýîd64¿Ókä2\Z_Þjk¼ÏÔýNSvE<˜¿ø+s@þóÑûŒ¢Î…ëâ$¹2coNÁË.\0o;;Ç×§}»\"ó\0ù¡Þ‘VÒoEÕÊÑ×P|C5_Ò¦êgºöI?U‹ªfUó\ZªŠjCUå`ý45ÍŠf:õÌkæée#4¾«—Á¾¯·ÝæmZjf\\À\n‰ÿŽ	Žaóc8&ÕôY7öá,dÃÇ…¾ùÞ”IúéØ¢6š\rÙ\"0þlÈ`6djÂçgßã^IPQà{Õ×Ÿ­ºçœ¤Ù®§C£›»¾›5À4].’„º~64¡/¸hê>œÕÅÈ{#GB c@tŸoyðúfË¤º\'—8À[n\Zœ£ÄEžjFè7@±bGÕ(VEDšÊýE‘	LÇ1o„ø!(™ê¦NŸ¸~„‚N+I-{na¼ï¥¹äG˜p–è#\\\0á\n”r¤Aé²ÐÔ©1®ˆ¯Õ4æ].l5îJ\\b\'œìð\r¼þÛ›³Ýb; g»Iú(`æíƒ â¬Ò—\0òÁåÐ*˜.ÕNÚ´ØÚ4É»#h~Dí;þÒyõÐèÙ<(ï~[o5×¸Ù°ÇQ3÷=¡\rƒ8Véy¹ä…ø…ig §8Ÿ%ÂÕ•)ÂÁ˜5C6•¿«õCv™Dm€Ñ:@Å5 ¤L¨Ê±¼Ví„1\0¶ˆ»µÂŠµ_‚­q@Å®_‡Ö*š/Merö:}”=+Ù ¼×a¡†£!„¼x5;ÞÃ(¦¸¬j˜>¾ðo¸Ö11-êð\\\rF*:3º•\njv[Iç\rqÉ¶²’ä>¬Ttft+	ŽvIãp¶2Qsi²‘Žr·)Ë¦Nž&%>LC>ÕôE‘OÖµü*ñÅZäÉUóÃ“ŽÂÃqMîQ©m)‰Ñ­±T\n¢AÓk?N¿_\"ç™{¡RM»·\Z–ÿBd}ûT±ØŠÚüoqW¨¹¼ol¶ª7\"@®¡‹!wi²8º†\0úæOxCŠ5¡û9\rÒ˜=,sëü¯Þ>ÿ¢\"LIÅƒRÌ¥ø¹MÛ÷\ZuVŒ5J¥³ùH™!Lö.üÏºÅM>©¥QÕQLa«½œÉ•6Z²›8|°:Þff‰Ü”:€ø4£–Þ €ÕÊú£63Pê˜Í’þˆRšIR*\Z e=™¤¡d½`#<ƒEõ5úKPÓGêèjidM\"IZS¼¶Fg¹¬?ª&×¤¬)î]%žÈ«èï]ÆÃËæ›W~ÀÝn÷2`¼Í’8ÎæW»Ç¯Õ>Ä7õ\n˜ø~t2žò6§SØØŽNóÚÓ¸o.=­÷öfÌÆ½vcyo»×7ã\r#í›RC9åÉUJéåiO:ÕMÅ	«û)räÊ«ØVaÆ™}ûºø-È	•ý9|ÌWò¢Æ-\"þ\n\',Oæ°?L>JqçaŒ“$^ 9¡š^Ç4ÇliYäÅîŠÕ$‰-T Jüù†xøefÿ+kuž…2ø_Ùç#ë&ùJüßR(xŒSlý[Mú\'™¾ýœu Oú[õæŸßò¦GÖ}æÜ:–l¹É7DÒ&oº…6?“x¿ªñA‹*MˆÍŸ,)\rFyoPÐ,»x\Z¦–ö9Á¦`š×#@c4ÓK€ÀŒÏ\0<øÉ²g\01výüùìñÐÎë	l¤©ñ…€OØÖïú¯DEË=î6šsÑ.V¥ÌÎùÕ[%[î{{RÒ°7ôj–u?¤-’¨7àÃ;Ë?m[Ô¤†½OB¿yNñ¡¤W	ûÍÞeÂpË•Ð*Oø\02Û4™:ûÏÞ5×LÜO©–ó{`dù[ûÏìÝ5ÙLñÝ\'Û üÝãÚ¾öÏ=3­÷º÷l\\5±Èp£weÛæs8æ/) ÷(óG’úô.“°Š,FU³Ps^™,X™8Š\\¥F»Øa}~kgEv±†lÌ6Ùbýo•-ê´Ë6ä8î#OX›e¨ËÝîXÇÚ ÞS^p£\'iè]>këµú{JÅ(Ùc¸~?Y¿£˜dÌ©3 ËW½ç…½³ö+Âþøë\n‚ÿ3‹»]³¬sCV´Ø¼%Š*R„æ3äÁ–z3…\\Å<²œ½òÎBvüŠc‰½rŸ²(eÐe.ƒFÀ‹;mò³Tæ¦ÎÓû(ûKÆè¨éó\0ý=ù9õ¯ÔûZ2@pïBÄqùX2Ï]¿–Hw”ôæ+¢GF€%÷džñ&ºý>ã5r_« 	¤{ šfŸ^úh£0U{ø	öÂ—ÿòšÕ_T\0\0','6.1.3-40302');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agegroup`
--

DROP TABLE IF EXISTS `agegroup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agegroup` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agegroup`
--

LOCK TABLES `agegroup` WRITE;
/*!40000 ALTER TABLE `agegroup` DISABLE KEYS */;
INSERT INTO `agegroup` VALUES (1,'15-20'),(2,'21-25'),(3,'26-30'),(4,'31-35'),(5,'36-40'),(6,'41-45'),(7,'46-50'),(8,'50 & Above'),(9,'-');
/*!40000 ALTER TABLE `agegroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `answer`
--

DROP TABLE IF EXISTS `answer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `answer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answer`
--

LOCK TABLES `answer` WRITE;
/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
INSERT INTO `answer` VALUES (1,'Yes'),(2,'No'),(3,'Maybe'),(4,'-');
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8 NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8 NOT NULL,
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) CHARACTER SET utf8 NOT NULL,
  `RoleId` varchar(128) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(128) CHARACTER SET utf8 NOT NULL,
  `Email` varchar(256) CHARACTER SET utf8 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('1a2d253b-6bd0-4516-97f6-2561320a7874','laoluolapegba@gmail.com',0,'AD3CNlQMCnHhTRs+EBhp1owy1TUxNnZT7Lgnah8I6w3OrRlIeJtkevdUCyQa8KPDsg==','81822955-74fa-47fd-9a26-0dc328d12ac9',NULL,0,0,NULL,1,0,'laoluolapegba@gmail.com');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `audittrail`
--

DROP TABLE IF EXISTS `audittrail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `audittrail` (
  `auditid` int(11) NOT NULL AUTO_INCREMENT,
  `sessionid` varchar(100) NOT NULL,
  `ipaddress` varchar(20) NOT NULL,
  `userid` varchar(100) NOT NULL,
  `urlaccessed` varchar(100) NOT NULL,
  `timeaccessed` datetime NOT NULL,
  `auditdata` varchar(2000) NOT NULL,
  `auditaction` varchar(20) DEFAULT NULL,
  `serializeddata` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`auditid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audittrail`
--

LOCK TABLES `audittrail` WRITE;
/*!40000 ALTER TABLE `audittrail` DISABLE KEYS */;
/*!40000 ALTER TABLE `audittrail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clusterarea`
--

DROP TABLE IF EXISTS `clusterarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clusterarea` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clusterarea`
--

LOCK TABLES `clusterarea` WRITE;
/*!40000 ALTER TABLE `clusterarea` DISABLE KEYS */;
INSERT INTO `clusterarea` VALUES (1,'Mobolaji Johnson'),(2,'Oniru'),(3,'UPDC'),(4,'Lekki Phase 1'),(5,'Oniru - Marwa'),(6,'1004 Estate/VI'),(7,'Parkview-Ikoyi'),(8,'Dolphin Estate'),(9,'Chevy view'),(10,'Friends Colony'),(11,'Northern Foreshore'),(12,'Milverton Estate'),(13,'Bourdillon Court'),(14,'Victory Park'),(15,'Agungi'),(16,'Osapa'),(17,'NICON'),(18,'Alpha Beach Road'),(19,'Igbo-Efon/Idado'),(20,'VGC'),(21,'Lekki County'),(22,'Ikota Villa Estate'),(23,'Lekki Conservation Area'),(24,'Ilaje-Ajah'),(25,'Dockville Estate'),(26,'od Homes Est'),(27,'Coop Villa'),(28,'Langbasa'),(29,'Awoyaya'),(30,'Abijo'),(31,'Eleko'),(32,'Lakowe'),(33,'Santedo'),(34,'Bogije'),(35,'LBS'),(36,'Abraham Adesanya'),(37,'Thomas Estate'),(38,'Penensular Estate'),(39,'Ombo'),(40,'Surulere - Aguda'),(41,'Surulere - Atunrase'),(42,'Akoka'),(43,'Yaba'),(44,'Isolo'),(45,'Papa Ajao/Mushin'),(46,'Matori/Oshodi'),(47,'Festac Town'),(48,'Atunrase - Gbagada'),(49,'Ifako - Gbagada'),(50,'Palmgrove/Pedro/Charlie-boy'),(51,'Anthony'),(52,'Olusosun - Ojota'),(53,'Ketu'),(54,'Marwa - Ikeja'),(55,'Toyin Ikeja'),(56,'Ojodu Berger'),(57,'Mado Isheri'),(58,'Ojota/Ogudu'),(59,'Egbeda - Akowonjo'),(60,'Alagbole'),(61,'Ogba'),(62,'Isheri - Ikotun'),(64,'Others');
/*!40000 ALTER TABLE `clusterarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gender`
--

DROP TABLE IF EXISTS `gender`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gender` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gender`
--

LOCK TABLES `gender` WRITE;
/*!40000 ALTER TABLE `gender` DISABLE KEYS */;
/*!40000 ALTER TABLE `gender` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guest`
--

DROP TABLE IF EXISTS `guest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `guest` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gender` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `agegroup` int(11) DEFAULT NULL,
  `maritalstat` int(11) DEFAULT NULL,
  `surname` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `othernames` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `phonenumber` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `emailaddress` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `homeaddress` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `nearestbstop` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `clusterarea` int(11) DEFAULT NULL,
  `officeadress` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `occupation` varchar(80) CHARACTER SET utf8 DEFAULT NULL,
  `flg_join` int(11) DEFAULT NULL,
  `flg_membershipinfo` int(11) DEFAULT NULL,
  `flg_moreinfo` int(11) DEFAULT NULL,
  `prayercomments` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `worshipdate` date DEFAULT NULL,
  `servicetype` int(11) DEFAULT NULL,
  `timecaptured` datetime DEFAULT NULL,
  `createdby` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `entrychannel` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `smssent` bit(1) NOT NULL,
  `smsresponse` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_visitordata_agegroup_idx` (`agegroup`),
  KEY `FK_visitordata_cluster_idx` (`agegroup`),
  KEY `FK_visitordata_maritalstat_idx` (`maritalstat`),
  KEY `FK_visitordata_cluster_idx1` (`clusterarea`),
  KEY `FK_visitordata_meminfo_idx` (`flg_membershipinfo`),
  KEY `FK_visitordata_moreabout_idx` (`flg_moreinfo`),
  KEY `FK_visitordata_smsresp_idx` (`smsresponse`),
  KEY `FK_visitordata_svctype_idx` (`servicetype`),
  CONSTRAINT `FK_visitordata_agegroup` FOREIGN KEY (`agegroup`) REFERENCES `agegroup` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_cluster` FOREIGN KEY (`clusterarea`) REFERENCES `clusterarea` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_maritalstat` FOREIGN KEY (`maritalstat`) REFERENCES `maritalstat` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_meminfo` FOREIGN KEY (`flg_membershipinfo`) REFERENCES `answer` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_moreinfo` FOREIGN KEY (`flg_moreinfo`) REFERENCES `answer` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_smsresp` FOREIGN KEY (`smsresponse`) REFERENCES `smsresponse` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_visitordata_svctype` FOREIGN KEY (`servicetype`) REFERENCES `servicetype` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `guest`
--

LOCK TABLES `guest` WRITE;
/*!40000 ALTER TABLE `guest` DISABLE KEYS */;
/*!40000 ALTER TABLE `guest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maritalstat`
--

DROP TABLE IF EXISTS `maritalstat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `maritalstat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maritalstat`
--

LOCK TABLES `maritalstat` WRITE;
/*!40000 ALTER TABLE `maritalstat` DISABLE KEYS */;
INSERT INTO `maritalstat` VALUES (1,'Married'),(2,'Single'),(3,'Widow'),(4,'Divorced');
/*!40000 ALTER TABLE `maritalstat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notification` (
  `noteid` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) NOT NULL,
  `notificationtype` int(11) NOT NULL,
  `controller` varchar(30) NOT NULL,
  `action` varchar(30) NOT NULL,
  `userid` varchar(50) NOT NULL,
  `isdismissed` int(11) NOT NULL,
  `notedate` datetime NOT NULL,
  `senderid` varchar(20) DEFAULT NULL,
  `msgbody` varchar(255) DEFAULT NULL,
  `notebadge` int(11) DEFAULT NULL,
  PRIMARY KEY (`noteid`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
INSERT INTO `notification` VALUES (1,'New Cash Order',1,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Femi',NULL,1),(2,'Pending Orders ',2,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Kaz',NULL,1),(3,'Pending Orders ',2,'Dash','Index','laoluolapegba@gmail.com',1,'2015-11-02 00:00:00','Femi',NULL,0),(4,'Awaiting Authorization',1,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Femi',NULL,2),(21,'Low Cash Level',1,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Femi',NULL,4),(22,'New Member Added',1,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Femi',NULL,3),(23,'Pending Orders',1,'Dash','Index','laoluolapegba@gmail.com',0,'2015-11-02 00:00:00','Femi',NULL,0);
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `occupation`
--

DROP TABLE IF EXISTS `occupation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `occupation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `occupation`
--

LOCK TABLES `occupation` WRITE;
/*!40000 ALTER TABLE `occupation` DISABLE KEYS */;
INSERT INTO `occupation` VALUES (1,'Teacher');
/*!40000 ALTER TABLE `occupation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permission`
--

DROP TABLE IF EXISTS `permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permission` (
  `PermissionId` int(11) NOT NULL,
  `PermissionDescription` varchar(50) NOT NULL,
  `action` varchar(20) NOT NULL,
  `controllername` varchar(20) NOT NULL,
  `parentpermission` int(11) DEFAULT NULL,
  `formurl` varchar(20) DEFAULT NULL,
  `imageurl` varchar(20) DEFAULT NULL,
  `iconclass` varchar(20) DEFAULT NULL,
  `isopenclass` varchar(20) DEFAULT NULL,
  `toggleicon` varchar(20) DEFAULT NULL,
  `isactive` int(11) DEFAULT NULL,
  PRIMARY KEY (`PermissionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permission`
--

LOCK TABLES `permission` WRITE;
/*!40000 ALTER TABLE `permission` DISABLE KEYS */;
INSERT INTO `permission` VALUES (1,'Dashboard','Index','Home',0,NULL,NULL,'fa-dashboard','open','fa fa-angle-down',1),(2,'Orders','Index','Home',0,NULL,NULL,'fa-clipboard','open','fa fa-angle-left',1),(3,'Charts & Analysis','Index','Home',0,NULL,NULL,'fa-bar-chart-o',NULL,'fa fa-angle-left',1),(4,'Admin','Index','Home',0,NULL,NULL,'fa-gears',NULL,'fa fa-angle-left',1),(5,'CMU Dashboard','Dashboard','Dashboard',1,NULL,NULL,NULL,NULL,NULL,1),(6,'Demand Forecast','DistScheduler','DistSched',1,NULL,NULL,NULL,NULL,NULL,1),(7,'Branch Dashboard','BranchDash','Dashboard',1,NULL,NULL,NULL,NULL,NULL,1),(8,'Donut View ','DonutView','Home',1,NULL,NULL,NULL,NULL,NULL,1),(9,'Request Cash','CashOrder','Home',2,NULL,NULL,NULL,NULL,NULL,1),(10,'Approve Request','BranchApprove','Home',2,NULL,NULL,NULL,NULL,NULL,1),(11,'View Request Status','ViewOrders','Home',2,NULL,NULL,NULL,NULL,NULL,1),(12,'Register Mutilated Notes','Index','BadNotes',2,NULL,NULL,NULL,NULL,NULL,1),(13,'Evacuate Cash','Index','Home',2,NULL,NULL,NULL,NULL,NULL,1),(14,'Branches','Index','Branch',4,NULL,NULL,NULL,NULL,NULL,1),(15,'States','Index','States',4,NULL,NULL,NULL,NULL,NULL,1),(16,'Regions','Index','Regions',4,NULL,NULL,NULL,NULL,NULL,1),(17,'CMU','Index','CMU',4,NULL,NULL,NULL,NULL,NULL,1),(18,'Cash Denominations','Index','Notes',4,NULL,NULL,NULL,NULL,NULL,1),(19,'Currencies','Index','Currency',4,NULL,NULL,NULL,NULL,NULL,1),(20,'Charts','Index','Home',3,NULL,NULL,NULL,NULL,NULL,1),(21,'Interactive Charts','Index','Home',3,NULL,NULL,NULL,NULL,NULL,1),(22,'Realtime Charts','Index','Home',3,NULL,NULL,NULL,NULL,NULL,1),(23,'Heap Maps','Index','Home',3,NULL,NULL,NULL,NULL,NULL,1),(24,'Users','Index','Admin',4,NULL,NULL,NULL,NULL,NULL,1),(25,'Roles','Index','Roles',4,NULL,NULL,NULL,NULL,NULL,1),(26,'Branch Efficiency','BranchEfficiency','Dashboard',1,NULL,NULL,NULL,NULL,NULL,1),(27,'Branch Cash Forecast','BrnCashSchedule','DistSched',1,NULL,NULL,NULL,NULL,NULL,1),(28,'Region Cash Forecast','RegCashSchedule','DistSched',1,NULL,NULL,NULL,NULL,NULL,1),(29,'CMU Cash Forecast','CmuCashSchedule','DistSched',1,NULL,NULL,NULL,NULL,NULL,1),(30,'Confirm Request','RegConfirm','Home',2,NULL,NULL,NULL,NULL,NULL,1),(31,'Settings','Settings','Config',4,NULL,NULL,NULL,NULL,NULL,1),(32,'Notes','Index','Notes',4,NULL,NULL,NULL,NULL,NULL,1),(33,'Cash Status','CashStatus','CashStatus',1,NULL,NULL,NULL,NULL,NULL,1),(34,'Regional Dash','RegDash','Dashboard',1,NULL,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolepermxref`
--

DROP TABLE IF EXISTS `rolepermxref`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolepermxref` (
  `roleid` int(11) NOT NULL,
  `permissionid` int(11) NOT NULL,
  `parenttask` int(11) NOT NULL,
  `createdby` varchar(20) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  PRIMARY KEY (`roleid`,`permissionid`),
  KEY `fk_roleperm_perm_idx` (`permissionid`),
  CONSTRAINT `fk_roleperm_perm` FOREIGN KEY (`permissionid`) REFERENCES `permission` (`PermissionId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_roleperm_role` FOREIGN KEY (`roleid`) REFERENCES `userrole` (`roleid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolepermxref`
--

LOCK TABLES `rolepermxref` WRITE;
/*!40000 ALTER TABLE `rolepermxref` DISABLE KEYS */;
INSERT INTO `rolepermxref` VALUES (1,1,0,NULL,NULL),(1,2,0,NULL,NULL),(1,3,0,NULL,NULL),(1,4,0,NULL,NULL),(1,9,0,NULL,NULL),(1,11,0,NULL,NULL),(1,12,0,NULL,NULL),(1,13,0,NULL,NULL),(1,27,1,NULL,NULL),(2,1,0,NULL,NULL),(2,2,0,NULL,NULL),(2,3,0,NULL,NULL),(2,4,0,NULL,NULL),(2,10,2,NULL,NULL),(2,11,2,NULL,NULL),(2,27,1,NULL,NULL),(3,1,0,NULL,NULL),(3,2,0,NULL,NULL),(3,3,0,NULL,NULL),(3,4,0,NULL,NULL),(3,5,1,NULL,NULL),(3,11,0,NULL,NULL),(3,18,0,NULL,NULL),(3,19,0,NULL,NULL),(3,26,1,NULL,NULL),(3,29,1,NULL,NULL),(3,31,0,NULL,NULL),(3,32,0,NULL,NULL),(3,33,0,NULL,NULL),(4,1,0,NULL,NULL),(4,2,0,NULL,NULL),(4,3,0,NULL,NULL),(4,4,0,NULL,NULL),(4,5,1,NULL,NULL),(4,6,1,NULL,NULL),(4,7,1,NULL,NULL),(4,8,1,NULL,NULL),(4,9,2,NULL,NULL),(4,10,2,NULL,NULL),(4,11,2,NULL,NULL),(4,12,2,NULL,NULL),(4,13,2,NULL,NULL),(4,14,4,NULL,NULL),(4,15,4,NULL,NULL),(4,16,4,NULL,NULL),(4,17,4,NULL,NULL),(4,18,4,NULL,NULL),(4,19,4,NULL,NULL),(4,20,3,NULL,NULL),(4,21,3,NULL,NULL),(4,22,3,NULL,NULL),(4,23,3,NULL,NULL),(4,24,4,NULL,NULL),(4,25,4,NULL,NULL),(4,26,1,NULL,NULL),(4,27,1,NULL,NULL),(4,28,0,NULL,NULL),(4,29,0,NULL,NULL),(4,31,4,NULL,NULL),(4,32,4,NULL,NULL),(4,33,0,NULL,NULL),(4,34,0,NULL,NULL),(5,1,0,NULL,NULL),(5,2,0,NULL,NULL),(5,3,0,NULL,NULL),(5,4,0,NULL,NULL),(5,28,1,NULL,NULL),(5,30,1,NULL,NULL),(5,34,1,NULL,NULL);
/*!40000 ALTER TABLE `rolepermxref` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicetype`
--

DROP TABLE IF EXISTS `servicetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `servicetype` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `servicename` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicetype`
--

LOCK TABLES `servicetype` WRITE;
/*!40000 ALTER TABLE `servicetype` DISABLE KEYS */;
INSERT INTO `servicetype` VALUES (1,'1st Service'),(2,'2nd Service'),(3,'3rd Service'),(4,'4th Service');
/*!40000 ALTER TABLE `servicetype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smsresponse`
--

DROP TABLE IF EXISTS `smsresponse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smsresponse` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smsresponse`
--

LOCK TABLES `smsresponse` WRITE;
/*!40000 ALTER TABLE `smsresponse` DISABLE KEYS */;
INSERT INTO `smsresponse` VALUES (-13,'Other'),(-12,'INVALID_DESTINATION_ADDRESS'),(-11,'MISSING_PASS'),(-10,'MISSING_USERNAME'),(-9,'DESTADDR_INVALIDFORMAT'),(-8,'MISSING_SENDERNAME'),(-7,'MISSING_SMSTEXT'),(-6,'MISSING_DESTINATION_ADDRESS'),(-5,'INVALID_USER_OR_PASS'),(-4,'SOCKET_EXCEPTION (Currently not in use)'),(-3,'NETWORK_NOTCOVERED'),(-2,'NOT_ENOUGHCREDITS'),(-1,'SEND_ERROR (Currently not in use)'),(1,'Successful, sent MESSAGE ID is the return val');
/*!40000 ALTER TABLE `smsresponse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userprofile`
--

DROP TABLE IF EXISTS `userprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userprofile` (
  `ProfileId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(50) NOT NULL,
  `cod_password` varchar(128) NOT NULL,
  `passwordsalt` varchar(128) DEFAULT NULL,
  `mobilepin` varchar(10) DEFAULT NULL,
  `passwordquestion` varchar(255) DEFAULT NULL,
  `passwordanswer` varchar(255) DEFAULT NULL,
  `isapproved` int(11) DEFAULT NULL,
  `islocked` int(11) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `lastlogindate` datetime DEFAULT NULL,
  `lastpasswordchangeddate` datetime DEFAULT NULL,
  `lastlockoutdate` datetime DEFAULT NULL,
  `failedpasswordattemptcount` int(11) DEFAULT NULL,
  `roleId` int(11) DEFAULT NULL,
  `displayname` varchar(100) DEFAULT NULL,
  `firstname` varchar(20) NOT NULL,
  `lastname` varchar(20) NOT NULL,
  `emailaddress` varchar(50) NOT NULL,
  PRIMARY KEY (`ProfileId`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`),
  KEY `fk_userroleid_idx` (`roleId`),
  CONSTRAINT `fk_userroleid` FOREIGN KEY (`roleId`) REFERENCES `userrole` (`roleid`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userprofile`
--

LOCK TABLES `userprofile` WRITE;
/*!40000 ALTER TABLE `userprofile` DISABLE KEYS */;
INSERT INTO `userprofile` VALUES (1,'laoluolapegba@gmail.com','yUdA/OEF7pLlAzwQLP1MU5KmbRAdB88VQmUugGaERmY=','SpgDetbvQ+Gf8ZsPHik3yANUVMdAAoBD','232',NULL,NULL,1,0,'2015-11-07 19:18:12','2015-11-07 19:19:18',NULL,NULL,NULL,1,'Laolu','Laolu','Olapegba','laoluolapegba@gmail.com');
/*!40000 ALTER TABLE `userprofile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userrole` (
  `roleid` int(11) NOT NULL AUTO_INCREMENT,
  `rolename` varchar(120) NOT NULL,
  `pswdlifedays` int(11) DEFAULT NULL,
  `userlevel` int(11) DEFAULT NULL,
  `createdby` varchar(20) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `lastmodifiedby` varchar(20) DEFAULT NULL,
  `lastmodifieddate` datetime DEFAULT NULL,
  `isdefault` int(11) DEFAULT NULL,
  PRIMARY KEY (`roleid`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrole`
--

LOCK TABLES `userrole` WRITE;
/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole` VALUES (1,'Data Manager',90,8,'system',NULL,NULL,NULL,1),(2,'Pastor',30,10,NULL,NULL,NULL,NULL,0),(3,'Senior Pastor',30,15,NULL,NULL,NULL,NULL,0),(4,'Administrator',30,30,NULL,NULL,NULL,NULL,1),(5,'Data Analyst',30,15,NULL,NULL,NULL,NULL,0),(81,'TestRole',30,30,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userrolexref`
--

DROP TABLE IF EXISTS `userrolexref`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userrolexref` (
  `userid` varchar(50) NOT NULL,
  `roleid` int(11) NOT NULL,
  PRIMARY KEY (`userid`,`roleid`),
  KEY `fk_rolexref_role_idx` (`roleid`),
  CONSTRAINT `fk_rolexref_role` FOREIGN KEY (`roleid`) REFERENCES `userrole` (`roleid`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rolexref_user` FOREIGN KEY (`userid`) REFERENCES `userprofile` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userrolexref`
--

LOCK TABLES `userrolexref` WRITE;
/*!40000 ALTER TABLE `userrolexref` DISABLE KEYS */;
INSERT INTO `userrolexref` VALUES ('laoluolapegba@gmail.com',1);
/*!40000 ALTER TABLE `userrolexref` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-07 21:50:53
