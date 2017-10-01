/*
Navicat MySQL Data Transfer

Source Server         : Byte Test & Acceptatie
Source Server Version : 50632
Source Host           : dbint036441:3306
Source Database       : db036441_ren_yourcontract

Target Server Type    : MYSQL
Target Server Version : 50632
File Encoding         : 65001

Date: 2017-05-11 19:53:53
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for attachmentdownloads
-- ----------------------------
DROP TABLE IF EXISTS `attachmentdownloads`;
CREATE TABLE `attachmentdownloads` (
  `attachmentdownload_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `attachment_id` int(10) unsigned NOT NULL,
  `receivercommunication_id` int(10) unsigned NOT NULL,
  `download_ip` varchar(50) NOT NULL,
  PRIMARY KEY (`attachmentdownload_id`),
  KEY `fk_filedownloads_receivercommunications_receivercommunicati_idx` (`receivercommunication_id`),
  KEY `fk_attachmentdownloads_attachments_attachment_id1_idx` (`attachment_id`),
  CONSTRAINT `fk_attachmentdownloads_attachments_attachment_id1` FOREIGN KEY (`attachment_id`) REFERENCES `attachments` (`attachment_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_filedownloads_receivercommunications_receivercommunication10` FOREIGN KEY (`receivercommunication_id`) REFERENCES `receivercommunications` (`receivercommunication_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

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
  `receiver_id` int(10) unsigned NOT NULL,
  `name` varchar(50) DEFAULT NULL,
  `filename` varchar(255) NOT NULL,
  `filelocation` varchar(255) NOT NULL,
  `fileupload_ip` varchar(50) NOT NULL,
  `filedeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`attachment_id`),
  UNIQUE KEY `name_UNIQUE` (`filename`),
  KEY `fk_attachments_receivers_receiver_id1_idx` (`receiver_id`),
  KEY `attachments_filedeleted` (`filedeleted`),
  CONSTRAINT `attachments_ibfk_1` FOREIGN KEY (`receiver_id`) REFERENCES `receivers` (`receiver_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for communicationtypes
-- ----------------------------
DROP TABLE IF EXISTS `communicationtypes`;
CREATE TABLE `communicationtypes` (
  `communicationtype_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `receivertype_id` int(10) unsigned NOT NULL,
  `setting_id` int(10) unsigned NOT NULL,
  `channel` enum('SMS','EMAIL') DEFAULT NULL,
  `name` varchar(20) NOT NULL,
  `sequence` int(11) NOT NULL,
  `previous_id` int(10) unsigned DEFAULT NULL,
  `period` varchar(50) DEFAULT NULL,
  `clangid` varchar(50) DEFAULT NULL,
  `groupid` varchar(50) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`communicationtype_id`),
  UNIQUE KEY `name_UNIQUE` (`name`,`receivertype_id`),
  UNIQUE KEY `sequence_UNIQUE` (`receivertype_id`,`sequence`,`channel`),
  KEY `fk_communicationtypes_receivertypes_receivertype_id1_idx` (`receivertype_id`),
  KEY `fk_communicationtypes_settings_setting_id1_idx` (`setting_id`),
  CONSTRAINT `fk_communicationtypes_receivertypes_receivertype_id1` FOREIGN KEY (`receivertype_id`) REFERENCES `receivertypes` (`receivertype_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_communicationtypes_settings_setting_id1` FOREIGN KEY (`setting_id`) REFERENCES `settings` (`setting_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for distributionlistreceivers
-- ----------------------------
DROP TABLE IF EXISTS `distributionlistreceivers`;
CREATE TABLE `distributionlistreceivers` (
  `distributionlistreceiver_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) NOT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `distributionlist_id` int(10) unsigned NOT NULL,
  `receivertype_id` int(10) unsigned NOT NULL,
  `company` varchar(100) DEFAULT NULL,
  `gender` enum('MALE','FEMALE','UNKNOWN') NOT NULL DEFAULT 'UNKNOWN',
  `initials` varchar(15) DEFAULT NULL,
  `middlename` varchar(15) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `emailaddress` varchar(255) NOT NULL,
  `mobilephone` varchar(15) DEFAULT NULL,
  `emailstate` enum('UNUSED','DELIVERD','BOUNCED') NOT NULL DEFAULT 'UNUSED',
  `emailstate_modified` datetime DEFAULT NULL,
  PRIMARY KEY (`distributionlistreceiver_id`),
  KEY `fk_distributionlistreceivers_distributionlists_distribution_idx` (`distributionlist_id`),
  KEY `fk_distributionlistreceivers_receivertypes_receivertype_id1_idx` (`receivertype_id`),
  CONSTRAINT `fk_distributionlistreceivers_distributionlists_distributionli1` FOREIGN KEY (`distributionlist_id`) REFERENCES `distributionlists` (`distributionlist_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_distributionlistreceivers_receivertypes_receivertype_id1` FOREIGN KEY (`receivertype_id`) REFERENCES `receivertypes` (`receivertype_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for distributionlistreceivervalues
-- ----------------------------
DROP TABLE IF EXISTS `distributionlistreceivervalues`;
CREATE TABLE `distributionlistreceivervalues` (
  `distributionlistreceivervalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `distributionlistreceiver_id` int(10) unsigned NOT NULL,
  `receiverdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`distributionlistreceivervalue_id`),
  UNIQUE KEY `unique_dislistval` (`receiverdefault_id`,`distributionlistreceiver_id`),
  KEY `fk_receivervalues_receiverdefaults_receiverdefault_id1_idx` (`receiverdefault_id`),
  KEY `fk_distributionlistreceivervalues_distributionlistreceivers_idx` (`distributionlistreceiver_id`),
  CONSTRAINT `fk_distributionlistreceivervalues_distributionlistreceivers_d1` FOREIGN KEY (`distributionlistreceiver_id`) REFERENCES `distributionlistreceivers` (`distributionlistreceiver_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_receivervalues_receiverdefaults_receiverdefault_id10` FOREIGN KEY (`receiverdefault_id`) REFERENCES `receiverdefaults` (`receiverdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=546 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for distributionlists
-- ----------------------------
DROP TABLE IF EXISTS `distributionlists`;
CREATE TABLE `distributionlists` (
  `distributionlist_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `receiversetting_id` int(10) unsigned DEFAULT NULL,
  `name` varchar(50) NOT NULL DEFAULT 'DL-',
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`distributionlist_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for documentdefaults
-- ----------------------------
DROP TABLE IF EXISTS `documentdefaults`;
CREATE TABLE `documentdefaults` (
  `documentdefault_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `receiverfieldset_id` int(10) unsigned DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`documentdefault_id`),
  KEY `fk_documentdefaults_receiverfieldsets_receiverfieldset_id1_idx` (`receiverfieldset_id`),
  CONSTRAINT `fk_documentdefaults_receiverfieldsets_receiverfieldset_id1` FOREIGN KEY (`receiverfieldset_id`) REFERENCES `receiverfieldsets` (`receiverfieldset_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for documentdefaultvalues
-- ----------------------------
DROP TABLE IF EXISTS `documentdefaultvalues`;
CREATE TABLE `documentdefaultvalues` (
  `documentdefaultvalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `documentdefault_id` int(10) unsigned NOT NULL,
  `settingdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`documentdefaultvalue_id`),
  UNIQUE KEY `unique_documentdefault_id_settingdefault_id` (`documentdefault_id`,`settingdefault_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_documentdefaultvalues_documentdefaults_documentdefault_i_idx` (`documentdefault_id`),
  CONSTRAINT `fk_campaignvalues_settingdefaults_settingdefault_id10` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_documentdefaultvalues_documentdefaults_documentdefault_id1` FOREIGN KEY (`documentdefault_id`) REFERENCES `documentdefaults` (`documentdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=624 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for documentdownloads
-- ----------------------------
DROP TABLE IF EXISTS `documentdownloads`;
CREATE TABLE `documentdownloads` (
  `documentdownload_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `document_id` int(10) unsigned NOT NULL,
  `receivercommunication_id` int(10) unsigned NOT NULL,
  `download_ip` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`documentdownload_id`),
  KEY `fk_documentdownloads_documents_document_id1_idx` (`document_id`),
  KEY `fk_documentdownloads_receivercommunications_receivercommuni_idx` (`receivercommunication_id`),
  CONSTRAINT `fk_documentdownloads_documents_document_id1` FOREIGN KEY (`document_id`) REFERENCES `documents` (`document_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_documentdownloads_receivercommunications_receivercommunica1` FOREIGN KEY (`receivercommunication_id`) REFERENCES `receivercommunications` (`receivercommunication_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for documents
-- ----------------------------
DROP TABLE IF EXISTS `documents`;
CREATE TABLE `documents` (
  `document_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `documentdefault_id` int(10) unsigned DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `filename` varchar(255) NOT NULL,
  `filelocation` varchar(255) NOT NULL,
  PRIMARY KEY (`document_id`),
  UNIQUE KEY `filename_UNIQUE` (`filename`),
  KEY `fk_documents_documentdefaults_documentdefault_id1_idx` (`documentdefault_id`),
  CONSTRAINT `fk_documents_documentdefaults_documentdefault_id1` FOREIGN KEY (`documentdefault_id`) REFERENCES `documentdefaults` (`documentdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for documentvalues
-- ----------------------------
DROP TABLE IF EXISTS `documentvalues`;
CREATE TABLE `documentvalues` (
  `documentvalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `document_id` int(10) unsigned NOT NULL,
  `settingdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`documentvalue_id`),
  UNIQUE KEY `unique_docval` (`settingdefault_id`,`document_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_documentvalues_documents_document_id1_idx` (`document_id`),
  CONSTRAINT `fk_campaignvalues_settingdefaults_settingdefault_id1` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_documentvalues_documents_document_id1` FOREIGN KEY (`document_id`) REFERENCES `documents` (`document_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=440 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for filedownloads
-- ----------------------------
DROP TABLE IF EXISTS `filedownloads`;
CREATE TABLE `filedownloads` (
  `filedownload_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `file_id` int(10) unsigned NOT NULL,
  `receivercommunication_id` int(10) unsigned NOT NULL,
  `download_ip` varchar(50) NOT NULL,
  PRIMARY KEY (`filedownload_id`),
  KEY `fk_filedownloads_files_file_id1_idx` (`file_id`),
  KEY `fk_filedownloads_receivercommunications_receivercommunicati_idx` (`receivercommunication_id`),
  CONSTRAINT `fk_filedownloads_files_file_id1` FOREIGN KEY (`file_id`) REFERENCES `files` (`file_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_filedownloads_receivercommunications_receivercommunication1` FOREIGN KEY (`receivercommunication_id`) REFERENCES `receivercommunications` (`receivercommunication_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

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
  `transfer_id` int(10) unsigned NOT NULL,
  `document_id` int(10) unsigned DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `filename` varchar(255) NOT NULL,
  `filelocation` varchar(255) DEFAULT NULL,
  `mandatory_signature` tinyint(1) NOT NULL DEFAULT '0',
  `signed_filename` varchar(255) DEFAULT NULL,
  `signed_filelocation` varchar(255) DEFAULT NULL,
  `filedeleted` datetime DEFAULT NULL,
  `signed_filedeleted` datetime DEFAULT NULL,
  PRIMARY KEY (`file_id`),
  UNIQUE KEY `name_UNIQUE` (`filename`),
  KEY `fk_files_transfers_transfer_id1_idx` (`transfer_id`),
  KEY `fk_files_documents_document_id1_idx` (`document_id`),
  KEY `files_filedeleted` (`filedeleted`),
  KEY `files_signed_filedeleted` (`signed_filedeleted`),
  CONSTRAINT `fk_files_documents_document_id1` FOREIGN KEY (`document_id`) REFERENCES `documents` (`document_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_files_transfers_transfer_id1` FOREIGN KEY (`transfer_id`) REFERENCES `transfers` (`transfer_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for filesignatures
-- ----------------------------
DROP TABLE IF EXISTS `filesignatures`;
CREATE TABLE `filesignatures` (
  `filesignature_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `file_id` int(10) unsigned NOT NULL,
  `receivercommunication_id` int(10) unsigned NOT NULL,
  `signature_ip` varchar(50) NOT NULL,
  PRIMARY KEY (`filesignature_id`),
  UNIQUE KEY `unique_signature` (`file_id`),
  KEY `fk_filesignatures_files_file_id1_idx` (`file_id`),
  KEY `fk_filesignatures_receivercommunications_receivercommunicat_idx` (`receivercommunication_id`),
  CONSTRAINT `fk_filesignatures_files_file_id1` FOREIGN KEY (`file_id`) REFERENCES `files` (`file_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_filesignatures_receivercommunications_receivercommunicatio1` FOREIGN KEY (`receivercommunication_id`) REFERENCES `receivercommunications` (`receivercommunication_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for kpnstaffels
-- ----------------------------
DROP TABLE IF EXISTS `kpnstaffels`;
CREATE TABLE `kpnstaffels` (
  `kpnstaffel_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `kpntype` varchar(50) DEFAULT NULL,
  `vanaf` int(11) DEFAULT NULL,
  `tarief` decimal(8,2) DEFAULT NULL,
  PRIMARY KEY (`kpnstaffel_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receivercommunications
-- ----------------------------
DROP TABLE IF EXISTS `receivercommunications`;
CREATE TABLE `receivercommunications` (
  `receivercommunication_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `condition` enum('READY','COMPLETED','ERROR') DEFAULT NULL,
  `condition_dt` datetime DEFAULT NULL,
  `communicationtype_id` int(10) unsigned NOT NULL,
  `receiver_id` int(10) unsigned NOT NULL,
  `cm_emailaddress` varchar(255) DEFAULT NULL,
  `cm_mobilephone` varchar(15) DEFAULT NULL,
  `cm_id` int(11) DEFAULT NULL,
  `cm_state` varchar(20) DEFAULT NULL COMMENT 'DELIVERED|HARDBOUNCE|SOFTBOUNCE|NO_RESULT',
  `cm_state_dt` datetime DEFAULT NULL,
  `cm_clangtag` varchar(50) NOT NULL,
  `cm_clangid` int(11) DEFAULT NULL,
  `cm_groupid` int(11) DEFAULT NULL,
  `cm_sendemailaddress` varchar(255) DEFAULT NULL,
  `cm_sendname` varchar(255) DEFAULT NULL,
  `cm_replyemailaddress` varchar(255) DEFAULT NULL,
  `cm_subject` varchar(255) DEFAULT NULL,
  `cm_smssender` varchar(255) DEFAULT NULL,
  `cm_smsname` varchar(255) DEFAULT NULL,
  `cm_smsid` varchar(50) DEFAULT NULL,
  `hash` varchar(64) NOT NULL,
  `previous_id` int(10) unsigned DEFAULT NULL,
  `external_file_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`receivercommunication_id`),
  UNIQUE KEY `hash_UNIQUE` (`hash`),
  UNIQUE KEY `next_id_UNIQUE` (`previous_id`),
  KEY `fk_receivercommunications_communicationtypes_communicationt_idx` (`communicationtype_id`),
  KEY `fk_receivercommunications_receivers_receiver_id1_idx` (`receiver_id`),
  KEY `receivercom_condition` (`condition`),
  KEY `receiver_created` (`created`),
  CONSTRAINT `fk_receivercommunications_communicationtypes_communicationtyp1` FOREIGN KEY (`communicationtype_id`) REFERENCES `communicationtypes` (`communicationtype_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_receivercommunications_receivers_receiver_id1` FOREIGN KEY (`receiver_id`) REFERENCES `receivers` (`receiver_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receiverdefaults
-- ----------------------------
DROP TABLE IF EXISTS `receiverdefaults`;
CREATE TABLE `receiverdefaults` (
  `receiverdefault_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `groupname` varchar(50) DEFAULT NULL,
  `groupsequence` int(11) DEFAULT NULL,
  `sequence` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `clangname` varchar(50) DEFAULT NULL,
  `label` varchar(50) DEFAULT NULL,
  `type` enum('string','integer','decimal','boolean','datetime','date','time','text') DEFAULT NULL,
  `class` varchar(255) DEFAULT NULL,
  `display_type` enum('select','radio','hidden','emailaddresspicker') DEFAULT NULL,
  `display_values` text NOT NULL COMMENT 'This can only be a json_encoded array!',
  `datacheck_id` int(10) unsigned DEFAULT NULL,
  `info` text,
  `default_string` varchar(255) DEFAULT NULL,
  `default_integer` int(11) DEFAULT NULL,
  `default_decimal` decimal(8,2) DEFAULT NULL,
  `default_boolean` tinyint(1) DEFAULT NULL,
  `default_datetime` datetime DEFAULT NULL,
  `default_date` date DEFAULT NULL,
  `default_time` time DEFAULT NULL,
  `default_text` text,
  PRIMARY KEY (`receiverdefault_id`),
  UNIQUE KEY `name_UNIQUE` (`name`),
  KEY `fk_settingdefaults_datachecks_datacheck_id1_idx` (`datacheck_id`),
  CONSTRAINT `fk_settingdefaults_datachecks_datacheck_id10` FOREIGN KEY (`datacheck_id`) REFERENCES `datachecks` (`datacheck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receiverfields
-- ----------------------------
DROP TABLE IF EXISTS `receiverfields`;
CREATE TABLE `receiverfields` (
  `receiverfield_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `receiverdefault_id` int(10) unsigned NOT NULL,
  `receiverfieldset_id` int(10) unsigned NOT NULL,
  `mandatory` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`receiverfield_id`),
  UNIQUE KEY `unique_receiverfields` (`receiverdefault_id`,`receiverfieldset_id`),
  KEY `fk_receiverfields_receiverdefaults_receiverdefault_id1_idx` (`receiverdefault_id`),
  KEY `fk_receiverfields_receiverfieldsets_receiverfieldset_id1_idx` (`receiverfieldset_id`),
  CONSTRAINT `fk_receiverfields_receiverdefaults_receiverdefault_id1` FOREIGN KEY (`receiverdefault_id`) REFERENCES `receiverdefaults` (`receiverdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_receiverfields_receiverfieldsets_receiverfieldset_id1` FOREIGN KEY (`receiverfieldset_id`) REFERENCES `receiverfieldsets` (`receiverfieldset_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=268 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receiverfieldsets
-- ----------------------------
DROP TABLE IF EXISTS `receiverfieldsets`;
CREATE TABLE `receiverfieldsets` (
  `receiverfieldset_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`receiverfieldset_id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receivers
-- ----------------------------
DROP TABLE IF EXISTS `receivers`;
CREATE TABLE `receivers` (
  `receiver_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `transfer_id` int(10) unsigned NOT NULL,
  `distributionlistreceiver_id` int(10) unsigned DEFAULT NULL,
  `receivertype_id` int(10) unsigned NOT NULL,
  `delegate_receiver_id` int(10) unsigned DEFAULT NULL,
  `company` varchar(50) DEFAULT NULL,
  `gender` enum('MALE','FEMALE','UNKNOWN') NOT NULL DEFAULT 'UNKNOWN',
  `initials` varchar(15) DEFAULT NULL,
  `middlename` varchar(15) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `emailaddress` varchar(255) DEFAULT NULL,
  `emailusable` tinyint(1) NOT NULL DEFAULT '1',
  `mobilephone` varchar(15) DEFAULT NULL,
  `security` tinyint(1) NOT NULL DEFAULT '0',
  `security_attempts` tinyint(1) NOT NULL DEFAULT '0',
  `security_state` enum('BLOCKED','OPEN') NOT NULL DEFAULT 'OPEN',
  `transfercompleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`receiver_id`),
  UNIQUE KEY `unique_distributionlist` (`distributionlistreceiver_id`,`transfer_id`),
  UNIQUE KEY `unique_receivers` (`emailaddress`,`transfer_id`,`receivertype_id`),
  KEY `fk_receivers_transfers_transfer_id1_idx` (`transfer_id`),
  KEY `fk_receivers_distributionlistreceivers_distributionlistrece_idx` (`distributionlistreceiver_id`),
  KEY `fk_receivers_receivertypes_receivertype_id1_idx` (`receivertype_id`),
  KEY `receiver_emailusable` (`emailusable`),
  KEY `receiver_trasfercompleted` (`transfercompleted`),
  CONSTRAINT `fk_receivers_distributionlistreceivers_distributionlistreceiv1` FOREIGN KEY (`distributionlistreceiver_id`) REFERENCES `distributionlistreceivers` (`distributionlistreceiver_id`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `fk_receivers_receivertypes_receivertype_id1` FOREIGN KEY (`receivertype_id`) REFERENCES `receivertypes` (`receivertype_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_receivers_transfers_transfer_id1` FOREIGN KEY (`transfer_id`) REFERENCES `transfers` (`transfer_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1087 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receiversecuritylogs
-- ----------------------------
DROP TABLE IF EXISTS `receiversecuritylogs`;
CREATE TABLE `receiversecuritylogs` (
  `receiversecuritylog_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `login_ip` varchar(50) NOT NULL,
  `login_result` tinyint(1) NOT NULL DEFAULT '0',
  `receiver_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`receiversecuritylog_id`),
  KEY `fk_receiversecuritylogs_receivers_receiver_id1_idx` (`receiver_id`),
  CONSTRAINT `fk_receiversecuritylogs_receivers_receiver_id1` FOREIGN KEY (`receiver_id`) REFERENCES `receivers` (`receiver_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receivertypes
-- ----------------------------
DROP TABLE IF EXISTS `receivertypes`;
CREATE TABLE `receivertypes` (
  `receivertype_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`receivertype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for receivervalues
-- ----------------------------
DROP TABLE IF EXISTS `receivervalues`;
CREATE TABLE `receivervalues` (
  `receivervalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `receiverdefault_id` int(10) unsigned NOT NULL,
  `receiver_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`receivervalue_id`),
  UNIQUE KEY `unique_recval` (`receiverdefault_id`,`receiver_id`),
  KEY `fk_receivervalues_receiverdefaults_receiverdefault_id1_idx` (`receiverdefault_id`),
  KEY `fk_receivervalues_receivers_receiver_id1_idx` (`receiver_id`),
  CONSTRAINT `fk_receivervalues_receiverdefaults_receiverdefault_id1` FOREIGN KEY (`receiverdefault_id`) REFERENCES `receiverdefaults` (`receiverdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_receivervalues_receivers_receiver_id1` FOREIGN KEY (`receiver_id`) REFERENCES `receivers` (`receiver_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3492 DEFAULT CHARSET=utf8;

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
  `name` varchar(50) NOT NULL,
  `clangname` varchar(50) DEFAULT NULL,
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
  UNIQUE KEY `name_UNIQUE` (`name`,`setting_id`),
  KEY `fk_settingdefaults_settings_setting_id1_idx` (`setting_id`),
  KEY `fk_settingdefaults_datachecks_datacheck_id1_idx` (`datacheck_id`),
  CONSTRAINT `fk_settingdefaults_datachecks_datacheck_id1` FOREIGN KEY (`datacheck_id`) REFERENCES `datachecks` (`datacheck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_settingdefaults_settings_setting_id1` FOREIGN KEY (`setting_id`) REFERENCES `settings` (`setting_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=87 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for systemlogs
-- ----------------------------
DROP TABLE IF EXISTS `systemlogs`;
CREATE TABLE `systemlogs` (
  `systemlog_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `emaillist_id` int(10) unsigned DEFAULT NULL,
  `condition` enum('OPEN','CLOSED','SEND','COMPLETED') DEFAULT 'OPEN',
  `conditiondt` datetime DEFAULT NULL,
  `message` text NOT NULL,
  PRIMARY KEY (`systemlog_id`),
  KEY `fk_systemlogs_emaillists_emaillist_id1_idx` (`emaillist_id`),
  CONSTRAINT `fk_systemlogs_emaillists_emaillist_id1` FOREIGN KEY (`emaillist_id`) REFERENCES `emaillists` (`emaillist_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for systems
-- ----------------------------
DROP TABLE IF EXISTS `systems`;
CREATE TABLE `systems` (
  `system_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `name` varchar(50) NOT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`system_id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
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
  UNIQUE KEY `unique_sysval` (`settingdefault_id`,`system_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_systemvalues_systems_system_id1_idx` (`system_id`),
  CONSTRAINT `fk_systemvalues_settingdefaults_settingdefault_id1` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_systemvalues_systems_system_id1` FOREIGN KEY (`system_id`) REFERENCES `systems` (`system_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for transfers
-- ----------------------------
DROP TABLE IF EXISTS `transfers`;
CREATE TABLE `transfers` (
  `transfer_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `documentdefault_id` int(10) unsigned NOT NULL DEFAULT '1',
  `distributionlist_id` int(10) unsigned DEFAULT NULL,
  `created_user` int(11) unsigned DEFAULT NULL,
  `main_transfer_id` int(11) DEFAULT NULL,
  `main_distributionlistreceiver_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`transfer_id`),
  KEY `fk_transfers_documentdefaults_documentdefault_id1_idx` (`documentdefault_id`),
  KEY `fk_transfers_distributionlists_distributionlist_id1_idx` (`distributionlist_id`),
  CONSTRAINT `fk_transfers_distributionlists_distributionlist_id1` FOREIGN KEY (`distributionlist_id`) REFERENCES `distributionlists` (`distributionlist_id`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `fk_transfers_documentdefaults_documentdefault_id1` FOREIGN KEY (`documentdefault_id`) REFERENCES `documentdefaults` (`documentdefault_id`) ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=780 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for transfervalues
-- ----------------------------
DROP TABLE IF EXISTS `transfervalues`;
CREATE TABLE `transfervalues` (
  `transfervalue_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `description` varchar(100) DEFAULT NULL,
  `created_user` int(11) DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user` int(11) DEFAULT NULL,
  `transfer_id` int(10) unsigned NOT NULL,
  `settingdefault_id` int(10) unsigned NOT NULL,
  `value_string` varchar(255) DEFAULT NULL,
  `value_integer` int(11) DEFAULT NULL,
  `value_decimal` decimal(8,2) DEFAULT NULL,
  `value_boolean` tinyint(1) DEFAULT NULL,
  `value_datetime` datetime DEFAULT NULL,
  `value_date` date DEFAULT NULL,
  `value_time` time DEFAULT NULL,
  `value_text` text,
  PRIMARY KEY (`transfervalue_id`),
  UNIQUE KEY `unique_tranval` (`settingdefault_id`,`transfer_id`),
  KEY `fk_campaignvalues_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_transfervalues_transfers_transfer_id1_idx` (`transfer_id`),
  CONSTRAINT `fk_campaignvalues_settingdefaults_settingdefault_id11` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transfervalues_transfers_transfer_id1` FOREIGN KEY (`transfer_id`) REFERENCES `transfers` (`transfer_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2474 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for userlocks
-- ----------------------------
DROP TABLE IF EXISTS `userlocks`;
CREATE TABLE `userlocks` (
  `userlock_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `portal_user_id` int(11) NOT NULL,
  `system_id` int(10) unsigned DEFAULT NULL,
  `receiverlist_id` int(10) unsigned DEFAULT NULL,
  `document_id` int(10) unsigned DEFAULT NULL,
  `documentdefault_id` int(10) unsigned DEFAULT NULL,
  `settingdefault_id` int(10) unsigned DEFAULT NULL,
  `receiverdefault_id` int(10) unsigned DEFAULT NULL,
  `receivervalue_id` int(10) unsigned DEFAULT NULL,
  `distributionlistreceiver_id` int(10) unsigned DEFAULT NULL,
  `receiver_id` int(10) unsigned DEFAULT NULL,
  `receiverfieldset_id` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`userlock_id`),
  UNIQUE KEY `unique_lock` (`system_id`,`documentdefault_id`,`receiverlist_id`,`document_id`,`settingdefault_id`,`receiverdefault_id`,`receivervalue_id`,`distributionlistreceiver_id`,`receiver_id`,`receiverfieldset_id`),
  KEY `fk_userlocks_systems_system_id1_idx` (`system_id`),
  KEY `fk_userlocks_receiverlists_receiverlist_id1_idx` (`receiverlist_id`),
  KEY `fk_userlocks_documents_document_id1_idx` (`document_id`),
  KEY `fk_userlocks_documentdefaults_documentdefault_id1_idx` (`documentdefault_id`),
  KEY `fk_userlocks_settingdefaults_settingdefault_id1_idx` (`settingdefault_id`),
  KEY `fk_userlocks_receiverdefaults_receiverdefault_id1_idx` (`receiverdefault_id`),
  KEY `fk_userlocks_receivervalues_receivervalue_id1_idx` (`receivervalue_id`),
  KEY `fk_userlocks_distributionlistreceivers_distributionlistrece_idx` (`distributionlistreceiver_id`),
  KEY `fk_userlocks_receiverfielfsets_receiverfieldsets1_idx` (`receiverfieldset_id`),
  KEY `fk_userlocks_receivers_receiver_id1_idx` (`receiver_id`),
  CONSTRAINT `fk_userlocks_distributionlistreceivers_distributionlistreceiv1` FOREIGN KEY (`distributionlistreceiver_id`) REFERENCES `distributionlistreceivers` (`distributionlistreceiver_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_documentdefaults_documentdefault_id1` FOREIGN KEY (`documentdefault_id`) REFERENCES `documentdefaults` (`documentdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_documents_document_id1` FOREIGN KEY (`document_id`) REFERENCES `documents` (`document_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_receiverdefaults_receiverdefault_id1` FOREIGN KEY (`receiverdefault_id`) REFERENCES `receiverdefaults` (`receiverdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_receiverlists_receiverlist_id1` FOREIGN KEY (`receiverlist_id`) REFERENCES `distributionlists` (`distributionlist_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_receivervalues_receivervalue_id1` FOREIGN KEY (`receivervalue_id`) REFERENCES `receivervalues` (`receivervalue_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_settingdefaults_settingdefault_id1` FOREIGN KEY (`settingdefault_id`) REFERENCES `settingdefaults` (`settingdefault_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_userlocks_systems_system_id1` FOREIGN KEY (`system_id`) REFERENCES `systems` (`system_id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `userlocks_ibfk_1` FOREIGN KEY (`receiverfieldset_id`) REFERENCES `receiverfieldsets` (`receiverfieldset_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `userlocks_ibfk_2` FOREIGN KEY (`receiver_id`) REFERENCES `receivers` (`receiver_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2563 DEFAULT CHARSET=utf8;

-- ----------------------------
-- View structure for qselClangInput
-- ----------------------------
DROP VIEW IF EXISTS `qselClangInput`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselClangInput` AS select `r`.`receiver_id` AS `receiver_id`,`rc`.`created` AS `created`,`t`.`receivertype_id` AS `receivertype_id`,`t`.`name` AS `receivertype`,`c`.`communicationtype_id` AS `communicationtype_id`,`c`.`name` AS `communicationtype`,`rc`.`receivercommunication_id` AS `receivercommunication_id` from (((`receivercommunications` `rc` join `communicationtypes` `c` on(((`c`.`communicationtype_id` = `rc`.`communicationtype_id`) and (`c`.`state` = 'ACTIVE')))) join `receivers` `r` on(((`r`.`receiver_id` = `rc`.`receiver_id`) and (`r`.`emailusable` = 1) and (`r`.`state` = 'ACTIVE')))) join `receivertypes` `t` on(((`t`.`receivertype_id` = `r`.`receivertype_id`) and (`t`.`state` = 'ACTIVE')))) where ((`rc`.`condition` = 'READY') and (`rc`.`state` = 'ACTIVE')) ;

-- ----------------------------
-- View structure for qselClangWaitingResult
-- ----------------------------
DROP VIEW IF EXISTS `qselClangWaitingResult`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselClangWaitingResult` AS select `r`.`receiver_id` AS `receiver_id`,`rc`.`receivercommunication_id` AS `receivercommunication_id`,`rc`.`condition_dt` AS `condition_dt`,`rc`.`cm_id` AS `cm_id` from (((`receivercommunications` `rc` join `communicationtypes` `c` on(((`c`.`communicationtype_id` = `rc`.`communicationtype_id`) and (`c`.`state` = 'ACTIVE')))) join `receivers` `r` on(((`r`.`receiver_id` = `rc`.`receiver_id`) and (`r`.`emailusable` = 1) and (`r`.`state` = 'ACTIVE')))) join `receivertypes` `t` on(((`t`.`receivertype_id` = `r`.`receivertype_id`) and (`t`.`state` = 'ACTIVE')))) where ((`rc`.`condition` = 'COMPLETED') and (`rc`.`state` = 'ACTIVE') and isnull(`rc`.`cm_state`) and (`rc`.`cm_clangid` is not null) and (`rc`.`cm_id` is not null)) ;

-- ----------------------------
-- View structure for qselDeleteFiles
-- ----------------------------
DROP VIEW IF EXISTS `qselDeleteFiles`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselDeleteFiles` AS select 'files' AS `files`,`files`.`file_id` AS `file_id`,`files`.`created` AS `created`,`files`.`filename` AS `filename`,`files`.`filelocation` AS `filelocation`,(`files`.`created` + interval `qfuncGetSystemValueByName`(`transfers`.`transfer_id`,'deleteperiod_files') day) AS `expired` from ((`files` join `transfers` on(((`transfers`.`transfer_id` = `files`.`transfer_id`) and (`transfers`.`state` = 'ACTIVE')))) left join `filesignatures` on((`filesignatures`.`file_id` = `files`.`file_id`))) where ((`files`.`state` = 'ACTIVE') and isnull(`filesignatures`.`filesignature_id`) and isnull(`files`.`filedeleted`)) union select 'filesignatures' AS `filesignatures`,`files`.`file_id` AS `file_id`,`filesignatures`.`created` AS `created`,`files`.`signed_filename` AS `signed_filename`,`files`.`signed_filelocation` AS `signed_filelocation`,(`filesignatures`.`created` + interval `qfuncGetSystemValueByName`(`transfers`.`transfer_id`,'deleteperiod_signedfiles') day) AS `expired` from ((`files` join `transfers` on(((`transfers`.`transfer_id` = `files`.`transfer_id`) and (`transfers`.`state` = 'ACTIVE')))) join `filesignatures` on((`filesignatures`.`file_id` = `files`.`file_id`))) where ((`files`.`state` = 'ACTIVE') and isnull(`files`.`signed_filedeleted`)) union select 'attachments' AS `attachments`,`attachments`.`attachment_id` AS `attachment_id`,`attachments`.`created` AS `created`,`attachments`.`filename` AS `filename`,`attachments`.`filelocation` AS `filelocation`,(`attachments`.`created` + interval `qfuncGetSystemValueByName`(`receivers`.`transfer_id`,'deleteperiod_attachments') day) AS `expired` from (`attachments` join `receivers` on((`receivers`.`receiver_id` = `attachments`.`receiver_id`))) where ((`attachments`.`state` = 'ACTIVE') and isnull(`attachments`.`filedeleted`)) ;

-- ----------------------------
-- View structure for qselSystemEmails
-- ----------------------------
DROP VIEW IF EXISTS `qselSystemEmails`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `qselSystemEmails` AS select `sl`.`systemlog_id` AS `systemlog_id`,`sl`.`message` AS `message`,`el`.`clangid` AS `clangid`,`el`.`clanggroupid` AS `clanggroupid`,`el`.`sendemailaddress` AS `sendemailaddress`,`el`.`sendname` AS `sendname`,`el`.`replyemailaddress` AS `replyemailaddress`,`el`.`subject` AS `subject`,`ea`.`emailaddress_id` AS `emailaddress_id`,`ea`.`emailaddress` AS `emailaddress`,`qfuncGetSystemValueByName`(1,'email_brand') AS `clangtag` from (((`systemlogs` `sl` join `emaillists` `el` on((`sl`.`emaillist_id` = `el`.`emaillist_id`))) join `emailuses` `eu` on((`eu`.`emaillist_id` = `el`.`emaillist_id`))) join `emailaddresses` `ea` on((`eu`.`emailaddress_id` = `ea`.`emailaddress_id`))) where ((`sl`.`state` = 'ACTIVE') and (`sl`.`emaillist_id` is not null) and (`sl`.`condition` = 'OPEN') and ((`sl`.`created` + interval 72 hour) > now()) and (`el`.`clangid` is not null) and (`el`.`clanggroupid` is not null) and (`el`.`sendemailaddress` is not null) and (`el`.`sendname` is not null) and (`el`.`replyemailaddress` is not null) and (`el`.`subject` is not null)) ;

-- ----------------------------
-- View structure for qselTransferFiles
-- ----------------------------
DROP VIEW IF EXISTS `qselTransferFiles`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qselTransferFiles` AS select `transfers`.`transfer_id` AS `transfer_id`,'files' AS `type`,`files`.`file_id` AS `id`,`files`.`created` AS `created`,`files`.`filename` AS `filename`,`files`.`filelocation` AS `filelocation`,(`files`.`created` + interval `qfuncGetSystemValueByName`(`transfers`.`transfer_id`,'deleteperiod_files') day) AS `expired`,NULL AS `signed` from (((`files` join `transfers` on(((`transfers`.`transfer_id` = `files`.`transfer_id`) and (`transfers`.`state` = 'ACTIVE')))) join `receivers` on(((`receivers`.`transfer_id` = `transfers`.`transfer_id`) and (`receivers`.`state` = 'ACTIVE')))) left join `filesignatures` on((`filesignatures`.`file_id` = `files`.`file_id`))) where ((`files`.`state` = 'ACTIVE') and isnull(`filesignatures`.`filesignature_id`) and isnull(`files`.`filedeleted`)) union select `transfers`.`transfer_id` AS `transfer_id`,'files' AS `type`,`files`.`file_id` AS `id`,`filesignatures`.`created` AS `created`,`files`.`signed_filename` AS `signed_filename`,`files`.`signed_filelocation` AS `signed_filelocation`,(`filesignatures`.`created` + interval `qfuncGetSystemValueByName`(`transfers`.`transfer_id`,'deleteperiod_signedfiles') day) AS `expired`,`filesignatures`.`created` AS `signed` from (((`files` join `transfers` on(((`transfers`.`transfer_id` = `files`.`transfer_id`) and (`transfers`.`state` = 'ACTIVE')))) join `receivers` on(((`receivers`.`transfer_id` = `transfers`.`transfer_id`) and (`receivers`.`state` = 'ACTIVE')))) join `filesignatures` on((`filesignatures`.`file_id` = `files`.`file_id`))) where ((`files`.`state` = 'ACTIVE') and isnull(`files`.`signed_filedeleted`)) union select `transfers`.`transfer_id` AS `transfer_id`,'attachments' AS `type`,`attachments`.`attachment_id` AS `id`,`attachments`.`created` AS `created`,`attachments`.`filename` AS `filename`,`attachments`.`filelocation` AS `filelocation`,(`attachments`.`created` + interval `qfuncGetSystemValueByName`(`receivers`.`transfer_id`,'deleteperiod_attachments') day) AS `expired`,NULL AS `signed` from ((`attachments` join `receivers` on(((`receivers`.`receiver_id` = `attachments`.`receiver_id`) and (`receivers`.`state` = 'ACTIVE')))) join `transfers` on(((`transfers`.`transfer_id` = `receivers`.`transfer_id`) and (`transfers`.`state` = 'ACTIVE')))) where ((`attachments`.`state` = 'ACTIVE') and isnull(`attachments`.`filedeleted`)) ;

-- ----------------------------
-- Procedure structure for qprodCompleteDelegate
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCompleteDelegate`;
DELIMITER ;;
CREATE PROCEDURE `qprodCompleteDelegate`(IN `_transfer_id` int,IN `_delegate_receiver_id` int,IN `_hash` varchar(64), _cm_clangid INT, _cm_subject VARCHAR(255), _cm_groupid INT, _cm_smssender VARCHAR(100), _cm_smsname VARCHAR(100), _cm_smsid INT)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _receiver_id INT;
	DECLARE _receiver_emailaddress VARCHAR(150);

	SELECT receiver_id, emailaddress INTO _receiver_id, _receiver_emailaddress FROM receivers WHERE receivers.delegate_receiver_id=_delegate_receiver_id;

	INSERT INTO receivervalues (created,modified,state,description,receiverdefault_id,receiver_id,value_string,value_integer,value_decimal,value_boolean,value_datetime,value_date,value_time,value_text)
		SELECT NOW(),NOW(),a.state,a.description,a.receiverdefault_id,_receiver_id,a.value_string,a.value_integer,a.value_decimal,a.value_boolean,a.value_datetime,a.value_date,a.value_time,a.value_text
		FROM receivervalues a
		WHERE a.receiver_id=_delegate_receiver_id
	ON DUPLICATE KEY UPDATE
		modified=NOW(),value_string=a.value_string,value_integer=a.value_integer,value_decimal=a.value_decimal,value_boolean=a.value_boolean,value_datetime=a.value_datetime,value_date=a.value_date,value_time=a.value_time,value_text=a.value_text;

	INSERT INTO receivercommunications SET
		created=NOW(),
		state='ACTIVE',
		`condition`='READY',
		condition_dt=NOW(),
		communicationtype_id=12,
		receiver_id=_receiver_id,
		cm_emailaddress=_receiver_emailaddress,
		cm_mobilephone=null,
		cm_clangid=_cm_clangid,
		cm_subject=_cm_subject,
		cm_groupid=_cm_groupid,
		cm_smssender=_cm_smssender,
		cm_smsname=_cm_smsname,
		cm_smsid=_cm_smsid,
		cm_sendemailaddress=qfuncGetTransferValueByName(_transfer_id,'sendemailaddress'),
		cm_sendname=qfuncGetTransferValueByName(_transfer_id,'sendname'),
		cm_replyemailaddress=qfuncGetTransferValueByName(_transfer_id,'replyemailaddress'),
		hash=_hash;

	UPDATE receivers SET modified=NOW(), transfercompleted=1 WHERE receiver_id=_delegate_receiver_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCreateClangReminders
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCreateClangReminders`;
DELIMITER ;;
CREATE PROCEDURE `qprodCreateClangReminders`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
INSERT INTO receivercommunications(created,state,`condition`,condition_dt,communicationtype_id,receiver_id,cm_emailaddress,cm_mobilephone,cm_clangtag,cm_clangid,cm_groupid,cm_sendemailaddress,cm_sendname,cm_replyemailaddress,cm_subject,`hash`,cm_smssender,cm_smsname,cm_smsid,previous_id)
SELECT 		
					NOW() as created,
					'ACTIVE' as state,
					'READY' as `condition`,
					NOW() as condition_dt,
					c2.communicationtype_id as communicationtype_id,
					r.receiver_id as receiver_id,
					rc.cm_emailaddress,
					rc.cm_mobilephone,

					rc.cm_clangtag,
					qfuncGetDocumentdefaultValueByName(dd.documentdefault_id,c2.clangid) as cm_clangid,
					qfuncGetDocumentdefaultValueByName(dd.documentdefault_id,c2.groupid) as cm_groupid,

					rc.cm_sendemailaddress,
					rc.cm_sendname,
					rc.cm_replyemailaddress,
					qfuncGetDocumentdefaultValueByName(dd.documentdefault_id, c2.`subject`) as cm_subject,
					rc.`hash` as `hash`,

					rc.cm_smssender,
					rc.cm_smsname,
					rc.cm_smsid,

					r.receiver_id as previous_id
					
FROM 			receivercommunications rc
JOIN 			communicationtypes c ON (c.communicationtype_id = rc.communicationtype_id AND c.state = 'ACTIVE')
JOIN 			communicationtypes c2 ON (c.communicationtype_id = c2.previous_id AND c2.state = 'ACTIVE')
JOIN 			receivers r ON (r.receiver_id = rc.receiver_id AND r.emailusable = 1 AND r.transfercompleted = 0 AND r.state = 'ACTIVE')
				#Indien tranfer voltooid is, dan geen reminder versturen
JOIN 			transfers tr ON (tr.transfer_id = r.transfer_id AND tr.state = 'ACTIVE')
JOIN 			documentdefaults dd ON (dd.documentdefault_id = tr.documentdefault_id AND dd.state = 'ACTIVE')
JOIN 			receivertypes t ON (t.receivertype_id = r.receivertype_id and t.state = 'ACTIVE')
LEFT JOIN 		receivercommunications rc2 ON (rc.receivercommunication_id = rc2.previous_id AND rc2.state = 'ACTIVE')
WHERE 			rc.`condition` = 'COMPLETED'
AND 			IFNULL(qfuncGetDocumentdefaultValueByName(dd.documentdefault_id,c2.period),0) > 0
				#Indien periode is leeg of 0 dan geen reminder versturen
AND 			rc2.communicationtype_id is null
AND 			NOW() > DATE_ADD(rc.condition_dt,INTERVAL qfuncGetDocumentdefaultValueByName(dd.documentdefault_id,c2.period) HOUR)
				#Na opgegeven periode de reminder versturen
AND 			DATEDIFF(NOW(),rc.created) < 30;
				#Uit veiligheid geen reminders op e-mails ouder dan 30 dagen.
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCreateDelegate
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCreateDelegate`;
DELIMITER ;;
CREATE PROCEDURE `qprodCreateDelegate`(IN `_transfer_id` int,IN `_receiver_id` int,IN `_delegate_email` varchar(100),IN `_hash` varchar(64), _cm_clangid INT, _cm_subject VARCHAR(255), _cm_groupid INT, _cm_smssender VARCHAR(100), _cm_smsname VARCHAR(100), _cm_smsid INT)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _delegate_receiver_id INT;

	INSERT INTO receivers SET
		created=NOW(),
		modified=NOW(),
		state='ACTIVE',
		transfer_id=_transfer_id,
		receivertype_id=5,
		delegate_receiver_id=_receiver_id,
		emailaddress=_delegate_email,
		emailusable=1,
		`security`=0,
		security_state='OPEN',
		transfercompleted=0;
	
	SELECT LAST_INSERT_ID() INTO _delegate_receiver_id;

	INSERT INTO receivervalues (created, modified,state,description,receiverdefault_id,receiver_id,value_string,value_integer,value_decimal,value_boolean,value_datetime,value_date,value_time,value_text)
		SELECT NOW(), NOW(),state,description,receiverdefault_id,_delegate_receiver_id,value_string,value_integer,value_decimal,value_boolean,value_datetime,value_date,value_time,value_text
		FROM receivervalues
		WHERE receiver_id=_receiver_id;

	INSERT INTO receivercommunications SET
		created=NOW(),
		state='ACTIVE',
		`condition`='READY',
		condition_dt=NOW(),
		communicationtype_id=11,
		receiver_id=_delegate_receiver_id,
		cm_emailaddress=_delegate_email,
		cm_mobilephone=null,
		cm_clangid=_cm_clangid,
		cm_subject=_cm_subject,
		cm_groupid=_cm_groupid,
		cm_smssender=_cm_smssender,
		cm_smsname=_cm_smsname,
		cm_smsid=_cm_smsid,
		cm_sendemailaddress=qfuncGetTransferValueByName(_transfer_id,'sendemailaddress'),
		cm_sendname=qfuncGetTransferValueByName(_transfer_id,'sendname'),
		cm_replyemailaddress=qfuncGetTransferValueByName(_transfer_id,'replyemailaddress'),
		hash=_hash;

	UPDATE receivers SET delegate_receiver_id=_delegate_receiver_id WHERE receiver_id=_receiver_id;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodCreateExternal
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodCreateExternal`;
DELIMITER ;;
CREATE PROCEDURE `qprodCreateExternal`(IN `_transfer_id` int,IN `_file_id` int,IN `_email` varchar(100),IN `_hash` varchar(64), _cm_clangid INT, _cm_subject VARCHAR(255), _cm_groupid INT)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _receiver_id INT;

	INSERT IGNORE INTO receivers SET
		created=NOW(),
		modified=NOW(),
		state='ACTIVE',
		transfer_id=_transfer_id,
		receivertype_id=4,
		delegate_receiver_id=_receiver_id,
		emailaddress=_email,
		emailusable=1,
		`security`=0,
		security_state='OPEN',
		transfercompleted=0;
	
	SELECT LAST_INSERT_ID() INTO _receiver_id;

	INSERT IGNORE INTO receivercommunications SET
		created=NOW(),
		state='ACTIVE',
		`condition`='READY',
		condition_dt=NOW(),
		communicationtype_id=8,
		receiver_id=_receiver_id,
		cm_emailaddress=_email,
		cm_clangid=_cm_clangid,
		cm_subject=_cm_subject,
		cm_groupid=_cm_groupid,
		cm_sendemailaddress=qfuncGetTransferValueByName(_transfer_id,'sendemailaddress'),
		cm_sendname=qfuncGetTransferValueByName(_transfer_id,'sendname'),
		cm_replyemailaddress=qfuncGetTransferValueByName(_transfer_id,'replyemailaddress'),
		hash=_hash,
		external_file_id=_file_id;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetClangValues
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetClangValues`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetClangValues`(`_receivercommunication_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle benodigde Clang waarden voor het versturen van een email of sms
#
# voorbeeld: 1

 

SELECT 'clangtag' as clangname,receivercommunications.cm_clangtag as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'clangid' as clangname,receivercommunications.cm_clangid as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'groupid' as clangname,receivercommunications.cm_groupid as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'sendemailaddress' as clangname,receivercommunications.cm_sendemailaddress as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'sendname' as clangname,receivercommunications.cm_sendname as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'replyemailaddress' as clangname,receivercommunications.cm_replyemailaddress as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'subject' as clangname,receivercommunications.cm_subject as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION 
SELECT 'sms_sender' as clangname,receivercommunications.cm_smssender as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'sms_name' as clangname,receivercommunications.cm_smsname as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'website' as clangname,
				CONCAT_WS('',qfuncGetDocumentdefaultValueByName(transfers.documentdefault_id, 'website'),'?t=',receivercommunications.`hash`) as waarde
FROM 		receivers
JOIN 		transfers 						 ON (transfers.transfer_id = receivers.transfer_id AND transfers.state =  'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'emailAddress' as clangname,receivercommunications.cm_emailaddress as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'address3' as clangname, CONCAT_WS('|',receivertypes.`name`,communicationtypes.name) as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
JOIN 		receivertypes 				 ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		communicationtypes 		 ON (communicationtypes.communicationtype_id = receivercommunications.communicationtype_id AND communicationtypes.state = 'ACTIVE')
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION 
SELECT  
				IFNULL(settingdefaults.clangname, settingdefaults.name) as clangname,
				qfuncGetTransferValueByName(transfers.transfer_id,settingdefaults.`name`) as waarde
FROM 		receivers
JOIN 		transfers 						ON (transfers.transfer_id = receivers.transfer_id AND transfers.state = 'ACTIVE')
JOIN 		transfervalues				ON (transfervalues.transfer_id = transfers.transfer_id AND transfervalues.state = 'ACTIVE')
JOIN 		settingdefaults				ON (settingdefaults.settingdefault_id = transfervalues.settingdefault_id AND settingdefaults.state = 'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		settingdefaults.settingdefault_id IN (19,21)
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'companyName' as clangname, receivers.company as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'gender' as clangname,receivers.gender as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION 
SELECT 'initials' as clangname,receivers.initials as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'prefix' as clangname,receivers.middlename as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 'mobilePhone' as clangname,receivers.mobilephone as waarde
FROM 		receivers
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY' AND receivercommunications.cm_emailaddress is not NULL)
WHERE		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE'
UNION
SELECT 
				IFNULL(receiverdefaults.clangname, receiverdefaults.name) as clangname,
				qfuncGetReceiverValueByName(receivers.receiver_id,receiverdefaults.`name`) as waarde
FROM 		receivers
JOIN 		transfers					ON (transfers.transfer_id = receivers.transfer_id AND transfers.state = 'ACTIVE')
JOIN 		documentdefaults	ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE')
JOIN		receiverfieldsets ON (receiverfieldsets.receiverfieldset_id = documentdefaults.receiverfieldset_id AND receiverfieldsets.state = 'ACTIVE')
JOIN 		receiverfields 		ON (receiverfields.receiverfieldset_id = receiverfieldsets.receiverfieldset_id AND receiverfields.state = 'ACTIVE')
JOIN 		receiverdefaults	ON (receiverdefaults.receiverdefault_id = receiverfields.receiverdefault_id AND receiverdefaults.state = 'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.`condition` = 'READY')
WHERE 	receivercommunications.cm_emailaddress is not NULL
AND 		receivercommunications.receivercommunication_id = _receivercommunication_id #<=== _receivercommunication_id
AND 		receivers.state = 'ACTIVE';
 
 
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetDistributionlistreceiverValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetDistributionlistreceiverValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetDistributionlistreceiverValuesByGroupname`(IN `_distributionlistreceiver_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
#
# Voorbeeld: 1, 'Adres'


SELECT _distributionlistreceiver_id AS distributionlistreceiver_id,
	NULL AS receiverfieldset_id, 
	sd.receiverdefault_id AS receiverdefault_id,
	sd.groupname AS groupname,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	NULL AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetDistributionlistreceiverValueByName(_distributionlistreceiver_id, sd.`name`) AS fieldvalue,
  qfuncGetReceiverDefaultValues(sd.type, sd.receiverdefault_id) AS defaultvalue,
	sd.info as info,
	sd.class as class,
	sd.display_type as display_type,
	sd.display_values as display_values

	FROM
		receiverdefaults AS sd
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
-- Procedure structure for qprodGetDocumentdefaultCommunications
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetDocumentdefaultCommunications`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetDocumentdefaultCommunications`(`_documentdefault_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle benodigde Clang waarden voor het versturen van een 1e email of sms
#
# voorbeeld: 1
 
SELECT 	
				receivertypes.receivertype_id,
				receivertypes.`name` as receivertype,
				communicationtypes.channel,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid)) is NULL, 
							0, 1)	
				WHEN 'SMS' THEN IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid)) is NULL, 
							0, IF(qfuncGetSystemValueByName(1,'SMS') = 1,1,0))	
				ELSE 0
				END as complete,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid)  
				ELSE NULL 
				END
				as cm_clangid,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid) 
				ELSE NULL 
				END  as cm_groupid,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)  
				ELSE NULL 
				END  as cm_subject,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') 
				ELSE NULL 
				END as cm_smsid,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_groupid') 
				ELSE NULL 
				END as cm_smsgroupid

FROM 		documentdefaults, 
				communicationtypes
JOIN		receivertypes ON (receivertypes.receivertype_id = communicationtypes.receivertype_id AND receivertypes.state = 'ACTIVE' )

WHERE 	documentdefaults.state = 'ACTIVE'
AND 		communicationtypes.sequence = 10
AND	 		documentdefaults.documentdefault_id = _documentdefault_id #<=== _documentdefault_id
;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetDocumentdefaultSignCommunications
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetDocumentdefaultSignCommunications`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetDocumentdefaultSignCommunications`(`_documentdefault_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle benodigde Clang waarden voor het versturen van een email na ondertekening
#
# voorbeeld: 1
 
SELECT 	
				receivertypes.receivertype_id,
				receivertypes.`name` as receivertype,
				communicationtypes.channel,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)) is NULL, 
							0, 1)	
				WHEN 'SMS' THEN IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)) is NULL, 
							0, IF(qfuncGetSystemValueByName(1,'SMS') = 1,1,0))	
				ELSE 0
				END as complete,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid)  
				ELSE NULL 
				END
				as cm_clangid,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid) 
				ELSE NULL 
				END  as cm_groupid,

				CASE communicationtypes.channel
				WHEN 'EMAIL' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)  
				ELSE NULL 
				END  as cm_subject,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') 
				ELSE NULL 
				END as cm_smsid,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_groupid') 
				ELSE NULL 
				END as cm_smsgroupid

FROM 		documentdefaults, 
				communicationtypes
JOIN		receivertypes ON (receivertypes.receivertype_id = communicationtypes.receivertype_id AND communicationtypes.state = 'ACTIVE')

WHERE 	documentdefaults.state = 'ACTIVE'
AND 		communicationtypes.sequence = 40 AND receivertypes.receivertype_id <> 4
AND	 		documentdefaults.documentdefault_id = 1 #<=== _documentdefault_id
;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetDocumentdefaultValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetDocumentdefaultValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetDocumentdefaultValuesByGroupname`(IN `_documentdefault_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle waardes van systemsettings binnen een groep.
# Indien geen specifieke groupname wordt opgegeven zullen alle worden getoond.
#
# Voorbeeld: 1, 'Ontvanger'


SELECT _documentdefault_id AS documentdefault_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetDocumentdefaultValueByName(_documentdefault_id, sd.`name`) AS fieldvalue,
    qfuncGetSettingDefaultValues(sd.type, sd.settingdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		settingdefaults AS sd
		JOIN settings AS s ON (sd.setting_id = s.setting_id AND s.`name`='DOCUMENTDEFAULTS')
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
-- Procedure structure for qprodGetDocumentValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetDocumentValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetDocumentValuesByGroupname`(IN `_document_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle waardes van systemsettings binnen een groep.
# Indien geen specifieke groupname wordt opgegeven zullen alle worden getoond.
#
# Voorbeeld: 1, 'Document'


SELECT _document_id AS document_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetDocumentValueByName(_document_id, sd.`name`) AS fieldvalue,
    qfuncGetSettingDefaultValues(sd.type, sd.settingdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		settingdefaults AS sd
		JOIN settings AS s ON (sd.setting_id = s.setting_id AND s.`name`='DOCUMENTS')
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
-- Procedure structure for qprodGetExternalCommunication
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetExternalCommunication`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetExternalCommunication`(`_transfer_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle gegevens om extra bevestigingen te versturen naar externe
#
# voorbeeld: 1

SELECT 	files.file_id, 
				qfuncGetDocumentValueByName(files.document_id, 'sign_emailaddress') as cm_emailaddress,
				qfuncGetDocumentValueByName(files.document_id, 'sign_clangid') as cm_clang_id,
				qfuncGetDocumentValueByName(files.document_id, 'sign_groupid') as cm_groupid,
				qfuncGetDocumentValueByName(files.document_id, 'sign_subject') as cm_subject
FROM 		files
JOIN 		documents ON (documents.document_id = files.document_id AND documents.state = 'ACTIVE')
WHERE 	qfuncGetDocumentValueByName(files.document_id, 'sign_email') = 1
AND 		files.state = 'ACTIVE'
AND 		files.transfer_id = _transfer_id;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetReceiverFiles
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetReceiverFiles`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetReceiverFiles`(IN `_receiver_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
#
# Voorbeeld: 1


SELECT 	'files'as type,
				files.file_id as id,
				files.created,
				files.filename,
				files.filelocation,
				DATE_ADD(files.created, INTERVAL qfuncGetSystemValueByName(transfers.transfer_id,'deleteperiod_files') DAY) as expired,
                NULL as signed
FROM 		files
JOIN 		transfers ON (transfers.transfer_id = files.transfer_id AND transfers.state = 'ACTIVE')
JOIN 		receivers ON (receivers.transfer_id = transfers.transfer_id AND receivers.receiver_id = _receiver_id)
LEFT JOIN 	filesignatures ON (filesignatures.file_id = files.file_id)
WHERE 		files.state = 'ACTIVE'
AND 		filesignatures.filesignature_id is NULL 
AND 		files.filedeleted is NULL
UNION

SELECT 	'files'as type,
				files.file_id as id,
				filesignatures.created,
				files.signed_filename,
				files.signed_filelocation,
				DATE_ADD(filesignatures.created, INTERVAL qfuncGetSystemValueByName(transfers.transfer_id,'deleteperiod_signedfiles') DAY) as expired,
				filesignatures.created as signed
FROM 		files 
JOIN 		transfers ON (transfers.transfer_id = files.transfer_id AND transfers.state = 'ACTIVE')
JOIN 		receivers ON (receivers.transfer_id = transfers.transfer_id AND receivers.receiver_id = _receiver_id)
JOIN 		filesignatures ON (filesignatures.file_id = files.file_id)
WHERE 		files.state = 'ACTIVE'
AND 		files.signed_filedeleted is NULL
UNION 
SELECT 	'attachments'as type,
				attachments.attachment_id as id,
				attachments.created,
				attachments.filename,
				attachments.filelocation,
				DATE_ADD(attachments.created, INTERVAL qfuncGetSystemValueByName(receivers.transfer_id,'deleteperiod_attachments') DAY) as expired,
                NULL as signed
FROM 		attachments
JOIN 		receivers ON (receivers.receiver_id = attachments.receiver_id AND receivers.receiver_id = _receiver_id)
WHERE 		attachments.state = 'ACTIVE'
AND 		attachments.filedeleted is NULL;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetReceiverValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetReceiverValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetReceiverValuesByGroupname`(IN `_receiver_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
#
# Voorbeeld: 1, 'Adres'


SELECT _receiver_id AS receiver_id,
	receiverfieldsets.receiverfieldset_id AS receiverfieldset_id, 
	sd.receiverdefault_id AS receiverdefault_id,
	sd.groupname AS groupname,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.class AS class,
	sd.display_type AS display_type,
	sd.display_values AS display_values,
	receiverfields.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetReceiverValueByName(_receiver_id, sd.`name`) AS fieldvalue,
  qfuncGetReceiverDefaultValues(sd.type, sd.receiverdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		receiverdefaults AS sd
		LEFT JOIN datachecks as dc ON (sd.datacheck_id = dc.datacheck_id)
        
    INNER JOIN 	receivers 			ON (receivers.receiver_id = _receiver_id AND receivers.state = 'ACTIVE') 
		INNER JOIN 	transfers		    ON (transfers.transfer_id = receivers.transfer_id AND transfers.state = 'ACTIVE')
		INNER JOIN 	documentdefaults	ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE')
		INNER JOIN	receiverfieldsets 	ON (receiverfieldsets.receiverfieldset_id = documentdefaults.receiverfieldset_id AND receiverfieldsets.state = 'ACTIVE')
 		INNER JOIN 	receiverfields 		ON (receiverfields.receiverfieldset_id = receiverfieldsets.receiverfieldset_id AND receiverfields.state = 'ACTIVE' AND receiverfields.receiverdefault_id = sd.receiverdefault_id )
        
        
	WHERE (_groupname='' OR sd.groupname=_groupname)
	AND   sd.state = 'ACTIVE'
	ORDER BY
		sd.groupsequence ASC,
		sd.sequence ASC;

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
# Voorbeeld: 1, 'AWS Bucket'


SELECT _system_id AS system_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
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
-- Procedure structure for qprodGetTransferAccess
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTransferAccess`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTransferAccess`(`_hash` varchar(64))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
#
# voorbeeld: 	'12564128sdfsdghf783rtsdy'

SELECT 		transfers.transfer_id,
					receivers.receiver_id,
					receivercommunications.receivercommunication_id,
					IF(receivers.security_state = 'OPEN',1,0) as transferaccess,
					IF(NOW() BETWEEN 
						MIN(rc2.condition_dt) AND 
						DATE_ADD(MIN(rc2.condition_dt),INTERVAL qfuncGetTransferValueByName(transfers.transfer_id,'security_availability') DAY),1,0) as transferactive,
					IF(receivers.transfercompleted, 1,0) as transfercompleted,		
					IF(qfuncGetTransferValueByName(transfers.transfer_id,'security') + IFNULL(receivers.`security`,0) > 0, 1,0)	as transfersecurity,
					receivertypes.name as receivertype,
					IF(NOW() BETWEEN 
						MIN(filesignatures.created) AND 
						DATE_ADD(MIN(filesignatures.created),INTERVAL qfuncGetTransferValueByName(transfers.transfer_id,'security_availability_signed') DAY),1,0) as signedactive,
					qfuncBlockedByDelegate(receivers.receiver_id) AS blocked_by_delegate
                    

FROM 			receivercommunications
JOIN 			receivercommunications rc2 ON (rc2.receiver_id = receivercommunications.receiver_id AND rc2.state = 'ACTIVE')
JOIN 			communicationtypes ON (communicationtypes.communicationtype_id = rc2.communicationtype_id AND communicationtypes.sequence IN (10, 30))
JOIN 			receivers ON (receivers.receiver_id = receivercommunications.receiver_id AND receivers.state = 'ACTIVE')
JOIN 			receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 			transfers ON (transfers.transfer_id = receivers.transfer_id AND transfers.state = 'ACTIVE')
LEFT JOIN 		receivercommunications rc3 ON (rc3.receiver_id = receivercommunications.receiver_id AND rc3.state = 'ACTIVE')
LEFT JOIN 			filesignatures ON (filesignatures.receivercommunication_id = rc3.receivercommunication_id)
WHERE 			receivercommunications.state = 'ACTIVE'
AND 			receivercommunications.`hash` = _hash; #<===== _hash
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetTransferCommunications
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTransferCommunications`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTransferCommunications`(`_transfer_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle benodigde Clang waarden voor het versturen van een email of sms
#
# voorbeeld: 1
 
SELECT 	
				transfers.transfer_id,
				receivertypes.`name` as receivertype,
				communicationtypes.`name` as communicationtype,
				communicationtypes.sequence as sequence,

         IF(communicationtypes.channel = 'EMAIL', 
						IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)) is NULL, 0,
							CASE receivertypes.`name`
								WHEN 'DELEGATE' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id, 'delegate')
								ELSE 1
							END),
            IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid)) is NULL, 0,1)) as complete,


				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL', qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),NULL)
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.clangid),NULL) #document_id
				ELSE NULL 
				END as cm_clangid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.groupid),NULL) #document_id
				ELSE NULL 
				END as cm_groupid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.`subject`),NULL) #document_id
				ELSE NULL 
				END as cm_subject,


				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.name = 'REMINDER',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`period`),NULL) #documentdefault_id
				ELSE NULL 
				END as period,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_sender') #documentdefault_id
				ELSE NULL 
				END as cm_smssender,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_name') #documentdefault_id
				ELSE NULL 
				END as cm_smsname,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') #documentdefault_id
				ELSE NULL 
				END as cm_smsid


FROM 		transfers 
JOIN 		documentdefaults ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE'), 
				communicationtypes
JOIN		receivertypes ON (receivertypes.receivertype_id = communicationtypes.receivertype_id AND receivertypes.state = 'ACTIVE' AND receivertypes.receivertype_id <> 4)

WHERE 	transfers.state =  'ACTIVE'
AND	 		transfers.transfer_id = _transfer_id #<=== _transfer_id
;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetTransferCommunicationsByReceivertypeAndCommunicationtype
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTransferCommunicationsByReceivertypeAndCommunicationtype`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTransferCommunicationsByReceivertypeAndCommunicationtype`(`_transfer_id` INT,`_receivertype` VARCHAR(50),`_communicationtype` VARCHAR(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle benodigde Clang waarden voor het versturen van een email of sms
#
# voorbeeld: 1
 
SELECT 	
				transfers.transfer_id,
				receivertypes.`name` as receivertype,
				communicationtypes.`name` as communicationtype,
				communicationtypes.sequence as sequence,

         IF(communicationtypes.channel = 'EMAIL', 
						IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`)) is NULL, 0,
							CASE receivertypes.`name`
								WHEN 'DELEGATE' THEN qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id, 'delegate')
								ELSE 1
							END),
            IF(CONCAT(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid)) is NULL, 0,1)) as complete,


				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL', qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),NULL)
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.clangid),NULL) #document_id
				ELSE NULL 
				END as cm_clangid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.groupid),NULL) #document_id
				ELSE NULL 
				END as cm_groupid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.`subject`),NULL) #document_id
				ELSE NULL 
				END as cm_subject,


				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.name = 'REMINDER',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`period`),NULL) #documentdefault_id
				ELSE NULL 
				END as period,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_sender') #documentdefault_id
				ELSE NULL 
				END as cm_smssender,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_name') #documentdefault_id
				ELSE NULL 
				END as cm_smsname,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') #documentdefault_id
				ELSE NULL 
				END as cm_smsid


FROM 		transfers 
JOIN 		documentdefaults ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE'), 
				communicationtypes
JOIN		receivertypes ON (receivertypes.receivertype_id = communicationtypes.receivertype_id AND receivertypes.state = 'ACTIVE' AND receivertypes.receivertype_id <> 4 AND receivertypes.name=_receivertype)

WHERE 	transfers.state =  'ACTIVE'
AND	 		transfers.transfer_id = _transfer_id #<=== _transfer_id
AND			communicationtypes.`name` = _communicationtype
;
 
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetTransferInformation
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTransferInformation`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTransferInformation`(`_transfer_id` INT, `_receiver_id` INT)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
#
# voorbeeld: 	1,1
#				1,0 

SELECT 	receivers.receiver_id,
				receivers.security_state,
				receivers.transfercompleted,
				transfers.transfer_id,
				receivertypes.`name` as receivertype,
				IF(files.file_id is NULL, 'documents', 'files') as type,
				IF(files.file_id is NULL, documents.document_id, files.file_id) as id,
				documents.name,
				documents.filename,
				documents.filelocation,
				qfuncGetDocumentValueByName(documents.document_id, 'download') as download_needed,
				IFNULL(files.mandatory_signature, qfuncGetDocumentValueByName(documents.document_id, 'signature')) as signature_needed,
				MIN(receivercommunications.condition_dt) as periodstart,
				DATE_ADD(MIN(receivercommunications.condition_dt),INTERVAL qfuncGetTransferValueByName(transfers.transfer_id,'security_availability') DAY) as periodend,
				IF(files.filename is NULL, 
						IFNULL(count(DISTINCT documentdownloads.documentdownload_id) + COUNT(DISTINCT filedownloads.filedownload_id),0),
						IFNULL(COUNT(DISTINCT filedownloads.filedownload_id),0))as downloads,
				COUNT(DISTINCT filesignatures.filesignature_id) as signature,
				MIN(filesignatures.created) as signed,
				COUNT(DISTINCT fd2.filedownload_id) as signeddownload,
				rc2.receivercommunication_id as receivercommunication_id,
				IF(qfuncGetDocumentValueByName(documents.document_id,'tooltip')='',NULL,qfuncGetDocumentValueByName(documents.document_id,'tooltip')) as tooltip
FROM 		transfers
JOIN 		documentdefaults ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE')
JOIN 		documents ON (documents.documentdefault_id = documentdefaults.documentdefault_id AND documents.state = 'ACTIVE')
JOIN 		receivers ON (receivers.transfer_id = transfers.transfer_id AND receivers.state = 'ACTIVE')
JOIN 		receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.state = 'ACTIVE' AND receivercommunications.`condition` = 'COMPLETED')
JOIN 		communicationtypes ON (communicationtypes.communicationtype_id = receivercommunications.communicationtype_id AND communicationtypes.state = 'ACTIVE' AND communicationtypes.sequence IN (10, 30))
LEFT JOIN 		documentdownloads ON (documentdownloads.document_id = documents.document_id AND documentdownloads.receivercommunication_id = receivercommunications.receivercommunication_id )
LEFT JOIN 		files ON (files.transfer_id = transfers.transfer_id AND files.document_id = documents.document_id)
LEFT JOIN 		filesignatures ON (filesignatures.file_id = files.file_id AND filesignatures.receivercommunication_id = receivercommunications.receivercommunication_id)
LEFT JOIN 		filedownloads ON (filedownloads.file_id = files.file_id AND filedownloads.receivercommunication_id = receivercommunications.receivercommunication_id AND IF(filesignatures.filesignature_id is NULL, 1=1,filedownloads.created < filesignatures.created))
LEFT JOIN 		filedownloads fd2 ON (fd2.file_id = files.file_id AND fd2.receivercommunication_id =  receivercommunications.receivercommunication_id AND fd2.created > filesignatures.created)
LEFT JOIN 		receivercommunications rc2 ON (rc2.receivercommunication_id = filesignatures.receivercommunication_id AND rc2.receiver_id = receivers.receiver_id)
WHERE 	transfers.state = 'ACTIVE'
AND 		transfers.transfer_id = _transfer_id #<=== _transfer_id
AND 		IF(_receiver_id = 0, 1=1, receivers.receiver_id = _receiver_id) #<=== _receiver_id
GROUP BY 1,2,3,4,5,6,7,8,9,10,11

UNION
SELECT 	receivers.receiver_id,
				receivers.security_state,
				receivers.transfercompleted,
				transfers.transfer_id,
				receivertypes.`name`,
				'files' as type,
				files.file_id as id,
				files.name,
				files.filename,
				files.filelocation,
				1 as download_needed,
				files.mandatory_signature as signature_needed,
				receivercommunications.condition_dt as periodstart,
				DATE_ADD(receivercommunications.condition_dt,INTERVAL qfuncGetTransferValueByName(transfers.transfer_id,'security_availability') DAY) as periodend,

				COUNT(DISTINCT filedownloads.filedownload_id) as downloads,
				COUNT(DISTINCT filesignatures.filesignature_id) as signature,
				MIN(filesignatures.created) as signed,
				COUNT(DISTINCT fd2.filedownload_id) as signeddownload,
				rc2.receivercommunication_id as receivercommunication_id,
				NULL as tooltip


FROM 		transfers
JOIN 		files ON (files.transfer_id = transfers.transfer_id AND files.state = 'ACTIVE')
JOIN 		receivers ON (receivers.transfer_id = transfers.transfer_id AND receivers.state = 'ACTIVE')
JOIN 		receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.state = 'ACTIVE' AND receivercommunications.`condition` = 'COMPLETED')
JOIN 		communicationtypes ON (communicationtypes.communicationtype_id = receivercommunications.communicationtype_id AND communicationtypes.state = 'ACTIVE' AND communicationtypes.sequence = 10)
LEFT JOIN 		filesignatures ON (filesignatures.file_id = files.file_id AND filesignatures.receivercommunication_id = receivercommunications.receivercommunication_id)
LEFT JOIN 		filedownloads ON (filedownloads.file_id = files.file_id AND filedownloads.receivercommunication_id = receivercommunications.receivercommunication_id AND IF(filesignatures.filesignature_id is NULL, 1=1,filedownloads.created < filesignatures.created))
LEFT JOIN 		filedownloads fd2 ON (fd2.file_id = files.file_id AND fd2.receivercommunication_id =  receivercommunications.receivercommunication_id AND fd2.created > filesignatures.created)
LEFT JOIN 		receivercommunications rc2 ON (rc2.receivercommunication_id = filesignatures.receivercommunication_id AND rc2.receiver_id = receivers.receiver_id)
WHERE 	files.state = 'ACTIVE'
AND 		files.document_id is NULL
AND 		transfers.transfer_id = _transfer_id #<=== _transfer_id
AND 		IF(_receiver_id = 0, 1=1, receivers.receiver_id = _receiver_id) #<=== _receiver_id
GROUP BY 1,2,3,4,5,6,7,8,9,10,11

UNION
SELECT 	receivers.receiver_id,
				receivers.security_state,
				receivers.transfercompleted,
				transfers.transfer_id,
				receivertypes.`name`,
				'attachments' as type,
				attachments.attachment_id as id,
				attachments.name,
				attachments.filename,
				attachments.filelocation,
				0 as download_needed,
				0 as signature_needed,
				receivercommunications.condition_dt as periodstart,
				DATE_ADD(receivercommunications.condition_dt,INTERVAL qfuncGetTransferValueByName(transfers.transfer_id,'security_availability') DAY) as periodend,

				COUNT(DISTINCT attachmentdownloads.attachmentdownload_id) as downloads,
				0 as signature,
				NULL as signed,
				0 as signeddownload,
				receivercommunications.receivercommunication_id as receivercommunication_id,
				NULL as tooltip

FROM 		transfers
JOIN 		receivers ON (receivers.transfer_id = transfers.transfer_id AND receivers.state = 'ACTIVE')
JOIN 		receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		receivercommunications ON (receivercommunications.receiver_id = receivers.receiver_id AND receivercommunications.state = 'ACTIVE' AND receivercommunications.`condition` = 'COMPLETED')
JOIN 		attachments ON (attachments.receiver_id = receivers.receiver_id AND attachments.state = 'ACTIVE')
LEFT JOIN 	attachmentdownloads ON (attachmentdownloads.attachment_id = attachments.attachment_id AND attachmentdownloads.receivercommunication_id = receivercommunications.receivercommunication_id )
WHERE 	attachments.state = 'ACTIVE'
AND 		transfers.transfer_id = _transfer_id #<=== _transfer_id
AND 		IF(_receiver_id = 0, 1=1, receivers.receiver_id = _receiver_id) #<=== _receiver_id
GROUP BY 1,2,3,4,5,6,7,8,9,10,11
ORDER BY 2,3;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetTransferValuesByGroupname
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetTransferValuesByGroupname`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetTransferValuesByGroupname`(IN `_transfer_id` int,IN `_groupname` varchar(50))
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Geeft alle waardes van systemsettings binnen een groep.
# Indien geen specifieke groupname wordt opgegeven zullen alle worden getoond.
#
# Voorbeeld: 1, 'Beveiliging'


SELECT _transfer_id AS transfer_id,
	s.setting_id AS setting_id,
	sd.settingdefault_id AS settingdefault_id,
	sd.groupname AS groupname,
	sd.`name` AS name,
	sd.label AS label,
	sd.type AS type,
	sd.mandatory AS mandatory,
	dc.`name` AS datacheck,
	qfuncGetTransferValueByName(_transfer_id, sd.`name`) AS fieldvalue,
    qfuncGetSettingDefaultValues(sd.type, sd.settingdefault_id) AS defaultvalue,
	sd.info as info

	FROM
		settingdefaults AS sd
		JOIN settings AS s ON (sd.setting_id = s.setting_id AND s.`name`='TRANSFERS')
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
-- Procedure structure for qprodInitializeDistributionlistreceiverSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeDistributionlistreceiverSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeDistributionlistreceiverSettings`( `_distributionlistreceiver_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	1

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO distributionlistreceivervalues											
				(	receiverdefault_id,
					created,
					distributionlistreceiver_id,									
					value_string,
					value_integer,
					value_decimal,
					value_boolean,
					value_datetime,
					value_date,
					value_time,
					value_text
				)
SELECT 		receiverdefaults.receiverdefault_id, 
					NOW(),
					_distributionlistreceiver_id, 									#<==== _distributionlistreceiver_id
					receiverdefaults.default_string,
					receiverdefaults.default_integer,
					receiverdefaults.default_decimal,
					receiverdefaults.default_boolean,
					receiverdefaults.default_datetime,
					receiverdefaults.default_date,
					receiverdefaults.default_time,
					receiverdefaults.default_text
FROM 		receiverdefaults 
WHERE 		receiverdefaults.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeDocumentdefaultSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeDocumentdefaultSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeDocumentdefaultSettings`( `_documentdefault_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	2

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO documentdefaultvalues											
				(	settingdefault_id,
					created,
					documentdefault_id,									
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
					_documentdefault_id, 									#<==== _documentdefault_id
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
WHERE 		settings.name = 'DOCUMENTDEFAULTS'  							#<=== SETTING
AND  			settings.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeDocumentSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeDocumentSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeDocumentSettings`( `_document_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	2

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO documentvalues											
				(	settingdefault_id,
					created,
					document_id,									
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
					_document_id, 									#<==== _document_id
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
WHERE 		settings.name = 'DOCUMENTS'  							#<=== SETTING
AND  			settings.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeReceiverSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeReceiverSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeReceiverSettings`( `_receiver_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	1

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO receivervalues											
				(	receiverdefault_id,
					created,
					receiver_id,									
					value_string,
					value_integer,
					value_decimal,
					value_boolean,
					value_datetime,
					value_date,
					value_time,
					value_text
				)
SELECT 		receiverdefaults.receiverdefault_id, 
					NOW(),
					_receiver_id, 									#<==== _receiver_id
					receiverdefaults.default_string,
					receiverdefaults.default_integer,
					receiverdefaults.default_decimal,
					receiverdefaults.default_boolean,
					receiverdefaults.default_datetime,
					receiverdefaults.default_date,
					receiverdefaults.default_time,
					receiverdefaults.default_text
FROM 		receiverdefaults 
WHERE 		receiverdefaults.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeSystemSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeSystemSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeSystemSettings`( `_system_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	1

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO systemvalues											
				(	settingdefault_id,
					created,
					system_id,									
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
					_system_id, 									#<==== _system_id
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
WHERE 		settings.name = 'SYSTEM'  							#<=== SETTING
AND  			settings.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);


END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeTransferCommunication
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeTransferCommunication`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeTransferCommunication`( `_transfer_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de initiele verzending (email en sms) aan te maken
# 
# voorbeeld: 	1

INSERT IGNORE receivercommunications (created,state,`condition`,condition_dt,communicationtype_id,receiver_id,cm_emailaddress, cm_mobilephone, cm_clangtag, cm_clangid, cm_groupid, cm_subject, cm_smssender, cm_smsname, cm_smsid, `hash`, cm_sendemailaddress, cm_sendname, cm_replyemailaddress)
SELECT 	
				NOW() as created,
				'ACTIVE'as `state`,
				'READY' as `condition`,
				NOW() as condition_dt,

				communicationtypes.communicationtype_id,
				receivers.receiver_id,

				receivers.emailaddress as cm_emailaddress,
				receivers.mobilephone as cm_mobilephone,

				CASE  communicationtypes.channel
				WHEN 	'EMAIL' THEN qfuncGetSystemValueByName(1,'email_brand')
				WHEN  'SMS'		THEN qfuncGetSystemValueByName(1,'sms_brand')
				ELSE 	NULL		
				END as cm_clangtag,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),NULL)
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.clangid),NULL) #document_id
				ELSE NULL 
				END as cm_clangid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.groupid),NULL) #document_id
				ELSE NULL 
				END as cm_groupid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.`subject`),NULL) #document_id
				ELSE NULL 
				END as cm_subject,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_sender') #documentdefault_id
				ELSE NULL 
				END as cm_smssender,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_name') #documentdefault_id
				ELSE NULL 
				END as cm_smsname,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') #documentdefault_id
				ELSE NULL 
				END as cm_smsid,

				MD5(CONCAT_WS('/',receivers.receiver_id, communicationtypes.communicationtype_id, now(),FLOOR(1000000000000 + (RAND() * 1000000000000)))) as `hash`,
                
                qfuncGetTransferValueByName(transfers.transfer_id,'sendemailaddress') as cm_sendemailaddress, 
                
                qfuncGetTransferValueByName(transfers.transfer_id,'sendname') as cm_sendname, 
                
                qfuncGetTransferValueByName(transfers.transfer_id,'replyemailaddress') as cm_replyemailaddress 
              

FROM 		receivers
JOIN 		transfers ON (transfers.transfer_id = receivers.transfer_id AND transfers.state =  'ACTIVE')
JOIN 		documentdefaults ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE')
JOIN 		receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		communicationtypes ON (communicationtypes.receivertype_id = receivertypes.receivertype_id AND communicationtypes.state = 'ACTIVE')
WHERE 	receivers.state = 'ACTIVE'
AND 		IF(qfuncGetSystemValueByName(1,'sms')=0, communicationtypes.channel <> 'SMS', 1=1)
AND 		IF(communicationtypes.channel = 'EMAIL', receivers.emailaddress is not NULL, 1=1)
AND 		IF(communicationtypes.channel = 'EMAIL', receivers.emailusable = 1, 1=1)
AND 		IF(communicationtypes.channel = 'SMS', receivers.mobilephone is not NULL, 1=1)
AND 		IF(communicationtypes.channel = 'SMS', IF(qfuncGetSystemValueByName(1,'SMS') = 1,1=1,1=0), 1=1)
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),'') <> '' 
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),'') <> '' 
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),'') <> '' 

AND 		communicationtypes.sequence = 10
AND	 		receivers.transfer_id = _transfer_id ;#<=== _transfer_id




END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeTransferCompleted
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeTransferCompleted`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeTransferCompleted`( `_transfer_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de  verzending (email) aan te maken wanneer documenten zijn ondertekend
# 
# voorbeeld: 	1

INSERT IGNORE receivercommunications (created,state,`condition`,condition_dt,communicationtype_id,receiver_id,cm_emailaddress, cm_mobilephone, cm_clangtag, cm_clangid, cm_groupid, cm_subject, cm_smssender, cm_smsname, cm_smsid, `hash`, cm_sendemailaddress, cm_sendname, cm_replyemailaddress)
SELECT 	
				NOW() as created,
				'ACTIVE'as `state`,
				'READY' as `condition`,
				NOW() as condition_dt,

				communicationtypes.communicationtype_id,
				receivers.receiver_id,

				receivers.emailaddress as cm_emailaddress,
				receivers.mobilephone as cm_mobilephone,

				CASE  communicationtypes.channel
				WHEN 	'EMAIL' THEN qfuncGetSystemValueByName(1,'email_brand')
				WHEN  'SMS'		THEN qfuncGetSystemValueByName(1,'sms_brand')
				ELSE 	NULL		
				END as cm_clangtag,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),NULL)
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.clangid),NULL) #document_id
				ELSE NULL 
				END as cm_clangid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.groupid),NULL) #document_id
				ELSE NULL 
				END as cm_groupid,

				CASE communicationtypes.setting_id
				WHEN 3 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),NULL) #documentdefault_id
#				WHEN 1 THEN IF(communicationtypes.channel = 'EMAIL',qfuncGetDocumentValueByName(1,communicationtypes.`subject`),NULL) #document_id
				ELSE NULL 
				END as cm_subject,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_sender') #documentdefault_id
				ELSE NULL 
				END as cm_smssender,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_name') #documentdefault_id
				ELSE NULL 
				END as cm_smsname,

				CASE communicationtypes.channel
				WHEN 'SMS' THEN qfuncGetDocumentdefaultValueByName (documentdefaults.documentdefault_id, 'sms_smsid') #documentdefault_id
				ELSE NULL 
				END as cm_smsid,

				MD5(CONCAT_WS('/',receivers.receiver_id, communicationtypes.communicationtype_id, now(),FLOOR(1000000000000 + (RAND() * 1000000000000)))) as `hash`,
                
                qfuncGetTransferValueByName(transfers.transfer_id,'sendemailaddress') as cm_sendemailaddress, 
                
                qfuncGetTransferValueByName(transfers.transfer_id,'sendname') as cm_sendname, 
                
                qfuncGetTransferValueByName(transfers.transfer_id,'replyemailaddress') as cm_replyemailaddress 

FROM 		receivers
JOIN 		transfers ON (transfers.transfer_id = receivers.transfer_id AND transfers.state =  'ACTIVE')
JOIN 		documentdefaults ON (documentdefaults.documentdefault_id = transfers.documentdefault_id AND documentdefaults.state = 'ACTIVE')
JOIN 		receivertypes ON (receivertypes.receivertype_id = receivers.receivertype_id AND receivertypes.state = 'ACTIVE')
JOIN 		communicationtypes ON (communicationtypes.receivertype_id = receivertypes.receivertype_id AND communicationtypes.state = 'ACTIVE')
WHERE 		receivers.state = 'ACTIVE'
AND 		IF(qfuncGetSystemValueByName(1,'sms')=0, communicationtypes.channel <> 'SMS', 1=1)
AND 		IF(communicationtypes.channel = 'EMAIL', receivers.emailaddress is not NULL, 1=1)
AND 		IF(communicationtypes.channel = 'EMAIL', receivers.emailusable = 1, 1=1)
AND 		IF(communicationtypes.channel = 'SMS', receivers.mobilephone is not NULL, 1=1)
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.clangid),'') <> '' 
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.groupid),'') <> '' 
AND 		IFNULL(qfuncGetDocumentdefaultValueByName(documentdefaults.documentdefault_id,communicationtypes.`subject`),'') <> '' 

AND 		communicationtypes.sequence = 40
AND	 		receivers.transfer_id = _transfer_id ;#<=== _transfer_id




END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeTransferReceivers
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeTransferReceivers`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeTransferReceivers`( `_dl_send` int, `_user_id` int, `_transfer_id` int, `_distributionlist_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de receiver records voor een nieuwe verzending aan te maken.
# 
# voorbeeld: 	1,1,2,1
# voorbeeld: 	0,1,2,1
DECLARE _done INT DEFAULT FALSE;
DECLARE _verzending INT;
DECLARE _cur1 CURSOR FOR SELECT transfers.transfer_id FROM transfers WHERE transfers.state = 'ACTIVE' AND (transfers.main_transfer_id = _transfer_id OR transfers.transfer_id = _transfer_id);
DECLARE CONTINUE HANDLER FOR NOT FOUND SET _done = TRUE;

SET _dl_send = IFNULL(_dl_send,1);
SET _user_id = IF(_user_id = 0, NULL, _user_id);

IF _distributionlist_id = 0
	THEN call qprodInitializeTransferCommunication(_transfer_id); #<== _transfer_id
    
ELSE 

IF 	_dl_send = 1 THEN  
	#ALLE distributielijstpersonen in 1 verzending 

	####### Receivers aanmaken
	INSERT IGNORE INTO receivers (created, created_user, modified, modified_user, transfer_id, distributionlistreceiver_id, receivertype_id, company, gender, initials, middlename, lastname, emailaddress, mobilephone, `security`)
	SELECT 		NOW() as created,
				_user_id as created_user, #<== _user_id
				NOW() as modified,
				_user_id as modified_user, #<== _user_id
				transfer_id as transfer_id,
				distributionlistreceivers.distributionlistreceiver_id as distributionlistreceiver_id,
				distributionlistreceivers.receivertype_id as receivertype_id,
				distributionlistreceivers.company as company,
				distributionlistreceivers.gender as gender,
				distributionlistreceivers.initials as initials,
				distributionlistreceivers.middlename as middlename,
				distributionlistreceivers.lastname as lastname,

				distributionlistreceivers.emailaddress as emailaddress,
				distributionlistreceivers.mobilephone as mobilephone,

				qfuncGetTransferValueByName(transfer_id,'security') as 'security'

	FROM 		transfers,
				distributionlists
	JOIN 		distributionlistreceivers ON (distributionlistreceivers.distributionlist_id = distributionlists.distributionlist_id AND distributionlistreceivers.state = 'ACTIVE')
	WHERE 		transfers.transfer_id = _transfer_id #<== _transfer_id
	AND 		distributionlists.distributionlist_id = _distributionlist_id #<== _distributionlist_id
	AND 		transfers.state =  'ACTIVE'
	AND 		distributionlists.state = 'ACTIVE';

	####### Receivervalues aanmaken
	INSERT IGNORE receivervalues (created, created_user, modified, modified_user, receiverdefault_id, receiver_id, value_string, value_integer, value_decimal, value_boolean, value_datetime, value_date, value_time, value_text)
	SELECT 		NOW() as created,
				_user_id as created_user, #<== _user_id
				NOW() as modified,
				_user_id as modified_user, #<== _user_id
				distributionlistreceivervalues.receiverdefault_id as receiverdefault_id,
				receivers.receiver_id as receiver_id,
				distributionlistreceivervalues.value_string,
				distributionlistreceivervalues.value_integer,
				distributionlistreceivervalues.value_decimal,
				distributionlistreceivervalues.value_boolean,
				distributionlistreceivervalues.value_datetime,
				distributionlistreceivervalues.value_date,
				distributionlistreceivervalues.value_time,
				distributionlistreceivervalues.value_text
	FROM 		receivers 
	JOIN 		distributionlistreceivervalues ON (distributionlistreceivervalues.distributionlistreceiver_id = receivers.distributionlistreceiver_id AND distributionlistreceivervalues.state = 'ACTIVE')
	WHERE 		receivers.transfer_id = _transfer_id; #<== _transfer_id
    
    ####### Communication records aanmaken
    call 		qprodInitializeTransferCommunication(_transfer_id); #<== _transfer_id

ELSE 
	#Voor elke distributielijstpersoon (type RECEIVER) een verzending aanmaken

	####### Transfers aanmaken
	INSERT 	INTO transfers (created, created_user, modified, modified_user, documentdefault_id, distributionlist_id, main_transfer_id, main_distributionlistreceiver_id)
	SELECT 	NOW() as created,
					_user_id as created_user, #<== _user_id
					NOW() as modified,
					_user_id as modified_user, #<== _user_id
					transfers.documentdefault_id as documentdefault_id,
					transfers.distributionlist_id as distributionlist_id,
					_transfer_id as main_transfer_id, #<== _transfer_id
					distributionlistreceivers.distributionlistreceiver_id as main_distributionlistreceiver_id

	FROM 			transfers,
					distributionlists
	JOIN 			distributionlistreceivers ON (distributionlistreceivers.distributionlist_id = distributionlists.distributionlist_id AND distributionlistreceivers.state = 'ACTIVE' AND distributionlistreceivers.receivertype_id = 1)
	WHERE 			transfers.transfer_id = _transfer_id #<== _transfer_id
	AND 			distributionlists.distributionlist_id = _distributionlist_id #<== _distributionlist_id
	AND 			transfers.state =  'ACTIVE'
	AND 			distributionlists.state = 'ACTIVE';

	####### Transfervalues aanmaken
	INSERT IGNORE INTO transfervalues (created, created_user, modified, modified_user, transfer_id, settingdefault_id, value_string, value_integer, value_decimal, value_boolean, value_datetime, value_date, value_time, value_text)
	SELECT 			NOW() as created,
					_user_id as created_user, #<== _user_id
					NOW() as modified,
					_user_id as modified_user, #<== _user_id
					t2.transfer_id as transfer_id,
					transfervalues.settingdefault_id as settingdefault_id,
					transfervalues.value_string,
					transfervalues.value_integer,
					transfervalues.value_decimal,
					transfervalues.value_boolean,
					transfervalues.value_datetime,
					transfervalues.value_date,
					transfervalues.value_time,
					transfervalues.value_text
	FROM 			transfervalues,
					transfers, transfers t2 
	WHERE			transfervalues.state = 'ACTIVE'
	AND 			transfers.transfer_id = _transfer_id #<== _transfer_id
	AND 			t2.main_transfer_id = _transfer_id; #<== _transfer_id

	####### Receivers aanmaken
	INSERT IGNORE INTO receivers (description, created, created_user, modified, modified_user, transfer_id, distributionlistreceiver_id, receivertype_id, company, gender, initials, middlename, lastname, emailaddress, mobilephone, `security`)
	SELECT 			'Deel I',
					NOW() as created,
					_user_id as created_user, #<== _user_id
					NOW() as modified,
					_user_id as modified_user, #<== _user_id
					transfer_id as transfer_id,
					distributionlistreceivers.distributionlistreceiver_id as distributionlistreceiver_id,
					distributionlistreceivers.receivertype_id as receivertype_id,
					distributionlistreceivers.company as company,
					distributionlistreceivers.gender as gender,
					distributionlistreceivers.initials as initials,
					distributionlistreceivers.middlename as middlename,
					distributionlistreceivers.lastname as lastname,
					distributionlistreceivers.emailaddress as emailaddress,
					distributionlistreceivers.mobilephone as mobilephone,
					qfuncGetTransferValueByName(transfer_id,'security') as 'security'
	FROM 			transfers
	JOIN			distributionlistreceivers ON (distributionlistreceivers.distributionlistreceiver_id = transfers.main_distributionlistreceiver_id AND distributionlistreceivers.state = 'ACTIVE')
	WHERE 			transfers.main_transfer_id = _transfer_id #<== _transfer_id
	AND 			transfers.state =  'ACTIVE';

	####### Receivers aanmaken deel II
	INSERT IGNORE INTO receivers (description, created, created_user, modified, modified_user, transfer_id, distributionlistreceiver_id, receivertype_id, company, gender, initials, middlename, lastname, emailaddress, mobilephone, `security`)
	SELECT 			'deel II',
					NOW() as created,
					_user_id as created_user, #<== _user_id
					NOW() as modified,
					_user_id as modified_user, #<== _user_id
					transfer_id as transfer_id,
					distributionlistreceivers.distributionlistreceiver_id as distributionlistreceiver_id,
					distributionlistreceivers.receivertype_id as receivertype_id,
					distributionlistreceivers.company as company,
					distributionlistreceivers.gender as gender,
					distributionlistreceivers.initials as initials,
					distributionlistreceivers.middlename as middlename,
					distributionlistreceivers.lastname as lastname,
					distributionlistreceivers.emailaddress as emailaddress,
					distributionlistreceivers.mobilephone as mobilephone,
					qfuncGetTransferValueByName(transfer_id,'security') as 'security'
	FROM 			transfers,
					distributionlistreceivers  
	WHERE 			transfers.main_transfer_id = _transfer_id #<== _transfer_id
	AND 			transfers.state =  'ACTIVE'
	AND 			distributionlistreceivers.distributionlist_id = transfers.distributionlist_id 
	AND 			distributionlistreceivers.receivertype_id <> 1
	AND 			distributionlistreceivers.state = 'ACTIVE';

	####### receivervalues aanmaken
	INSERT IGNORE receivervalues (created, created_user, modified, modified_user, receiverdefault_id, receiver_id, value_string, value_integer, value_decimal, value_boolean, value_datetime, value_date, value_time, value_text)
	SELECT 			
					NOW() as created,
					_user_id as created_user, #<== _user_id
					NOW() as modified,
					_user_id as modified_user, #<== _user_id
					distributionlistreceivervalues.receiverdefault_id as receiverdefault_id,
					receivers.receiver_id as receiver_id,
					distributionlistreceivervalues.value_string,
					distributionlistreceivervalues.value_integer,
					distributionlistreceivervalues.value_decimal,
					distributionlistreceivervalues.value_boolean,
					distributionlistreceivervalues.value_datetime,
					distributionlistreceivervalues.value_date,
					distributionlistreceivervalues.value_time,
					distributionlistreceivervalues.value_text
	FROM 			receivers
	JOIN 			transfers ON (receivers.transfer_id = receivers.transfer_id AND transfers.state = 'ACTIVE' AND transfers.main_transfer_id = _transfer_id) #<== _transfer_id
	JOIN 			distributionlistreceivervalues ON (distributionlistreceivervalues.distributionlistreceiver_id = receivers.distributionlistreceiver_id AND distributionlistreceivervalues.state = 'ACTIVE')
	WHERE 			receivers.state = 'ACTIVE';
    
	####### Communication records aanmaken
	OPEN _cur1;
    read_loop: LOOP
      FETCH _cur1 INTO _verzending;
        IF _done THEN
          LEAVE read_loop;
        END IF;
			call qprodInitializeTransferCommunication(_verzending); #<== _verzending
		END LOOP;
    CLOSE _cur1;
    

END IF;
END IF;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInitializeTransferSettings
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInitializeTransferSettings`;
DELIMITER ;;
CREATE PROCEDURE `qprodInitializeTransferSettings`( `_transfer_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# Wordt gebruikt om de nog settings te initieren
# 
# voorbeeld: 	2

# ===========================
# Wegschrijven standaard settings
# ===========================

INSERT INTO transfervalues											
				(	settingdefault_id,
					created,
					transfer_id,									
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
					_transfer_id, 									#<==== _transfer_id
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
WHERE 		settings.name = 'TRANSFERS'  							#<=== SETTING
AND  			settings.state = 'ACTIVE'
	ON DUPLICATE KEY UPDATE
			value_string= IFNULL(value_string,default_string),
			value_integer= IFNULL(value_integer,default_integer),
			value_decimal= IFNULL(value_decimal,default_decimal),
			value_boolean= IFNULL(value_boolean,default_boolean), 
			value_datetime= IFNULL(value_datetime,default_datetime),
			value_date= IFNULL(value_date,default_date),
			value_time= IFNULL(value_time,default_time),
			value_text= IFNULL(value_text,default_text);


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
# tabel userlocks 'opruimen' voor specifieke gebruiker en alles wat ouder is dan 2 uur
#
DELETE FROM userlocks
WHERE 		portal_user_id = _user_id OR 
			HOUR(TIMEDIFF(NOW(),userlocks.created)) > 2;
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
# voorbeeld 1,1,'document_id'
#
set @kweerie = 	CONCAT_WS(	'',
							'INSERT INTO userlocks (created, portal_user_id,',
							_type,
							') ',
							'SELECT	NOW(),',
							_user_id,', ',
							_id
						);

DELETE FROM userlocks WHERE portal_user_id = _user_id; 

PREPARE uitvoeren FROM @kweerie;

EXECUTE uitvoeren;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodRemoveDelegate
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodRemoveDelegate`;
DELIMITER ;;
CREATE PROCEDURE `qprodRemoveDelegate`(IN `_receiver_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _delegate_receiver_id INT;

	SELECT delegate_receiver_id INTO _delegate_receiver_id FROm receivers WHERE receiver_id=_receiver_id;

	UPDATE receivers SET state='INACTIVE', modified=NOW(), security_state='BLOCKED' where receiver_id=_delegate_receiver_id;
	
	UPDATE receivers SET delegate_receiver_id=null WHERE receiver_id=_receiver_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodUpdateBounceInfo
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodUpdateBounceInfo`;
DELIMITER ;;
CREATE PROCEDURE `qprodUpdateBounceInfo`()
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	UPDATE
		db036441_4dms_clang.mailer AS m
	INNER JOIN db036441_4dms_transfer2.emailaddresses AS t ON t.clangmailer_id = m.id
	SET t.received_state=m.rec_delivery_status
	WHERE
		m.tag = '4DMS' AND
		m.groupId = 138 AND
		t.received_state IS NULL;

END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodUpdateMailboxes
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodUpdateMailboxes`;
DELIMITER ;;
CREATE PROCEDURE `qprodUpdateMailboxes`(IN `_receiver_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
            DECLARE _emails text default '';
            DECLARE _emailCount int default 0;
            DECLARE _receiverdefault_id int default 0;
            
            

            # Get the emailaddresses to be counted
            SELECT qfuncGetReceiverValueByName(_receiver_id, 'kpn_emailaddresses') INTO _emails;

            # Ubermagic function to count `;`, in other terms: count the number of `;` and add 1 
			SELECT ROUND((CHAR_LENGTH(_emails)-CHAR_LENGTH(REPLACE( _emails, ";", ""))) / CHAR_LENGTH(";"))+1 INTO _emailCount;

            # Get the default_id for kpn_mailboxes
            SELECT receiverdefault_id INTO _receiverdefault_id FROM receiverdefaults WHERE name='kpn_mailboxes' AND state='ACTIVE';

            # Try to insert the new value orelse update the current
            INSERT INTO receivervalues (created, receiverdefault_id, receiver_id, value_integer) VALUES (NOW(), _receiverdefault_id, _receiver_id, _emailCount)
            ON DUPLICATE KEY UPDATE value_integer=_emailCount;
            
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncBlockedByDelegate
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncBlockedByDelegate`;
DELIMITER ;;
CREATE FUNCTION `qfuncBlockedByDelegate`(`_receiver_id` int) RETURNS tinyint(1)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _retval TINYINT(1) DEFAULT 0;
	DECLARE _delegate_receiver_id INT(11) DEFAULT 0;

	SELECT rd.receiver_id INTO _delegate_receiver_id 
	FROM receivers AS r
		INNER JOIN receivers AS rd ON r.delegate_receiver_id = rd.receiver_id AND rd.state='ACTIVE'
	WHERE
		r.receiver_id = _receiver_id;
	
	IF _delegate_receiver_id <> 0 THEN
		SELECT NOT r.transfercompleted INTO _retval
			FROM
				receivers AS r
			WHERE
				r.receiver_id = _delegate_receiver_id;
	ELSE
		SET _retval = 0;
	END IF;

	RETURN _retval;

END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncCalculateStaffelPrice
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncCalculateStaffelPrice`;
DELIMITER ;;
CREATE FUNCTION `qfuncCalculateStaffelPrice`(`_type` varchar(25),`_count` int) RETURNS decimal(8,2)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _ret DECIMAL(8,2) DEFAULT 0.0;

	SELECT tarief*_count INTO _ret FROM kpnstaffels WHERE kpntype=_type AND vanaf <= _count ORDER BY kpnstaffel_id DESC LIMIT 1;

	RETURN _ret;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDistributionlistreceiverValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDistributionlistreceiverValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDistributionlistreceiverValueByName`(`_distributionlistreceiver_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	# voorbeeld: 1,'street'


	DECLARE _receiverdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			distributionlistreceivervalues.receiverdefault_id, 
					receiverdefaults.type INTO _receiverdefault_id, _type
	FROM 			distributionlistreceivervalues 
		INNER JOIN 	receiverdefaults 	ON (distributionlistreceivervalues.receiverdefault_id = receiverdefaults.receiverdefault_id)
 	WHERE
		distributionlistreceivervalues.distributionlistreceiver_id 	= _distributionlistreceiver_id AND
		receiverdefaults.name 						= _settingname AND
		receiverdefaults.state 						= 'ACTIVE' AND
		distributionlistreceivervalues.state 		= 'ACTIVE';

	SET _returnvalue = qfuncGetDistributionlistreceiverValues(_receiverdefault_id, _type , _distributionlistreceiver_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDistributionlistreceiverValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDistributionlistreceiverValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDistributionlistreceiverValues`(`_receiverdefault_id` INT, `_type` varchar(50),  `_distributionlistreceiver_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld:  1,'string',1

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM distributionlistreceivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.distributionlistreceiver_id = _distributionlistreceiver_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDocumentdefaultValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDocumentdefaultValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDocumentdefaultValueByName`(`_documentdefault_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_documentdefault_id 	=  opvragen van een bepaalde document, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'send_clangid'


	DECLARE _settingdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			documentdefaultvalues.settingdefault_id, 
					settingdefaults.type INTO _settingdefault_id, _type
	FROM 			documentdefaultvalues 
		INNER JOIN 	settingdefaults 	ON (documentdefaultvalues.settingdefault_id = settingdefaults.settingdefault_id)
		INNER JOIN 	settings 				ON (settings.setting_id = settingdefaults.setting_id)
	WHERE
		settings.name 								= 'DOCUMENTDEFAULTS' AND
		documentdefaultvalues.documentdefault_id 	= _documentdefault_id AND
		settingdefaults.name 						= _settingname AND
		settingdefaults.state 						= 'ACTIVE' AND
		settings.state	 									= 'ACTIVE' AND
		documentdefaultvalues.state 			= 'ACTIVE';

	SET _returnvalue = qfuncGetDocumentdefaultValues(_settingdefault_id, _type , _documentdefault_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDocumentdefaultValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDocumentdefaultValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDocumentdefaultValues`(`_settingdefault_id` INT, `_type` varchar(50),  `_documentdefault_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM documentdefaultvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.documentdefault_id = _documentdefault_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDocumentValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDocumentValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDocumentValueByName`(`_document_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_document_id 			=  opvragen van een bepaalde document, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'start'


	DECLARE _settingdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			documentvalues.settingdefault_id, 
					settingdefaults.type INTO _settingdefault_id, _type
	FROM 			documentvalues 
		INNER JOIN 	settingdefaults 	ON (documentvalues.settingdefault_id = settingdefaults.settingdefault_id)
		INNER JOIN 	settings 				ON (settings.setting_id = settingdefaults.setting_id)
	WHERE
		settings.name 								= 'DOCUMENTS' AND
		documentvalues.document_id 					= _document_id AND
		settingdefaults.name 						= _settingname AND
		settingdefaults.state 						= 'ACTIVE' AND
		settings.state	 							= 'ACTIVE' AND
		documentvalues.state 						= 'ACTIVE';

	SET _returnvalue = qfuncGetDocumentValues(_settingdefault_id, _type , _document_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetDocumentValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetDocumentValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetDocumentValues`(`_settingdefault_id` INT, `_type` varchar(50),  `_document_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM documentvalues s WHERE s.settingdefault_id = _settingdefault_id AND s.document_id = _document_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetReceiverDefaultValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetReceiverDefaultValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetReceiverDefaultValues`(`_type` varchar(255), `_receiverdefault_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN   
# ophalen van default settingwaarde
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.default_string INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'integer' THEN SELECT s.default_integer        INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'decimal' THEN SELECT s.default_decimal        INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'boolean' THEN SELECT s.default_boolean        INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'datetime' THEN SELECT s.default_datetime INTO _returnvalue   FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'date' THEN SELECT s.default_date              INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'time' THEN SELECT s.default_time              INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id; 
                   WHEN 'text' THEN SELECT s.default_text              INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'language' THEN SELECT s.default_language INTO _returnvalue   FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;
                   WHEN 'country' THEN SELECT s.default_country        INTO _returnvalue       FROM receiverdefaults s WHERE s.receiverdefault_id = _receiverdefault_id;

                ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetReceiverValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetReceiverValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetReceiverValueByName`(`_receiver_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_receiver_id 			=  opvragen van een bepaalde system, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'street'


	DECLARE _receiverdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			receivervalues.receiverdefault_id, 
					receiverdefaults.type INTO _receiverdefault_id, _type
	FROM 			receivervalues 
		INNER JOIN 	receiverdefaults 	ON (receivervalues.receiverdefault_id = receiverdefaults.receiverdefault_id)
 	WHERE
		receivervalues.receiver_id 					= _receiver_id AND
		receiverdefaults.name 						= _settingname AND
		receiverdefaults.state 						= 'ACTIVE' AND
		receivervalues.state 						= 'ACTIVE';

	SET _returnvalue = qfuncGetReceiverValues(_receiverdefault_id, _type , _receiver_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetReceiverValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetReceiverValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetReceiverValues`(`_receiverdefault_id` INT, `_type` varchar(50),  `_receiver_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld:  1,'string',1

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM receivervalues s WHERE s.receiverdefault_id = _receiverdefault_id AND s.receiver_id = _receiver_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
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

	# voorbeeld: 1,'email_brand'


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
-- Function structure for qfuncGetTransferValueByName
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetTransferValueByName`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetTransferValueByName`(`_transfer_id` int,`_settingname` varchar(50)) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
	#_tranfser_id 			=  opvragen van een bepaalde document, met
	#_settingname			= 'waarde van een bepaalde setting.

	# voorbeeld: 1,'security'


	DECLARE _settingdefault_id INT;
	DECLARE _type varchar(50);
	DECLARE _returnvalue TEXT DEFAULT '';

	SELECT 			transfervalues.settingdefault_id, 
					settingdefaults.type INTO _settingdefault_id, _type
	FROM 			transfervalues 
		INNER JOIN 	settingdefaults 	ON (transfervalues.settingdefault_id = settingdefaults.settingdefault_id)
		INNER JOIN 	settings 				ON (settings.setting_id = settingdefaults.setting_id)
	WHERE
		settings.name 								= 'TRANSFERS' AND
		transfervalues.transfer_id 					= _transfer_id AND
		settingdefaults.name 						= _settingname AND
		settingdefaults.state 						= 'ACTIVE' AND
		settings.state	 							= 'ACTIVE' AND
		transfervalues.state 						= 'ACTIVE';

	SET _returnvalue = qfuncGetTransfervalues(_settingdefault_id, _type , _transfer_id);


	RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetTransferValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetTransferValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetTransferValues`(`_settingdefault_id` INT, `_type` varchar(50),  `_transfer_id` INT) RETURNS mediumtext CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN 
# 
#
# voorbeeld: 

                DECLARE _returnvalue TEXT DEFAULT '';
                
                CASE _type
                   WHEN 'string' THEN SELECT s.value_string 	INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'integer' THEN SELECT s.value_integer 	INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'decimal' THEN SELECT s.value_decimal 	INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'boolean' THEN SELECT s.value_boolean 	INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'datetime' THEN SELECT s.value_datetime INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'date' THEN SELECT s.value_date 		INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
                   WHEN 'time' THEN SELECT s.value_time 		INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id; 
                   WHEN 'text' THEN SELECT s.value_text 		INTO _returnvalue 	FROM transfervalues s WHERE s.settingdefault_id = _settingdefault_id AND s.transfer_id = _transfer_id;
 
								ELSE SET _returnvalue='';
                END CASE;
                
                RETURN _returnvalue;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncWrongPincode
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncWrongPincode`;
DELIMITER ;;
CREATE FUNCTION `qfuncWrongPincode`(`_receiver_id` int) RETURNS int(10)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _out int default 0;

	UPDATE receivers SET modified=Now(), security_attempts = security_attempts+1, security_state=IF(security_attempts >= 3, 'BLOCKED', 'OPEN') WHERE receiver_id=_receiver_id;

	SELECT security_attempts INTO _out FROM receivers WHERE receiver_id=_receiver_id;

	RETURN _out;
END
;;
DELIMITER ;
SET FOREIGN_KEY_CHECKS=1;
