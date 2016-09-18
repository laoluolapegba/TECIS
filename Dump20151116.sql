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
INSERT INTO `__migrationhistory` VALUES ('201511131706093_InitialCreate','TECIS.Data.Identity.ApplicationDbContext','‹\0\0\0\0\0\0Ý\\Ûnä¸}ô”Þ–/ñ`btïÂÓ¶7FÆL{y°%v›‰ÒJ”×F/ËC>)¿R¢n¼H”Z}ñb€AK,ž*‹d±Tåÿýç¿ÓŸ^ßzq‚B<³O&Ç¶±z¯gvJV?|´úñ˜^{Á«õKAwÆèhOœÌìgB¢ÇIÜg€d 7“pE&n8ÀÓãã¿9\'\'¤6Å²¬é—Àì>ÎCìÂˆ¤À¿=è\'ü=mYd¨Ö=`Îì§ëùíbr˜ÜzÂ7Ûºô ¢, ¿²-€qH\0¡‚^|Mà‚Ä!^/\"úøOo¤t+à\'à¢\"7Ëñ)‹Su, Ü4!aÐðäŒ+Ç»R±]*ªï:Óu¦Â™]¨ìKèSˆ/æ~Ìˆgö]Éâ2‰î!)u=É!ob\n÷[ŸÔ,ã~G¥1NŽÙ¿#kžú$áÃ”ÄÀ?²Ó¥ÜÀ·§ð;Ä³³“åêìãùà}ø+<;¯”Ž•Ò5^ÐWqÁ˜ÊWåømËiösÄŽe·ZŸ\\+Ô–èº°­;ðúâ5y¦+æô£mÝ Wèo¸q}Åˆ.#Ú‰Ä)}¼O},}X¶;­<Ùÿ-\\OÏ?ŒÂõ¼ u6õºpâÄ¶¾@?kMžQ”/¯Æ|ãd7q°ç¦}å­ßa\Z»l0¡–ä	ÄkHšÒMÊxLšAoÖêá›6“T6o%)Ð•P°Øõj(äÝ._c‹»Œ\":y™iuœâ´šÝ¬Š¨2SÓÁtH¶õ	$kG\\¤v«j¯`âÆ(Ê­~éO#ýnªNf`¨“uC¿ãƒåÅ	Áí§ËÙ–9};bt\0äpX\Zp¡Žê\nÅ,\'îSHWÀ½§á$	=+¼¿ƒäyë\nZ@7éRYD[çöøbxŸK¶”wÇk´©yú-¼.	ãkÌzmŒ÷9t¿‡)¹ÆÝ’àWâ€ìñ	æ\0£ˆséº0In¨1CoÒ{Xx‹ÉÙio8¶åîÛYû\0joU8¾¤•Çª¦¼V\r™Êsmõs¸FØLÔ‚T/jNÑ)*\'ë+*3“”SêÍ:åÌ©F»d34þe ƒ=üÛÀfþˆn/¨©qAwHø3Ä0¦Û˜÷1®fÀdßØ‡ÿ“Mcºõ³)ãôðÓ±Y\rZ\rÙ&0þjÈ`5dbÒ×/Èc^‰Á¹ ¦ðFôêÛw÷š$Ûõrhs×Ìw³è–Ëe’„.ÊV\"8ÊC[Mù©guÇ¹4×pëŽ\Z:bG}CÇf‹Fõ€¯ 	´.Ý<x<‰<Yt@^ÁŠU!X3k\n÷‰\'µt³N€]‚ºR&ò²@ØEð;µ$ô4<ÂØØKbËŒ f;5aÂ\\\"c”|„IéÒÐÔ©Y\\»!j¼VÝœw¹°Õ¼K¡–Ød‡ï¬±Kî¿mÅ0Û5¶ãlW‰‰\0Úpï>”ßUL\r@¼¸š\n7&r—j\'ÚÔØ´©’wg ùÕtþ…ûê¡™gó¢¼ûc½U]{°Í†>Ì4sß“ö!´Œeó¼Z²FøJ—3*\'¿Ÿ%ÜÕM„/ i†l*Wé‡:í ¢µV†ÖÊ?K@Ò‚ê!\\Ëk•Ž{=`‹¸[+,ßûØš\rÈØõæ5BýguÑ8nåÈJkŒÜè²PÃQ„¸y5n ]\\VVŒ‰/ÜÇ®\rŒOF‹‚:<W’ŠÁŒ®¥Â4»µ¤rÈú¸diIpŸ4Z*3º–¸v+Iáôp6RQói±‘Žò´)Û¦NžHÇ_LMÆÝôDÂëZc-òô»ù‹þiiAŽá¸‰\";­”¶äDÂ¬¡ÐJYSI³Ï×ìÓþ°8ÏÜ$2åÙªÙþ–õãSžÄâ(¨Ùo¾·\'ì÷ÃêOªÄ„úîúg…_Âánè`æÜdu…)ÈI`áÄŠ þ<ôÓ\0ë}-}ïüS^½þFF˜:‚ü’/%)®f\rgÞ‰J6u˜FƒZ¯‡²[MöA‘yÔÀC/@ÐQÈ”µ+|ßó%é·é(ïT¹E{µ+íYòy1Ö”•¾ýðiÓCè¦®¸™ÕU¯»­éQŠàmEÐÝÛÌéœüÁ{bvê?YÛÙk‰huÚks¬*Õ¬U½5Gâ¹duþª\'F-I«µ™£63Æê˜ÍsD!-¬)4õ²žüÕ²Þ0O£Q5…99Ý«Ž.·ö°J9ñ«ažró\0l…Ìb›9ª\"7¬¬h6Ç®ÅÄ½}[æ\'ª6Ø0üHÍR›©\ZŒílÔãÉµ¼›:PíuO,žY#ñ÷iNÚ¨ÌpsÊ‘›™“C¿÷4RVš[Okž³‘‡ÒØÞÛòpôxýŒv«¦!EeD’’{¢0Sé.Ž”B$9‰mjœÙwo‹_ýÜ ²ŸsA¶“w\0£LHž|eŸOÎ…òÊÃ)ut’Äó%]½csÎvF‰_@ì>ƒXNjÚ °•¾Ýb¾Îìe½.²Ð#û•½>²n“¯ýšÒ†§8…Ö¿å$ížR)j‡üÂe³*,“dIáz½‘ú†W0WÝ™Oÿí?¿å]¬‡˜®ìëX˜ô!¦Ø¬Åë%MÞui—”½ß•/Õk\r]ab9ÖPœFµ•r˜ÂV2¼¸j†þ(•UCÇª,œ\Z\n¦¨‹\Zj¥éjžiž<úH²‚§Çº(ÿSÇ½\rYY5HRm-ÂdãJ(ó­±è9Î9½A±ÌÎ·ÉLÏ•$¥•ïû¼”\nN†.z¹žÄiƒr‘öðÎ*-F;§…£aïÓ ·^=q(U*Û~ë$vY\ZÑò‰ïwUq\09¼ŠœÄý×=ìÚÖt±ïOïWÝp`ÆÆ3U÷_Ã°kcÓEÆÜØzU*˜­íëüÜ³¥¡{¯;S(5ß°Táó®º‚ü[½æ/Cj¹G™—ƒ«YuÌ*cÑ2¬HôLõ´\"ciáH|%Šv¶ýÆÊüÖÁršv¶š¼ó6Þ|ÿoåÍiÚyk²¹÷Q¡Ì§VU©tìcm	mï©¢1’Ž‚›.Ÿµ5!á=<Œ¢”ÆêÑ|V?õ\r£¨dÌ¥Ó£žAþBNÏÎÚ¦çw‚ÖKýÅÐmœš%Í-^…Åá-HTš;H€GÔË˜ p	mf‘åìïYðÔâë`	½[ü’(%tÈ0Xú€sÚøgEM™§ÙÇ×dŒ!P1Ð?àO)ò½RîELHÁ¼ÇesIX<wýV\"Ý‡Øˆ«¯tŠž`ù,yÀð‡ÈFÍï3\\÷­Š\0ê@º\'¢©öéë	Ç¨úÓGjÃ^ðúãÿ¬m‹›k[\0\0','6.1.3-40302');
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
  `Description` longtext,
  `Discriminator` varchar(128) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('65f6ea2a-8477-465e-a4a0-8ed388fb9134','Data Manager','Data Manager DMU Role','ApplicationRole'),('a04a9f28-6810-404a-8834-08c0cc70b9c1','Admin','Admin','ApplicationRole');
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
INSERT INTO `aspnetuserroles` VALUES ('05447ace-e24e-499d-9660-6f9475f17426','65f6ea2a-8477-465e-a4a0-8ed388fb9134');
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
  `Firstname` longtext,
  `Lastname` longtext,
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
INSERT INTO `aspnetusers` VALUES ('05447ace-e24e-499d-9660-6f9475f17426','Laolu','Olapegba','laoluolapegba@gmail.com',1,'ACe1r9mB6dAQ5Vf7abccBWSFVEDPbSoJ6ngRQk98qvsyyr498BY2BrZPqBh725QtgQ==','c4f73031-00d4-4f13-97c4-b0c01e660c04',NULL,0,0,NULL,1,0,'laoluolapegba@gmail.com');
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-16 17:54:03
