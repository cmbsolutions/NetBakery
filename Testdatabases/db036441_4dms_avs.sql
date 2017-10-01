/*
Navicat MySQL Data Transfer

Source Server         : Byte Test & Acceptatie
Source Server Version : 50632
Source Host           : dbint036441:3306
Source Database       : db036441_4dms_avs

Target Server Type    : MYSQL
Target Server Version : 50632
File Encoding         : 65001

Date: 2017-05-11 19:55:34
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for actie_na_overhalen
-- ----------------------------
DROP TABLE IF EXISTS `actie_na_overhalen`;
CREATE TABLE `actie_na_overhalen` (
  `actie` varchar(6) NOT NULL,
  PRIMARY KEY (`actie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for agenda
-- ----------------------------
DROP TABLE IF EXISTS `agenda`;
CREATE TABLE `agenda` (
  `agenda_id` int(10) NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `from_datetime` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `to_datetime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `emailaddress_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`agenda_id`),
  KEY `emailaddress_id` (`emailaddress_id`),
  CONSTRAINT `agenda_ibfk_1` FOREIGN KEY (`emailaddress_id`) REFERENCES `emailaddresses` (`emailaddress_id`)
) ENGINE=InnoDB AUTO_INCREMENT=262 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for bestanden
-- ----------------------------
DROP TABLE IF EXISTS `bestanden`;
CREATE TABLE `bestanden` (
  `bestand_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) DEFAULT '0',
  `traject_id` int(11) DEFAULT '0',
  `ontvangst_id` int(11) DEFAULT NULL,
  `ontvangst_soort` varchar(20) DEFAULT NULL,
  `archiefbestand_jn` tinyint(1) DEFAULT '0',
  `bestand_id_archief` int(11) DEFAULT NULL,
  `bestandsnaam` varchar(255) DEFAULT NULL,
  `xdms_bestandsnaam` varchar(255) DEFAULT NULL,
  `pad` varchar(255) DEFAULT NULL,
  `datum_ontvangen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `datum_verwerkt` datetime DEFAULT NULL,
  `datum_toegewezen` datetime DEFAULT '0000-00-00 00:00:00',
  `op_netwerk_geplaatst` tinyint(1) DEFAULT '0',
  `datum_netwerk` datetime DEFAULT NULL,
  `pm_bevestigings_email_verstuurd_jn` tinyint(1) DEFAULT '0',
  `klant_bevestigings_email_verstuurd_jn` tinyint(1) DEFAULT '0',
  `klant_fout_email_verstuurd_jn` tinyint(1) DEFAULT '0',
  `fout_jn` tinyint(1) DEFAULT '0',
  `fouttekst` mediumtext,
  PRIMARY KEY (`bestand_id`),
  KEY `fk_bestanden_klant` (`klant_id`) USING BTREE,
  KEY `fk_bestanden_klanttraject` (`traject_id`) USING BTREE,
  KEY `fk_bestanden_soort` (`ontvangst_soort`) USING BTREE,
  KEY `fk_bestanden_bestanden` (`bestand_id_archief`) USING BTREE,
  KEY `fk_bestanden_email` (`ontvangst_id`) USING BTREE,
  CONSTRAINT `bestanden_ibfk_1` FOREIGN KEY (`bestand_id_archief`) REFERENCES `bestanden` (`bestand_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `bestanden_ibfk_2` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `bestanden_ibfk_3` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `bestanden_ibfk_4` FOREIGN KEY (`ontvangst_soort`) REFERENCES `soort` (`soort_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `bestanden_ibfk_5` FOREIGN KEY (`ontvangst_id`) REFERENCES `email` (`email_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=744 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for email
-- ----------------------------
DROP TABLE IF EXISTS `email`;
CREATE TABLE `email` (
  `email_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) DEFAULT NULL,
  `traject_id` int(11) DEFAULT NULL,
  `van` varchar(255) DEFAULT NULL,
  `aan` varchar(255) DEFAULT NULL,
  `onderwerp` varchar(255) DEFAULT NULL,
  `body` text,
  `datum_ontvangen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `datum_ingelezen` datetime DEFAULT NULL,
  `datum_toegewezen` datetime DEFAULT NULL,
  `aantal_bijlagen` int(11) DEFAULT '0',
  `aantal_bestanden` int(11) DEFAULT '0',
  `ontvangst_soort` varchar(20) NOT NULL DEFAULT 'email',
  PRIMARY KEY (`email_id`),
  KEY `fk_email_klant` (`klant_id`) USING BTREE,
  KEY `fk_email_klanttraject` (`traject_id`) USING BTREE,
  KEY `fk_email_soort` (`ontvangst_soort`) USING BTREE,
  KEY `fk_email_bestanden` (`email_id`) USING BTREE,
  CONSTRAINT `email_ibfk_1` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `email_ibfk_2` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `email_ibfk_3` FOREIGN KEY (`ontvangst_soort`) REFERENCES `soort` (`soort_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for emailaddresses
-- ----------------------------
DROP TABLE IF EXISTS `emailaddresses`;
CREATE TABLE `emailaddresses` (
  `emailaddress_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `emailname` varchar(100) NOT NULL,
  `emailaddress` varchar(100) DEFAULT NULL,
  `phonenumber` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`emailaddress_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for emaillists
-- ----------------------------
DROP TABLE IF EXISTS `emaillists`;
CREATE TABLE `emaillists` (
  `emaillist_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `clangid` int(11) DEFAULT NULL,
  `clanggroupid` int(11) DEFAULT NULL,
  `sendemailaddress` varchar(100) DEFAULT NULL,
  `sendname` varchar(50) DEFAULT NULL,
  `replyemailaddress` varchar(100) DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`emaillist_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for emailuses
-- ----------------------------
DROP TABLE IF EXISTS `emailuses`;
CREATE TABLE `emailuses` (
  `emailuses_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `emailaddress_id` int(10) unsigned NOT NULL,
  `emaillist_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`emailuses_id`),
  KEY `fk_emailuses_emailaddresses_emailaddress_id_idx` (`emailaddress_id`) USING BTREE,
  KEY `fk_emailuses_emaillists_emailist_id1_idx` (`emaillist_id`) USING BTREE,
  CONSTRAINT `emailuses_ibfk_1` FOREIGN KEY (`emailaddress_id`) REFERENCES `emailaddresses` (`emailaddress_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `emailuses_ibfk_2` FOREIGN KEY (`emaillist_id`) REFERENCES `emaillists` (`emaillist_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for errorlog
-- ----------------------------
DROP TABLE IF EXISTS `errorlog`;
CREATE TABLE `errorlog` (
  `errorlog_id` int(11) NOT NULL AUTO_INCREMENT,
  `datum_ontvangen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `datum_verwerkt` datetime DEFAULT NULL,
  `klant_id` int(11) DEFAULT NULL,
  `traject_id` int(11) DEFAULT NULL,
  `ontvangst_id` int(11) DEFAULT NULL,
  `ontvangst_soort` varchar(20) DEFAULT NULL,
  `foutcode` varchar(50) DEFAULT NULL,
  `foutmelding` text,
  `aantal_keer_opgetreden` int(11) DEFAULT NULL,
  PRIMARY KEY (`errorlog_id`),
  KEY `fk_errorlog_klant` (`klant_id`) USING BTREE,
  KEY `fk_errorlog_klanttraject` (`traject_id`) USING BTREE,
  KEY `fk_errorlog_soort` (`ontvangst_soort`) USING BTREE,
  KEY `idx_ontvangst_id` (`ontvangst_id`,`ontvangst_soort`) USING BTREE,
  CONSTRAINT `errorlog_ibfk_1` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `errorlog_ibfk_2` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `errorlog_ibfk_3` FOREIGN KEY (`ontvangst_soort`) REFERENCES `soort` (`soort_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4291 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for errorlog_severity
-- ----------------------------
DROP TABLE IF EXISTS `errorlog_severity`;
CREATE TABLE `errorlog_severity` (
  `errorlog_id` int(11) NOT NULL,
  `errorseverity_id` int(11) NOT NULL,
  `errortext_id` int(11) NOT NULL,
  PRIMARY KEY (`errorlog_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for errorseverity
-- ----------------------------
DROP TABLE IF EXISTS `errorseverity`;
CREATE TABLE `errorseverity` (
  `errorseverity_id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(20) NOT NULL,
  `severity` int(2) DEFAULT NULL,
  `color` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`errorseverity_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for errortext
-- ----------------------------
DROP TABLE IF EXISTS `errortext`;
CREATE TABLE `errortext` (
  `errortext_id` int(11) NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `errortext` text NOT NULL,
  `errorseverity_id` int(11) NOT NULL,
  `erroraction` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`errortext_id`),
  KEY `errorseverity` (`errorseverity_id`),
  CONSTRAINT `errortext_ibfk_1` FOREIGN KEY (`errorseverity_id`) REFERENCES `errorseverity` (`errorseverity_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for feestdagen
-- ----------------------------
DROP TABLE IF EXISTS `feestdagen`;
CREATE TABLE `feestdagen` (
  `datum` date NOT NULL,
  `omschrijving` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`datum`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for ftpconnection
-- ----------------------------
DROP TABLE IF EXISTS `ftpconnection`;
CREATE TABLE `ftpconnection` (
  `ftp_connection_id` int(11) NOT NULL AUTO_INCREMENT,
  `ftp_omschrijving` varchar(100) DEFAULT NULL,
  `ftp_host` varchar(100) DEFAULT NULL,
  `ftp_port` int(11) DEFAULT NULL,
  `ftp_user` varchar(50) DEFAULT NULL,
  `ftp_pass` varchar(50) DEFAULT NULL,
  `ftp_use_passive` tinyint(1) DEFAULT '0',
  `ftp_mode` enum('FTP','SFTP') DEFAULT 'FTP',
  `ftp_security` enum('Implicit','Explicit','None') DEFAULT 'None',
  `ftp_transfer_mode` enum('Ascii','Binary') DEFAULT 'Binary',
  `ftp_use_key` tinyint(1) DEFAULT '0',
  `ftp_key_data` text,
  `ftp_key_pass` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ftp_connection_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for ftpschema
-- ----------------------------
DROP TABLE IF EXISTS `ftpschema`;
CREATE TABLE `ftpschema` (
  `ftp_schema_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL,
  `regelmaat_id` char(1) NOT NULL,
  `datum` datetime DEFAULT NULL,
  `dag` char(2) DEFAULT NULL,
  `dag_van_de_maand` char(2) DEFAULT NULL,
  `zoveelste_weekdag_van_de_maand` char(1) DEFAULT NULL,
  `tijd` time DEFAULT NULL,
  `aantal_pogingen` int(11) DEFAULT '0',
  `tijd_wachten_na_poging` time DEFAULT NULL,
  `aantal_geprobeerd` int(11) DEFAULT '0',
  `datum_laatste_keer_uitgevoerd` datetime DEFAULT NULL,
  `poging_succesvol` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`ftp_schema_id`),
  KEY `fk_ftpschema_klant` (`klant_id`) USING BTREE,
  KEY `fk_ftpschema_klanttraject` (`traject_id`) USING BTREE,
  KEY `fk_ftpschema_regelmaat` (`regelmaat_id`) USING BTREE,
  CONSTRAINT `ftpschema_ibfk_1` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ftpschema_ibfk_2` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ftpschema_ibfk_3` FOREIGN KEY (`regelmaat_id`) REFERENCES `regelmaat` (`regelmaat_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for inspire_printjob
-- ----------------------------
DROP TABLE IF EXISTS `inspire_printjob`;
CREATE TABLE `inspire_printjob` (
  `printjob_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL,
  `datum_aangeboden` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `datum_verwerkt` datetime DEFAULT NULL,
  `odd_workflow` varchar(255) DEFAULT NULL,
  `odd_job` varchar(255) DEFAULT NULL,
  `odd_bestand` varchar(255) DEFAULT NULL,
  `aantal_records_aangeleverd` int(11) DEFAULT NULL,
  `aantal_records` int(11) DEFAULT NULL,
  `aantal_paginas` int(11) DEFAULT NULL,
  `print_tijd` varchar(20) DEFAULT NULL,
  `status_id` int(11) NOT NULL DEFAULT '1',
  `error_count` int(11) NOT NULL DEFAULT '0',
  `error_message` text,
  PRIMARY KEY (`printjob_id`),
  KEY `fk_klant` (`klant_id`),
  KEY `fk_traject` (`traject_id`,`klant_id`),
  CONSTRAINT `fk_klant` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_traject` FOREIGN KEY (`traject_id`, `klant_id`) REFERENCES `klanttraject` (`traject_id`, `klant_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1004 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for klant
-- ----------------------------
DROP TABLE IF EXISTS `klant`;
CREATE TABLE `klant` (
  `klant_id` int(11) NOT NULL AUTO_INCREMENT,
  `klantnaam` varchar(50) NOT NULL,
  `pm_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`klant_id`),
  KEY `pm_id` (`pm_id`),
  CONSTRAINT `klant_ibfk_1` FOREIGN KEY (`pm_id`) REFERENCES `pm` (`pm_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for klant__pm
-- ----------------------------
DROP TABLE IF EXISTS `klant__pm`;
CREATE TABLE `klant__pm` (
  `klant_id` int(11) NOT NULL,
  `pm_id` int(11) NOT NULL,
  PRIMARY KEY (`klant_id`,`pm_id`),
  KEY `dd` (`pm_id`),
  CONSTRAINT `dd` FOREIGN KEY (`pm_id`) REFERENCES `pm` (`pm_id`) ON UPDATE CASCADE,
  CONSTRAINT `kl` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for klanttraject
-- ----------------------------
DROP TABLE IF EXISTS `klanttraject`;
CREATE TABLE `klanttraject` (
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL AUTO_INCREMENT,
  `recdt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `recsta` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `trajectomschrijving` varchar(255) NOT NULL,
  `soort` varchar(20) NOT NULL,
  `ftp_connection_id` int(11) DEFAULT NULL,
  `ftp_masker` varchar(255) DEFAULT NULL,
  `ftp_pad` varchar(255) DEFAULT NULL,
  `ftp_scan_recursive` tinyint(1) DEFAULT '0',
  `ftp_actie_na_overhalen` varchar(6) DEFAULT '',
  `ftp_move_pad` varchar(255) DEFAULT NULL,
  `email_onderwerp_masker` varchar(255) DEFAULT NULL,
  `email_bestand_masker` varchar(255) DEFAULT NULL,
  `email_bestand_verplicht` tinyint(1) DEFAULT '0',
  `netwerk_masker` varchar(255) DEFAULT NULL,
  `netwerk_pad` varchar(255) DEFAULT NULL,
  `netwerk_subdirectories` tinyint(1) DEFAULT '0',
  `rapportage_masker` varchar(255) DEFAULT NULL,
  `rapportage_pad` varchar(255) DEFAULT NULL,
  `archief_wachtwoord` varchar(100) DEFAULT NULL,
  `pm_id` int(11) DEFAULT NULL,
  `pm_bevestigingsemail` tinyint(1) DEFAULT '0',
  `klant_bevestigingsemail` tinyint(1) DEFAULT '0',
  `klant_bevestigingsemail_adres` varchar(255) DEFAULT NULL,
  `klant_foutemail` tinyint(1) DEFAULT '0',
  `klant_foutemail_adres` varchar(255) DEFAULT NULL,
  `bestanden_kopieren_naar_pad` varchar(255) DEFAULT NULL,
  `bestanden_kopieren_met_xdms_naam` tinyint(1) DEFAULT '0',
  `databasename` varchar(40) DEFAULT NULL,
  `viewname` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`traject_id`),
  KEY `fk_klanttraject_klant` (`klant_id`) USING BTREE,
  KEY `fk_klanttraject_actie` (`ftp_actie_na_overhalen`) USING BTREE,
  KEY `fk_klanttraject_soort` (`soort`) USING BTREE,
  KEY `fk_klanttraject_ftpconnections` (`ftp_connection_id`) USING BTREE,
  KEY `traject_id` (`traject_id`,`klant_id`),
  KEY `status` (`recsta`),
  KEY `pm_id` (`pm_id`),
  CONSTRAINT `klanttraject_ibfk_1` FOREIGN KEY (`ftp_actie_na_overhalen`) REFERENCES `actie_na_overhalen` (`actie`) ON UPDATE CASCADE,
  CONSTRAINT `klanttraject_ibfk_2` FOREIGN KEY (`ftp_connection_id`) REFERENCES `ftpconnection` (`ftp_connection_id`) ON UPDATE CASCADE,
  CONSTRAINT `klanttraject_ibfk_3` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `klanttraject_ibfk_4` FOREIGN KEY (`soort`) REFERENCES `soort` (`soort_id`) ON UPDATE CASCADE,
  CONSTRAINT `klanttraject_ibfk_5` FOREIGN KEY (`pm_id`) REFERENCES `pm` (`pm_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for klanttraject__pm
-- ----------------------------
DROP TABLE IF EXISTS `klanttraject__pm`;
CREATE TABLE `klanttraject__pm` (
  `traject_id` int(11) NOT NULL,
  `pm_id` int(11) NOT NULL,
  PRIMARY KEY (`traject_id`,`pm_id`),
  KEY `pm_id` (`pm_id`),
  CONSTRAINT `klanttraject__pm_ibfk_1` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON UPDATE CASCADE,
  CONSTRAINT `klanttraject__pm_ibfk_2` FOREIGN KEY (`pm_id`) REFERENCES `pm` (`pm_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for netwerkschema
-- ----------------------------
DROP TABLE IF EXISTS `netwerkschema`;
CREATE TABLE `netwerkschema` (
  `netwerk_schema_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL,
  `regelmaat_id` char(1) NOT NULL,
  `datum` datetime DEFAULT NULL,
  `dag` char(2) DEFAULT NULL,
  `dag_van_de_maand` char(2) DEFAULT NULL,
  `zoveelste_weekdag_van_de_maand` char(1) DEFAULT NULL,
  `tijd` time DEFAULT NULL,
  `aantal_pogingen` int(11) DEFAULT '0',
  `tijd_wachten_na_poging` time DEFAULT NULL,
  `aantal_geprobeerd` int(11) DEFAULT '0',
  `datum_laatste_keer_uitgevoerd` datetime DEFAULT NULL,
  `poging_succesvol` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`netwerk_schema_id`),
  KEY `fk_netwerkschema_klant` (`klant_id`) USING BTREE,
  KEY `fk_netwerkschema_klanttraject` (`traject_id`) USING BTREE,
  KEY `fk_netwerkschema_regelmaat` (`regelmaat_id`) USING BTREE,
  CONSTRAINT `netwerkschema_ibfk_1` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `netwerkschema_ibfk_2` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `netwerkschema_ibfk_3` FOREIGN KEY (`regelmaat_id`) REFERENCES `regelmaat` (`regelmaat_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for plugin
-- ----------------------------
DROP TABLE IF EXISTS `plugin`;
CREATE TABLE `plugin` (
  `pluginId` int(11) NOT NULL AUTO_INCREMENT,
  `pluginNaam` varchar(75) NOT NULL,
  `pluginGUID` varchar(40) NOT NULL,
  `pluginVersie` varchar(15) NOT NULL,
  `insertDatum` datetime DEFAULT NULL,
  `updateDatum` datetime DEFAULT NULL,
  `updateTimes` int(11) NOT NULL DEFAULT '0',
  `pluginNotFound` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`pluginId`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for pluginmodules
-- ----------------------------
DROP TABLE IF EXISTS `pluginmodules`;
CREATE TABLE `pluginmodules` (
  `moduleId` int(11) NOT NULL AUTO_INCREMENT,
  `pluginId` int(11) NOT NULL,
  `moduleNaam` varchar(75) NOT NULL,
  `lastrunDate` datetime DEFAULT NULL,
  `nextrunDate` datetime DEFAULT NULL,
  `crashed` tinyint(1) NOT NULL DEFAULT '0',
  `crashedDate` datetime DEFAULT NULL,
  `crashedTimes` int(11) NOT NULL DEFAULT '0',
  `moduleNotFound` tinyint(1) NOT NULL DEFAULT '0',
  `RunInTest` tinyint(1) DEFAULT '0',
  `StoppedManual` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`moduleId`),
  UNIQUE KEY `moduleId_pluginId` (`moduleId`,`pluginId`) USING BTREE,
  KEY `plugin_pluginModules` (`pluginId`) USING BTREE,
  CONSTRAINT `pluginmodules_ibfk_1` FOREIGN KEY (`pluginId`) REFERENCES `plugin` (`pluginId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for pm
-- ----------------------------
DROP TABLE IF EXISTS `pm`;
CREATE TABLE `pm` (
  `pm_id` int(11) NOT NULL AUTO_INCREMENT,
  `pm_naam` varchar(100) NOT NULL,
  `pm_emailadres` varchar(255) NOT NULL,
  `recsta` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  PRIMARY KEY (`pm_id`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for printjob_tickets
-- ----------------------------
DROP TABLE IF EXISTS `printjob_tickets`;
CREATE TABLE `printjob_tickets` (
  `printjob_ticket_id` int(11) NOT NULL AUTO_INCREMENT,
  `recdt` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `description` varchar(100) DEFAULT NULL,
  `mutate_user` int(11) DEFAULT NULL,
  `mutate_dt` datetime DEFAULT NULL,
  `printjob_id` int(11) NOT NULL,
  `reference_id` int(11) DEFAULT NULL,
  `barcode` int(11) NOT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `postedby` int(11) DEFAULT NULL,
  `posteddt` datetime DEFAULT NULL,
  PRIMARY KEY (`printjob_ticket_id`),
  UNIQUE KEY `idx_barcode` (`barcode`),
  KEY `fk_printjob_tickets` (`printjob_id`),
  CONSTRAINT `fk_printjob_tickets` FOREIGN KEY (`printjob_id`) REFERENCES `inspire_printjob` (`printjob_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for rapportages
-- ----------------------------
DROP TABLE IF EXISTS `rapportages`;
CREATE TABLE `rapportages` (
  `rapportage_id` int(11) NOT NULL AUTO_INCREMENT,
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL,
  `datum` date NOT NULL,
  `omschrijving` varchar(100) NOT NULL,
  `aantal` int(11) DEFAULT NULL,
  `extra` varchar(100) DEFAULT NULL,
  `grouped` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`rapportage_id`),
  KEY `klant_id` (`klant_id`),
  KEY `traject_id` (`traject_id`),
  CONSTRAINT `rapportages_ibfk_1` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON UPDATE CASCADE,
  CONSTRAINT `rapportages_ibfk_2` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=528 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for regelmaat
-- ----------------------------
DROP TABLE IF EXISTS `regelmaat`;
CREATE TABLE `regelmaat` (
  `regelmaat_id` char(1) NOT NULL,
  `regelmaat_omschrijving` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`regelmaat_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for soort
-- ----------------------------
DROP TABLE IF EXISTS `soort`;
CREATE TABLE `soort` (
  `soort_id` varchar(20) NOT NULL,
  PRIMARY KEY (`soort_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for soort_copy
-- ----------------------------
DROP TABLE IF EXISTS `soort_copy`;
CREATE TABLE `soort_copy` (
  `soort_id` varchar(20) NOT NULL,
  PRIMARY KEY (`soort_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for verstuuroutlookemail
-- ----------------------------
DROP TABLE IF EXISTS `verstuuroutlookemail`;
CREATE TABLE `verstuuroutlookemail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `datum_ontvangen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `datum_verwerkt` datetime DEFAULT NULL,
  `recstate` enum('READY','WAIT_FOR_FILE','COMPLETED','ERROR') NOT NULL DEFAULT 'READY',
  `klant_id` int(11) NOT NULL,
  `traject_id` int(11) NOT NULL,
  `usepmlist` tinyint(1) DEFAULT '1',
  `emailadres` text,
  `onderwerp` varchar(255) DEFAULT NULL,
  `body` text,
  `attachments` text,
  PRIMARY KEY (`id`),
  KEY `traject_id` (`traject_id`),
  KEY `recstate` (`recstate`),
  KEY `klant_id` (`klant_id`,`traject_id`),
  CONSTRAINT `verstuuroutlookemail_ibfk_1` FOREIGN KEY (`klant_id`) REFERENCES `klant` (`klant_id`) ON UPDATE CASCADE,
  CONSTRAINT `verstuuroutlookemail_ibfk_2` FOREIGN KEY (`traject_id`) REFERENCES `klanttraject` (`traject_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for waakdienst
-- ----------------------------
DROP TABLE IF EXISTS `waakdienst`;
CREATE TABLE `waakdienst` (
  `datum_vanaf` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `naam` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`datum_vanaf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- View structure for qselBestanden
-- ----------------------------
DROP VIEW IF EXISTS `qselBestanden`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselBestanden` AS select `bestanden`.`bestand_id` AS `bestand_id`,`bestanden`.`klant_id` AS `klant_id`,`klant`.`klantnaam` AS `klantnaam`,`klant`.`pm_id` AS `klant_pm_id`,`pm_klant`.`pm_naam` AS `klant_pm_naam`,`bestanden`.`traject_id` AS `traject_id`,`klanttraject`.`trajectomschrijving` AS `trajectomschrijving`,`bestanden`.`ontvangst_id` AS `ontvangst_id`,`bestanden`.`ontvangst_soort` AS `ontvangst_soort`,if(`bestanden`.`archiefbestand_jn`,'Ja','') AS `archiefbestand_jn`,`bestanden`.`bestand_id_archief` AS `bestand_id_archief`,`bestanden`.`bestandsnaam` AS `bestandsnaam`,`bestanden`.`xdms_bestandsnaam` AS `xdms_bestandsnaam`,`bestanden`.`pad` AS `pad`,`bestanden`.`datum_ontvangen` AS `datum_ontvangen`,`bestanden`.`datum_toegewezen` AS `datum_toegewezen`,`bestanden`.`datum_verwerkt` AS `datum_verwerkt`,if(`bestanden`.`op_netwerk_geplaatst`,'Ja','Nee') AS `op_netwerk_geplaatst`,`bestanden`.`datum_netwerk` AS `datum_netwerk`,`klanttraject`.`pm_id` AS `klanttraject_pm_id`,`pm_klanttraject`.`pm_naam` AS `klanttraject_pm_naam`,if(`bestanden`.`pm_bevestigings_email_verstuurd_jn`,'Ja','Nee') AS `pm_bevestigings_email_verstuurd_jn`,if(`bestanden`.`klant_bevestigings_email_verstuurd_jn`,'Ja','Nee') AS `klant_bevestigings_email_verstuurd_jn`,if(`bestanden`.`klant_fout_email_verstuurd_jn`,'Ja','Nee') AS `klant_fout_email_verstuurd_jn`,if(`bestanden`.`fout_jn`,'Ja','') AS `fout_jn`,`bestanden`.`fouttekst` AS `fouttekst` from ((((`bestanden` join `klant` on((`bestanden`.`klant_id` = `klant`.`klant_id`))) join `klanttraject` on((`bestanden`.`traject_id` = `klanttraject`.`traject_id`))) left join `pm` `pm_klanttraject` on((`klanttraject`.`pm_id` = `pm_klanttraject`.`pm_id`))) left join `pm` `pm_klant` on((`klant`.`pm_id` = `pm_klant`.`pm_id`))) ;

-- ----------------------------
-- View structure for qselErrorlog
-- ----------------------------
DROP VIEW IF EXISTS `qselErrorlog`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselErrorlog` AS select `errorlog`.`errorlog_id` AS `errorlog_id`,`errorlog`.`datum_ontvangen` AS `datum_ontvangen`,`errorlog`.`datum_verwerkt` AS `datum_verwerkt`,`errorlog`.`klant_id` AS `klant_id`,`errorlog`.`traject_id` AS `traject_id`,`errorlog`.`ontvangst_id` AS `ontvangst_id`,`errorlog`.`ontvangst_soort` AS `ontvangst_soort`,`errorlog`.`foutcode` AS `foutcode`,`errorlog`.`foutmelding` AS `foutmelding`,`errorlog`.`aantal_keer_opgetreden` AS `aantal_keer_opgetreden`,substring_index(substring_index(substring_index(`errorlog`.`foutmelding`,' ',3),'.',-(2)),'.',1) AS `plugin`,substring_index(substring_index(substring_index(`errorlog`.`foutmelding`,' ',3),'.',-(2)),'.',-(1)) AS `proces` from `errorlog` ;

-- ----------------------------
-- View structure for qselErrorlogSeverities
-- ----------------------------
DROP VIEW IF EXISTS `qselErrorlogSeverities`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselErrorlogSeverities` AS select `errorlog`.`errorlog_id` AS `errorlog_id`,`errortext`.`errortext_id` AS `errortext_id`,`errortext`.`errortext` AS `errortext`,`errortext`.`erroraction` AS `erroraction`,`errorseverity`.`description` AS `description`,`errorseverity`.`severity` AS `severity` from ((`errorlog` join `errortext` on(((`errorlog`.`foutmelding` like concat('%',`errortext`.`errortext`,'%')) and (`errortext`.`state` = 'ACTIVE')))) join `errorseverity` on((`errorseverity`.`errorseverity_id` = `errortext`.`errorseverity_id`))) order by `errorlog`.`errorlog_id`,`errorseverity`.`severity` desc ;

-- ----------------------------
-- View structure for qselErrorlogSeverity
-- ----------------------------
DROP VIEW IF EXISTS `qselErrorlogSeverity`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselErrorlogSeverity` AS select `qselErrorlog`.`errorlog_id` AS `errorlog_id`,`qselErrorlog`.`datum_ontvangen` AS `datum_ontvangen`,`qselErrorlog`.`datum_verwerkt` AS `datum_verwerkt`,`qselErrorlog`.`klant_id` AS `klant_id`,`qselErrorlog`.`traject_id` AS `traject_id`,`qselErrorlog`.`ontvangst_id` AS `ontvangst_id`,`qselErrorlog`.`ontvangst_soort` AS `ontvangst_soort`,`qselErrorlog`.`foutcode` AS `foutcode`,`qselErrorlog`.`foutmelding` AS `foutmelding`,`qselErrorlog`.`aantal_keer_opgetreden` AS `aantal_keer_opgetreden`,`qselErrorlog`.`plugin` AS `plugin`,`qselErrorlog`.`proces` AS `proces`,`qselErrorlogSeverities`.`errortext_id` AS `errortext_id`,`qselErrorlogSeverities`.`errortext` AS `errortext`,`qselErrorlogSeverities`.`erroraction` AS `erroraction`,`qselErrorlogSeverities`.`description` AS `description`,`qselErrorlogSeverities`.`severity` AS `severity` from (`qselErrorlog` left join `qselErrorlogSeverities` on((`qselErrorlog`.`errorlog_id` = `qselErrorlogSeverities`.`errorlog_id`))) group by `qselErrorlog`.`errorlog_id` ;

-- ----------------------------
-- View structure for qselftpwithoutschema
-- ----------------------------
DROP VIEW IF EXISTS `qselftpwithoutschema`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselftpwithoutschema` AS select `k`.`klant_id` AS `klant_id`,`k`.`traject_id` AS `traject_id`,`fc`.`ftp_host` AS `ftp_host`,`fc`.`ftp_port` AS `ftp_port`,`fc`.`ftp_user` AS `ftp_user`,`fc`.`ftp_pass` AS `ftp_pass`,`fc`.`ftp_use_passive` AS `ftp_use_passive`,`fc`.`ftp_mode` AS `ftp_mode`,`fc`.`ftp_security` AS `ftp_security`,`fc`.`ftp_transfer_mode` AS `ftp_transfer_mode`,`fc`.`ftp_key_data` AS `ftp_key_data`,`k`.`ftp_masker` AS `ftp_masker`,`k`.`ftp_pad` AS `ftp_pad`,`k`.`ftp_actie_na_overhalen` AS `ftp_actie_na_overhalen`,`k`.`ftp_move_pad` AS `ftp_move_pad`,`k`.`ftp_scan_recursive` AS `ftp_scan_recursive`,`fc`.`ftp_use_key` AS `ftp_use_key`,`fc`.`ftp_key_pass` AS `ftp_key_pass` from ((`klanttraject` `k` join `ftpconnection` `fc` on((`k`.`ftp_connection_id` = `fc`.`ftp_connection_id`))) left join `ftpschema` `fs` on(((`k`.`klant_id` = `fs`.`klant_id`) and (`k`.`traject_id` = `fs`.`traject_id`)))) where ((`k`.`soort` = 'ftp') and isnull(`fs`.`ftp_schema_id`) and (`k`.`recsta` = 'ACTIVE')) ;

-- ----------------------------
-- View structure for qselftpwithschema
-- ----------------------------
DROP VIEW IF EXISTS `qselftpwithschema`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselftpwithschema` AS select `fs`.`ftp_schema_id` AS `ftp_schema_id`,`fs`.`klant_id` AS `klant_id`,`fs`.`traject_id` AS `traject_id`,`fs`.`regelmaat_id` AS `regelmaat_id`,`fs`.`datum` AS `datum`,`fs`.`dag` AS `dag`,`fs`.`dag_van_de_maand` AS `dag_van_de_maand`,`fs`.`zoveelste_weekdag_van_de_maand` AS `zoveelste_weekdag_van_de_maand`,`fs`.`tijd` AS `tijd`,`fs`.`aantal_pogingen` AS `aantal_pogingen`,`fs`.`tijd_wachten_na_poging` AS `tijd_wachten_na_poging`,`fs`.`aantal_geprobeerd` AS `aantal_geprobeerd`,`fs`.`datum_laatste_keer_uitgevoerd` AS `datum_laatste_keer_uitgevoerd`,`fs`.`poging_succesvol` AS `poging_succesvol`,`fc`.`ftp_host` AS `ftp_host`,`fc`.`ftp_port` AS `ftp_port`,`fc`.`ftp_user` AS `ftp_user`,`fc`.`ftp_pass` AS `ftp_pass`,`fc`.`ftp_use_passive` AS `ftp_use_passive`,`fc`.`ftp_mode` AS `ftp_mode`,`fc`.`ftp_security` AS `ftp_security`,`fc`.`ftp_transfer_mode` AS `ftp_transfer_mode`,`fc`.`ftp_key_data` AS `ftp_key_data`,`kt`.`ftp_masker` AS `ftp_masker`,`kt`.`ftp_pad` AS `ftp_pad`,`kt`.`ftp_actie_na_overhalen` AS `ftp_actie_na_overhalen`,`kt`.`ftp_move_pad` AS `ftp_move_pad`,`kt`.`ftp_scan_recursive` AS `ftp_scan_recursive`,`fc`.`ftp_use_key` AS `ftp_use_key`,`fc`.`ftp_key_pass` AS `ftp_key_pass` from ((`klanttraject` `kt` join `ftpconnection` `fc` on((`kt`.`ftp_connection_id` = `fc`.`ftp_connection_id`))) join `ftpschema` `fs` on(((`kt`.`klant_id` = `fs`.`klant_id`) and (`kt`.`traject_id` = `fs`.`traject_id`)))) where ((`kt`.`soort` = 'ftp') and (`kt`.`recsta` = 'ACTIVE')) ;

-- ----------------------------
-- View structure for qselInspire_printjobs
-- ----------------------------
DROP VIEW IF EXISTS `qselInspire_printjobs`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselInspire_printjobs` AS select `inspire_printjob`.`printjob_id` AS `printjob_id`,`inspire_printjob`.`klant_id` AS `klant_id`,`inspire_printjob`.`traject_id` AS `traject_id`,`inspire_printjob`.`datum_aangeboden` AS `datum_aangeboden`,`inspire_printjob`.`datum_verwerkt` AS `datum_verwerkt`,`inspire_printjob`.`odd_workflow` AS `odd_workflow`,`inspire_printjob`.`odd_job` AS `odd_job`,`inspire_printjob`.`odd_bestand` AS `odd_bestand`,`inspire_printjob`.`aantal_records_aangeleverd` AS `aantal_records_aangeleverd`,`inspire_printjob`.`aantal_records` AS `aantal_records`,`inspire_printjob`.`aantal_paginas` AS `aantal_paginas`,`inspire_printjob`.`print_tijd` AS `print_tijd`,`inspire_printjob`.`status_id` AS `status_id`,`inspire_printjob`.`error_count` AS `error_count`,`inspire_printjob`.`error_message` AS `error_message` from `inspire_printjob` ;

-- ----------------------------
-- View structure for qselnetwerkwithoutschema
-- ----------------------------
DROP VIEW IF EXISTS `qselnetwerkwithoutschema`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselnetwerkwithoutschema` AS select `kt`.`klant_id` AS `klant_id`,`kt`.`traject_id` AS `traject_id`,`kt`.`netwerk_masker` AS `netwerk_masker`,`kt`.`netwerk_pad` AS `netwerk_pad`,`kt`.`netwerk_subdirectories` AS `netwerk_subdirectories` from (`klanttraject` `kt` left join `netwerkschema` `ns` on(((`ns`.`klant_id` = `kt`.`klant_id`) and (`ns`.`traject_id` = `kt`.`traject_id`)))) where ((`kt`.`soort` = 'netwerk') and isnull(`ns`.`netwerk_schema_id`) and (`kt`.`recsta` = 'ACTIVE')) ;

-- ----------------------------
-- View structure for qselnetwerkwithschema
-- ----------------------------
DROP VIEW IF EXISTS `qselnetwerkwithschema`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselnetwerkwithschema` AS select `ns`.`netwerk_schema_id` AS `netwerk_schema_id`,`ns`.`klant_id` AS `klant_id`,`ns`.`traject_id` AS `traject_id`,`ns`.`regelmaat_id` AS `regelmaat_id`,`ns`.`datum` AS `datum`,`ns`.`dag` AS `dag`,`ns`.`dag_van_de_maand` AS `dag_van_de_maand`,`ns`.`zoveelste_weekdag_van_de_maand` AS `zoveelste_weekdag_van_de_maand`,`ns`.`tijd` AS `tijd`,`ns`.`aantal_pogingen` AS `aantal_pogingen`,`ns`.`tijd_wachten_na_poging` AS `tijd_wachten_na_poging`,`ns`.`aantal_geprobeerd` AS `aantal_geprobeerd`,`ns`.`datum_laatste_keer_uitgevoerd` AS `datum_laatste_keer_uitgevoerd`,`ns`.`poging_succesvol` AS `poging_succesvol`,`kt`.`netwerk_masker` AS `netwerk_masker`,`kt`.`netwerk_pad` AS `netwerk_pad`,`kt`.`netwerk_subdirectories` AS `netwerk_subdirectories` from (`klanttraject` `kt` join `netwerkschema` `ns` on(((`ns`.`klant_id` = `kt`.`klant_id`) and (`ns`.`traject_id` = `kt`.`traject_id`)))) where ((`kt`.`soort` = 'netwerk') and (`kt`.`recsta` = 'ACTIVE')) ;

-- ----------------------------
-- View structure for qselprintjobtickets
-- ----------------------------
DROP VIEW IF EXISTS `qselprintjobtickets`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselprintjobtickets` AS select `klant`.`klant_id` AS `klant_id`,`klanttraject`.`traject_id` AS `traject_id`,`inspire_printjob`.`printjob_id` AS `printjob_id`,`printjob_tickets`.`printjob_ticket_id` AS `printjob_ticket_id`,`klant`.`klantnaam` AS `klantnaam`,`klanttraject`.`trajectomschrijving` AS `trajectomschrijving`,`klanttraject`.`databasename` AS `databasename`,`klanttraject`.`viewname` AS `viewname`,date_format(`inspire_printjob`.`datum_aangeboden`,'%d-%m-%Y %H:%i') AS `datum_aangeboden`,date_format(`inspire_printjob`.`datum_verwerkt`,'%d-%m-%Y %H:%i') AS `datum_verwerkt`,`inspire_printjob`.`odd_bestand` AS `odd_bestand`,`inspire_printjob`.`aantal_records_aangeleverd` AS `aantal_records_aangeleverd`,`inspire_printjob`.`aantal_records` AS `aantal_records`,`inspire_printjob`.`aantal_paginas` AS `aantal_paginas`,`inspire_printjob`.`print_tijd` AS `print_tijd`,`inspire_printjob`.`error_message` AS `error_message`,`printjob_tickets`.`mutate_user` AS `mutate_user`,date_format(`printjob_tickets`.`mutate_dt`,'%d-%m-%Y %H:%i') AS `mutate_dt`,`printjob_tickets`.`reference_id` AS `reference_id`,`printjob_tickets`.`barcode` AS `barcode`,`printjob_tickets`.`remark` AS `remark`,date_format(`printjob_tickets`.`posteddt`,'%d-%m-%Y %H:%i') AS `posteddt`,`printjob_tickets`.`postedby` AS `postedby`,if(isnull(`printjob_tickets`.`mutate_user`),NULL,concat_ws('',`user1`.`username`,' / ',`user1`.`voorletters`,'. ',`user1`.`tussenvoegsel`,' ',`user1`.`achternaam`)) AS `mutated_displayname`,if(isnull(`printjob_tickets`.`postedby`),NULL,concat_ws('',`user2`.`username`,' / ',`user2`.`voorletters`,'. ',`user2`.`tussenvoegsel`,' ',`user2`.`achternaam`)) AS `posted_displayname` from (((((`klant` join `klanttraject` on((`klanttraject`.`klant_id` = `klant`.`klant_id`))) join `inspire_printjob` on(((`inspire_printjob`.`klant_id` = `klant`.`klant_id`) and (`inspire_printjob`.`traject_id` = `klanttraject`.`traject_id`)))) join `printjob_tickets` on((`printjob_tickets`.`printjob_id` = `inspire_printjob`.`printjob_id`))) left join `db036441_portal_4dms`.`user` `user1` on((`printjob_tickets`.`mutate_user` = `user1`.`id`))) left join `db036441_portal_4dms`.`user` `user2` on((`printjob_tickets`.`postedby` = `user2`.`id`))) ;

-- ----------------------------
-- View structure for qselWaakdienstRapportage01
-- ----------------------------
DROP VIEW IF EXISTS `qselWaakdienstRapportage01`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselWaakdienstRapportage01` AS select date_format(`agenda`.`from_datetime`,'%Y-%m') AS `maand`,`emailaddresses`.`emailname` AS `naam`,`agenda`.`from_datetime` AS `from_datetime`,`agenda`.`to_datetime` AS `to_datetime`,(time_to_sec(timediff(`agenda`.`to_datetime`,`agenda`.`from_datetime`)) / 3600) AS `uren`,dayofweek(`agenda`.`from_datetime`) AS `weekdag`,dayname(`agenda`.`from_datetime`) AS `dag`,`feestdagen`.`datum` AS `feestdag_datum`,`feestdagen`.`omschrijving` AS `feestdag_omschrijving`,if(((`feestdagen`.`datum` is not null) or (dayofweek(`agenda`.`from_datetime`) = 1) or (dayofweek(`agenda`.`from_datetime`) = 7)),2,1.25) AS `tarief` from ((`agenda` join `emailaddresses` on((`agenda`.`emailaddress_id` = `emailaddresses`.`emailaddress_id`))) left join `feestdagen` on((cast(`agenda`.`from_datetime` as date) = `feestdagen`.`datum`))) where (`agenda`.`to_datetime` is not null) order by 1,2,3 ;

-- ----------------------------
-- View structure for qselWaakdienstRapportage02
-- ----------------------------
DROP VIEW IF EXISTS `qselWaakdienstRapportage02`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselWaakdienstRapportage02` AS select `qselWaakdienstRapportage01`.`maand` AS `maand`,`qselWaakdienstRapportage01`.`naam` AS `naam`,`qselWaakdienstRapportage01`.`from_datetime` AS `from_datetime`,`qselWaakdienstRapportage01`.`to_datetime` AS `to_datetime`,`qselWaakdienstRapportage01`.`uren` AS `uren`,`qselWaakdienstRapportage01`.`weekdag` AS `weekdag`,`qselWaakdienstRapportage01`.`dag` AS `dag`,`qselWaakdienstRapportage01`.`feestdag_datum` AS `feestdag_datum`,`qselWaakdienstRapportage01`.`feestdag_omschrijving` AS `feestdag_omschrijving`,`qselWaakdienstRapportage01`.`tarief` AS `tarief`,round((`qselWaakdienstRapportage01`.`uren` * `qselWaakdienstRapportage01`.`tarief`),2) AS `bedrag` from `qselWaakdienstRapportage01` ;

-- ----------------------------
-- View structure for qselWaakdienstRapportage03
-- ----------------------------
DROP VIEW IF EXISTS `qselWaakdienstRapportage03`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselWaakdienstRapportage03` AS select `qselWaakdienstRapportage02`.`maand` AS `maand`,`qselWaakdienstRapportage02`.`naam` AS `naam`,sum(`qselWaakdienstRapportage02`.`bedrag`) AS `totaalbedrag` from `qselWaakdienstRapportage02` group by 1,2 ;

-- ----------------------------
-- Procedure structure for qfuncnotfound
-- ----------------------------
DROP PROCEDURE IF EXISTS `qfuncnotfound`;
DELIMITER ;;
CREATE PROCEDURE `qfuncnotfound`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Routine body goes here...
	UPDATE `plugin` SET pluginNotFound=0;
	UPDATE `pluginmodules` SET moduleNotFound=0;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprod_TestPeter
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprod_TestPeter`;
DELIMITER ;;
CREATE PROCEDURE `qprod_TestPeter`()
BEGIN
	#Routine body goes here...
	DECLARE done INT DEFAULT 0;
	DECLARE var_fieldname VARCHAR(50) DEFAULT '';
	DECLARE var_errortext_id INT;
	DECLARE var_errortext TEXT;
	DECLARE var_errorseverity_id INT;

	DECLARE cur_errortext CURSOR FOR SELECT errortext_id, errortext, errorseverity_id FROM errortext WHERE state = 'ACTIVE';
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

	OPEN cur_errortext;
	REPEAT
		FETCH cur_errortext INTO var_errortext_id, var_errortext, var_errorseverity_id;
		IF NOT done THEN
			# respondents vullen
			SELECT var_errortext_id, var_errortext, var_errorseverity_id;
			#INSERT INTO respondents (
			#UPDATE dipsta SET resultaatid='READY_LATE' WHERE dipstaid=var_dipstaid;
			#INSERT INTO errorlog SET proces=var_proces, bestandsnaam=var_bestandsnaam, error='Termijn voor dit proces is verstreken', dipstaid=var_dipstaid, systememailid=var_opvolg_limiet_sysemail;
		END IF;
	UNTIL done END REPEAT;
	CLOSE cur_errortext;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodBestandenPerKlantEnTraject
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodBestandenPerKlantEnTraject`;
DELIMITER ;;
CREATE PROCEDURE `qprodBestandenPerKlantEnTraject`(IN `_klant_id` int,IN `_traject_id` int,IN `_archief` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	SELECT * FROM bestanden b WHERE 
		b.klant_id = _klant_id AND
		b.traject_id = _traject_id AND
		b.datum_verwerkt IS NULL AND
		b.op_netwerk_geplaatst = 1 AND
		(b.archiefbestand_jn = 0 OR b.archiefbestand_jn = _archief) AND
		b.fout_jn = 0;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodFileReceivedEmail
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodFileReceivedEmail`;
DELIMITER ;;
CREATE PROCEDURE `qprodFileReceivedEmail`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	# Insert new files into outlookemail
	INSERT INTO verstuuroutlookemail (datum_ontvangen, recstate, klant_id, traject_id, usepmlist, emailadres, onderwerp, body)
	SELECT
		NOW(),
		'READY',
		b.klant_id,
		b.traject_id,
		1,
		null,
		CONCAT_WS(' ','Bestand ontvangen voor', IF(k.klantnaam = kj.trajectomschrijving, k.klantnaam, CONCAT(k.klantnaam, ' ', kj.trajectomschrijving))), 
		CONCAT_WS(' ', 'Er is een bestand ontvangen met de naam:', b.bestandsnaam)
	FROM
		bestanden AS b
		INNER JOIN klanttraject AS kj ON b.traject_id = kj.traject_id
		INNER JOIN klant k ON kj.klant_id = k.klant_id
	WHERE
		kj.pm_bevestigingsemail = 1 AND
		b.datum_toegewezen IS NOT NULL AND
		b.pm_bevestigings_email_verstuurd_jn = 0 AND
		b.archiefbestand_jn = 0;

	# Update files
	UPDATE bestanden b INNER JOIN klanttraject AS kj ON b.traject_id = kj.traject_id
	SET b.pm_bevestigings_email_verstuurd_jn = 1
	WHERE
		kj.pm_bevestigingsemail = 1 AND
		b.datum_toegewezen IS NOT NULL AND
		b.pm_bevestigings_email_verstuurd_jn = 0 AND
		b.archiefbestand_jn = 0;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetKlantPMEmailList
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetKlantPMEmailList`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetKlantPMEmailList`(IN `_klant_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klant AS k
			INNER JOIN pm ON pm.pm_id = k.pm_id
	WHERE
		k.klant_id = _klant_id
 
UNION

	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klant AS k
			INNER JOIN klant__pm kp ON kp.klant_id = k.klant_id
			INNER JOIN pm ON kp.pm_id = pm.pm_id
	WHERE
		k.klant_id = _klant_id AND
		pm.recsta = 'ACTIVE';
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetTrajectPMEmailList
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTrajectPMEmailList`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTrajectPMEmailList`(IN `_traject_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klanttraject AS kt
			INNER JOIN pm ON kt.pm_id = pm.pm_id
	WHERE
		kt.traject_id = _traject_id

UNION

	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klanttraject AS kt
			INNER JOIN klanttraject__pm ktp ON ktp.traject_id = kt.traject_id
			INNER JOIN pm ON ktp.pm_id = pm.pm_id
	WHERE
		kt.traject_id = _traject_id AND
		pm.recsta = 'ACTIVE'

UNION

	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klant AS k
			INNER JOIN klanttraject kt ON k.klant_id = kt.klant_id
			INNER JOIN pm ON pm.pm_id = k.pm_id
	WHERE
		kt.traject_id = _traject_id
 
UNION

	SELECT
		pm.pm_naam,
		pm.pm_emailadres
	FROM
		klant AS k
			INNER JOIN klanttraject kt ON k.klant_id = kt.klant_id
			INNER JOIN klant__pm kp ON kp.klant_id = k.klant_id
			INNER JOIN pm ON kp.pm_id = pm.pm_id
	WHERE
		kt.traject_id = _traject_id AND
		pm.recsta = 'ACTIVE';
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGroupRapportages
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGroupRapportages`;
DELIMITER ;;
CREATE PROCEDURE `qprodGroupRapportages`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	# Eerst records markeren voor rapportagegroups
	UPDATE rapportages SET grouped=2 WHERE grouped=0;
	
	# Records groeperen en inserten in dezelfde tabel
	INSERT INTO rapportages (klant_id, traject_id, datum, omschrijving, aantal, extra, grouped)
		SELECT klant_id,traject_id,datum,omschrijving,SUM(aantal),extra,1 FROM rapportages WHERE grouped=2 GROUP BY klant_id,traject_id,datum,omschrijving,extra;

	# De "single" records verwijderen uit de tabel
	DELETE FROM rapportages WHERE grouped=2;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetPrintTicketPosted
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetPrintTicketPosted`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetPrintTicketPosted`(`_traject_id` int,`_reference_id` int) RETURNS datetime
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Routine body goes here...
	DECLARE _rt datetime; 

	SELECT pt.posteddt INTO _rt
	FROM
	printjob_tickets AS pt
	INNER JOIN inspire_printjob AS ip ON pt.printjob_id = ip.printjob_id
	WHERE
	ip.traject_id = _traject_id AND
	pt.reference_id = _reference_id;

	RETURN _rt;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for TruncateTime
-- ----------------------------
DROP FUNCTION IF EXISTS `TruncateTime`;
DELIMITER ;;
CREATE FUNCTION `TruncateTime`(`indt` datetime) RETURNS date
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# omzetten datetime naar date voor .net ef5

RETURN DATE_FORMAT(indt,'%Y-%m-%d');
                
END
;;
DELIMITER ;
SET FOREIGN_KEY_CHECKS=1;
