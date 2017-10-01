/*
Navicat MySQL Data Transfer

Source Server         : Byte Test & Acceptatie
Source Server Version : 50632
Source Host           : dbint036441:3306
Source Database       : db036441_nuon_dep

Target Server Type    : MYSQL
Target Server Version : 50632
File Encoding         : 65001

Date: 2017-05-11 19:54:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for activities
-- ----------------------------
DROP TABLE IF EXISTS `activities`;
CREATE TABLE `activities` (
  `activity_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `processor_id` int(10) unsigned DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `timelimit` int(11) DEFAULT NULL,
  `timedeadline` int(11) DEFAULT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`activity_id`),
  KEY `fk_activities_processors_processor_id1_idx` (`processor_id`),
  CONSTRAINT `fk_activities_processors_processor_id1` FOREIGN KEY (`processor_id`) REFERENCES `processors` (`processor_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=404 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for activities_activityresults
-- ----------------------------
DROP TABLE IF EXISTS `activities_activityresults`;
CREATE TABLE `activities_activityresults` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `activity_id` int(10) unsigned NOT NULL,
  `activityresult_id` int(10) unsigned NOT NULL,
  `followup_activity_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_activities_activityresults_activityresults_activityresul_idx` (`activityresult_id`),
  KEY `fk_activities_activityresults_activities_activity_id1_idx` (`activity_id`),
  KEY `fk_activities_activityresults_activities_activity_id11_idx` (`followup_activity_id`),
  CONSTRAINT `fk_activities_activityresults_activities_activity_id1` FOREIGN KEY (`activity_id`) REFERENCES `activities` (`activity_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_activities_activityresults_activities_activity_id11` FOREIGN KEY (`followup_activity_id`) REFERENCES `activities` (`activity_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_activities_activityresults_activityresults_activityresult_1` FOREIGN KEY (`activityresult_id`) REFERENCES `activityresults` (`activityresult_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for activitylogs
-- ----------------------------
DROP TABLE IF EXISTS `activitylogs`;
CREATE TABLE `activitylogs` (
  `activitylog_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `respondent_id` int(10) unsigned DEFAULT NULL,
  `scan_id` int(10) unsigned DEFAULT NULL,
  `activity_id` int(10) unsigned NOT NULL,
  `activityresult_id` int(10) unsigned DEFAULT NULL,
  `condition` enum('READY','READY_LATE','READY_ERROR','ERROR','PROCESSING','COMPLETED','NO_ACTION') NOT NULL DEFAULT 'READY',
  `conditiondt` datetime DEFAULT NULL,
  `startdt` datetime DEFAULT NULL,
  `processdt` datetime DEFAULT NULL,
  `enddt` datetime DEFAULT NULL,
  `former` int(10) unsigned DEFAULT NULL,
  `next` int(10) unsigned DEFAULT NULL,
  `cm_emailaddress` varchar(100) DEFAULT NULL,
  `cm_id` int(11) DEFAULT NULL COMMENT 'Clangmailer id',
  `cm_delivery` datetime DEFAULT NULL,
  `cm_bouncetype` enum('HARD','SOFT') DEFAULT NULL,
  `cm_bouncerule` varchar(50) DEFAULT NULL,
  `cm_bouncedate` datetime DEFAULT NULL,
  `cm_complaindate` datetime DEFAULT NULL,
  `cm_opendate` datetime DEFAULT NULL,
  `cm_clickdate` datetime DEFAULT NULL,
  PRIMARY KEY (`activitylog_id`),
  KEY `fk_activitylogs_activities_activity_id1_idx` (`activity_id`),
  KEY `fk_activitylogs_respondents_respondent_id1_idx` (`respondent_id`),
  KEY `fk_activitylogs_activityresults_activityresult_id1_idx` (`activityresult_id`),
  KEY `fk_activitylogs_scans_scan_id1_idx` (`scan_id`),
  CONSTRAINT `fk_activitylogs_activities_activity_id1` FOREIGN KEY (`activity_id`) REFERENCES `activities` (`activity_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_activitylogs_activityresults_activityresult_id1` FOREIGN KEY (`activityresult_id`) REFERENCES `activityresults` (`activityresult_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_activitylogs_respondents_respondent_id1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_activitylogs_scans_scan_id1` FOREIGN KEY (`scan_id`) REFERENCES `scans` (`scan_id`) ON DELETE SET NULL ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=823 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for activityresults
-- ----------------------------
DROP TABLE IF EXISTS `activityresults`;
CREATE TABLE `activityresults` (
  `activityresult_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`activityresult_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for attachments
-- ----------------------------
DROP TABLE IF EXISTS `attachments`;
CREATE TABLE `attachments` (
  `attachment_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `extension` varchar(50) DEFAULT NULL,
  `size` int(11) DEFAULT NULL,
  `pages` int(11) DEFAULT NULL,
  `location` varchar(255) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `condition` enum('PENDING','AVAILABLE','SELECTED','DELETED','CANCELLED','PARKED','INCOMPLETE') DEFAULT 'AVAILABLE',
  `conditiondt` datetime DEFAULT NULL,
  `qrcode` varchar(50) NOT NULL,
  PRIMARY KEY (`attachment_id`),
  UNIQUE KEY `qrcode_UNIQUE` (`qrcode`),
  KEY `fk_attachments_scans_qrcode1_idx` (`qrcode`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for batches
-- ----------------------------
DROP TABLE IF EXISTS `batches`;
CREATE TABLE `batches` (
  `batch_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `condition` enum('OPEN','CLOSED','CHECKED','EXPORTED','ERROR') DEFAULT 'OPEN',
  `conditiondt` datetime DEFAULT NULL,
  `type` enum('MAIL','FULL') DEFAULT NULL,
  `respondent_count` int(11) DEFAULT '0',
  PRIMARY KEY (`batch_id`)
) ENGINE=InnoDB AUTO_INCREMENT=153 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for batchrespondentchecks
-- ----------------------------
DROP TABLE IF EXISTS `batchrespondentchecks`;
CREATE TABLE `batchrespondentchecks` (
  `batchrespondentcheck_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `batch_id` int(10) unsigned NOT NULL,
  `respondent_id` int(10) unsigned NOT NULL,
  `checked` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`batchrespondentcheck_id`),
  UNIQUE KEY `respondent_id_UNIQUE` (`respondent_id`),
  KEY `fk_batchrespondentchecks_batches_batch_id1_idx` (`batch_id`),
  KEY `fk_batchrespondentchecks_respondents_respondent_id1_idx` (`respondent_id`),
  CONSTRAINT `fk_batchrespondentchecks_batches_batch_id1` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_batchrespondentchecks_respondents_respondent_id1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=167 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaignproducts
-- ----------------------------
DROP TABLE IF EXISTS `campaignproducts`;
CREATE TABLE `campaignproducts` (
  `campaignproduct_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `campaign_id` int(10) unsigned NOT NULL,
  `stroom_upb_id` int(10) unsigned DEFAULT NULL,
  `gas_upb_id` int(10) unsigned DEFAULT NULL,
  `nbl` varchar(10) DEFAULT NULL,
  `entry_month` date DEFAULT NULL,
  PRIMARY KEY (`campaignproduct_id`),
  KEY `fk_campaignproducts_campaigns_campaign_id1_idx` (`campaign_id`),
  KEY `fk_campaignproducts_upbs_upb_id1_idx` (`stroom_upb_id`),
  KEY `fk_campaignproducts_upbs_upb_id11_idx` (`gas_upb_id`),
  CONSTRAINT `fk_campaignproducts_campaigns_campaign_id1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_campaignproducts_upbs_upb_id1` FOREIGN KEY (`stroom_upb_id`) REFERENCES `upbs` (`upb_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_campaignproducts_upbs_upb_id11` FOREIGN KEY (`gas_upb_id`) REFERENCES `upbs` (`upb_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=859 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaigns
-- ----------------------------
DROP TABLE IF EXISTS `campaigns`;
CREATE TABLE `campaigns` (
  `campaign_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `startdt` datetime DEFAULT NULL,
  `enddt` datetime DEFAULT NULL,
  `type` enum('MAIL','FULL') DEFAULT 'MAIL' COMMENT 'MAIL=Mailbestand\nFULL=Volledig vastleggen',
  `type2` enum('VERHUIZEN','SWITCH','ADDONONLY') DEFAULT 'SWITCH',
  PRIMARY KEY (`campaign_id`),
  UNIQUE KEY `name_UNIQUE` (`name`,`type`)
) ENGINE=InnoDB AUTO_INCREMENT=1119 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaignvalues
-- ----------------------------
DROP TABLE IF EXISTS `campaignvalues`;
CREATE TABLE `campaignvalues` (
  `campaignvalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `campaign_id` int(10) unsigned NOT NULL,
  `settingdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`campaignvalue_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_campaignvalues_campaigns_campaign_id1_idx` (`campaign_id`),
  CONSTRAINT `fk_campaignvalues_campaigns_campaign_id1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_campaignvalues_settingdefaults_settingdefault_id1` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for datachecks
-- ----------------------------
DROP TABLE IF EXISTS `datachecks`;
CREATE TABLE `datachecks` (
  `datacheck_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`datacheck_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

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
  PRIMARY KEY (`emailaddress_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for emailfields
-- ----------------------------
DROP TABLE IF EXISTS `emailfields`;
CREATE TABLE `emailfields` (
  `emailfield_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `sequence` int(11) NOT NULL,
  `sourcetable` varchar(50) NOT NULL,
  `sourcefield` varchar(50) NOT NULL,
  PRIMARY KEY (`emailfield_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

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
  KEY `fk_emailuses_emailaddresses_emailaddress_id_idx` (`emailaddress_id`),
  KEY `fk_emailuses_emaillists_emailist_id1_idx` (`emaillist_id`),
  CONSTRAINT `fk_emailuses_emailaddresses_emailaddress_id` FOREIGN KEY (`emailaddress_id`) REFERENCES `emailaddresses` (`emailaddress_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_emailuses_emaillists_emailist_id1` FOREIGN KEY (`emaillist_id`) REFERENCES `emaillists` (`emaillist_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for errorlogs
-- ----------------------------
DROP TABLE IF EXISTS `errorlogs`;
CREATE TABLE `errorlogs` (
  `errorlog_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `activitylog_id` int(10) unsigned DEFAULT NULL,
  `file_id` int(10) unsigned DEFAULT NULL,
  `emaillist_id` int(10) unsigned DEFAULT NULL,
  `condition` enum('OPEN','CLOSED','SEND','COMPLETED') DEFAULT 'OPEN' COMMENT 'OPEN = openstaande melding\nCLOSED = afgehandelde melding\nSEND = te versturen melding\nCOMPLETED = verstuurde melding',
  `conditiondt` datetime DEFAULT NULL,
  `message` text NOT NULL,
  PRIMARY KEY (`errorlog_id`),
  KEY `fk_errorlogs_activitylogs_activitylog_id1_idx` (`activitylog_id`),
  KEY `fk_errorlogs_files_file_id1_idx` (`file_id`),
  KEY `fk_errorlogs_emaillists_emaillist_id1_idx` (`emaillist_id`),
  CONSTRAINT `fk_errorlogs_activitylogs_activitylog_id1` FOREIGN KEY (`activitylog_id`) REFERENCES `activitylogs` (`activitylog_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_errorlogs_emaillists_emaillist_id1` FOREIGN KEY (`emaillist_id`) REFERENCES `emaillists` (`emaillist_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_errorlogs_files_file_id1` FOREIGN KEY (`file_id`) REFERENCES `files` (`file_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=152 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for failurereasons
-- ----------------------------
DROP TABLE IF EXISTS `failurereasons`;
CREATE TABLE `failurereasons` (
  `failurereason_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `sequence` int(11) NOT NULL,
  `code` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`failurereason_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for files
-- ----------------------------
DROP TABLE IF EXISTS `files`;
CREATE TABLE `files` (
  `file_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `filetype_id` int(10) unsigned NOT NULL,
  `condition` enum('READY','ERROR','COMPLETED','CANCELLED') DEFAULT 'READY' COMMENT 'READY = ingelezen in mail_import_tbl\nERROR = bestand heeft fouten\nCOMPLETED = bestand overgenomen in mailbestand\nCANCELLED = bestand negeren (bijv. na goed te zijn ingelezen)',
  `conditiondt` datetime DEFAULT NULL,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`file_id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_files_filetypes_filetype_id1_idx` (`filetype_id`),
  CONSTRAINT `fk_files_filetypes_filetype_id1` FOREIGN KEY (`filetype_id`) REFERENCES `filetypes` (`filetype_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=498 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for filetypes
-- ----------------------------
DROP TABLE IF EXISTS `filetypes`;
CREATE TABLE `filetypes` (
  `filetype_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`filetype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for mail_imports
-- ----------------------------
DROP TABLE IF EXISTS `mail_imports`;
CREATE TABLE `mail_imports` (
  `refnr` varchar(30) DEFAULT NULL,
  `programma` varchar(100) DEFAULT NULL,
  `actiecode1` varchar(50) DEFAULT NULL,
  `actiecode2` varchar(50) DEFAULT NULL,
  `actiecode3` varchar(50) DEFAULT NULL,
  `actiecode4` varchar(50) DEFAULT NULL,
  `actiecode5` varchar(50) DEFAULT NULL,
  `contentcode1` varchar(15) DEFAULT NULL,
  `contentcode2` varchar(15) DEFAULT NULL,
  `contentcode3` varchar(15) DEFAULT NULL,
  `contentcode4` varchar(15) DEFAULT NULL,
  `contentcode5` varchar(15) DEFAULT NULL,
  `zp` int(11) DEFAULT NULL,
  `voorletters` varchar(150) DEFAULT NULL,
  `tussenvoegsel` varchar(15) DEFAULT NULL,
  `achternaam` varchar(150) DEFAULT NULL,
  `geslacht` varchar(1) DEFAULT NULL,
  `titel` varchar(45) DEFAULT NULL,
  `geboortedatum` date DEFAULT NULL,
  `bedrijfsnaam` varchar(255) DEFAULT NULL,
  `kvk` varchar(50) DEFAULT NULL,
  `correspondentie_straat` varchar(150) DEFAULT NULL,
  `correspondentie_nummer` varchar(90) DEFAULT NULL,
  `correspondentie_toevoeg` varchar(150) DEFAULT NULL,
  `correspondentie_postcode` varchar(90) DEFAULT NULL,
  `correspondentie_plaats` varchar(50) DEFAULT NULL,
  `correspondentie_land` varchar(50) DEFAULT NULL,
  `aansluit_straat` varchar(150) DEFAULT NULL,
  `aansluit_nummer` varchar(90) DEFAULT NULL,
  `aansluit_toevoeg` varchar(150) DEFAULT NULL,
  `aansluit_postcode` varchar(90) DEFAULT NULL,
  `aansluit_plaats` varchar(50) DEFAULT NULL,
  `aansluit_land` varchar(50) DEFAULT NULL,
  `telefoon_vast` varchar(50) DEFAULT NULL,
  `telefoon_mobiel` varchar(50) DEFAULT NULL,
  `telefoon_werk` varchar(50) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `username` varchar(150) DEFAULT NULL,
  `woonbestemming` varchar(1) DEFAULT NULL,
  `type` varchar(3) DEFAULT NULL,
  `klantlabel` varchar(10) DEFAULT NULL,
  `actief` varchar(1) DEFAULT NULL,
  `contractrek` int(11) DEFAULT NULL,
  `contractrekeningnummer` int(11) DEFAULT NULL,
  `behoeftesegment` varchar(1) DEFAULT NULL,
  `waardesegment` varchar(50) DEFAULT NULL,
  `klantwaarde` varchar(10) DEFAULT NULL,
  `betalingswijze` varchar(1) DEFAULT NULL,
  `voorkeursdatum_ai` int(11) DEFAULT NULL,
  `rekeningnummer` varchar(34) DEFAULT NULL,
  `contractnummer_stroom` int(11) DEFAULT NULL,
  `product_stroom` varchar(150) DEFAULT NULL,
  `tarieftype_stroom` varchar(17) DEFAULT NULL,
  `verbruik_stroom_hoog` int(11) DEFAULT NULL,
  `ean_stroom` varchar(52) DEFAULT NULL,
  `verbruiktype_s` varchar(2) DEFAULT NULL,
  `netbeheerder_stroom` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_s` varchar(70) DEFAULT NULL,
  `begindatum_stroom` date DEFAULT NULL,
  `einddatum_stroom` date DEFAULT NULL,
  `verbruik_stroom_laag` int(11) DEFAULT NULL,
  `exitdatum_stroom` date DEFAULT NULL,
  `contractnummer_gas` int(11) DEFAULT NULL,
  `product_gas` varchar(255) DEFAULT NULL,
  `tarieftype_gas` varchar(15) DEFAULT NULL,
  `ean_gas` varchar(52) DEFAULT NULL,
  `verbruiktype_g` varchar(6) DEFAULT NULL,
  `netbeheerder_gas` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_g` varchar(70) DEFAULT NULL,
  `begindatum_gas` date DEFAULT NULL,
  `einddatum_gas` date DEFAULT NULL,
  `verbruik_gas` int(11) DEFAULT NULL,
  `gasregio` varchar(2) DEFAULT NULL,
  `exitdatum_gas` date DEFAULT NULL,
  `termijnbedrag` decimal(8,2) DEFAULT NULL,
  `klacht` varchar(1) DEFAULT NULL,
  `kc_kanaal` varchar(120) DEFAULT NULL,
  `kc_categorie` varchar(120) DEFAULT NULL,
  `kc_onderwerp` varchar(120) DEFAULT NULL,
  `kc_datum` date DEFAULT NULL,
  `koophuur` varchar(6) DEFAULT NULL,
  `type_woning` varchar(24) DEFAULT NULL,
  `bouwjaar_woning` varchar(16) DEFAULT NULL,
  `cv_ketel_bouwjaar` int(4) DEFAULT NULL,
  `profiel_1_def` varchar(100) DEFAULT NULL,
  `profiel_1_waarde` varchar(150) DEFAULT NULL,
  `profiel_2_def` varchar(100) DEFAULT NULL,
  `profiel_2_waarde` varchar(150) DEFAULT NULL,
  `profiel_3_def` varchar(100) DEFAULT NULL,
  `profiel_3_waarde` varchar(150) DEFAULT NULL,
  `profiel_4_def` varchar(100) DEFAULT NULL,
  `profiel_4_waarde` varchar(150) DEFAULT NULL,
  `profiel_5_def` varchar(100) DEFAULT NULL,
  `profiel_5_waarde` varchar(150) DEFAULT NULL,
  `profiel_6_def` varchar(100) DEFAULT NULL,
  `profiel_6_waarde` varchar(150) DEFAULT NULL,
  `profiel_7_def` varchar(100) DEFAULT NULL,
  `profiel_7_waarde` varchar(150) DEFAULT NULL,
  `profiel_8_def` varchar(100) DEFAULT NULL,
  `profiel_8_waarde` varchar(150) DEFAULT NULL,
  `profiel_9_def` varchar(100) DEFAULT NULL,
  `profiel_9_waarde` varchar(150) DEFAULT NULL,
  `profiel_10_def` varchar(100) DEFAULT NULL,
  `profiel_10_waarde` varchar(150) DEFAULT NULL,
  `profiel_11_def` varchar(100) DEFAULT NULL,
  `profiel_11_waarde` varchar(150) DEFAULT NULL,
  `profiel_12_def` varchar(100) DEFAULT NULL,
  `profiel_12_waarde` varchar(150) DEFAULT NULL,
  `profiel_13_def` varchar(100) DEFAULT NULL,
  `profiel_13_waarde` varchar(150) DEFAULT NULL,
  `profiel_14_def` varchar(100) DEFAULT NULL,
  `profiel_14_waarde` varchar(150) DEFAULT NULL,
  `profiel_15_def` varchar(100) DEFAULT NULL,
  `profiel_15_waarde` varchar(150) DEFAULT NULL,
  `profiel_16_def` varchar(100) DEFAULT NULL,
  `profiel_16_waarde` varchar(150) DEFAULT NULL,
  `profiel_17_def` varchar(100) DEFAULT NULL,
  `profiel_17_waarde` varchar(150) DEFAULT NULL,
  `profiel_18_def` varchar(100) DEFAULT NULL,
  `profiel_18_waarde` varchar(150) DEFAULT NULL,
  `profiel_19_def` varchar(100) DEFAULT NULL,
  `profiel_19_waarde` varchar(150) DEFAULT NULL,
  `profiel_20_def` varchar(100) DEFAULT NULL,
  `profiel_20_waarde` varchar(150) DEFAULT NULL,
  `profiel_vraag_1` varchar(255) DEFAULT NULL,
  `profiel_vraag_2` varchar(255) DEFAULT NULL,
  `profiel_vraag_3` varchar(255) DEFAULT NULL,
  `profiel_vraag_4` varchar(255) DEFAULT NULL,
  `profiel_vraag_5` varchar(255) DEFAULT NULL,
  `reserveveld_1` varchar(100) DEFAULT NULL,
  `reserveveld_2` varchar(100) DEFAULT NULL,
  `reserveveld_3` varchar(100) DEFAULT NULL,
  `reserveveld_4` varchar(100) DEFAULT NULL,
  `reserveveld_5` varchar(100) DEFAULT NULL,
  `reserveveld_6` varchar(100) DEFAULT NULL,
  `reserveveld_7` varchar(100) DEFAULT NULL,
  `reserveveld_8` varchar(100) DEFAULT NULL,
  `reserveveld_9` varchar(100) DEFAULT NULL,
  `reserveveld_10` varchar(100) DEFAULT NULL,
  `reserveveld_11` varchar(100) DEFAULT NULL,
  `reserveveld_12` varchar(100) DEFAULT NULL,
  `reserveveld_13` varchar(100) DEFAULT NULL,
  `reserveveld_14` varchar(100) DEFAULT NULL,
  `reserveveld_15` varchar(100) DEFAULT NULL,
  `reserveveld_16` varchar(100) DEFAULT NULL,
  `reserveveld_17` varchar(100) DEFAULT NULL,
  `reserveveld_18` varchar(100) DEFAULT NULL,
  `reserveveld_19` varchar(100) DEFAULT NULL,
  `reserveveld_20` varchar(100) DEFAULT NULL,
  `reserveveld_21` varchar(100) DEFAULT NULL,
  `reserveveld_22` varchar(100) DEFAULT NULL,
  `reserveveld_23` varchar(100) DEFAULT NULL,
  `reserveveld_24` varchar(100) DEFAULT NULL,
  `reserveveld_25` varchar(100) DEFAULT NULL,
  `reserveveld_26` varchar(100) DEFAULT NULL,
  `reserveveld_27` varchar(100) DEFAULT NULL,
  `reserveveld_28` varchar(100) DEFAULT NULL,
  `reserveveld_29` varchar(100) DEFAULT NULL,
  `reserveveld_30` varchar(100) DEFAULT NULL,
  `reserveveld_31` varchar(100) DEFAULT NULL,
  `reserveveld_32` varchar(100) DEFAULT NULL,
  `reserveveld_33` varchar(100) DEFAULT NULL,
  `reserveveld_34` varchar(100) DEFAULT NULL,
  `reserveveld_35` varchar(100) DEFAULT NULL,
  `reserveveld_36` varchar(100) DEFAULT NULL,
  `reserveveld_37` varchar(100) DEFAULT NULL,
  `ppc_stroom` varchar(10) DEFAULT NULL,
  `ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_gas` varchar(10) DEFAULT NULL,
  `teruglevering` varchar(1) DEFAULT NULL,
  `teruglevering_hoog` int(11) DEFAULT NULL,
  `teruglevering_laag` int(11) DEFAULT NULL,
  `ac1_chb_tot_ex` decimal(8,2) DEFAULT NULL,
  `ac1_chb_tot_in` decimal(8,2) DEFAULT NULL,
  `branche` varchar(150) DEFAULT NULL,
  `reserveveld_38` varchar(100) DEFAULT NULL,
  `reserveveld_39` varchar(100) DEFAULT NULL,
  `reserveveld_40` varchar(100) DEFAULT NULL,
  `reserveveld_41` varchar(100) DEFAULT NULL,
  `reserveveld_42` varchar(100) DEFAULT NULL,
  `reserveveld_43` varchar(100) DEFAULT NULL,
  `reserveveld_44` varchar(100) DEFAULT NULL,
  `reserveveld_45` varchar(100) DEFAULT NULL,
  `reserveveld_46` varchar(100) DEFAULT NULL,
  `reserveveld_47` varchar(100) DEFAULT NULL,
  `reserveveld_48` varchar(100) DEFAULT NULL,
  `reserveveld_49` varchar(100) DEFAULT NULL,
  `reserveveld_50` varchar(100) DEFAULT NULL,
  `reserveveld_51` varchar(100) DEFAULT NULL,
  `reserveveld_52` varchar(100) DEFAULT NULL,
  `reserveveld_53` varchar(100) DEFAULT NULL,
  `reserveveld_54` varchar(100) DEFAULT NULL,
  `bmnr_downloaddatum` date DEFAULT NULL,
  `bmnr_max_bellen_tot` date DEFAULT NULL,
  `partij` varchar(30) DEFAULT NULL,
  `test` varchar(100) DEFAULT NULL,
  `prioriteiten` int(11) DEFAULT NULL,
  `gewenste_actie` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `status_reden` varchar(255) DEFAULT NULL,
  KEY `refnr` (`refnr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for mail_imports_tpl
-- ----------------------------
DROP TABLE IF EXISTS `mail_imports_tpl`;
CREATE TABLE `mail_imports_tpl` (
  `refnr` varchar(30) DEFAULT NULL,
  `programma` varchar(100) DEFAULT NULL,
  `actiecode1` varchar(50) DEFAULT NULL,
  `actiecode2` varchar(50) DEFAULT NULL,
  `actiecode3` varchar(50) DEFAULT NULL,
  `actiecode4` varchar(50) DEFAULT NULL,
  `actiecode5` varchar(50) DEFAULT NULL,
  `contentcode1` varchar(15) DEFAULT NULL,
  `contentcode2` varchar(15) DEFAULT NULL,
  `contentcode3` varchar(15) DEFAULT NULL,
  `contentcode4` varchar(15) DEFAULT NULL,
  `contentcode5` varchar(15) DEFAULT NULL,
  `zp` int(11) DEFAULT NULL,
  `voorletters` varchar(150) DEFAULT NULL,
  `tussenvoegsel` varchar(15) DEFAULT NULL,
  `achternaam` varchar(150) DEFAULT NULL,
  `geslacht` varchar(1) DEFAULT NULL,
  `titel` varchar(45) DEFAULT NULL,
  `geboortedatum` date DEFAULT NULL,
  `bedrijfsnaam` varchar(255) DEFAULT NULL,
  `kvk` varchar(50) DEFAULT NULL,
  `correspondentie_straat` varchar(150) DEFAULT NULL,
  `correspondentie_nummer` varchar(90) DEFAULT NULL,
  `correspondentie_toevoeg` varchar(150) DEFAULT NULL,
  `correspondentie_postcode` varchar(90) DEFAULT NULL,
  `correspondentie_plaats` varchar(50) DEFAULT NULL,
  `correspondentie_land` varchar(50) DEFAULT NULL,
  `aansluit_straat` varchar(150) DEFAULT NULL,
  `aansluit_nummer` varchar(90) DEFAULT NULL,
  `aansluit_toevoeg` varchar(150) DEFAULT NULL,
  `aansluit_postcode` varchar(90) DEFAULT NULL,
  `aansluit_plaats` varchar(50) DEFAULT NULL,
  `aansluit_land` varchar(50) DEFAULT NULL,
  `telefoon_vast` varchar(50) DEFAULT NULL,
  `telefoon_mobiel` varchar(50) DEFAULT NULL,
  `telefoon_werk` varchar(50) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `username` varchar(150) DEFAULT NULL,
  `woonbestemming` varchar(1) DEFAULT NULL,
  `type` varchar(3) DEFAULT NULL,
  `klantlabel` varchar(10) DEFAULT NULL,
  `actief` varchar(1) DEFAULT NULL,
  `contractrek` int(11) DEFAULT NULL,
  `contractrekeningnummer` int(11) DEFAULT NULL,
  `behoeftesegment` varchar(1) DEFAULT NULL,
  `waardesegment` varchar(50) DEFAULT NULL,
  `klantwaarde` varchar(10) DEFAULT NULL,
  `betalingswijze` varchar(1) DEFAULT NULL,
  `voorkeursdatum_ai` int(11) DEFAULT NULL,
  `rekeningnummer` varchar(34) DEFAULT NULL,
  `contractnummer_stroom` int(11) DEFAULT NULL,
  `product_stroom` varchar(150) DEFAULT NULL,
  `tarieftype_stroom` varchar(17) DEFAULT NULL,
  `verbruik_stroom_hoog` int(11) DEFAULT NULL,
  `ean_stroom` varchar(52) DEFAULT NULL,
  `verbruiktype_s` varchar(2) DEFAULT NULL,
  `netbeheerder_stroom` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_s` varchar(70) DEFAULT NULL,
  `begindatum_stroom` date DEFAULT NULL,
  `einddatum_stroom` date DEFAULT NULL,
  `verbruik_stroom_laag` int(11) DEFAULT NULL,
  `exitdatum_stroom` date DEFAULT NULL,
  `contractnummer_gas` int(11) DEFAULT NULL,
  `product_gas` varchar(255) DEFAULT NULL,
  `tarieftype_gas` varchar(15) DEFAULT NULL,
  `ean_gas` varchar(52) DEFAULT NULL,
  `verbruiktype_g` varchar(6) DEFAULT NULL,
  `netbeheerder_gas` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_g` varchar(70) DEFAULT NULL,
  `begindatum_gas` date DEFAULT NULL,
  `einddatum_gas` date DEFAULT NULL,
  `verbruik_gas` int(11) DEFAULT NULL,
  `gasregio` varchar(2) DEFAULT NULL,
  `exitdatum_gas` date DEFAULT NULL,
  `termijnbedrag` decimal(8,2) DEFAULT NULL,
  `klacht` varchar(1) DEFAULT NULL,
  `kc_kanaal` varchar(120) DEFAULT NULL,
  `kc_categorie` varchar(120) DEFAULT NULL,
  `kc_onderwerp` varchar(120) DEFAULT NULL,
  `kc_datum` date DEFAULT NULL,
  `koophuur` varchar(6) DEFAULT NULL,
  `type_woning` varchar(24) DEFAULT NULL,
  `bouwjaar_woning` varchar(16) DEFAULT NULL,
  `cv_ketel_bouwjaar` int(4) DEFAULT NULL,
  `profiel_1_def` varchar(100) DEFAULT NULL,
  `profiel_1_waarde` varchar(150) DEFAULT NULL,
  `profiel_2_def` varchar(100) DEFAULT NULL,
  `profiel_2_waarde` varchar(150) DEFAULT NULL,
  `profiel_3_def` varchar(100) DEFAULT NULL,
  `profiel_3_waarde` varchar(150) DEFAULT NULL,
  `profiel_4_def` varchar(100) DEFAULT NULL,
  `profiel_4_waarde` varchar(150) DEFAULT NULL,
  `profiel_5_def` varchar(100) DEFAULT NULL,
  `profiel_5_waarde` varchar(150) DEFAULT NULL,
  `profiel_6_def` varchar(100) DEFAULT NULL,
  `profiel_6_waarde` varchar(150) DEFAULT NULL,
  `profiel_7_def` varchar(100) DEFAULT NULL,
  `profiel_7_waarde` varchar(150) DEFAULT NULL,
  `profiel_8_def` varchar(100) DEFAULT NULL,
  `profiel_8_waarde` varchar(150) DEFAULT NULL,
  `profiel_9_def` varchar(100) DEFAULT NULL,
  `profiel_9_waarde` varchar(150) DEFAULT NULL,
  `profiel_10_def` varchar(100) DEFAULT NULL,
  `profiel_10_waarde` varchar(150) DEFAULT NULL,
  `profiel_11_def` varchar(100) DEFAULT NULL,
  `profiel_11_waarde` varchar(150) DEFAULT NULL,
  `profiel_12_def` varchar(100) DEFAULT NULL,
  `profiel_12_waarde` varchar(150) DEFAULT NULL,
  `profiel_13_def` varchar(100) DEFAULT NULL,
  `profiel_13_waarde` varchar(150) DEFAULT NULL,
  `profiel_14_def` varchar(100) DEFAULT NULL,
  `profiel_14_waarde` varchar(150) DEFAULT NULL,
  `profiel_15_def` varchar(100) DEFAULT NULL,
  `profiel_15_waarde` varchar(150) DEFAULT NULL,
  `profiel_16_def` varchar(100) DEFAULT NULL,
  `profiel_16_waarde` varchar(150) DEFAULT NULL,
  `profiel_17_def` varchar(100) DEFAULT NULL,
  `profiel_17_waarde` varchar(150) DEFAULT NULL,
  `profiel_18_def` varchar(100) DEFAULT NULL,
  `profiel_18_waarde` varchar(150) DEFAULT NULL,
  `profiel_19_def` varchar(100) DEFAULT NULL,
  `profiel_19_waarde` varchar(150) DEFAULT NULL,
  `profiel_20_def` varchar(100) DEFAULT NULL,
  `profiel_20_waarde` varchar(150) DEFAULT NULL,
  `profiel_vraag_1` varchar(255) DEFAULT NULL,
  `profiel_vraag_2` varchar(255) DEFAULT NULL,
  `profiel_vraag_3` varchar(255) DEFAULT NULL,
  `profiel_vraag_4` varchar(255) DEFAULT NULL,
  `profiel_vraag_5` varchar(255) DEFAULT NULL,
  `reserveveld_1` varchar(100) DEFAULT NULL,
  `reserveveld_2` varchar(100) DEFAULT NULL,
  `reserveveld_3` varchar(100) DEFAULT NULL,
  `reserveveld_4` varchar(100) DEFAULT NULL,
  `reserveveld_5` varchar(100) DEFAULT NULL,
  `reserveveld_6` varchar(100) DEFAULT NULL,
  `reserveveld_7` varchar(100) DEFAULT NULL,
  `reserveveld_8` varchar(100) DEFAULT NULL,
  `reserveveld_9` varchar(100) DEFAULT NULL,
  `reserveveld_10` varchar(100) DEFAULT NULL,
  `reserveveld_11` varchar(100) DEFAULT NULL,
  `reserveveld_12` varchar(100) DEFAULT NULL,
  `reserveveld_13` varchar(100) DEFAULT NULL,
  `reserveveld_14` varchar(100) DEFAULT NULL,
  `reserveveld_15` varchar(100) DEFAULT NULL,
  `reserveveld_16` varchar(100) DEFAULT NULL,
  `reserveveld_17` varchar(100) DEFAULT NULL,
  `reserveveld_18` varchar(100) DEFAULT NULL,
  `reserveveld_19` varchar(100) DEFAULT NULL,
  `reserveveld_20` varchar(100) DEFAULT NULL,
  `reserveveld_21` varchar(100) DEFAULT NULL,
  `reserveveld_22` varchar(100) DEFAULT NULL,
  `reserveveld_23` varchar(100) DEFAULT NULL,
  `reserveveld_24` varchar(100) DEFAULT NULL,
  `reserveveld_25` varchar(100) DEFAULT NULL,
  `reserveveld_26` varchar(100) DEFAULT NULL,
  `reserveveld_27` varchar(100) DEFAULT NULL,
  `reserveveld_28` varchar(100) DEFAULT NULL,
  `reserveveld_29` varchar(100) DEFAULT NULL,
  `reserveveld_30` varchar(100) DEFAULT NULL,
  `reserveveld_31` varchar(100) DEFAULT NULL,
  `reserveveld_32` varchar(100) DEFAULT NULL,
  `reserveveld_33` varchar(100) DEFAULT NULL,
  `reserveveld_34` varchar(100) DEFAULT NULL,
  `reserveveld_35` varchar(100) DEFAULT NULL,
  `reserveveld_36` varchar(100) DEFAULT NULL,
  `reserveveld_37` varchar(100) DEFAULT NULL,
  `ppc_stroom` varchar(10) DEFAULT NULL,
  `ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_gas` varchar(10) DEFAULT NULL,
  `teruglevering` varchar(1) DEFAULT NULL,
  `teruglevering_hoog` int(11) DEFAULT NULL,
  `teruglevering_laag` int(11) DEFAULT NULL,
  `ac1_chb_tot_ex` decimal(8,2) DEFAULT NULL,
  `ac1_chb_tot_in` decimal(8,2) DEFAULT NULL,
  `branche` varchar(150) DEFAULT NULL,
  `reserveveld_38` varchar(100) DEFAULT NULL,
  `reserveveld_39` varchar(100) DEFAULT NULL,
  `reserveveld_40` varchar(100) DEFAULT NULL,
  `reserveveld_41` varchar(100) DEFAULT NULL,
  `reserveveld_42` varchar(100) DEFAULT NULL,
  `reserveveld_43` varchar(100) DEFAULT NULL,
  `reserveveld_44` varchar(100) DEFAULT NULL,
  `reserveveld_45` varchar(100) DEFAULT NULL,
  `reserveveld_46` varchar(100) DEFAULT NULL,
  `reserveveld_47` varchar(100) DEFAULT NULL,
  `reserveveld_48` varchar(100) DEFAULT NULL,
  `reserveveld_49` varchar(100) DEFAULT NULL,
  `reserveveld_50` varchar(100) DEFAULT NULL,
  `reserveveld_51` varchar(100) DEFAULT NULL,
  `reserveveld_52` varchar(100) DEFAULT NULL,
  `reserveveld_53` varchar(100) DEFAULT NULL,
  `reserveveld_54` varchar(100) DEFAULT NULL,
  `bmnr_downloaddatum` date DEFAULT NULL,
  `bmnr_max_bellen_tot` date DEFAULT NULL,
  `partij` varchar(30) DEFAULT NULL,
  `test` varchar(100) DEFAULT NULL,
  `prioriteiten` int(11) DEFAULT NULL,
  `gewenste_actie` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `status_reden` varchar(255) DEFAULT NULL,
  KEY `refnr` (`refnr`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for mails
-- ----------------------------
DROP TABLE IF EXISTS `mails`;
CREATE TABLE `mails` (
  `mail_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `file_id` int(11) unsigned DEFAULT NULL,
  `refnr` varchar(30) DEFAULT NULL,
  `programma` varchar(100) DEFAULT NULL,
  `actiecode1` varchar(50) DEFAULT NULL,
  `actiecode2` varchar(50) DEFAULT NULL,
  `actiecode3` varchar(50) DEFAULT NULL,
  `actiecode4` varchar(50) DEFAULT NULL,
  `actiecode5` varchar(50) DEFAULT NULL,
  `contentcode1` varchar(15) DEFAULT NULL,
  `contentcode2` varchar(15) DEFAULT NULL,
  `contentcode3` varchar(15) DEFAULT NULL,
  `contentcode4` varchar(15) DEFAULT NULL,
  `contentcode5` varchar(15) DEFAULT NULL,
  `zp` int(11) DEFAULT NULL,
  `voorletters` varchar(150) DEFAULT NULL,
  `tussenvoegsel` varchar(15) DEFAULT NULL,
  `achternaam` varchar(150) DEFAULT NULL,
  `geslacht` varchar(1) DEFAULT NULL,
  `titel` varchar(45) DEFAULT NULL,
  `geboortedatum` date DEFAULT NULL,
  `bedrijfsnaam` varchar(255) DEFAULT NULL,
  `kvk` varchar(50) DEFAULT NULL,
  `correspondentie_straat` varchar(150) DEFAULT NULL,
  `correspondentie_nummer` varchar(90) DEFAULT NULL,
  `correspondentie_toevoeg` varchar(150) DEFAULT NULL,
  `correspondentie_postcode` varchar(90) DEFAULT NULL,
  `correspondentie_plaats` varchar(50) DEFAULT NULL,
  `correspondentie_land` varchar(50) DEFAULT NULL,
  `aansluit_straat` varchar(150) DEFAULT NULL,
  `aansluit_nummer` varchar(90) DEFAULT NULL,
  `aansluit_toevoeg` varchar(150) DEFAULT NULL,
  `aansluit_postcode` varchar(90) DEFAULT NULL,
  `aansluit_plaats` varchar(50) DEFAULT NULL,
  `aansluit_land` varchar(50) DEFAULT NULL,
  `telefoon_vast` varchar(50) DEFAULT NULL,
  `telefoon_mobiel` varchar(50) DEFAULT NULL,
  `telefoon_werk` varchar(50) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `username` varchar(150) DEFAULT NULL,
  `woonbestemming` varchar(1) DEFAULT NULL,
  `type` varchar(3) DEFAULT NULL,
  `klantlabel` varchar(10) DEFAULT NULL,
  `actief` varchar(1) DEFAULT NULL,
  `contractrek` int(11) DEFAULT NULL,
  `contractrekeningnummer` int(11) DEFAULT NULL,
  `behoeftesegment` varchar(1) DEFAULT NULL,
  `waardesegment` varchar(50) DEFAULT NULL,
  `klantwaarde` varchar(10) DEFAULT NULL,
  `betalingswijze` varchar(1) DEFAULT NULL,
  `voorkeursdatum_ai` int(11) DEFAULT NULL,
  `rekeningnummer` varchar(34) DEFAULT NULL,
  `contractnummer_stroom` int(11) DEFAULT NULL,
  `product_stroom` varchar(150) DEFAULT NULL,
  `tarieftype_stroom` varchar(17) DEFAULT NULL,
  `verbruik_stroom_hoog` int(11) DEFAULT NULL,
  `ean_stroom` varchar(52) DEFAULT NULL,
  `verbruiktype_s` varchar(2) DEFAULT NULL,
  `netbeheerder_stroom` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_s` varchar(70) DEFAULT NULL,
  `begindatum_stroom` date DEFAULT NULL,
  `einddatum_stroom` date DEFAULT NULL,
  `verbruik_stroom_laag` int(11) DEFAULT NULL,
  `exitdatum_stroom` date DEFAULT NULL,
  `contractnummer_gas` int(11) DEFAULT NULL,
  `product_gas` varchar(255) DEFAULT NULL,
  `tarieftype_gas` varchar(15) DEFAULT NULL,
  `ean_gas` varchar(52) DEFAULT NULL,
  `verbruiktype_g` varchar(6) DEFAULT NULL,
  `netbeheerder_gas` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_g` varchar(70) DEFAULT NULL,
  `begindatum_gas` date DEFAULT NULL,
  `einddatum_gas` date DEFAULT NULL,
  `verbruik_gas` int(11) DEFAULT NULL,
  `gasregio` varchar(2) DEFAULT NULL,
  `exitdatum_gas` date DEFAULT NULL,
  `termijnbedrag` decimal(8,2) DEFAULT NULL,
  `klacht` varchar(1) DEFAULT NULL,
  `kc_kanaal` varchar(120) DEFAULT NULL,
  `kc_categorie` varchar(120) DEFAULT NULL,
  `kc_onderwerp` varchar(120) DEFAULT NULL,
  `kc_datum` date DEFAULT NULL,
  `koophuur` varchar(6) DEFAULT NULL,
  `type_woning` varchar(24) DEFAULT NULL,
  `bouwjaar_woning` varchar(16) DEFAULT NULL,
  `cv_ketel_bouwjaar` int(4) DEFAULT NULL,
  `profiel_1_def` varchar(100) DEFAULT NULL,
  `profiel_1_waarde` varchar(150) DEFAULT NULL,
  `profiel_2_def` varchar(100) DEFAULT NULL,
  `profiel_2_waarde` varchar(150) DEFAULT NULL,
  `profiel_3_def` varchar(100) DEFAULT NULL,
  `profiel_3_waarde` varchar(150) DEFAULT NULL,
  `profiel_4_def` varchar(100) DEFAULT NULL,
  `profiel_4_waarde` varchar(150) DEFAULT NULL,
  `profiel_5_def` varchar(100) DEFAULT NULL,
  `profiel_5_waarde` varchar(150) DEFAULT NULL,
  `profiel_6_def` varchar(100) DEFAULT NULL,
  `profiel_6_waarde` varchar(150) DEFAULT NULL,
  `profiel_7_def` varchar(100) DEFAULT NULL,
  `profiel_7_waarde` varchar(150) DEFAULT NULL,
  `profiel_8_def` varchar(100) DEFAULT NULL,
  `profiel_8_waarde` varchar(150) DEFAULT NULL,
  `profiel_9_def` varchar(100) DEFAULT NULL,
  `profiel_9_waarde` varchar(150) DEFAULT NULL,
  `profiel_10_def` varchar(100) DEFAULT NULL,
  `profiel_10_waarde` varchar(150) DEFAULT NULL,
  `profiel_11_def` varchar(100) DEFAULT NULL,
  `profiel_11_waarde` varchar(150) DEFAULT NULL,
  `profiel_12_def` varchar(100) DEFAULT NULL,
  `profiel_12_waarde` varchar(150) DEFAULT NULL,
  `profiel_13_def` varchar(100) DEFAULT NULL,
  `profiel_13_waarde` varchar(150) DEFAULT NULL,
  `profiel_14_def` varchar(100) DEFAULT NULL,
  `profiel_14_waarde` varchar(150) DEFAULT NULL,
  `profiel_15_def` varchar(100) DEFAULT NULL,
  `profiel_15_waarde` varchar(150) DEFAULT NULL,
  `profiel_16_def` varchar(100) DEFAULT NULL,
  `profiel_16_waarde` varchar(150) DEFAULT NULL,
  `profiel_17_def` varchar(100) DEFAULT NULL,
  `profiel_17_waarde` varchar(150) DEFAULT NULL,
  `profiel_18_def` varchar(100) DEFAULT NULL,
  `profiel_18_waarde` varchar(150) DEFAULT NULL,
  `profiel_19_def` varchar(100) DEFAULT NULL,
  `profiel_19_waarde` varchar(150) DEFAULT NULL,
  `profiel_20_def` varchar(100) DEFAULT NULL,
  `profiel_20_waarde` varchar(150) DEFAULT NULL,
  `profiel_vraag_1` varchar(255) DEFAULT NULL,
  `profiel_vraag_2` varchar(255) DEFAULT NULL,
  `profiel_vraag_3` varchar(255) DEFAULT NULL,
  `profiel_vraag_4` varchar(255) DEFAULT NULL,
  `profiel_vraag_5` varchar(255) DEFAULT NULL,
  `reserveveld_1` varchar(100) DEFAULT NULL,
  `reserveveld_2` varchar(100) DEFAULT NULL,
  `reserveveld_3` varchar(100) DEFAULT NULL,
  `reserveveld_4` varchar(100) DEFAULT NULL,
  `reserveveld_5` varchar(100) DEFAULT NULL,
  `reserveveld_6` varchar(100) DEFAULT NULL,
  `reserveveld_7` varchar(100) DEFAULT NULL,
  `reserveveld_8` varchar(100) DEFAULT NULL,
  `reserveveld_9` varchar(100) DEFAULT NULL,
  `reserveveld_10` varchar(100) DEFAULT NULL,
  `reserveveld_11` varchar(100) DEFAULT NULL,
  `reserveveld_12` varchar(100) DEFAULT NULL,
  `reserveveld_13` varchar(100) DEFAULT NULL,
  `reserveveld_14` varchar(100) DEFAULT NULL,
  `reserveveld_15` varchar(100) DEFAULT NULL,
  `reserveveld_16` varchar(100) DEFAULT NULL,
  `reserveveld_17` varchar(100) DEFAULT NULL,
  `reserveveld_18` varchar(100) DEFAULT NULL,
  `reserveveld_19` varchar(100) DEFAULT NULL,
  `reserveveld_20` varchar(100) DEFAULT NULL,
  `reserveveld_21` varchar(100) DEFAULT NULL,
  `reserveveld_22` varchar(100) DEFAULT NULL,
  `reserveveld_23` varchar(100) DEFAULT NULL,
  `reserveveld_24` varchar(100) DEFAULT NULL,
  `reserveveld_25` varchar(100) DEFAULT NULL,
  `reserveveld_26` varchar(100) DEFAULT NULL,
  `reserveveld_27` varchar(100) DEFAULT NULL,
  `reserveveld_28` varchar(100) DEFAULT NULL,
  `reserveveld_29` varchar(100) DEFAULT NULL,
  `reserveveld_30` varchar(100) DEFAULT NULL,
  `reserveveld_31` varchar(100) DEFAULT NULL,
  `reserveveld_32` varchar(100) DEFAULT NULL,
  `reserveveld_33` varchar(100) DEFAULT NULL,
  `reserveveld_34` varchar(100) DEFAULT NULL,
  `reserveveld_35` varchar(100) DEFAULT NULL,
  `reserveveld_36` varchar(100) DEFAULT NULL,
  `reserveveld_37` varchar(100) DEFAULT NULL,
  `ppc_stroom` varchar(10) DEFAULT NULL,
  `ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_gas` varchar(10) DEFAULT NULL,
  `teruglevering` varchar(1) DEFAULT NULL,
  `teruglevering_hoog` int(11) DEFAULT NULL,
  `teruglevering_laag` int(11) DEFAULT NULL,
  `ac1_chb_tot_ex` decimal(8,2) DEFAULT NULL,
  `ac1_chb_tot_in` decimal(8,2) DEFAULT NULL,
  `branche` varchar(150) DEFAULT NULL,
  `reserveveld_38` varchar(100) DEFAULT NULL,
  `reserveveld_39` varchar(100) DEFAULT NULL,
  `reserveveld_40` varchar(100) DEFAULT NULL,
  `reserveveld_41` varchar(100) DEFAULT NULL,
  `reserveveld_42` varchar(100) DEFAULT NULL,
  `reserveveld_43` varchar(100) DEFAULT NULL,
  `reserveveld_44` varchar(100) DEFAULT NULL,
  `reserveveld_45` varchar(100) DEFAULT NULL,
  `reserveveld_46` varchar(100) DEFAULT NULL,
  `reserveveld_47` varchar(100) DEFAULT NULL,
  `reserveveld_48` varchar(100) DEFAULT NULL,
  `reserveveld_49` varchar(100) DEFAULT NULL,
  `reserveveld_50` varchar(100) DEFAULT NULL,
  `reserveveld_51` varchar(100) DEFAULT NULL,
  `reserveveld_52` varchar(100) DEFAULT NULL,
  `reserveveld_53` varchar(100) DEFAULT NULL,
  `reserveveld_54` varchar(100) DEFAULT NULL,
  `bmnr_downloaddatum` date DEFAULT NULL,
  `bmnr_max_bellen_tot` date DEFAULT NULL,
  `partij` varchar(30) DEFAULT NULL,
  `test` varchar(100) DEFAULT NULL,
  `prioriteiten` int(11) DEFAULT NULL,
  `gewenste_actie` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `status_reden` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`mail_id`),
  UNIQUE KEY `refnr` (`refnr`) USING BTREE,
  KEY `file_id` (`file_id`),
  KEY `actiecode1` (`actiecode1`) USING BTREE,
  KEY `zp` (`zp`) USING BTREE,
  CONSTRAINT `mails_ibfk_1` FOREIGN KEY (`file_id`) REFERENCES `files` (`file_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2857144 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for mails_test
-- ----------------------------
DROP TABLE IF EXISTS `mails_test`;
CREATE TABLE `mails_test` (
  `mail_id` int(11) unsigned NOT NULL DEFAULT '0',
  `created` datetime DEFAULT NULL,
  `file_id` int(11) unsigned DEFAULT NULL,
  `refnr` varchar(30) DEFAULT NULL,
  `programma` varchar(100) DEFAULT NULL,
  `actiecode1` varchar(50) DEFAULT NULL,
  `actiecode2` varchar(50) DEFAULT NULL,
  `actiecode3` varchar(50) DEFAULT NULL,
  `actiecode4` varchar(50) DEFAULT NULL,
  `actiecode5` varchar(50) DEFAULT NULL,
  `contentcode1` varchar(15) DEFAULT NULL,
  `contentcode2` varchar(15) DEFAULT NULL,
  `contentcode3` varchar(15) DEFAULT NULL,
  `contentcode4` varchar(15) DEFAULT NULL,
  `contentcode5` varchar(15) DEFAULT NULL,
  `zp` int(11) DEFAULT NULL,
  `voorletters` varchar(150) DEFAULT NULL,
  `tussenvoegsel` varchar(15) DEFAULT NULL,
  `achternaam` varchar(150) DEFAULT NULL,
  `geslacht` varchar(1) DEFAULT NULL,
  `titel` varchar(45) DEFAULT NULL,
  `geboortedatum` date DEFAULT NULL,
  `bedrijfsnaam` varchar(255) DEFAULT NULL,
  `kvk` varchar(50) DEFAULT NULL,
  `correspondentie_straat` varchar(150) DEFAULT NULL,
  `correspondentie_nummer` varchar(90) DEFAULT NULL,
  `correspondentie_toevoeg` varchar(150) DEFAULT NULL,
  `correspondentie_postcode` varchar(90) DEFAULT NULL,
  `correspondentie_plaats` varchar(50) DEFAULT NULL,
  `correspondentie_land` varchar(50) DEFAULT NULL,
  `aansluit_straat` varchar(150) DEFAULT NULL,
  `aansluit_nummer` varchar(90) DEFAULT NULL,
  `aansluit_toevoeg` varchar(150) DEFAULT NULL,
  `aansluit_postcode` varchar(90) DEFAULT NULL,
  `aansluit_plaats` varchar(50) DEFAULT NULL,
  `aansluit_land` varchar(50) DEFAULT NULL,
  `telefoon_vast` varchar(50) DEFAULT NULL,
  `telefoon_mobiel` varchar(50) DEFAULT NULL,
  `telefoon_werk` varchar(50) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `username` varchar(150) DEFAULT NULL,
  `woonbestemming` varchar(1) DEFAULT NULL,
  `type` varchar(3) DEFAULT NULL,
  `klantlabel` varchar(10) DEFAULT NULL,
  `actief` varchar(1) DEFAULT NULL,
  `contractrek` int(11) DEFAULT NULL,
  `contractrekeningnummer` int(11) DEFAULT NULL,
  `behoeftesegment` varchar(1) DEFAULT NULL,
  `waardesegment` varchar(50) DEFAULT NULL,
  `klantwaarde` varchar(10) DEFAULT NULL,
  `betalingswijze` varchar(1) DEFAULT NULL,
  `voorkeursdatum_ai` int(11) DEFAULT NULL,
  `rekeningnummer` varchar(34) DEFAULT NULL,
  `contractnummer_stroom` int(11) DEFAULT NULL,
  `product_stroom` varchar(150) DEFAULT NULL,
  `tarieftype_stroom` varchar(17) DEFAULT NULL,
  `verbruik_stroom_hoog` int(11) DEFAULT NULL,
  `ean_stroom` varchar(52) DEFAULT NULL,
  `verbruiktype_s` varchar(2) DEFAULT NULL,
  `netbeheerder_stroom` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_s` varchar(70) DEFAULT NULL,
  `begindatum_stroom` date DEFAULT NULL,
  `einddatum_stroom` date DEFAULT NULL,
  `verbruik_stroom_laag` int(11) DEFAULT NULL,
  `exitdatum_stroom` date DEFAULT NULL,
  `contractnummer_gas` int(11) DEFAULT NULL,
  `product_gas` varchar(255) DEFAULT NULL,
  `tarieftype_gas` varchar(15) DEFAULT NULL,
  `ean_gas` varchar(52) DEFAULT NULL,
  `verbruiktype_g` varchar(6) DEFAULT NULL,
  `netbeheerder_gas` varchar(96) DEFAULT NULL,
  `fysieke_capaciteit_g` varchar(70) DEFAULT NULL,
  `begindatum_gas` date DEFAULT NULL,
  `einddatum_gas` date DEFAULT NULL,
  `verbruik_gas` int(11) DEFAULT NULL,
  `gasregio` varchar(2) DEFAULT NULL,
  `exitdatum_gas` date DEFAULT NULL,
  `termijnbedrag` decimal(8,2) DEFAULT NULL,
  `klacht` varchar(1) DEFAULT NULL,
  `kc_kanaal` varchar(120) DEFAULT NULL,
  `kc_categorie` varchar(120) DEFAULT NULL,
  `kc_onderwerp` varchar(120) DEFAULT NULL,
  `kc_datum` date DEFAULT NULL,
  `koophuur` varchar(6) DEFAULT NULL,
  `type_woning` varchar(24) DEFAULT NULL,
  `bouwjaar_woning` varchar(16) DEFAULT NULL,
  `cv_ketel_bouwjaar` int(4) DEFAULT NULL,
  `profiel_1_def` varchar(100) DEFAULT NULL,
  `profiel_1_waarde` varchar(150) DEFAULT NULL,
  `profiel_2_def` varchar(100) DEFAULT NULL,
  `profiel_2_waarde` varchar(150) DEFAULT NULL,
  `profiel_3_def` varchar(100) DEFAULT NULL,
  `profiel_3_waarde` varchar(150) DEFAULT NULL,
  `profiel_4_def` varchar(100) DEFAULT NULL,
  `profiel_4_waarde` varchar(150) DEFAULT NULL,
  `profiel_5_def` varchar(100) DEFAULT NULL,
  `profiel_5_waarde` varchar(150) DEFAULT NULL,
  `profiel_6_def` varchar(100) DEFAULT NULL,
  `profiel_6_waarde` varchar(150) DEFAULT NULL,
  `profiel_7_def` varchar(100) DEFAULT NULL,
  `profiel_7_waarde` varchar(150) DEFAULT NULL,
  `profiel_8_def` varchar(100) DEFAULT NULL,
  `profiel_8_waarde` varchar(150) DEFAULT NULL,
  `profiel_9_def` varchar(100) DEFAULT NULL,
  `profiel_9_waarde` varchar(150) DEFAULT NULL,
  `profiel_10_def` varchar(100) DEFAULT NULL,
  `profiel_10_waarde` varchar(150) DEFAULT NULL,
  `profiel_11_def` varchar(100) DEFAULT NULL,
  `profiel_11_waarde` varchar(150) DEFAULT NULL,
  `profiel_12_def` varchar(100) DEFAULT NULL,
  `profiel_12_waarde` varchar(150) DEFAULT NULL,
  `profiel_13_def` varchar(100) DEFAULT NULL,
  `profiel_13_waarde` varchar(150) DEFAULT NULL,
  `profiel_14_def` varchar(100) DEFAULT NULL,
  `profiel_14_waarde` varchar(150) DEFAULT NULL,
  `profiel_15_def` varchar(100) DEFAULT NULL,
  `profiel_15_waarde` varchar(150) DEFAULT NULL,
  `profiel_16_def` varchar(100) DEFAULT NULL,
  `profiel_16_waarde` varchar(150) DEFAULT NULL,
  `profiel_17_def` varchar(100) DEFAULT NULL,
  `profiel_17_waarde` varchar(150) DEFAULT NULL,
  `profiel_18_def` varchar(100) DEFAULT NULL,
  `profiel_18_waarde` varchar(150) DEFAULT NULL,
  `profiel_19_def` varchar(100) DEFAULT NULL,
  `profiel_19_waarde` varchar(150) DEFAULT NULL,
  `profiel_20_def` varchar(100) DEFAULT NULL,
  `profiel_20_waarde` varchar(150) DEFAULT NULL,
  `profiel_vraag_1` varchar(255) DEFAULT NULL,
  `profiel_vraag_2` varchar(255) DEFAULT NULL,
  `profiel_vraag_3` varchar(255) DEFAULT NULL,
  `profiel_vraag_4` varchar(255) DEFAULT NULL,
  `profiel_vraag_5` varchar(255) DEFAULT NULL,
  `reserveveld_1` varchar(100) DEFAULT NULL,
  `reserveveld_2` varchar(100) DEFAULT NULL,
  `reserveveld_3` varchar(100) DEFAULT NULL,
  `reserveveld_4` varchar(100) DEFAULT NULL,
  `reserveveld_5` varchar(100) DEFAULT NULL,
  `reserveveld_6` varchar(100) DEFAULT NULL,
  `reserveveld_7` varchar(100) DEFAULT NULL,
  `reserveveld_8` varchar(100) DEFAULT NULL,
  `reserveveld_9` varchar(100) DEFAULT NULL,
  `reserveveld_10` varchar(100) DEFAULT NULL,
  `reserveveld_11` varchar(100) DEFAULT NULL,
  `reserveveld_12` varchar(100) DEFAULT NULL,
  `reserveveld_13` varchar(100) DEFAULT NULL,
  `reserveveld_14` varchar(100) DEFAULT NULL,
  `reserveveld_15` varchar(100) DEFAULT NULL,
  `reserveveld_16` varchar(100) DEFAULT NULL,
  `reserveveld_17` varchar(100) DEFAULT NULL,
  `reserveveld_18` varchar(100) DEFAULT NULL,
  `reserveveld_19` varchar(100) DEFAULT NULL,
  `reserveveld_20` varchar(100) DEFAULT NULL,
  `reserveveld_21` varchar(100) DEFAULT NULL,
  `reserveveld_22` varchar(100) DEFAULT NULL,
  `reserveveld_23` varchar(100) DEFAULT NULL,
  `reserveveld_24` varchar(100) DEFAULT NULL,
  `reserveveld_25` varchar(100) DEFAULT NULL,
  `reserveveld_26` varchar(100) DEFAULT NULL,
  `reserveveld_27` varchar(100) DEFAULT NULL,
  `reserveveld_28` varchar(100) DEFAULT NULL,
  `reserveveld_29` varchar(100) DEFAULT NULL,
  `reserveveld_30` varchar(100) DEFAULT NULL,
  `reserveveld_31` varchar(100) DEFAULT NULL,
  `reserveveld_32` varchar(100) DEFAULT NULL,
  `reserveveld_33` varchar(100) DEFAULT NULL,
  `reserveveld_34` varchar(100) DEFAULT NULL,
  `reserveveld_35` varchar(100) DEFAULT NULL,
  `reserveveld_36` varchar(100) DEFAULT NULL,
  `reserveveld_37` varchar(100) DEFAULT NULL,
  `ppc_stroom` varchar(10) DEFAULT NULL,
  `ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod1_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod2_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod3_ppc_gas` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_stroom` varchar(10) DEFAULT NULL,
  `ac1_aanbod4_ppc_gas` varchar(10) DEFAULT NULL,
  `teruglevering` varchar(1) DEFAULT NULL,
  `teruglevering_hoog` int(11) DEFAULT NULL,
  `teruglevering_laag` int(11) DEFAULT NULL,
  `ac1_chb_tot_ex` decimal(8,2) DEFAULT NULL,
  `ac1_chb_tot_in` decimal(8,2) DEFAULT NULL,
  `branche` varchar(150) DEFAULT NULL,
  `reserveveld_38` varchar(100) DEFAULT NULL,
  `reserveveld_39` varchar(100) DEFAULT NULL,
  `reserveveld_40` varchar(100) DEFAULT NULL,
  `reserveveld_41` varchar(100) DEFAULT NULL,
  `reserveveld_42` varchar(100) DEFAULT NULL,
  `reserveveld_43` varchar(100) DEFAULT NULL,
  `reserveveld_44` varchar(100) DEFAULT NULL,
  `reserveveld_45` varchar(100) DEFAULT NULL,
  `reserveveld_46` varchar(100) DEFAULT NULL,
  `reserveveld_47` varchar(100) DEFAULT NULL,
  `reserveveld_48` varchar(100) DEFAULT NULL,
  `reserveveld_49` varchar(100) DEFAULT NULL,
  `reserveveld_50` varchar(100) DEFAULT NULL,
  `reserveveld_51` varchar(100) DEFAULT NULL,
  `reserveveld_52` varchar(100) DEFAULT NULL,
  `reserveveld_53` varchar(100) DEFAULT NULL,
  `reserveveld_54` varchar(100) DEFAULT NULL,
  `bmnr_downloaddatum` date DEFAULT NULL,
  `bmnr_max_bellen_tot` date DEFAULT NULL,
  `partij` varchar(30) DEFAULT NULL,
  `test` varchar(100) DEFAULT NULL,
  `prioriteiten` int(11) DEFAULT NULL,
  `gewenste_actie` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `status_reden` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for multisites
-- ----------------------------
DROP TABLE IF EXISTS `multisites`;
CREATE TABLE `multisites` (
  `multisite_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `created` datetime DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `respondent_id` int(10) unsigned NOT NULL,
  `mail_id` int(11) unsigned NOT NULL,
  `selected` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`multisite_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `mail_id` (`mail_id`),
  CONSTRAINT `multisites_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `multisites_ibfk_2` FOREIGN KEY (`mail_id`) REFERENCES `mails` (`mail_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=296 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for processors
-- ----------------------------
DROP TABLE IF EXISTS `processors`;
CREATE TABLE `processors` (
  `processor_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `lastrunstart` datetime DEFAULT NULL,
  `lastrunend` datetime DEFAULT NULL,
  PRIMARY KEY (`processor_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for respondents
-- ----------------------------
DROP TABLE IF EXISTS `respondents`;
CREATE TABLE `respondents` (
  `respondent_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `mail_id` int(11) unsigned DEFAULT NULL,
  `campaign_id` int(10) unsigned NOT NULL,
  `scan_id` int(10) unsigned DEFAULT NULL,
  `batch_id` int(10) unsigned NOT NULL,
  `failurereason_id` int(10) unsigned DEFAULT NULL,
  `stroom_upb_id` int(10) unsigned DEFAULT NULL,
  `gas_upb_id` int(10) unsigned DEFAULT NULL,
  `productkeuze` varchar(50) DEFAULT NULL,
  `nbl` varchar(10) DEFAULT NULL,
  `voorletters` varchar(150) DEFAULT NULL,
  `tussenvoegsel` varchar(15) DEFAULT NULL,
  `achternaam` varchar(150) DEFAULT NULL,
  `geslacht` enum('M','V','O') DEFAULT NULL,
  `titel` varchar(45) DEFAULT NULL,
  `geboortedatum` date DEFAULT NULL,
  `bedrijfsnaam` varchar(255) DEFAULT NULL,
  `kvk` varchar(50) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `aansluit_straat` varchar(150) DEFAULT NULL,
  `aansluit_nummer` varchar(90) DEFAULT NULL,
  `aansluit_toevoeg` varchar(150) DEFAULT NULL,
  `aansluit_postcode` varchar(90) DEFAULT NULL,
  `aansluit_plaats` varchar(50) DEFAULT NULL,
  `aansluit_land` varchar(50) DEFAULT NULL,
  `correspondentie_straat` varchar(150) DEFAULT NULL,
  `correspondentie_nummer` varchar(90) DEFAULT NULL,
  `correspondentie_toevoeg` varchar(150) DEFAULT NULL,
  `correspondentie_postcode` varchar(90) DEFAULT NULL,
  `correspondentie_plaats` varchar(50) DEFAULT NULL,
  `correspondentie_land` varchar(50) DEFAULT NULL,
  `telefoon_vast` varchar(50) DEFAULT NULL,
  `telefoon_mobiel` varchar(50) DEFAULT NULL,
  `token` varchar(100) DEFAULT NULL COMMENT 'token tbv selfservice pagina',
  `iban` varchar(34) DEFAULT NULL,
  `betaalwijze` enum('A','I','M') DEFAULT NULL,
  `voorkeursdatum` int(2) DEFAULT NULL,
  `ondertekendatum` date DEFAULT NULL,
  `handtekening` tinyint(1) DEFAULT NULL,
  `wil_post_online_ontvangen` tinyint(1) DEFAULT NULL,
  `geen_woon_werk_pand` tinyint(1) DEFAULT NULL,
  `correspondentie` enum('Geen','Correspondentie','Uitvalreden') DEFAULT 'Geen',
  `selfservice` datetime DEFAULT NULL COMMENT 'Laatste login poging',
  `selfservice_ip` varchar(20) DEFAULT NULL COMMENT 'IP laatste login poging',
  `selfservice_login` int(11) DEFAULT '0',
  `selfservice_succes` tinyint(1) DEFAULT '0' COMMENT '1 selfservice is succesvol',
  `tarieftype_stroom` varchar(2) DEFAULT NULL,
  `termijnbedrag` int(11) DEFAULT NULL,
  `order_id` varchar(12) DEFAULT NULL,
  `agent_id` varchar(100) DEFAULT NULL,
  `makelaarscode` varchar(100) DEFAULT NULL,
  `datum_sleuteloverdracht` date DEFAULT NULL,
  `meterstand_elek_1` int(11) DEFAULT NULL,
  `meterstand_elek_2` int(11) DEFAULT NULL,
  `meterstand_gas` int(11) DEFAULT NULL,
  `meterstand_stadswarmte` decimal(11,3) DEFAULT NULL,
  `meterstand_warm_tapwater` decimal(11,1) DEFAULT NULL,
  `gewenste_ingangsdatum_contract` date DEFAULT NULL,
  PRIMARY KEY (`respondent_id`),
  UNIQUE KEY `token_UNIQUE` (`token`),
  UNIQUE KEY `mail_id_UNIQUE` (`mail_id`),
  KEY `fk_respondents_mails_mail_id1_idx` (`mail_id`),
  KEY `fk_respondents_campaigns_campaign_id1_idx` (`campaign_id`),
  KEY `fk_respondents_scans_scan_id1_idx` (`scan_id`),
  KEY `fk_respondents_batches_batch_id1_idx` (`batch_id`),
  KEY `fk_respondents_upbs_upb_id1_idx` (`stroom_upb_id`),
  KEY `fk_respondents_upbs_upb_id2_idx` (`gas_upb_id`),
  KEY `created_user` (`created_user`) USING BTREE,
  KEY `fk_respondents_failurereasons_failurereason_id1_idx` (`failurereason_id`),
  CONSTRAINT `fk_respondents_batches_batch_id1` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_campaigns_campaign_id1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_failurereasons_failurereason_id1` FOREIGN KEY (`failurereason_id`) REFERENCES `failurereasons` (`failurereason_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_mails_mail_id1` FOREIGN KEY (`mail_id`) REFERENCES `mails` (`mail_id`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_scans_scan_id1` FOREIGN KEY (`scan_id`) REFERENCES `scans` (`scan_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_upbs_upb_id1` FOREIGN KEY (`stroom_upb_id`) REFERENCES `upbs` (`upb_id`) ON UPDATE NO ACTION,
  CONSTRAINT `fk_respondents_upbs_upb_id2` FOREIGN KEY (`gas_upb_id`) REFERENCES `upbs` (`upb_id`) ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=513 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for scans
-- ----------------------------
DROP TABLE IF EXISTS `scans`;
CREATE TABLE `scans` (
  `scan_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `info` varchar(255) DEFAULT NULL,
  `extension` varchar(50) DEFAULT NULL,
  `size` int(11) DEFAULT NULL,
  `pages` int(11) DEFAULT NULL,
  `location` varchar(255) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `condition` enum('PENDING','AVAILABLE','SELECTED','DELETED','CANCELLED','PARKED','INCOMPLETE') DEFAULT NULL COMMENT 'PENDING = process van wegschijven is nog niet afgerond\nAVAILABLE = beschikbaar om te dowmloaden\nSELECTED = geselecteerd om verwijderd te worden\nDELETED = file is verwijderd uit archief\nCANCELLED = annulering \nPARKED = door gebruiker geparkeerd om later te bekijken\nINCOMPLETE = Onvolledig ingevuld',
  `conditiondt` datetime DEFAULT NULL,
  `exportdt` datetime DEFAULT NULL,
  `type` enum('MAIL','FULL') DEFAULT 'MAIL',
  `referencenumber` varchar(10) DEFAULT NULL,
  `token` varchar(100) DEFAULT NULL COMMENT 'download token',
  `downloaded` datetime DEFAULT NULL COMMENT 'Genesys download datetime (first)',
  `qrcode` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`scan_id`),
  UNIQUE KEY `token_UNIQUE` (`token`),
  UNIQUE KEY `qrcode_UNIQUE` (`qrcode`),
  KEY `referencenumber` (`referencenumber`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=46318 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for settingdefaults
-- ----------------------------
DROP TABLE IF EXISTS `settingdefaults`;
CREATE TABLE `settingdefaults` (
  `settingdefault_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `setting_id` int(10) unsigned NOT NULL,
  `groupname` varchar(50) DEFAULT NULL,
  `groupsequence` int(11) DEFAULT NULL,
  `sequence` int(11) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `label` varchar(50) DEFAULT NULL,
  `type` enum('string','integer','decimal','boolean','datetime','date','time','text') DEFAULT NULL,
  `mandatory` tinyint(1) DEFAULT '0',
  `datacheck_id` int(10) unsigned DEFAULT NULL,
  `info` varchar(255) DEFAULT NULL,
  `default_string` varchar(255) DEFAULT NULL,
  `default_integer` int(11) DEFAULT NULL,
  `default_decimal` decimal(8,2) DEFAULT NULL,
  `default_boolean` tinyint(1) DEFAULT NULL,
  `default_datetime` datetime DEFAULT NULL,
  `default_date` date DEFAULT NULL,
  `default_time` time DEFAULT NULL,
  `default_text` text,
  PRIMARY KEY (`settingdefault_id`),
  KEY `fk_settingdefaults_settings_setting_id1_idx` (`setting_id`),
  KEY `fk_settingdefaults_datachecks_datacheck_id1_idx` (`datacheck_id`),
  CONSTRAINT `fk_settingdefaults_datachecks_datacheck_id1` FOREIGN KEY (`datacheck_id`) REFERENCES `datachecks` (`datacheck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_settingdefaults_settings_setting_id1` FOREIGN KEY (`setting_id`) REFERENCES `settings` (`setting_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for settings
-- ----------------------------
DROP TABLE IF EXISTS `settings`;
CREATE TABLE `settings` (
  `setting_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`setting_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for systems
-- ----------------------------
DROP TABLE IF EXISTS `systems`;
CREATE TABLE `systems` (
  `system_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`system_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for systemvalues
-- ----------------------------
DROP TABLE IF EXISTS `systemvalues`;
CREATE TABLE `systemvalues` (
  `systemvalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `system_id` int(10) unsigned NOT NULL,
  `settingdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`systemvalue_id`),
  UNIQUE KEY `system_id` (`system_id`,`settingdefault_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_systemvalues_systems_system_id1_idx` (`system_id`),
  CONSTRAINT `fk_systemvalues_settingdefaults_settingdefault_id1` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_systemvalues_systems_system_id1` FOREIGN KEY (`system_id`) REFERENCES `systems` (`system_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for upbs
-- ----------------------------
DROP TABLE IF EXISTS `upbs`;
CREATE TABLE `upbs` (
  `upb_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `upbfile` varchar(255) DEFAULT NULL,
  `upb_type` enum('E','G') DEFAULT NULL,
  `upb_a` varchar(255) DEFAULT NULL,
  `upb_b` int(11) DEFAULT NULL,
  `upb_c` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`upb_id`),
  UNIQUE KEY `upb_c_UNIQUE` (`upb_c`),
  KEY `opzoeken_ppc` (`upb_type`,`upb_c`)
) ENGINE=InnoDB AUTO_INCREMENT=12262 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for userlocks
-- ----------------------------
DROP TABLE IF EXISTS `userlocks`;
CREATE TABLE `userlocks` (
  `userlock_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `portal_user_id` int(11) NOT NULL,
  `campaign_id` int(10) unsigned DEFAULT NULL,
  `scan_id` int(10) unsigned DEFAULT NULL,
  `respondent_id` int(10) unsigned DEFAULT NULL,
  `system_id` int(10) unsigned DEFAULT NULL,
  `batch_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`userlock_id`),
  UNIQUE KEY `fk_userlocks_campaigns_campaign_id1_idx` (`campaign_id`) USING BTREE,
  UNIQUE KEY `fk_userlocks_scans_scan_id1_idx` (`scan_id`) USING BTREE,
  UNIQUE KEY `fk_userlocks_respondents_respondent_id1_idx` (`respondent_id`) USING BTREE,
  UNIQUE KEY `fk_userlocks_batches_batch_id1_idx` (`batch_id`) USING BTREE,
  UNIQUE KEY `fk_userlocks_systems_system_id1_idx` (`system_id`) USING BTREE,
  UNIQUE KEY `unique_scan_id` (`scan_id`) USING BTREE,
  UNIQUE KEY `unique_respondent_id` (`respondent_id`) USING BTREE,
  UNIQUE KEY `unique_batch_id` (`batch_id`) USING BTREE,
  UNIQUE KEY `unique_campaign_id` (`campaign_id`) USING BTREE,
  UNIQUE KEY `unique_system_id` (`system_id`) USING BTREE,
  CONSTRAINT `fk_userlocks_batches_batch_id1` FOREIGN KEY (`batch_id`) REFERENCES `batches` (`batch_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_campaigns_campaign_id1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_respondents_respondent_id1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_scans_scan_id1` FOREIGN KEY (`scan_id`) REFERENCES `scans` (`scan_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_systems_system_id1` FOREIGN KEY (`system_id`) REFERENCES `systems` (`system_id`) ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1289 DEFAULT CHARSET=utf8;

-- ----------------------------
-- View structure for qselCampaignMailRespondentOverview
-- ----------------------------
DROP VIEW IF EXISTS `qselCampaignMailRespondentOverview`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselCampaignMailRespondentOverview` AS select `c`.`campaign_id` AS `campaign_id`,`c`.`created` AS `created`,`c`.`state` AS `state`,`c`.`description` AS `description`,`c`.`created_user` AS `created_user`,`c`.`modified` AS `modified`,`c`.`modified_user` AS `modified_user`,`c`.`name` AS `name`,`c`.`startdt` AS `startdt`,`c`.`enddt` AS `enddt`,`c`.`type` AS `type`,`c`.`type2` AS `type2`,if((`c`.`type` = 'MAIL'),(select count(1) from `mails` `m` where (`m`.`actiecode1` = `c`.`name`)),0) AS `mailbestand`,(select count(1) from `respondents` `r` where (`r`.`campaign_id` = `c`.`campaign_id`)) AS `respondenten` from `campaigns` `c` where (`c`.`state` = 'ACTIVE') ;

-- ----------------------------
-- View structure for qselCampaignproductPropositionList
-- ----------------------------
DROP VIEW IF EXISTS `qselCampaignproductPropositionList`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselCampaignproductPropositionList` AS select `campaignproducts`.`campaignproduct_id` AS `campaignproduct_id`,`campaignproducts`.`campaign_id` AS `campaign_id`,date_format(`campaignproducts`.`entry_month`,'%Y-%m') AS `entry_month`,`upbs_stroom`.`upb_c` AS `stroom_ppc`,`upbs_stroom`.`upb_b` AS `stroom_looptijd`,`upbs_gas`.`upb_c` AS `gas_ppc`,`upbs_gas`.`upb_b` AS `gas_looptijd`,`campaignproducts`.`nbl` AS `nbl`,`campaignproducts`.`stroom_upb_id` AS `stroom_upb_id`,`campaignproducts`.`gas_upb_id` AS `gas_upb_id`,`upbs_stroom`.`upb_a` AS `stroom_naam`,`upbs_gas`.`upb_a` AS `gas_naam` from ((`campaignproducts` left join `upbs` `upbs_stroom` on((`campaignproducts`.`stroom_upb_id` = `upbs_stroom`.`upb_id`))) left join `upbs` `upbs_gas` on((`campaignproducts`.`gas_upb_id` = `upbs_gas`.`upb_id`))) order by `campaignproducts`.`campaign_id`,if(((`upbs_stroom`.`upb_id` is not null) and (`upbs_gas`.`upb_id` is not null)),'J','N'),`campaignproducts`.`entry_month` desc,`upbs_stroom`.`upb_c`,`upbs_gas`.`upb_c` ;

-- ----------------------------
-- View structure for qselCampaignReports
-- ----------------------------
DROP VIEW IF EXISTS `qselCampaignReports`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselCampaignReports` AS select `mails`.`actiecode1` AS `campaign`,count(distinct `mails`.`mail_id`) AS `mails`,count(distinct `scans`.`scan_id`) AS `workload_scans_recognized`,count(distinct `respondents`.`respondent_id`) AS `respondents` from ((`mails` left join `respondents` on(((`respondents`.`mail_id` = `mails`.`mail_id`) and (`respondents`.`state` = 'ACTIVE')))) left join `scans` on(((`scans`.`referencenumber` = `mails`.`refnr`) and (`scans`.`condition` in ('AVAILABLE','PARKED')) and (`scans`.`state` = 'ACTIVE') and (`scans`.`scan_id` <> `respondents`.`scan_id`)))) group by 1 order by 1 ;

-- ----------------------------
-- View structure for qselEmaillistsEmailaddresses
-- ----------------------------
DROP VIEW IF EXISTS `qselEmaillistsEmailaddresses`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselEmaillistsEmailaddresses` AS select `emaillists`.`emaillist_id` AS `emaillist_id`,`emailaddresses`.`emailaddress` AS `emailaddress` from ((`emaillists` join `emailuses` on(((`emailuses`.`emaillist_id` = `emaillists`.`emaillist_id`) and (`emailuses`.`state` = 'ACTIVE')))) join `emailaddresses` on(((`emailaddresses`.`emailaddress_id` = `emailuses`.`emailaddress_id`) and (`emailaddresses`.`state` = 'ACTIVE')))) ;

-- ----------------------------
-- View structure for qselErrorlogsEmails
-- ----------------------------
DROP VIEW IF EXISTS `qselErrorlogsEmails`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselErrorlogsEmails` AS select `errorlogs`.`errorlog_id` AS `errorlog_id`,`errorlogs`.`created` AS `created`,`errorlogs`.`state` AS `state`,`errorlogs`.`description` AS `description`,`errorlogs`.`created_user` AS `created_user`,`errorlogs`.`modified` AS `modified`,`errorlogs`.`modified_user` AS `modified_user`,`errorlogs`.`activitylog_id` AS `activitylog_id`,`errorlogs`.`file_id` AS `file_id`,`errorlogs`.`emaillist_id` AS `emaillist_id`,`errorlogs`.`condition` AS `condition`,`errorlogs`.`conditiondt` AS `conditiondt`,`errorlogs`.`message` AS `message`,`emaillists`.`name` AS `emaillist`,`qfuncGetSystemValueByName`(1,'brand') AS `brand`,`emaillists`.`clangid` AS `clangid`,`emaillists`.`clanggroupid` AS `clanggroupid`,`emaillists`.`sendemailaddress` AS `sendemailaddress`,`emaillists`.`sendname` AS `sendname`,`emaillists`.`replyemailaddress` AS `replyemailaddress`,`emaillists`.`subject` AS `subject`,`files`.`name` AS `filename`,`processors`.`name` AS `processor`,`activities`.`name` AS `activity`,`activities`.`info` AS `info`,`qfuncGetSystemValueByName`(1,'pm_email') AS `pmemail` from (((((`errorlogs` join `emaillists` on(((`emaillists`.`emaillist_id` = `errorlogs`.`emaillist_id`) and (`emaillists`.`state` = 'ACTIVE')))) left join `files` on(((`files`.`file_id` = `errorlogs`.`file_id`) and (`files`.`state` = 'ACTIVE')))) left join `activitylogs` on(((`activitylogs`.`activitylog_id` = `errorlogs`.`activitylog_id`) and (`activitylogs`.`state` = 'ACTIVE')))) left join `activities` on(((`activitylogs`.`activity_id` = `activities`.`activity_id`) and (`activities`.`state` = 'ACTIVE')))) left join `processors` on(((`processors`.`processor_id` = `activities`.`processor_id`) and (`processors`.`state` = 'ACTIVE')))) where ((`errorlogs`.`state` = 'ACTIVE') and (`errorlogs`.`condition` = 'SEND') and (`errorlogs`.`emaillist_id` is not null)) ;

-- ----------------------------
-- View structure for qselMailFileImportOverview
-- ----------------------------
DROP VIEW IF EXISTS `qselMailFileImportOverview`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselMailFileImportOverview` AS select `f`.`file_id` AS `file_id`,`f`.`created` AS `created`,`f`.`condition` AS `condition`,`f`.`conditiondt` AS `conditiondt`,`f`.`name` AS `name`,`ft`.`name` AS `filetype`,(select count(1) from `mails` `m` where (`m`.`file_id` = `f`.`file_id`)) AS `mailbestand`,(select count(1) from (`mails` `m2` join `respondents` `r` on((`m2`.`mail_id` = `r`.`mail_id`))) where (`m2`.`file_id` = `f`.`file_id`)) AS `responsbestand` from (`files` `f` join `filetypes` `ft` on((`f`.`filetype_id` = `ft`.`filetype_id`))) where (`f`.`state` = 'ACTIVE') order by `f`.`file_id` desc ;

-- ----------------------------
-- View structure for qselMonthlyReport
-- ----------------------------
DROP VIEW IF EXISTS `qselMonthlyReport`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselMonthlyReport` AS select year(`respondents`.`created`) AS `jaar`,month(`respondents`.`created`) AS `maand`,count(if((`campaigns`.`type` = 'MAIL'),`respondents`.`respondent_id`,NULL)) AS `MAIL`,count(if((`campaigns`.`type` = 'FULL'),`respondents`.`respondent_id`,NULL)) AS `FULL` from (`respondents` join `campaigns` on((`campaigns`.`campaign_id` = `respondents`.`campaign_id`))) where ((`respondents`.`state` = 'ACTIVE') and (`respondents`.`created` <> '0000-00-00 00:00:00')) group by 1,2 order by 1 desc,2 desc ;

-- ----------------------------
-- View structure for qselMultisites
-- ----------------------------
DROP VIEW IF EXISTS `qselMultisites`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselMultisites` AS select `mails`.`mail_id` AS `mail_id`,`mails`.`refnr` AS `refnr`,`mails`.`actiecode1` AS `actiecode1`,count(1) AS `multisites`,group_concat(`mails2`.`mail_id` order by 1 ASC separator ',') AS `multi_mail_id` from (`mails` join `mails` `mails2` on(((`mails2`.`zp` = `mails`.`zp`) and (`mails2`.`file_id` = `mails`.`file_id`) and (`mails2`.`actiecode1` = `mails`.`actiecode1`)))) group by 1,2,3 having (`multisites` > 1) ;

-- ----------------------------
-- View structure for qselRespondentOverview
-- ----------------------------
DROP VIEW IF EXISTS `qselRespondentOverview`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselRespondentOverview` AS select `respondents`.`respondent_id` AS `respondent_id`,`respondents`.`created` AS `created`,`respondents`.`created_user` AS `created_user`,`respondents`.`batch_id` AS `batch_id`,`respondents`.`scan_id` AS `scan_id`,`campaigns`.`campaign_id` AS `campaign_id`,`campaigns`.`name` AS `name`,`mails`.`mail_id` AS `mail_id`,`mails`.`refnr` AS `refnr`,`respondents`.`voorletters` AS `voorletters`,`respondents`.`tussenvoegsel` AS `tussenvoegsel`,`respondents`.`achternaam` AS `achternaam`,`respondents`.`aansluit_straat` AS `aansluit_straat`,`respondents`.`aansluit_nummer` AS `aansluit_nummer`,`respondents`.`aansluit_toevoeg` AS `aansluit_toevoeg`,`respondents`.`aansluit_postcode` AS `aansluit_postcode`,`respondents`.`aansluit_plaats` AS `aansluit_plaats`,`respondents`.`email` AS `email`,`respondents`.`ondertekendatum` AS `ondertekendatum`,if(`respondents`.`handtekening`,'Ja','Nee') AS `handtekening`,`userlocks`.`portal_user_id` AS `batch_userlocks_portal_user_id` from (((`respondents` join `campaigns` on(((`respondents`.`campaign_id` = `campaigns`.`campaign_id`) and (`campaigns`.`state` = 'ACTIVE')))) left join `mails` on((`respondents`.`mail_id` = `mails`.`mail_id`))) left join `userlocks` on((`userlocks`.`batch_id` = `respondents`.`batch_id`))) where (`respondents`.`state` = 'ACTIVE') ;

-- ----------------------------
-- View structure for qselRespondentsReport
-- ----------------------------
DROP VIEW IF EXISTS `qselRespondentsReport`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselRespondentsReport` AS select year(`respondents`.`created`) AS `jaar`,month(`respondents`.`created`) AS `maand`,count(`respondents`.`respondent_id`) AS `aantal` from `respondents` where (`respondents`.`state` = 'ACTIVE') group by 1,2 order by 1 desc,2 desc ;

-- ----------------------------
-- View structure for qselWorklist
-- ----------------------------
DROP VIEW IF EXISTS `qselWorklist`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselWorklist` AS select sum(if((`scans`.`condition` = 'AVAILABLE'),if((`scans`.`type` = 'MAIL'),if(isnull(`respondents`.`respondent_id`),1,0),0),0)) AS `MAIL`,sum(if((`scans`.`condition` = 'AVAILABLE'),if((`scans`.`type` = 'FULL'),if(isnull(`respondents`.`respondent_id`),1,0),0),0)) AS `FULL`,sum(if((`scans`.`condition` = 'PARKED'),1,0)) AS `PARKED` from ((`scans` left join `respondents` on(((`respondents`.`scan_id` = `scans`.`scan_id`) and (`respondents`.`state` = 'ACTIVE')))) left join `userlocks` on((`userlocks`.`scan_id` = `scans`.`scan_id`))) where ((`scans`.`state` = 'ACTIVE') and isnull(`userlocks`.`scan_id`)) ;

-- ----------------------------
-- View structure for qselWorklistBatches
-- ----------------------------
DROP VIEW IF EXISTS `qselWorklistBatches`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselWorklistBatches` AS select count(distinct `batches`.`batch_id`) AS `batches`,count(distinct `respondents`.`respondent_id`) AS `respondents` from (`batches` join `respondents` on(((`respondents`.`batch_id` = `batches`.`batch_id`) and (`respondents`.`state` = 'ACTIVE')))) where ((`batches`.`state` = 'ACTIVE') and (`batches`.`condition` = 'CLOSED')) ;

-- ----------------------------
-- View structure for qselWorklistRPM
-- ----------------------------
DROP VIEW IF EXISTS `qselWorklistRPM`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselWorklistRPM` AS select sum(if((`activities`.`activity_id` = 100),1,0)) AS `mailbestand`,sum(if((`activities`.`activity_id` = 101),1,0)) AS `volledigvastleggen`,timediff(now(),min(`activitylogs`.`created`)) AS `Langste_tijd` from (`activitylogs` join `activities` on((`activities`.`activity_id` = `activitylogs`.`activity_id`))) where ((`activitylogs`.`activity_id` in (100,101)) and (`activitylogs`.`condition` = 'READY') and (`activitylogs`.`state` = 'ACTIVE')) ;

-- ----------------------------
-- Procedure structure for qprodAddOnOnly
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodAddOnOnly`;
DELIMITER ;;
CREATE PROCEDURE `qprodAddOnOnly`(IN `_actiecode` varchar(20))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	UPDATE mails SET ac1_aanbod1_ppc_stroom=null, ac1_aanbod1_ppc_gas=null WHERE actiecode1=_actiecode;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCleanNonrespons
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCleanNonrespons`;
DELIMITER ;;
CREATE PROCEDURE `qprodCleanNonrespons`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# De non-respons 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
#

DECLARE          _cleanmails int(10) DEFAULT 0;
DECLARE          _cleanfiles int(10) DEFAULT 0;
DECLARE          _maxdays int;

SELECT 		qfuncGetSystemValueByName(1,'del_nonrespons') into _maxdays;

SELECT
            COUNT(1) INTO _cleanmails
FROM
            mails AS m
LEFT JOIN 	respondents AS r ON r.mail_id = m.mail_id
LEFT JOIN 	multisites AS ms ON ms.mail_id = m.mail_id
WHERE
            r.mail_id IS NULL AND
            ms.mail_id IS NULL AND
            DATEDIFF(CURDATE(), m.created) > _maxdays;

IF _cleanmails > 0 THEN
            DELETE
                        m.*
            FROM
                        mails AS m
            LEFT JOIN 	respondents AS r ON r.mail_id = m.mail_id
            LEFT JOIN 	multisites AS ms ON ms.mail_id = m.mail_id
            WHERE
            r.mail_id IS NULL AND
            ms.mail_id IS NULL AND
            DATEDIFF(CURDATE(), m.created) > _maxdays;
END IF;

SELECT
            COUNT(1) INTO _cleanfiles
FROM
            files AS f
LEFT JOIN 	mails AS m ON m.file_id = f.file_id
WHERE
            m.file_id IS NULL AND
            f.`condition` = 'COMPLETED' AND
            DATEDIFF(CURDATE(), f.created) > _maxdays;

IF _cleanfiles > 0 THEN
            DELETE
                        f.*
            FROM
						files AS f
			LEFT JOIN 	mails AS m ON m.file_id = f.file_id
            WHERE
                        m.file_id IS NULL AND
                        f.`condition` = 'COMPLETED' AND
                        DATEDIFF(CURDATE(), f.created) > _maxdays;
END IF;

INSERT INTO errorlogs (created, emaillist_id, `condition`, conditiondt, message)
VALUES (NOW(), 5, 'OPEN', NOW(), CONCAT_WS('','Aantal mailbestand records verwijderd uit systeem: ',_cleanmails,'. Voorkomend in ',_cleanfiles,' bestanden.'));

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCleanRespons
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCleanRespons`;
DELIMITER ;;
CREATE PROCEDURE `qprodCleanRespons`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# Verwerkte respons 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
#
DECLARE 	_cleanrespons int(11) DEFAULT 0;
DECLARE 	_maxdays int;

SELECT qfuncGetSystemValueByName(1,'del_respons') into _maxdays;

SELECT 			COUNT(respondents.respondent_id) into _cleanrespons
FROM 				respondents
JOIN 				(
						SELECT 	DISTINCT activitylogs.respondent_id 
						FROM 		activitylogs
						WHERE 	activitylogs.`condition` = 'COMPLETED' 
										AND 	activitylogs.activityresult_id = 2
										AND 	activitylogs.activity_id = 300 
										AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY)
						) selectie ON (selectie.respondent_id = respondents.respondent_id)
LEFT JOIN 	multisites ON (multisites.respondent_id = respondents.respondent_id AND multisites.selected = 1 AND multisites.state = 'ACTIVE');

DELETE FROM mails
WHERE 		mails.mail_id IN (
				SELECT 	DISTINCT multisites.mail_id
				FROM 	activitylogs
                JOIN 	multisites ON (multisites.respondent_id = activitylogs.respondent_id)
				WHERE 	activitylogs.`condition` = 'COMPLETED' 
                AND 	activitylogs.activity_id = 300 
                AND 	activitylogs.activityresult_id = 2
                AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY));

DELETE FROM mails
WHERE 		mails.mail_id IN (
				SELECT 	DISTINCT respondents.mail_id
				FROM 	activitylogs
				JOIN 	respondents ON (respondents.respondent_id = activitylogs.respondent_id)
				WHERE 	activitylogs.`condition` = 'COMPLETED' 
                AND 	activitylogs.activity_id = 300 
                AND 	activitylogs.activityresult_id = 2
                AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY));

DELETE FROM multisites
WHERE 		multisites.respondent_id IN (
				SELECT 	DISTINCT activitylogs.respondent_id
				FROM 	activitylogs
				WHERE 	activitylogs.`condition` = 'COMPLETED' 
                AND 	activitylogs.activityresult_id = 2                
                AND 	activitylogs.activity_id = 300 
                AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY));

DELETE FROM scans
WHERE 		scans.scan_id IN (
				SELECT 	DISTINCT respondents.scan_id
				FROM 	activitylogs
                JOIN 	respondents ON (respondents.respondent_id = activitylogs.respondent_id)
				WHERE 	activitylogs.respondent_id = respondents.respondent_id 
                AND 	activitylogs.`condition` = 'COMPLETED' 
                AND 	activitylogs.activityresult_id = 2
                AND 	activitylogs.activity_id = 300 
                AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY));
                
DELETE FROM respondents
WHERE 		respondents.respondent_id IN (
				SELECT 	DISTINCT activitylogs.respondent_id 
				FROM 	activitylogs
				WHERE 	activitylogs.`condition` = 'COMPLETED' 
                AND 	activitylogs.activityresult_id = 2                
                AND 	activitylogs.activity_id = 300 
                AND 	NOW() > DATE_ADD(activitylogs.`conditiondt`,INTERVAL _maxdays DAY));

INSERT INTO errorlogs (created, emaillist_id, `condition`, conditiondt, message)
VALUES (NOW(), 5, 'OPEN', NOW(), CONCAT_WS('','Aantal respons records verwijderd uit systeem: ',_cleanrespons,'.'));

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodClearLockRecord
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodClearLockRecord`;
DELIMITER ;;
CREATE PROCEDURE `qprodClearLockRecord`(IN `_user_id` int, IN `_id` int, IN `_type` varchar(50))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# Het locken van een record in tabel userlocks
#
# voorbeeld 1,1,'campaign_id'
#
DECLARE _scan_id int;
# tabel userlocks 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
DELETE FROM userlocks
WHERE 			TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s');

#Opgegeven lock verwijderen
set @kweerie_del = 	CONCAT_WS(	'',
							'DELETE FROM userlocks WHERE ',
							_type,
							' = ', _id, ' AND portal_user_id = ',
							_user_id
						);

PREPARE uitvoeren_del FROM @kweerie_del;
EXECUTE uitvoeren_del;

# In bepaaldegevallen ook de lock op de scan verwijderen
IF _type = 'respondent_id'
	THEN SELECT scan_id into _scan_id from respondents where respondents.respondent_id = _id;
	#Opgegeven lock verwijderen op de scan
	set @kweerie_del = 	CONCAT_WS(	'',
								'DELETE FROM userlocks WHERE ',
								'scan_id',
								' = ', 
                                _scan_id, 
                                ' AND portal_user_id = ',
								_user_id
								);

	PREPARE uitvoeren_del FROM @kweerie_del;
	EXECUTE uitvoeren_del;
END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCloseActivitylog
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCloseActivitylog`;
DELIMITER ;;
CREATE PROCEDURE `qprodCloseActivitylog`(IN `_activitylog_id` INT, IN `_activityresult` varchar(50))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#== Procedure om een activiteit af te sluiten
#== _activitylog_id 		= activiteit welke afgesloten dient te worden
#== _activityresult			= Resultaat van af te sluiten activiteit: COMPLETED, CANCELLED, ABORTED, EXPIRED, BOUNCED

#== Voorbeeld 1, 'OK'
#==
#=============================================================================================================
#== Variabelen definieren 
#=============================================================================================================
DECLARE _followup INT;
DECLARE _activity_id INT;
DECLARE _activityresult_id INT DEFAULT NULL;
DECLARE _activitylog_id_next INT;
#============================================================================================================
#== Bepaal activityresult_id van activiteit welke afgesloten moet worden.
#============================================================================================================
SELECT 	activityresult_id			into _activityresult_id
FROM 	activityresults
WHERE 	activityresults.name 		= _activityresult #<= _activityresult
AND 	activityresults.state		= 'ACTIVE';
#============================================================================================================
#== Bepaal activity_id van activiteit welke afgesloten moet worden.
#== Indien activiteit al is afgesloten, kan deze niet opnieuw worden afgesloten.
#== LET OP: activitylogs.next moet NULL zijn. Bij het 'resetten'van een record hiermee rekening houde !!
#============================================================================================================
SELECT 	activitylogs.activity_id  	into _activity_id
FROM 	activitylogs 
WHERE 	activitylogs.activitylog_id = _activitylog_id #<= _activitylog_id
AND 	activitylogs.next 			is NULL 
AND 	activitylogs.state			= 'ACTIVE';
#============================================================================================================
#== Bepaal opvolgactie van activiteit op basis van resultaat.
#============================================================================================================
SELECT  activities_activityresults.followup_activity_id into _followup
FROM 	activities_activityresults
WHERE 	activities_activityresults.activity_id 			= _activity_id #<= _activity_id
AND 	activities_activityresults.activityresult_id 	= _activityresult_id#<= _activityresult_id
AND 	activities_activityresults.state				= 'ACTIVE';
#============================================================================================================
#== Registratie eindresultaat indien dit niet eerder is gedaan.
#============================================================================================================
IF _activityresult is not NULL AND _activity_id is NOT NULL THEN 
	UPDATE 	activitylogs
	SET 	activitylogs.activityresult_id 	= _activityresult_id, #<= _activityresult_id
			activitylogs.`condition`		= 'COMPLETED',
			activitylogs.conditiondt		= NOW(),
            activitylogs.processdt			= IFNULL(activitylogs.processdt,NOW()),
			activitylogs.enddt 				= NOW()
	WHERE 	activitylogs.activitylog_id 	= _activitylog_id #<= _activitylog_id
	AND 	activitylogs.state				= 'ACTIVE'
	AND 	activitylogs.activityresult_id	is NULL;
END IF;
#============================================================================================================
#== Aanmaken opvolg activiteit indien noodzakelijk, gebaseerd op resultaat
#============================================================================================================
IF _followup is not NULL THEN 
	INSERT IGNORE INTO activitylogs (
						created, activitylogs.`condition`, conditiondt, 
						respondent_id, scan_id,
						activity_id, startdt, former, cm_emailaddress, cm_id)
				SELECT 
				NOW(),
				'READY',
				NOW(),
				respondent_id,
				scan_id,
				_followup,
				NOW(),
				_activitylog_id, #<= _activitylog_id 
				cm_emailaddress,
				cm_id
				FROM 	activitylogs
				WHERE 	activitylogs.activitylog_id = _activitylog_id;
#==
	SET 		_activitylog_id_next = LAST_INSERT_ID();
#==
	UPDATE 		activitylogs 
	SET 		activitylogs.next = _activitylog_id_next,
				activitylogs.enddt = NOW()
	WHERE 		activitylogs.activitylog_id = _activitylog_id;#<= _activitylog_id
#==
END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGenesys
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGenesys`;
DELIMITER ;;
CREATE PROCEDURE `qprodGenesys`(IN `_activitylog_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om e-mail naar Genesys met intentie aan te sturen
# 
# voorbeeld: 	1

DECLARE _hostname varchar(50);
DECLARE _correspondentie tinyint(1) DEFAULT 0; #('Geen', 'Correspondentie', 'Uitvalreden')
DECLARE _respondent_id int(11) DEFAULT 0;
DECLARE _scan_id int(11) DEFAULT 0;
SELECT @@hostname into _hostname;
#**************************************************************************************************
SELECT 			activitylogs.respondent_id into _respondent_id 
FROM 			activitylogs
WHERE 			activitylogs.activitylog_id = _activitylog_id #<_ activitylog_id
AND 			activitylogs.activity_id 	= 300; # alleen bij export Scan

SET 			_respondent_id 	= IFNULL(_respondent_id, 0);

SELECT 			scan_id into _scan_id
FROM 			respondents
WHERE 			respondents.respondent_id = _respondent_id;
#**************************************************************************************************
# Genesys met intentie
#**************************************************************************************************
IF _respondent_id > 0
THEN 
		SELECT 			1 into _correspondentie
		FROM 			respondents
		JOIN 			scans ON (scans.scan_id = respondents.scan_id)
		WHERE 			respondents.respondent_id = _respondent_id #<_respondnet_id
		AND 			respondents.correspondentie = 'Correspondentie';

		IF _correspondentie = 1
		THEN 
			INSERT INTO activitylogs (created, respondent_id, activity_id, conditiondt, scan_id)
			VALUES (NOW(),_respondent_id,201,NOW(), _scan_id);
		END IF;
#**************************************************************************************************
# Genesys ZONDER intentie
#**************************************************************************************************       
# zijn al verstuurd
#ELSE 	
#		SELECT 			1 into _correspondentie
#		FROM 			scans 
#		WHERE 			scans.scan_id = _scan_id #<_scan_id
#		AND 			scans.`condition` = 'INCOMPLETE';		
#
#		IF _correspondentie = 1
#		THEN 
#			INSERT INTO activitylogs (created, scan_id, activity_id, conditiondt, scan_id)
#			VALUES (NOW(),_scan_id,202,NOW(), _scan_id);
#		END IF;
        
END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetBatch
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetBatch`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetBatch`(`_user_id` INT, `_type` varchar(10))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Type = MAIL, FULL, 
#
# voorbeeld: 44,'MAIL'

DECLARE _batch_id INT(11) DEFAULT 0;
DECLARE _batch_id_lock INT(11) DEFAULT 0;
DECLARE _batch_date DATE;

SELECT batch_id into _batch_id_lock FROM userlocks WHERE userlocks.portal_user_id = _user_id AND userlocks.batch_id is not NULL ORDER BY userlocks.created DESC limit 0,1;

#oude lock verwijderen buiten lock batch en scan om voor dezelfde gebruiker
DELETE FROM userlocks WHERE batch_id is NULL AND scan_id is NULL AND portal_user_id = _user_id;
#********************************************************************************************************************
# indien er al een batch is voor deze user, batch_id lezen
SELECT 	batches.batch_id, DATE(batches.created) into _batch_id, _batch_date
FROM 		batches
WHERE 		batches.created_user = _user_id #<_user_id
AND 		batches.state = 'ACTIVE'
AND 		batches.type = _type #<_type
AND 		batches.`condition` = 'OPEN'
ORDER BY 1 DESC 
LIMIT 0,1;

#********************************************************************************************************************
SELECT IFNULL(_batch_id,0) into _batch_id;
SELECT IFNULL(_batch_date, DATE(NOW())) into _batch_date;
#********************************************************************************************************************
# indien er geen batch is voor deze user, een nieuwe bepalen
IF _batch_id = 0 
	THEN 
#	#oude lock verwijderen
	DELETE FROM userlocks WHERE batch_id is NOT NULL AND portal_user_id = _user_id;

	#Nieuw batch aanmaken
	INSERT INTO batches (created, created_user, conditiondt, type) 
				VALUES (NOW(), _user_id, NOW(), _type);
        SELECT LAST_INSERT_ID() into _batch_id;

	SET _batch_id_lock = 1;
END IF; 

IF _batch_id_lock = 0 THEN 
	#nieuwe lock setten
	INSERT INTO userlocks (userlocks.created, userlocks.portal_user_id, userlocks.batch_id)
	SELECT 	NOW(),
					_user_id, #<_user_id
					_batch_id; #<_batch_id

END IF;
#********************************************************************************************************************
#Sluiten overige oude batches
UPDATE 	batches
SET			batches.`condition` 		= 'CLOSED',
				batches.conditiondt 		= NOW(),
				batches.description 		= 'Automatisch gesloten.'
WHERE 	batches.`condition` 		= 'OPEN'
AND 		batches.batch_id 			<> _batch_id
AND     (DATE(batches.conditiondt) 	< DATE(NOW()) OR batches.created_user = _user_id)
AND 		batches.state 				= 'ACTIVE';
UPDATE 	userlocks
SET 		userlocks.created			= NOW()
WHERE 	userlocks.portal_user_id 	= _user_id
AND			userlocks.batch_id			= _batch_id;
#********************************************************************************************************************
#Verwijderen lege & gesloten batches
UPDATE 	batches 
SET 		batches.state 				= 'INACTIVE',
				batches.description 		= 'Automatisch verwijderd, geen respondenten.',
				batches.modified_user 		= NULL,
				batches.modified 			= NOW(),
				batches.respondent_count 	= 0
WHERE 	batches.batch_id NOT IN (SELECT DISTINCT respondents.batch_id FROM respondents )
AND 		batches.`condition` 		= 'CLOSED'
AND 		batches.state 				= 'ACTIVE';
#********************************************************************************************************************
# tabel userlocks 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
#DELETE FROM userlocks
#WHERE 			TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s');
#********************************************************************************************************************
# Actieve batch_id terugleveren
#SELECT batch_id from userlocks where userlocks.portal_user_id = _user_id AND userlocks.batch_id is not null;
SELECT batch_id into _batch_id from userlocks where userlocks.portal_user_id = _user_id AND userlocks.batch_id is not null;
SELECT _batch_id;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetCampaignValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetCampaignValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetCampaignValuesByGroupname`(IN `_campaign_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle waardes van een campagnesettings binnen een groep.
# Indien geen specifieke groupname wordt opgegeven zullen alle worden getoond.
#
# Voorbeeld: 2, 'TEST'
# Voorbeeld: 2, ''

SELECT _campaign_id AS campaign_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
#	sd.grouplabel AS grouplabel,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetCampaignValueByName(_campaign_id, sd.`name`) AS fieldvalue,
    qfuncGetSettingDefaultValues(sd.type, sd.settingdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		settingdefaults AS sd
		JOIN settings AS s ON (sd.setting_id = s.setting_id AND s.`name`='CAMPAIGNS')
		LEFT JOIN datachecks as dc ON (sd.datacheck_id = dc.datacheck_id)
	WHERE (_groupname='' OR sd.groupname=_groupname)
	AND   sd.state = 'ACTIVE'
	ORDER BY
		sd.groupsequence ASC,
		sd.sequence ASC;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetClangValues
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetClangValues`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetClangValues`(IN `_activitylog_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog te clang export values op te halen
# 
# voorbeeld: 	1

DECLARE _productie tinyint(1);
SELECT IF(@@hostname <> 'db217', 0,1) into _productie;

#**************************************************************************************************
SELECT 			1 as sequence,
				'clangtag' as clangfield,
				qfuncGetSystemValueByName(1,'brand') as clangvalue
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			2 as sequence,
				'clangid' ,
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'clangid') #Consumenten email
   					WHEN 203 THEN qfuncGetSystemValueByName(1,'clangid') #Consumenten reminder email
					WHEN 201 THEN qfuncGetSystemValueByName(1,'clangid2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'clangid3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			3 as sequence,
				'clanggroupid' ,
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'clanggroupid') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'clanggroupid') #Consumenten reminder email                    
					WHEN 201 THEN qfuncGetSystemValueByName(1,'clanggroupid2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'clanggroupid3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			4 as sequence,
				'url2' ,
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'sendemail') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'sendemail') #Consumenten reminder email                    
					WHEN 201 THEN qfuncGetSystemValueByName(1,'sendemail2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'sendemail3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			5 as sequence,
				'usp1' ,
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'sendname') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'sendname') #Consumenten reminder email                    
					WHEN 201 THEN qfuncGetSystemValueByName(1,'sendname2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'sendname3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			6 as sequence,
				'usp2' ,
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'replyemail') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'replyemail') #Consumenten reminder email                    
					WHEN 201 THEN qfuncGetSystemValueByName(1,'replyemail2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'replyemail3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			7 as sequence,
				'url1' , #e-mail onderwerp
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'subject') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'subject4') #Consumenten reminder email                    
					WHEN 201 THEN qfuncGetSystemValueByName(1,'subject2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'subject3') #Genesys zonder intentie
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 			8 as sequence,
				'website' , 
				CASE activitylogs.activity_id
					WHEN 200 THEN IF(_productie = 0,
							CONCAT_WS('',qfuncGetSystemValueByName(1,'testselfservice'),'?t=',qfuncGetRespondentDataValues(activitylogs.respondent_id,'token')),
                            CONCAT_WS('',qfuncGetSystemValueByName(1,'selfserviceurl'),'?t=',qfuncGetRespondentDataValues(activitylogs.respondent_id,'token'))) #Consumenten email
					WHEN 203 THEN IF(_productie = 0,
							CONCAT_WS('',qfuncGetSystemValueByName(1,'testselfservice'),'?t=',qfuncGetRespondentDataValues(activitylogs.respondent_id,'token')),
                            CONCAT_WS('',qfuncGetSystemValueByName(1,'selfserviceurl'),'?t=',qfuncGetRespondentDataValues(activitylogs.respondent_id,'token'))) #Consumenten reminder email                    
					WHEN 201 THEN IF(_productie = 0,
							CONCAT_WS('',qfuncGetSystemValueByName(1,'testdownload'),'?t=',qfuncGetScanDataValues(activitylogs.scan_id,'token')),
							CONCAT_WS('',qfuncGetSystemValueByName(1,'scanurl'),'?t=',qfuncGetScanDataValues(activitylogs.scan_id,'token'))) #Genesys met intentie
					WHEN 202 THEN IF(_productie = 0,
							CONCAT_WS('',qfuncGetSystemValueByName(1,'testdownload'),'?t=',qfuncGetScanDataValues(activitylogs.scan_id,'token')),
							CONCAT_WS('',qfuncGetSystemValueByName(1,'scanurl2'),'?t=',qfuncGetScanDataValues(activitylogs.scan_id,'token'))) #Genesys zonder intentie
				END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 	
				9 as sequence,
				'tijd_link', 
				CASE activitylogs.activity_id 
					WHEN 200 THEN qfuncGetSystemValueByName(1,'period')+qfuncGetSystemValueByName(1,'period4') #Consumenten email
					WHEN 203 THEN qfuncGetSystemValueByName(1,'period4') #Consumenten reminder email 
					WHEN 201 THEN qfuncGetSystemValueByName(1,'period2') #Genesys met intentie
					WHEN 202 THEN qfuncGetSystemValueByName(1,'period3') #Genesys zonder intentie                    
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
#**************************************************************************************************
SELECT 	
				10 as sequence,
				'emailAddress', 
				CASE activitylogs.activity_id 
					WHEN 200 THEN 
						IF(_productie = 0,
							IFNULL(IF(qfuncGetSystemValueByName(1,'testemail')='',NULL,qfuncGetSystemValueByName(1,'testemail')),'ketentest@4dms.nl'),
                            qfuncGetRespondentDataValues(activitylogs.respondent_id,'email')) #Consumenten email
					WHEN 203 THEN 
						IF(_productie = 0,
							IFNULL(IF(qfuncGetSystemValueByName(1,'testemail')='',NULL,qfuncGetSystemValueByName(1,'testemail')),'ketentest@4dms.nl'),
                            qfuncGetRespondentDataValues(activitylogs.respondent_id,'email')) #Consumenten email#Consumenten reminder email 
					WHEN 201 THEN 
						IF(_productie = 0,
							IFNULL(IF(qfuncGetSystemValueByName(1,'testemail')='',NULL,qfuncGetSystemValueByName(1,'testemail')),'ketentest@4dms.nl'),
                            qfuncGetSystemValueByName(1,'toemail2')) #Genesys met intentie
					WHEN 202 THEN 
						IF(_productie = 0,
							IFNULL(IF(qfuncGetSystemValueByName(1,'testemail')='',NULL,qfuncGetSystemValueByName(1,'testemail')),'ketentest@4dms.nl'),
                            qfuncGetSystemValueByName(1,'toemail3')) #Genesys zonder intentie                    
                END
FROM 		activitylogs 
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
#**************************************************************************************************
UNION
SELECT
				emailfields.sequence+10,
				emailfields.name,
                IF(activitylogs.activity_id IN (200,203),
					IF(emailfields.sourcetable = 'respondents',
						IF(activitylogs.respondent_id is NULL, 
							NULL,
							qfuncGetRespondentDataValues(activitylogs.respondent_id, emailfields.sourcefield)),
					IF(emailfields.sourcetable = 'campaigns',
						IF(activitylogs.respondent_id is NULL, 
							NULL,
							qfuncGetCampaignDataValues(qfuncGetRespondentDataValues(activitylogs.respondent_id,'campaign_id'), emailfields.sourcefield)),
					IF(emailfields.sourcetable = 'campaignvalues',
						IF(activitylogs.respondent_id is NULL, 
							NULL,
							qfuncGetCampaignValueByName(qfuncGetRespondentDataValues(activitylogs.respondent_id,'campaign_id'), emailfields.sourcefield)),
						''))),
					NULL)
FROM 		activitylogs 
JOIN 		emailfields ON (emailfields.state = 'ACTIVE')
WHERE 		activitylogs.state = 'ACTIVE' 
AND 		activitylogs.activitylog_id = _activitylog_id #<== _activitylog_id
AND 		emailfields.name not in ('clangtag','clangid','clanggroupid','url1','url1','usp1','usp2','Website','emailAddress')
;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetParkedScan
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetParkedScan`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetParkedScan`(`_user_id` INT, `_type` varchar(10))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# 
#
# voorbeeld: 1,'MAIL'

DECLARE _scan_id INT(11) DEFAULT 0;

#oude locks opruimen van andere gebruikers
DELETE 	FROM userlocks
WHERE 	TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s')
AND 	userlocks.portal_user_id <> _user_id; #<_user_id

# tabel userlocks 'opruimen' voor specifieke gebruiker niet zijnde SCAN lock
DELETE FROM userlocks
WHERE 		userlocks.portal_user_id = _user_id AND 
			userlocks.scan_id is not NULL;
 
# indien er al een scan lock is voor deze user, dezelfde scan openen
SELECT 		userlocks.scan_id into _scan_id
FROM 		userlocks
JOIN 		scans ON (scans.scan_id = userlocks.scan_id 
						AND scans.type = _type #<_type
						AND scans.`condition`	= 'PARKED')
LEFT JOIN 	respondents ON (respondents.scan_id = scans.scan_id AND respondents.state = 'ACTIVE')
WHERE 		userlocks.portal_user_id = _user_id #<_user_id
AND 		userlocks.scan_id is not null
AND 		respondents.respondent_id is NULL
ORDER BY 1 
LIMIT 0,1;

# indien er geen scan lock is voor deze user, een nieuwe bepalen
IF _scan_id = 0
	THEN 
		SELECT 	scans.scan_id into _scan_id
		FROM 		scans
		LEFT JOIN userlocks ON (userlocks.scan_id = scans.scan_id)
		LEFT JOIN respondents ON (respondents.scan_id = scans.scan_id AND respondents.state = 'ACTIVE')
		WHERE 	scans.state 			= 'ACTIVE'
		AND 		scans.type 				= _type #<_type
		AND 		scans.`condition`	= 'PARKED'
		AND 		userlocks.userlock_id is NULL
   		AND 		respondents.respondent_id is NULL
		ORDER BY 1
		LIMIT 0,1;
 END IF;

SELECT IFNULL(_scan_id,0) into _scan_id;

#indien er geen scans meer zijn, geen nieuwe ophalen / lock toepassen
IF _scan_id > 0
THEN 
 
	DELETE 	FROM 		userlocks 
	WHERE 		userlocks.portal_user_id = _user_id #<_user_id
	AND 		userlocks.scan_id is not NULL; 

	INSERT INTO userlocks (userlocks.created, userlocks.portal_user_id, userlocks.scan_id)
	SELECT 	
			NOW(),
			_user_id, #<_user_id
			_scan_id; #<_scan_id
 
END IF;

SELECT _scan_id;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetProcessorProcessingData
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetProcessorProcessingData`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetProcessorProcessingData`(IN `_processor` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# wordt gebruikt om records te bepalen voor het uitvoeren van een automtisch proces
# voorbeeld:  'EXPORT_WEBSERVICE'

SELECT 			
				activities.name as 'activity', 
				activities.activity_id,
				activitylogs.respondent_id,
				activitylogs.activitylog_id,
				activitylogs.`condition`,
				activitylogs.created,
				activitylogs.startdt,
				activitylogs.processdt,
				activitylogs.enddt,
				activitylogs.former,
				activitylogs.next,
				activities.timelimit,
				activities.timedeadline

FROM 		activitylogs
JOIN 		activities ON (
				activities.activity_id = activitylogs.activity_id AND 
				activities.state = 'ACTIVE')
JOIN 		processors ON (
				processors.processor_id = activities.processor_id AND 
				processors.name = _processor AND #<=== _processor
				processors.state = 'ACTIVE')
#JOIN 		respondents ON (
#				respondents.respondent_id = activitylogs.respondent_id AND
#				respondents.state = 'ACTIVE')
WHERE 		activitylogs.state = 'ACTIVE'
AND 		activitylogs.processdt is NULL
AND 		activitylogs.`condition` = 'PROCESSING';

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetProcessorReset1
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetProcessorReset1`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetProcessorReset1`(IN `_processor_id` int(11))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN  

UPDATE activitylogs 
JOIN activities ON (activities.activity_id = activitylogs.activity_id AND activities.state = 'ACTIVE' AND activities.processor_id = _processor_id)
SET activitylogs.processdt = NULL 
WHERE
	activitylogs.state = 'ACTIVE' AND
	activitylogs.`condition`='PROCESSING' AND
	activitylogs.enddt is NULL;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetProcessorReset2
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetProcessorReset2`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetProcessorReset2`(IN `_processor_id` int(11))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN  

UPDATE activitylogs 
JOIN activities ON (activities.activity_id = activitylogs.activity_id AND activities.state = 'ACTIVE' AND activities.processor_id = _processor_id)
SET activitylogs.processdt = NULL, activitylogs.`condition` = 'PROCESSING',	activitylogs.startdt = IFNULL(startdt, NOW())
WHERE
	activitylogs.state = 'ACTIVE' AND
	activitylogs.`condition` in ('READY','READY_LATE','READY_ERROR');

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetProcessorReset3
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetProcessorReset3`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetProcessorReset3`(IN `_processor_id` int(11))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# =========================== 
# registreren wanneer deze processor wordt aangesproken
# ===========================

UPDATE processors
SET	processors.lastrunstart = NOW(),
		processors.lastrunend	= NULL
WHERE
 	processors.processor_id	= _processor_id; #<== _processor


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetProcessorReset4
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetProcessorReset4`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetProcessorReset4`(IN `_processor_id` int(11))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  

SELECT count(1) as records
FROM activitylogs
JOIN activities ON (activities.activity_id = activitylogs.activity_id AND activities.state = 'ACTIVE' AND activities.processor_id = _processor_id)
WHERE 
  activitylogs.state = 'ACTIVE' AND
	activitylogs.`condition` ='PROCESSING' AND
	activitylogs.processdt is null;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetScan
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetScan`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetScan`(`_user_id` INT, `_type` varchar(10))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN   
# 
#
# voorbeeld: 1,'MAIL'

DECLARE _scan_id INT(11) DEFAULT 0;
DECLARE _setlock tinyint(1) DEFAULT 1;

#oude locks opruimen van andere gebruikers (muv batch)
DELETE 	FROM userlocks
WHERE 	TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s')
AND 		userlocks.portal_user_id <> _user_id AND userlocks.batch_id is not NULL;
 
# indien er al een scan lock is voor deze user, dezelfde scan openen
SELECT 	userlocks.scan_id into _scan_id
FROM 		userlocks
JOIN 		scans ON (scans.scan_id = userlocks.scan_id 
						AND scans.type = _type #<_type
						AND scans.`condition`	= 'AVAILABLE')
LEFT JOIN 	respondents ON (respondents.scan_id = scans.scan_id AND respondents.state = 'ACTIVE')
WHERE 		userlocks.portal_user_id = _user_id #<_user_id
AND 		userlocks.scan_id is not null
AND 		respondents.respondent_id is NULL
ORDER BY 1 
LIMIT 0,1;

# indien geen scan gevonden, dan eventueel nog aanwezige scan locks (met condition<>'AVAILABLE') verwijderen voor deze user
IF _scan_id = 0 THEN
	DELETE 	FROM userlocks
	WHERE 	userlocks.portal_user_id = _user_id AND userlocks.scan_id is not NULL;
END IF;

# indien er geen scan lock is voor deze user, een nieuwe bepalen
SELECT IFNULL(_scan_id,0) into _scan_id; ########################################################
IF _scan_id = 0
	THEN 
		# tabel userlocks 'opruimen' voor specifieke gebruiker niet zijnde SCAN lock of batch lock
		DELETE FROM userlocks
		WHERE 		userlocks.portal_user_id = _user_id AND 
							userlocks.scan_id is not NULL AND userlocks.batch_id is not null;

		SELECT 	scans.scan_id into _scan_id
		FROM 		scans
		LEFT JOIN userlocks ON (userlocks.scan_id = scans.scan_id)
		LEFT JOIN respondents ON (respondents.scan_id = scans.scan_id AND respondents.state = 'ACTIVE')
		WHERE 	scans.state 			= 'ACTIVE'
		AND 		scans.type 				= _type #<_type
		AND 		scans.`condition`	= 'AVAILABLE'
		AND 		userlocks.userlock_id is NULL 
		AND 		respondents.respondent_id is NULL
		ORDER BY 1
		LIMIT 0,1;

		SET _setlock = 0;

 END IF;

#indien er geen scans meer zijn, geen nieuwe ophalen / lock toepassen
SELECT IFNULL(_scan_id,0) into _scan_id; ########################################################

IF _setlock = 0 THEN 

	INSERT INTO userlocks (userlocks.created, userlocks.portal_user_id, userlocks.scan_id)
	SELECT 	NOW(),
					_user_id, #<_user_id
					_scan_id ;#<_scan_id
END IF;

# Actieve scan_id terugleveren
#SELECT scan_id from userlocks where userlocks.portal_user_id = _user_id AND userlocks.scan_id is not null;
SELECT scan_id into _scan_id from userlocks where userlocks.portal_user_id = _user_id AND userlocks.scan_id is not null;
SELECT _scan_id;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetSystemValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetSystemValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetSystemValuesByGroupname`(IN `_system_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle waardes van systemsettings binnen een groep.
# Indien geen specifieke groupname wordt opgegeven zullen alle worden getoond.
#
# Voorbeeld: 2, 'Projectmanager'
# Voorbeeld: 2, ''

SELECT _system_id AS system_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
#	sd.grouplabel AS grouplabel,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetSystemValueByName(_system_id, sd.`name`) AS fieldvalue,
    qfuncGetSettingDefaultValues(sd.type, sd.settingdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		settingdefaults AS sd
		JOIN settings AS s ON (sd.setting_id = s.setting_id AND s.`name`='SYSTEM')
		LEFT JOIN datachecks as dc ON (sd.datacheck_id = dc.datacheck_id)
	WHERE (_groupname='' OR sd.groupname=_groupname)
	AND   sd.state = 'ACTIVE'
	ORDER BY
		sd.groupsequence ASC,
		sd.sequence ASC;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetUserSpeed
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetUserSpeed`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetUserSpeed`(IN `_user_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de invoersnelheid te bepalen
# 
# voorbeeld: 	1

#**************************************************************************************************
SELECT 		created_user,
					jaar,
					maand,
					type,
					SEC_TO_TIME(ROUND(avg(gemiddeld_seconden))) as snelheid_per_awk,
					count(distinct batch_id) as aantal_batches,
					sum(batch_aantal) as invoer_awk_aantal
FROM 			(
		SELECT 		YEAR(batchdate) as jaar,
							MONTH(batchdate) as maand,
							batch_id, type, created_user,
							AVG(TIME_TO_SEC((TIMEDIFF(created2,created)))) gemiddeld_seconden,
							max(batch_aantal) as batch_aantal
		FROM 			(			
				SELECT 			respondents.batch_id, batches.type, 
										batches.created as batchdate,
										respondents.created_user,
										respondents.created,
										min(respondents2.respondent_id) as respondent_id2,
										min(respondents2.created) as created2,
										(count(respondents.respondent_id))+1 as batch_aantal
				FROM 				respondents
				JOIN 				batches ON (
											batches.batch_id						= respondents.batch_id AND 
											batches.`condition`					IN ('CLOSED', 'CHECKED','EXPORTED') AND
											batches.state 							= 'ACTIVE')
				JOIN				respondents respondents2 ON (
											respondents2.batch_id 			= respondents.batch_id AND 
											respondents2.created_user		= respondents2.created_user AND 
											respondents.respondent_id		< respondents2.respondent_id AND 
											respondents2.state 					= 'ACTIVE') 
				WHERE 			respondents.state 						= 'ACTIVE'
				AND 				respondents.created_user			= _user_id #<_user_id
				GROUP BY 1,2,3,4,5
							) total_entry
		GROUP BY 1,2,3,4,5
					) total_time
GROUP BY 1,2,3,4;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeCampaignSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeCampaignSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeCampaignSettings`( `_campaign_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	2

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO campaignvalues											
				(	settingdefault_id,
					created,
					campaign_id,									
					value_string,
					value_integer,
					value_decimal,
					value_boolean,
					value_datetime,
					value_date,
					value_time,
					value_text
				)
SELECT 		settingdefaults.settingdefault_id, 
					NOW(),
					_campaign_id, 									#<==== _campaign_id
					settingdefaults.default_string,
					settingdefaults.default_integer,
					settingdefaults.default_decimal,
					settingdefaults.default_boolean,
					settingdefaults.default_datetime,
					settingdefaults.default_date,
					settingdefaults.default_time,
					settingdefaults.default_text
FROM 			settings 
JOIN 		settingdefaults ON (
					settingdefaults.setting_id = settings.setting_id AND 
					settingdefaults.state = 'ACTIVE')
WHERE 		settings.name = 'CAMPAIGNS'  							#<=== SETTING
AND  			settings.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string=default_string,
			value_integer=default_integer,
			value_decimal=default_decimal,
			value_boolean=default_boolean, 
			value_datetime=default_datetime,
			value_date=default_date,
			value_time=default_time,
			value_text=default_text;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodLockCleansing
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodLockCleansing`;
DELIMITER ;;
CREATE PROCEDURE `qprodLockCleansing`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# tabel userlocks 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
#
DELETE FROM userlocks
WHERE 		TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s');
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodLockClear
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodLockClear`;
DELIMITER ;;
CREATE PROCEDURE `qprodLockClear`(IN `_user_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# tabel userlocks 'opruimen' voor specifieke gebruiker en alles wat ouder is dan de ingeregelde tijd
#
DELETE FROM userlocks
WHERE 		portal_user_id = _user_id OR 
			TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s');
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodLockRecord
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodLockRecord`;
DELIMITER ;;
CREATE PROCEDURE `qprodLockRecord`(IN `_user_id` int, IN `_id` int, IN `_type` varchar(50))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
#
# Het locken van een record in tabel userlocks
#
# voorbeeld 1,1,'campaign_id'
#
DECLARE _scan_id int;
# tabel userlocks 'opruimen' voor alles wat ouder is dan de ingeregelde tijd
DELETE FROM userlocks
WHERE 			TIMEDIFF(NOW(),created) > STR_TO_DATE(qfuncGetSystemValueByName(1,'locktime'), '%H:%i:%s');

#oude lock verwijderen
set @kweerie_del = 	CONCAT_WS(	'',
							'DELETE FROM userlocks WHERE ',
							_type,
							' is not NULL AND portal_user_id = ',
							_user_id
						);

PREPARE uitvoeren_del FROM @kweerie_del;

EXECUTE uitvoeren_del;

commit;

#nieuwe lock setten
set @kweerie = 	CONCAT_WS(	'',
			  				'INSERT INTO userlocks (created, portal_user_id,',
		  					_type,
   							') ',
							  'SELECT	NOW(),',
							  _user_id,', ',
						  	_id,
							  ' ON DUPLICATE KEY UPDATE ',
								'created = NOW(),',
								'portal_user_id = ', _user_id,',',
								_type ,' = ', _id 
						);

PREPARE uitvoeren FROM @kweerie;

EXECUTE uitvoeren;

# In bepaaldegevallen ook de lock op de scan zetten
IF _type = 'respondent_id'
	THEN SELECT scan_id into _scan_id from respondents where respondents.respondent_id = _id;
	#nieuwe lock setten op de scan
	set @kweerie = 	CONCAT_WS(	'',
								'INSERT INTO userlocks (created, portal_user_id,',
								'scan_id',
								') ',
								'SELECT	NOW(),',
								_user_id,', ',
								_scan_id, 
								' ON DUPLICATE KEY UPDATE ',
								'created = NOW(),',
								'portal_user_id = ', _user_id,',',
								'scan_id = ', _scan_id 
								);
	PREPARE uitvoeren FROM @kweerie;

	EXECUTE uitvoeren;    
		
END IF;     

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodMailImportsToMails
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodMailImportsToMails`;
DELIMITER ;;
CREATE PROCEDURE `qprodMailImportsToMails`(IN `_file_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
            INSERT IGNORE INTO campaigns (created, name, type)
            (SELECT NOW(), actiecode1, "MAIL" FROM mail_imports GROUP BY actiecode1);

            INSERT INTO mails (created, file_id, refnr, programma, actiecode1, actiecode2, actiecode3, actiecode4, actiecode5, contentcode1, contentcode2, contentcode3, contentcode4, contentcode5, zp, voorletters, tussenvoegsel, achternaam, geslacht, titel, geboortedatum, bedrijfsnaam, kvk, correspondentie_straat, correspondentie_nummer, correspondentie_toevoeg, correspondentie_postcode, correspondentie_plaats, correspondentie_land, aansluit_straat, aansluit_nummer, aansluit_toevoeg, aansluit_postcode, aansluit_plaats, aansluit_land, telefoon_vast, telefoon_mobiel, telefoon_werk, email, username, woonbestemming, type, klantlabel, actief, contractrek, contractrekeningnummer, behoeftesegment, waardesegment, klantwaarde, betalingswijze, voorkeursdatum_ai, rekeningnummer, contractnummer_stroom, product_stroom, tarieftype_stroom, verbruik_stroom_hoog, ean_stroom, verbruiktype_s, netbeheerder_stroom, fysieke_capaciteit_s, begindatum_stroom, einddatum_stroom, verbruik_stroom_laag, exitdatum_stroom, contractnummer_gas, product_gas, tarieftype_gas, ean_gas, verbruiktype_g, netbeheerder_gas, fysieke_capaciteit_g, begindatum_gas, einddatum_gas, verbruik_gas, gasregio, exitdatum_gas, termijnbedrag, klacht, kc_kanaal, kc_categorie, kc_onderwerp, kc_datum, koophuur, type_woning, bouwjaar_woning, cv_ketel_bouwjaar, profiel_1_def, profiel_1_waarde, profiel_2_def, profiel_2_waarde, profiel_3_def, profiel_3_waarde, profiel_4_def, profiel_4_waarde, profiel_5_def, profiel_5_waarde, profiel_6_def, profiel_6_waarde, profiel_7_def, profiel_7_waarde, profiel_8_def, profiel_8_waarde, profiel_9_def, profiel_9_waarde, profiel_10_def, profiel_10_waarde, profiel_11_def, profiel_11_waarde, profiel_12_def, profiel_12_waarde, profiel_13_def, profiel_13_waarde, profiel_14_def, profiel_14_waarde, profiel_15_def, profiel_15_waarde, profiel_16_def, profiel_16_waarde, profiel_17_def, profiel_17_waarde, profiel_18_def, profiel_18_waarde, profiel_19_def, profiel_19_waarde, profiel_20_def, profiel_20_waarde, profiel_vraag_1, profiel_vraag_2, profiel_vraag_3, profiel_vraag_4, profiel_vraag_5, reserveveld_1, reserveveld_2, reserveveld_3, reserveveld_4, reserveveld_5, reserveveld_6, reserveveld_7, reserveveld_8, reserveveld_9, reserveveld_10, reserveveld_11, reserveveld_12, reserveveld_13, reserveveld_14, reserveveld_15, reserveveld_16, reserveveld_17, reserveveld_18, reserveveld_19, reserveveld_20, reserveveld_21, reserveveld_22, reserveveld_23, reserveveld_24, reserveveld_25, reserveveld_26, reserveveld_27, reserveveld_28, reserveveld_29, reserveveld_30, reserveveld_31, reserveveld_32, reserveveld_33, reserveveld_34, reserveveld_35, reserveveld_36, reserveveld_37, ppc_stroom, ppc_gas, ac1_aanbod1_ppc_stroom, ac1_aanbod1_ppc_gas, ac1_aanbod2_ppc_stroom, ac1_aanbod2_ppc_gas, ac1_aanbod3_ppc_stroom, ac1_aanbod3_ppc_gas, ac1_aanbod4_ppc_stroom, ac1_aanbod4_ppc_gas, teruglevering, teruglevering_hoog, teruglevering_laag, ac1_chb_tot_ex, ac1_chb_tot_in, branche, reserveveld_38, reserveveld_39, reserveveld_40, reserveveld_41, reserveveld_42, reserveveld_43, reserveveld_44, reserveveld_45, reserveveld_46, reserveveld_47, reserveveld_48, reserveveld_49, reserveveld_50, reserveveld_51, reserveveld_52, reserveveld_53, reserveveld_54, bmnr_downloaddatum, bmnr_max_bellen_tot, partij, test, prioriteiten, gewenste_actie, status, status_reden)
            (SELECT NOW(), _file_id, refnr, programma, actiecode1, actiecode2, actiecode3, actiecode4, actiecode5, contentcode1, contentcode2, contentcode3, contentcode4, contentcode5, zp, voorletters, tussenvoegsel, achternaam, geslacht, titel, geboortedatum, bedrijfsnaam, kvk, correspondentie_straat, correspondentie_nummer, correspondentie_toevoeg, correspondentie_postcode, correspondentie_plaats, correspondentie_land, aansluit_straat, aansluit_nummer, aansluit_toevoeg, aansluit_postcode, aansluit_plaats, aansluit_land, telefoon_vast, telefoon_mobiel, telefoon_werk, email, username, woonbestemming, type, klantlabel, actief, contractrek, contractrekeningnummer, behoeftesegment, waardesegment, klantwaarde, betalingswijze, voorkeursdatum_ai, rekeningnummer, contractnummer_stroom, product_stroom, tarieftype_stroom, verbruik_stroom_hoog, ean_stroom, verbruiktype_s, netbeheerder_stroom, fysieke_capaciteit_s, begindatum_stroom, einddatum_stroom, verbruik_stroom_laag, exitdatum_stroom, contractnummer_gas, product_gas, tarieftype_gas, ean_gas, verbruiktype_g, netbeheerder_gas, fysieke_capaciteit_g, begindatum_gas, einddatum_gas, verbruik_gas, gasregio, exitdatum_gas, termijnbedrag, klacht, kc_kanaal, kc_categorie, kc_onderwerp, kc_datum, koophuur, type_woning, bouwjaar_woning, cv_ketel_bouwjaar, profiel_1_def, profiel_1_waarde, profiel_2_def, profiel_2_waarde, profiel_3_def, profiel_3_waarde, profiel_4_def, profiel_4_waarde, profiel_5_def, profiel_5_waarde, profiel_6_def, profiel_6_waarde, profiel_7_def, profiel_7_waarde, profiel_8_def, profiel_8_waarde, profiel_9_def, profiel_9_waarde, profiel_10_def, profiel_10_waarde, profiel_11_def, profiel_11_waarde, profiel_12_def, profiel_12_waarde, profiel_13_def, profiel_13_waarde, profiel_14_def, profiel_14_waarde, profiel_15_def, profiel_15_waarde, profiel_16_def, profiel_16_waarde, profiel_17_def, profiel_17_waarde, profiel_18_def, profiel_18_waarde, profiel_19_def, profiel_19_waarde, profiel_20_def, profiel_20_waarde, profiel_vraag_1, profiel_vraag_2, profiel_vraag_3, profiel_vraag_4, profiel_vraag_5, reserveveld_1, reserveveld_2, reserveveld_3, reserveveld_4, reserveveld_5, reserveveld_6, reserveveld_7, reserveveld_8, reserveveld_9, reserveveld_10, reserveveld_11, reserveveld_12, reserveveld_13, reserveveld_14, reserveveld_15, reserveveld_16, reserveveld_17, reserveveld_18, reserveveld_19, reserveveld_20, reserveveld_21, reserveveld_22, reserveveld_23, reserveveld_24, reserveveld_25, reserveveld_26, reserveveld_27, reserveveld_28, reserveveld_29, reserveveld_30, reserveveld_31, reserveveld_32, reserveveld_33, reserveveld_34, reserveveld_35, reserveveld_36, reserveveld_37, ppc_stroom, ppc_gas, ac1_aanbod1_ppc_stroom, ac1_aanbod1_ppc_gas, ac1_aanbod2_ppc_stroom, ac1_aanbod2_ppc_gas, ac1_aanbod3_ppc_stroom, ac1_aanbod3_ppc_gas, ac1_aanbod4_ppc_stroom, ac1_aanbod4_ppc_gas, teruglevering, teruglevering_hoog, teruglevering_laag, ac1_chb_tot_ex, ac1_chb_tot_in, branche, reserveveld_38, reserveveld_39, reserveveld_40, reserveveld_41, reserveveld_42, reserveveld_43, reserveveld_44, reserveveld_45, reserveveld_46, reserveveld_47, reserveveld_48, reserveveld_49, reserveveld_50, reserveveld_51, reserveveld_52, reserveveld_53, reserveveld_54, bmnr_downloaddatum, bmnr_max_bellen_tot, partij, test, prioriteiten, gewenste_actie, status, status_reden FROM mail_imports);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodMultisites
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodMultisites`;
DELIMITER ;;
CREATE PROCEDURE `qprodMultisites`(IN `_mail_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
SELECT
	`mails`.`mail_id` AS `mail_id`,
	`mails`.`refnr` AS `refnr`,
	`mails`.`actiecode1` AS `actiecode1`,
	count(1) AS `multisites`,
	group_concat(`mails2`.`mail_id` ORDER BY 1 ASC SEPARATOR ',') AS `multi_mail_id`
FROM
	(`mails` JOIN `mails` `mails2` ON(((`mails2`.`zp` = `mails`.`zp`) AND(`mails2`.`file_id` = `mails`.`file_id`) AND(`mails2`.`actiecode1` = `mails`.`actiecode1`))))
WHERE mails.mail_id=_mail_id and mails.zp <> '10000000'
GROUP BY
	1,
	2,
	3
HAVING
	(`multisites` > 1);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodParkScanWithRespondent
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodParkScanWithRespondent`;
DELIMITER ;;
CREATE PROCEDURE `qprodParkScanWithRespondent`(IN `_scan_id` int,IN `_user_id` int,IN `_respondent_id` int,IN `_batch_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
            DECLARE scantype VARCHAR(10) DEFAULT 'MAIL';
            DECLARE newBatchId INT;
            DECLARE batchCount INT DEFAULT 0;
            DECLARE batchOpen INT DEFAULT 0;

            SELECT respondent_count INTO batchCount FROM batches WHERE batch_id=_batch_id AND `condition` = 'CLOSED';
            SELECT 1 INTO batchOpen FROM batches WHERE batch_id=_batch_id AND `condition` = 'OPEN';

            IF batchOpen = 1 OR batchCount > 1 THEN
                        SELECT type INTO scantype FROM scans WHERE scan_id = _scan_id;

                        INSERT INTO batches (created, created_user, `condition`, conditiondt, respondent_count, type) VALUES (NOW(), _user_id, 'CLOSED', NOW(), 1, scantype);

                        SELECT LAST_INSERT_ID() INTO newBatchId;

                        UPDATE respondents SET batch_id=newBatchId WHERE respondent_id=_respondent_id;

                        UPDATE batches SET respondent_count=respondent_count-1 WHERE batch_id=_batch_id;

                        DELETE FROM batchrespondentchecks WHERE respondent_id=_respondent_id;
            END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodReportInvoice
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodReportInvoice`;
DELIMITER ;;
CREATE PROCEDURE `qprodReportInvoice`(IN `_year` int, `_month` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de de gegevens voor het facturatie rapport op te halen
# 
# voorbeeld: 	1

SELECT 	'4. Scans ingelezen in applicatie' as 'Onderdeel',
		YEAR(scans.created) as jaar,
		MONTH(scans.created) as maand,
		count(1) as aantal
FROM 	scans
WHERE 	scans.state 	= 'ACTIVE'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #========================================================================= 
SELECT 	'6. AWKs uitgeleverd <b>FDE</b>',
				YEAR(activitylogs.enddt) as jaar,
				MONTH(activitylogs.enddt) as maand,
				count(1) as aantal
FROM 		respondents
JOIN 		activitylogs ON (activitylogs.respondent_id = respondents.respondent_id AND activitylogs.state = 'ACTIVE' AND activitylogs.activity_id = 101 AND activitylogs.`condition` = 'COMPLETED' AND activitylogs.activityresult_id = 2)
JOIN 		scans ON (scans.scan_id = respondents.scan_id AND scans.type = 'FULL')
WHERE 	respondents.state 	= 'ACTIVE'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #========================================================================= 
SELECT 	'5. AWKs uitgeleverd <b>RB</b>',
				YEAR(activitylogs.enddt) as jaar,
				MONTH(activitylogs.enddt) as maand,
				count(1) as aantal
FROM 		respondents
JOIN 		activitylogs ON (activitylogs.respondent_id = respondents.respondent_id AND activitylogs.state = 'ACTIVE' AND activitylogs.activity_id = 100 AND activitylogs.`condition` = 'COMPLETED' AND activitylogs.activityresult_id = 2)
JOIN 		scans ON (scans.scan_id = respondents.scan_id AND scans.type = 'MAIL')
WHERE 	respondents.state 	= 'ACTIVE'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #========================================================================= 
SELECT 	'1. Ingeregelde actiecodes <b>FDE</b>',
				YEAR(campaigns.created) as jaar,
				MONTH(campaigns.created) as maand,
				count(1) as aantal
FROM 		campaigns
WHERE 	campaigns.state = 'ACTIVE'
AND 		campaigns.type	= 'FULL'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #========================================================================= 
SELECT 	'2. Gewijzigde actiecodes <b>MAIL</b>',
				YEAR(campaigns.modified) as jaar,
				MONTH(campaigns.modified) as maand,
				count(1) as aantal
FROM 		campaigns
WHERE 	campaigns.state = 'ACTIVE'
AND 		campaigns.type	= 'MAIL'
AND 		campaigns.type2 IN ('ADDONONLY','VERHUIZEN')
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #========================================================================= 
SELECT 	'3. Ingeregelde producten <b>FDE</b>',
				YEAR(campaignproducts.created) as jaar,
				MONTH(campaignproducts.created) as maand,
				count(1) as aantal
FROM 		campaignproducts
WHERE 	campaignproducts.state = 'ACTIVE'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #=========================================================================
SELECT 	'7. Batches goedgekeurde',
				YEAR(batches.conditiondt) as jaar,
				MONTH(batches.conditiondt) as maand,
				count(1) as aantal
FROM 		batches
WHERE 	batches.state = 'ACTIVE'
AND 		batches.`condition` = 'CHECKED'
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
UNION #=========================================================================
SELECT 	'8. AWKs gecontroleerde',
				YEAR(batchrespondentchecks.modified) as jaar,
				MONTH(batchrespondentchecks.modified) as maand,
				count(1) as aantal
FROM 		batchrespondentchecks
WHERE 	batchrespondentchecks.state = 'ACTIVE'
AND 		batchrespondentchecks.`checked` = 1
GROUP BY 1,2,3
HAVING 	jaar = _year AND maand = _month
#===============================================================================
ORDER BY 1,2 DESC,3 DESC;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodReportResponse
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodReportResponse`;
DELIMITER ;;
CREATE PROCEDURE `qprodReportResponse`(IN `_date_from` date,IN `_date_to` date)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Routine body goes here...
	SELECT 	datum,
					created_user,
					MAX(IF(type = 'FULL', count_respondents, NULL)) as full_respons_count,
					MAX(IF(type = 'FULL', total_time, NULL)) as full_total_time,
					TIME_FORMAT(MAX(IF(type = 'FULL', avg_card_time, NULL)),'%H:%i:%s') as full_avg_card_time,

					MAX(IF(type = 'MAIL', count_respondents, NULL)) as mail_respons_count,
					MAX(IF(type = 'MAIL', total_time, NULL)) as mail_total_time,

					TIME_FORMAT(MAX(IF(type = 'MAIL', avg_card_time, NULL)),'%H:%i:%s') as mail_avg_card_time

	FROM (

			SELECT 	
							datum,
							created_user,
							type,
							SUM(count_respondents) as count_respondents,
							SEC_TO_TIME(SUM(TIME_TO_SEC(batch_time))) as total_time,
							SEC_TO_TIME(AVG(avg_time)) as avg_card_time
			FROM (
					SELECT 	DATE(respondents.created) as datum,
									respondents.created_user,
									respondents.batch_id,
									batches.type,
									count(respondents.respondent_id) as count_respondents,
									TIMEDIFF(max(respondents.created), min(respondents.created)) as batch_time,
									TIME_TO_SEC(TIMEDIFF(max(respondents.created),min(respondents.created)))/count(respondents.respondent_id) 'avg_time'
					FROM 		respondents 
					JOIN 		batches ON (batches.batch_id = respondents.batch_id)
					WHERE 	respondents.state = 'ACTIVE' AND batches.type = 'FULL'
					AND 		DATE(respondents.created) BETWEEN DATE_ADD(DATE(NOW()),INTERVAL -60 DAY) AND DATE(NOW())
					GROUP BY 1,2,3,4
						) FULL_SELECTION 
			GROUP BY 1,2,3

			UNION 

			SELECT 	
							datum,
							created_user,
							type,
							SUM(count_respondents) as count_respondents,
							SEC_TO_TIME(SUM(TIME_TO_SEC(batch_time))) as total_time,
							SEC_TO_TIME(AVG(avg_time)) as avg_card_time
			FROM (
					SELECT 	DATE(respondents.created) as datum,
									respondents.created_user,
									respondents.batch_id,
									batches.type,
									count(respondents.respondent_id) as count_respondents,
									TIMEDIFF(max(respondents.created), min(respondents.created)) as batch_time,
									TIME_TO_SEC(TIMEDIFF(max(respondents.created),min(respondents.created)))/count(respondents.respondent_id) 'avg_time'
					FROM 		respondents 
					JOIN 		batches ON (batches.batch_id = respondents.batch_id)
					WHERE 	respondents.state = 'ACTIVE' AND batches.type = 'MAIL'
					AND 		DATE(respondents.created) BETWEEN DATE_ADD(DATE(NOW()),INTERVAL -60 DAY) AND DATE(NOW())
					GROUP BY 1,2,3,4
						) FULL_SELECTION 
			GROUP BY 1,2,3
			) report

	WHERE
		(_date_from IS NULL OR datum >= _date_from) AND
		(_date_to IS NULL OR datum <= _date_to)
	GROUP BY 1,2
	ORDER BY 1 DESC, 2 DESC, 3;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodStartProcessor
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodStartProcessor`;
DELIMITER ;;
CREATE PROCEDURE `qprodStartProcessor`(IN `_processor` varchar(50))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 

# Start verwerking registreren 
# 
# voorbeeld: 'EMAIL'

UPDATE 		processors
SET 		processors.lastrunstart = NOW(),
			processors.lastrunend = NULL
WHERE 		processors.state 	= 'ACTIVE'
AND 		processors.name		= _processor;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodStopProcessor
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodStopProcessor`;
DELIMITER ;;
CREATE PROCEDURE `qprodStopProcessor`(IN `_processor` varchar(50))
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 

# Eind verwerking registreren
# 
# voorbeeld: 'EMAIL'

UPDATE 		processors
SET			processors.lastrunend = NOW()
WHERE 		processors.state 	= 'ACTIVE'
AND 		processors.name		= _processor;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncCheckMultisite
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncCheckMultisite`;
DELIMITER ;;
CREATE FUNCTION `qfuncCheckMultisite`(`_respondent_id` int(11)) RETURNS varchar(25) CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt in het controleren of er multisite getoond moet worden op de selfservice pagina. 
# 
# voorbeeld:    124

DECLARE _returnvalue varchar(25);

#SELECT 	IF(count(multisites.respondent_id) > 0,
#					IF(IFNULL(sum(multisites.selected),1) > 0,
#						0,
#						1),
#					0) into _returnvalue
#FROM 		multisites
#WHERE 	multisites.respondent_id = _respondent_id;#<_respondent_id

SELECT 	IF(count(multisites.respondent_id) > 0,1,0) into _returnvalue
FROM 		multisites
WHERE 	multisites.respondent_id = _respondent_id;#<_respondent_id


CASE _returnvalue
	WHEN 0 THEN set _returnvalue = 'DENIED';
	ELSE set _returnvalue = 'OK';
END CASE;

RETURN 	_returnvalue;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncCheckPPCMailImports
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncCheckPPCMailImports`;
DELIMITER ;;
CREATE FUNCTION `qfuncCheckPPCMailImports`() RETURNS int(11)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
            DECLARE _out INT DEFAULT 0;

            SELECT COUNT(1) INTo _out FROM (
                        SELECT
                        mi.ac1_aanbod1_ppc_stroom,
                        mi.ac1_aanbod1_ppc_gas,
                        mi.ac1_aanbod2_ppc_stroom,
                        mi.ac1_aanbod2_ppc_gas,
                        mi.ac1_aanbod3_ppc_stroom,
                        mi.ac1_aanbod3_ppc_gas,
                        mi.ac1_aanbod4_ppc_stroom,
                        mi.ac1_aanbod4_ppc_gas
                        FROM
                        mail_imports AS mi
                        LEFT JOIN upbs AS u1 ON mi.ac1_aanbod1_ppc_stroom = u1.upb_c
                        LEFT JOIN upbs AS u2 ON mi.ac1_aanbod1_ppc_gas = u2.upb_c
                        LEFT JOIN upbs AS u3 ON mi.ac1_aanbod2_ppc_stroom = u3.upb_c
                        LEFT JOIN upbs AS u4 ON mi.ac1_aanbod2_ppc_gas = u4.upb_c
                        LEFT JOIN upbs AS u5 ON mi.ac1_aanbod3_ppc_stroom = u5.upb_c
                        LEFT JOIN upbs AS u6 ON mi.ac1_aanbod3_ppc_gas = u6.upb_c
                        LEFT JOIN upbs AS u7 ON mi.ac1_aanbod4_ppc_stroom = u7.upb_c
                        LEFT JOIN upbs AS u8 ON mi.ac1_aanbod4_ppc_gas = u8.upb_c
                        WHERE
                        (mi.ac1_aanbod1_ppc_stroom IS NOT NULL AND u1.upb_c IS NULL) OR
                        (mi.ac1_aanbod1_ppc_gas IS NOT NULL AND u2.upb_c IS NULL) OR
                        (mi.ac1_aanbod2_ppc_stroom IS NOT NULL AND u3.upb_c IS NULL) OR
                        (mi.ac1_aanbod2_ppc_gas IS NOT NULL AND u4.upb_c IS NULL) OR
                        (mi.ac1_aanbod3_ppc_stroom IS NOT NULL AND u5.upb_c IS NULL) OR
                        (mi.ac1_aanbod3_ppc_gas IS NOT NULL AND u6.upb_c IS NULL) OR
                        (mi.ac1_aanbod4_ppc_stroom IS NOT NULL AND u7.upb_c IS NULL) OR
                        (mi.ac1_aanbod4_ppc_gas IS NOT NULL AND u8.upb_c IS NULL)
            ) x;

            RETURN _out;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncCheckProcessor
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncCheckProcessor`;
DELIMITER ;;
CREATE FUNCTION `qfuncCheckProcessor`( `_processor` varchar(50)) RETURNS varchar(25) CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt in het controleren ovan de processor. 
# 
# voorbeeld:    'EMAIL'

DECLARE _returnvalue varchar(25);

SELECT 	IFNULL(state,'MISSING') into _returnvalue
FROM 	processors
WHERE 	processors.`name` = _processor;

RETURN 	_returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncCheckSelfservice
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncCheckSelfservice`;
DELIMITER ;;
CREATE FUNCTION `qfuncCheckSelfservice`( `_respondent_id` int(11), _postcode varchar(10)) RETURNS varchar(25) CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt in het controleren ovan de processor. 
# 
# voorbeeld:    124, '5275 JB'

DECLARE _returnvalue varchar(25);

SELECT	FIND_IN_SET(
		REPLACE(_postcode, ' ', ''), #<_postcode
	(
		SELECT 			GROUP_CONCAT(postcode SEPARATOR ',')
		FROM 				(
			SELECT 			REPLACE(respondents.aansluit_postcode, ' ', '') as postcode
			FROM 				respondents
			WHERE 			respondents.respondent_id = _respondent_id #<_respondent_id
		UNION 
			SELECT 			REPLACE(respondents.correspondentie_postcode, ' ', '') as postcode
			FROM 				respondents
			WHERE 			respondents.respondent_id = _respondent_id #<_respondent_id
		UNION 
			SELECT 			REPLACE(mails.aansluit_postcode, ' ', '') as postcode	
			FROM 				respondents
			JOIN 				multisites ON (multisites.respondent_id = respondents.respondent_id)
			JOIN 				mails ON (mails.mail_id = multisites.mail_id)
			WHERE 			respondents.respondent_id = _respondent_id #<_respondent_id
		UNION 
			SELECT 			REPLACE(mails.correspondentie_postcode, ' ', '') as postcode		
			FROM 				respondents
			JOIN 				multisites ON (multisites.respondent_id = respondents.respondent_id)
			JOIN 				mails ON (mails.mail_id = multisites.mail_id)		
			WHERE 			respondents.respondent_id = _respondent_id #<_respondent_id
		) pcselection)
	 ) into _returnvalue;

CASE _returnvalue
	WHEN 0 THEN set _returnvalue = 'DENIED';
	ELSE set _returnvalue = 'OK';
END CASE;

RETURN 	_returnvalue;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncDownloadScan
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncDownloadScan`;
DELIMITER ;;
CREATE FUNCTION `qfuncDownloadScan`(`_token` varchar(100)) RETURNS int(11)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# voorbeeld: 

DECLARE _returnvalue INT(11) DEFAULT 0;

SELECT  
			IF(MAX(
				IF(activitylogs.activity_id = 201, 
					DATE_ADD(activitylogs.enddt, INTERVAL qfuncGetSystemValueByName(1,'period2') HOUR ) ,
					IF(activitylogs.activity_id = 202, 
						DATE_ADD(activitylogs.enddt, INTERVAL qfuncGetSystemValueByName(1,'period3') HOUR ), 
						NULL))) < NOW(), 0, scans.scan_id) into _returnvalue

FROM 		activitylogs
JOIN 		scans ON (scans.scan_id = activitylogs.scan_id AND scans.state = 'ACTIVE' AND scans.`condition` IN ('AVAILABLE','INCOMPLETE'))
WHERE 		activitylogs.state = 'ACTIVE'
AND 		activitylogs.`condition` = 'COMPLETED'
AND 		activitylogs.activityresult_id = 2
AND 		scans.token = _token; #<_token

SET _returnvalue = IFNULL(_returnvalue,0);

IF _returnvalue > 0 THEN update scans set scans.downloaded = NOW() where scans.scan_id = _returnvalue;
END IF;

RETURN _returnvalue;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncDuplicateMailImports
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncDuplicateMailImports`;
DELIMITER ;;
CREATE FUNCTION `qfuncDuplicateMailImports`() RETURNS int(11)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
            DECLARE _out INT(11) DEFAULT 0;
            
            SELECT COUNT(1) INTO _out FROM 
                        (SELECT
                                   MIN(mi.refnr) AS duplicate_refnr,
                                   COUNT(1) AS duplicate_count
                        FROM
                                   mail_imports AS mi
                        GROUP BY mi.refnr
                        HAVING COUNT(mi.refnr)>1) AS x;

            RETURN _out;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncDuplicateMails
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncDuplicateMails`;
DELIMITER ;;
CREATE FUNCTION `qfuncDuplicateMails`() RETURNS int(11)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
            DECLARE _out INT(11) DEFAULT 0;

            SELECT
                        COUNT(1) INTO _out
            FROM
                        mail_imports AS mi
                        INNER JOIN mails AS m ON mi.refnr = m.refnr;

            RETURN _out;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetCampaignDataValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetCampaignDataValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetCampaignDataValues`(`_campaign_id` INT, `_field` varchar(255)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# 
#
# voorbeeld: 1,'type'

	DECLARE _returnvalue TEXT DEFAULT '';
                
	CASE _field
		WHEN 'name' 	THEN SELECT name 	INTO _returnvalue 	FROM campaigns s WHERE s.campaign_id = _campaign_id;
		WHEN 'type' 		THEN 
					SELECT 
						CASE campaigns.type 		
						WHEN 'MAIL' THEN 'mailbestand' 
						WHEN 'FULL' THEN 'volledigvastleggen' 
						ELSE 'ERROR' 
						END 
					INTO _returnvalue
                    FROM 	campaigns 
					WHERE 	campaigns.campaign_id = _campaign_id;
                    
		WHEN 'startdt' 	THEN SELECT voorletters 	INTO _returnvalue 	FROM campaigns s WHERE s.campaign_id = _campaign_id;
		WHEN 'enddt' 	THEN SELECT tussenvoegsel	INTO _returnvalue 	FROM campaigns s WHERE s.campaign_id = _campaign_id;
   		WHEN 'type2' 	THEN SELECT type2		 	INTO _returnvalue 	FROM campaigns s WHERE s.campaign_id = _campaign_id;
	ELSE SET _returnvalue='';
	END CASE;
                
RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetCampaignValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetCampaignValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetCampaignValueByName`(`_campaign_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_campaign_id 		=  opvragen van een bepaalde camapaign, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'info'


	DECLARE _settingdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			campaignvalues.settingdefault_id, 
					settingdefaults.type INTO _settingdefault_id, _type
	FROM 			campaignvalues 
		INNER JOIN 	settingdefaults 	ON (campaignvalues.settingdefault_id = settingdefaults.settingdefault_id)
		INNER JOIN 	settings 				ON (settings.setting_id = settingdefaults.setting_id)
	WHERE
		settings.name 								= 'CAMPAIGNS' AND
		campaignvalues.campaign_id 					= _campaign_id AND
		settingdefaults.name 						= _settingname AND
		settingdefaults.state 						= 'ACTIVE' AND
		settings.state	 							= 'ACTIVE' AND
		campaignvalues.state 						= 'ACTIVE';

	SET _returnvalue = qfuncGetCampaignValues(_settingdefault_id, _type , _campaign_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetCampaignValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetCampaignValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetCampaignValues`(`_settingdefault_id` INT, `_type` varchar(50),  `_campaign_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM campaignvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.campaign_id = _campaign_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetRespondentDataValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetRespondentDataValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetRespondentDataValues`(`_respondent_id` INT, `_field` varchar(255)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# 
#
# voorbeeld: 1,'email'

	DECLARE _returnvalue TEXT DEFAULT '';
                
	CASE _field
		WHEN 'respondent_id' 	THEN SELECT respondent_id 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'bedrijfsnaam' 	THEN SELECT bedrijfsnaam 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'geslacht' 		THEN 
					SELECT 
						CASE respondents.geslacht 		
						WHEN 'M' THEN 'MALE' #voor CLang vertaald
						WHEN 'V' THEN 'FEMALE' #voor Clang vertaald
						WHEN 'O' THEN 'UNKNOWN' 
						ELSE 'UNKNOWN' 
						END 
					INTO _returnvalue
                    FROM 	respondents 
					WHERE 	respondents.respondent_id = _respondent_id;
                    
		WHEN 'voorletters' 				THEN SELECT voorletters 		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'tussenvoegsel' 			THEN SELECT tussenvoegsel		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'achternaam' 				THEN SELECT achternaam 			INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'email' 					THEN SELECT email		 		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		WHEN 'token' 					THEN SELECT token 				INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_straat' 			THEN SELECT aansluit_straat 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_nummer' 			THEN SELECT aansluit_nummer 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_toevoeg' 		THEN SELECT aansluit_toevoeg 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_postcode'		THEN SELECT aansluit_postcode 	INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_plaats' 			THEN SELECT aansluit_plaats		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'aansluit_land' 			THEN SELECT aansluit_land 		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
   		WHEN 'telefoon_vast' 			THEN SELECT telefoon_vast 		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
        WHEN 'telefoon_mobiel' 			THEN SELECT telefoon_mobiel		INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
        WHEN 'campaign_id' 				THEN SELECT campaign_id			INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
        
	ELSE SET _returnvalue='';
	END CASE;

IF _field = 'token'
	THEN 	
		IF _returnvalue is NULL
			THEN
				UPDATE respondents SET token = CONCAT(SHA1(MD5(floor(POW(10,30-1) + (rand() * (POW(10,30)-POW(10,30-1)))))),SHA1(MD5(NOW()))) WHERE respondent_id = _respondent_id;
				SELECT token INTO _returnvalue 	FROM respondents s WHERE s.respondent_id = _respondent_id;
		END IF;
	END IF;
                
RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetScanDataValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetScanDataValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetScanDataValues`(`_scan_id` INT, `_field` varchar(255)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# 
#
# voorbeeld: 1,'token'

	DECLARE _returnvalue TEXT DEFAULT '';
                
	CASE _field
		WHEN 'scan_id' 			THEN SELECT scan_id 			INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'info' 			THEN SELECT info 				INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'size' 			THEN SELECT size 				INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'pages' 			THEN SELECT pages				INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'location' 		THEN SELECT location 			INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'filename' 		THEN SELECT filename		 	INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		WHEN 'condition' 		THEN SELECT `condition`			INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
   		WHEN 'conditiondt' 		THEN SELECT conditiondt 		INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
   		WHEN 'exportdt' 		THEN SELECT exportdt 			INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
   		WHEN 'type' 			THEN SELECT `type`			 	INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
   		WHEN 'referencenumber'	THEN SELECT referencenumber 	INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
   		WHEN 'token' 			THEN SELECT token				INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
        
	ELSE SET _returnvalue='';
	END CASE;

IF _field = 'token'
	THEN 	
		IF _returnvalue is NULL
			THEN
				UPDATE scans SET token = CONCAT(SHA1(MD5(floor(POW(10,30-1) + (rand() * (POW(10,30)-POW(10,30-1)))))),SHA1(MD5(NOW()))) WHERE scan_id = _scan_id;
				SELECT token INTO _returnvalue 	FROM scans s WHERE s.scan_id = _scan_id;
		END IF;
	END IF;
        
RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetSettingDefaultValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetSettingDefaultValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetSettingDefaultValues`(`_type` varchar(255), `_settingdefault_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN   
# ophalen van default settingwaarde
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.default_string INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'integer' THEN SELECT s.default_integer        INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'decimal' THEN SELECT s.default_decimal        INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'boolean' THEN SELECT s.default_boolean        INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'datetime' THEN SELECT s.default_datetime INTO _returnvalue   FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'date' THEN SELECT s.default_date              INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'time' THEN SELECT s.default_time              INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id; 
                   WHEN 'text' THEN SELECT s.default_text              INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'language' THEN SELECT s.default_language INTO _returnvalue   FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;
                   WHEN 'country' THEN SELECT s.default_country        INTO _returnvalue       FROM settingdefaults s WHERE s.settingdefault_id = _settingdefault_id;

                ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetSystemValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetSystemValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetSystemValueByName`(`_system_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_system_id 		=  opvragen van een bepaalde system, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'test'


	DECLARE _settingdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			systemvalues.settingdefault_id, 
					settingdefaults.type INTO _settingdefault_id, _type
	FROM 			systemvalues 
		INNER JOIN 	settingdefaults 	ON (systemvalues.settingdefault_id = settingdefaults.settingdefault_id)
		INNER JOIN 	settings 				ON (settings.setting_id = settingdefaults.setting_id)
	WHERE
		settings.name 								= 'SYSTEM' AND
		systemvalues.system_id 						= _system_id AND
		settingdefaults.name 						= _settingname AND
		settingdefaults.state 						= 'ACTIVE' AND
		settings.state	 							= 'ACTIVE' AND
		systemvalues.state 						= 'ACTIVE';

	SET _returnvalue = qfuncGetSystemValues(_settingdefault_id, _type , _system_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetSystemValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetSystemValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetSystemValues`(`_settingdefault_id` INT, `_type` varchar(50),  `_system_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM systemvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.system_id = _system_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncUpdateScan
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncUpdateScan`;
DELIMITER ;;
CREATE FUNCTION `qfuncUpdateScan`(`_token` varchar(100)) RETURNS int(11)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN  
# Controleert of de consument de selfwervice pagina nog mag openen. 

DECLARE _returnvalue INT(11) DEFAULT 0;

SELECT  
				IF(
				IFNULL(MAX(
				CASE activitylogs.activity_id
				WHEN 200 THEN DATE_ADD(activitylogs.enddt, INTERVAL qfuncGetSystemValueByName(1,'period') HOUR )
				WHEN 203 THEN DATE_ADD(activitylogs.enddt, INTERVAL qfuncGetSystemValueByName(1,'period4') HOUR )
				END),STR_TO_DATE(CURDATE(), '%Y-%m-%d')) 
				< NOW(), 0, respondents.respondent_id) into _returnvalue

FROM 		activitylogs
JOIN 		respondents ON (respondents.respondent_id = activitylogs.respondent_id AND respondents.state = 'ACTIVE')
JOIN 		scans ON (respondents.scan_id = scans.scan_id AND scans.`condition` = 'AVAILABLE' AND scans.state = 'ACTIVE')
WHERE 		activitylogs.state = 'ACTIVE'
AND 		activitylogs.`condition` = 'COMPLETED'
AND 		activitylogs.activityresult_id = 2
AND			respondents.selfservice_succes = 0
AND 		respondents.token = _token; #<_token

SET _returnvalue = IFNULL(_returnvalue,0);

RETURN _returnvalue;
 
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
	RETURN DATE_FORMAT(indt,'%Y-%m-%d');
END
;;
DELIMITER ;
SET FOREIGN_KEY_CHECKS=1;
