/*
Navicat MySQL Data Transfer

Source Server         : Byte Test & Acceptatie
Source Server Version : 50632
Source Host           : dbint036441:3306
Source Database       : db036441_4dmc_nixxis_calldata

Target Server Type    : MYSQL
Target Server Version : 50632
File Encoding         : 65001

Date: 2017-05-11 19:55:11
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for booleanvalues
-- ----------------------------
DROP TABLE IF EXISTS `booleanvalues`;
CREATE TABLE `booleanvalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` tinyint(1) unsigned zerofill DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `booleanvalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `booleanvalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for callhistories
-- ----------------------------
DROP TABLE IF EXISTS `callhistories`;
CREATE TABLE `callhistories` (
  `callhistory_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `user_id` int(11) unsigned NOT NULL,
  `startdate` datetime DEFAULT NULL,
  `enddate` datetime DEFAULT NULL,
  PRIMARY KEY (`callhistory_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `callhistories_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `callhistories_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=270 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaign_field_validations
-- ----------------------------
DROP TABLE IF EXISTS `campaign_field_validations`;
CREATE TABLE `campaign_field_validations` (
  `campaign_field_validation_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `created_user_id` int(11) unsigned NOT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `campaign_field_id` int(11) unsigned NOT NULL,
  `rule` varchar(100) DEFAULT NULL,
  `param1` varchar(255) DEFAULT NULL,
  `param2` varchar(255) DEFAULT NULL,
  `param3` varchar(255) DEFAULT NULL,
  `message` varchar(255) DEFAULT NULL,
  `last` tinyint(1) unsigned DEFAULT '0',
  `allowEmpty` tinyint(1) unsigned DEFAULT '0',
  `displayorder` int(11) unsigned DEFAULT '0',
  PRIMARY KEY (`campaign_field_validation_id`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `campaign_fieldvalidations_ibfk_3` (`campaign_field_id`),
  CONSTRAINT `campaign_field_validations_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `campaign_field_validations_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `campaign_field_validations_ibfk_3` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2123 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaign_fields
-- ----------------------------
DROP TABLE IF EXISTS `campaign_fields`;
CREATE TABLE `campaign_fields` (
  `campaign_field_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `campaign_id` int(11) unsigned NOT NULL,
  `fieldsetvalue_id` int(11) unsigned DEFAULT NULL,
  `fieldtype_id` int(11) unsigned DEFAULT NULL,
  `displayset_id` int(11) unsigned DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `label` varchar(255) DEFAULT NULL,
  `info` text,
  `required` tinyint(1) unsigned DEFAULT '0',
  `markup` varchar(255) DEFAULT NULL,
  `readonly` tinyint(1) unsigned DEFAULT '0',
  `displayorder` int(11) unsigned DEFAULT '0',
  `griddisplay` tinyint(1) unsigned zerofill DEFAULT '0',
  PRIMARY KEY (`campaign_field_id`),
  UNIQUE KEY `campaign_id` (`campaign_id`,`fieldsetvalue_id`) USING BTREE,
  KEY `state` (`state`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `fieldsetvalue_id` (`fieldsetvalue_id`),
  KEY `fieldtype_id` (`fieldtype_id`),
  KEY `displayset_id` (`displayset_id`),
  CONSTRAINT `campaign_fields_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `campaign_fields_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `campaign_fields_ibfk_3` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `campaign_fields_ibfk_5` FOREIGN KEY (`fieldtype_id`) REFERENCES `fieldtypes` (`fieldtype_id`) ON UPDATE CASCADE,
  CONSTRAINT `campaign_fields_ibfk_6` FOREIGN KEY (`displayset_id`) REFERENCES `displaysets` (`displayset_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5546 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for campaigns
-- ----------------------------
DROP TABLE IF EXISTS `campaigns`;
CREATE TABLE `campaigns` (
  `campaign_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('DESIGN','TEST','PRODUCTION','DELETED') DEFAULT 'DESIGN',
  `organisation_id` int(11) unsigned NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `type` enum('INBOUND','OUTBOUND') DEFAULT NULL,
  `nixxis_to` varchar(20) DEFAULT NULL,
  `nixxis_cpid` varchar(32) DEFAULT NULL,
  `nixxis_version` int(1) unsigned DEFAULT '1',
  `respondent_count` int(11) unsigned DEFAULT '0',
  PRIMARY KEY (`campaign_id`),
  KEY `fk_campaign_organisation` (`organisation_id`),
  KEY `idx_state` (`state`) USING BTREE,
  CONSTRAINT `fk_campaign_organisation` FOREIGN KEY (`organisation_id`) REFERENCES `organisations` (`organisation_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for datetimevalues
-- ----------------------------
DROP TABLE IF EXISTS `datetimevalues`;
CREATE TABLE `datetimevalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `datetimevalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `datetimevalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for datevalues
-- ----------------------------
DROP TABLE IF EXISTS `datevalues`;
CREATE TABLE `datevalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `datevalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `datevalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2964 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for displaysets
-- ----------------------------
DROP TABLE IF EXISTS `displaysets`;
CREATE TABLE `displaysets` (
  `displayset_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(100) DEFAULT NULL,
  `description` text,
  `displaytype_id` int(11) unsigned DEFAULT NULL,
  `model_list_source` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`displayset_id`),
  UNIQUE KEY `idx_name` (`name`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `idx_state` (`state`),
  KEY `displaytype_id` (`displaytype_id`),
  CONSTRAINT `displaysets_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `displaysets_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `displaysets_ibfk_3` FOREIGN KEY (`displaytype_id`) REFERENCES `displaytypes` (`displaytype_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=80 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for displaysetvalues
-- ----------------------------
DROP TABLE IF EXISTS `displaysetvalues`;
CREATE TABLE `displaysetvalues` (
  `displaysetvalue_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `displayset_id` int(11) unsigned NOT NULL,
  `displaytype_id` int(11) unsigned DEFAULT NULL,
  `value` varchar(100) DEFAULT NULL,
  `label` varchar(100) DEFAULT NULL,
  `info` text,
  `isdefault` tinyint(1) unsigned zerofill DEFAULT '0',
  PRIMARY KEY (`displaysetvalue_id`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `displayset_id` (`displayset_id`),
  KEY `displaytype_id` (`displaytype_id`),
  CONSTRAINT `displaysetvalues_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `displaysetvalues_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `displaysetvalues_ibfk_3` FOREIGN KEY (`displayset_id`) REFERENCES `displaysets` (`displayset_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `displaysetvalues_ibfk_4` FOREIGN KEY (`displaytype_id`) REFERENCES `displaytypes` (`displaytype_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=348 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for displaytypes
-- ----------------------------
DROP TABLE IF EXISTS `displaytypes`;
CREATE TABLE `displaytypes` (
  `displaytype_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(50) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `custom_options` tinyint(1) unsigned zerofill DEFAULT '0',
  `class` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`displaytype_id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for exportfiles
-- ----------------------------
DROP TABLE IF EXISTS `exportfiles`;
CREATE TABLE `exportfiles` (
  `exportfile_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `campaign_id` int(11) unsigned DEFAULT NULL,
  `date_from` date DEFAULT NULL,
  `date_to` date DEFAULT NULL,
  `delimiter` varchar(5) DEFAULT NULL,
  `recordcount` int(11) unsigned DEFAULT NULL,
  PRIMARY KEY (`exportfile_id`),
  KEY `campaign_id` (`campaign_id`),
  CONSTRAINT `exportfiles_ibfk_1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for fieldsets
-- ----------------------------
DROP TABLE IF EXISTS `fieldsets`;
CREATE TABLE `fieldsets` (
  `fieldset_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(100) DEFAULT NULL,
  `description` text,
  `campaign_id` int(11) unsigned DEFAULT NULL,
  PRIMARY KEY (`fieldset_id`),
  UNIQUE KEY `idx_name` (`name`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `idx_state` (`state`),
  KEY `campaign_id` (`campaign_id`),
  CONSTRAINT `fieldsets_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsets_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsets_ibfk_3` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for fieldsetvalues
-- ----------------------------
DROP TABLE IF EXISTS `fieldsetvalues`;
CREATE TABLE `fieldsetvalues` (
  `fieldsetvalue_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `fieldset_id` int(11) unsigned NOT NULL,
  `fieldtype_id` int(11) unsigned DEFAULT NULL,
  `displayset_id` int(11) unsigned DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `label` varchar(255) DEFAULT NULL,
  `info` text,
  `required` tinyint(1) unsigned zerofill DEFAULT '0',
  `markup` varchar(255) DEFAULT NULL,
  `readonly` tinyint(1) unsigned zerofill DEFAULT '0',
  `griddisplay` tinyint(1) DEFAULT '0',
  `fieldsetvalue_order` int(11) DEFAULT '0',
  PRIMARY KEY (`fieldsetvalue_id`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `fieldset_id` (`fieldset_id`),
  KEY `fieldtype_id` (`fieldtype_id`),
  KEY `displayset_id` (`displayset_id`),
  CONSTRAINT `fieldsetvalues_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvalues_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvalues_ibfk_3` FOREIGN KEY (`fieldset_id`) REFERENCES `fieldsets` (`fieldset_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvalues_ibfk_4` FOREIGN KEY (`fieldtype_id`) REFERENCES `fieldtypes` (`fieldtype_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvalues_ibfk_5` FOREIGN KEY (`displayset_id`) REFERENCES `displaysets` (`displayset_id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=157 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for fieldsetvaluevalidations
-- ----------------------------
DROP TABLE IF EXISTS `fieldsetvaluevalidations`;
CREATE TABLE `fieldsetvaluevalidations` (
  `fieldsetvaluevalidation_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime NOT NULL,
  `created_user_id` int(11) unsigned NOT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') NOT NULL DEFAULT 'ACTIVE',
  `fieldsetvalue_id` int(11) unsigned NOT NULL,
  `rule` varchar(100) DEFAULT NULL,
  `param1` varchar(255) DEFAULT NULL,
  `param2` varchar(255) DEFAULT NULL,
  `param3` varchar(255) DEFAULT NULL,
  `message` varchar(255) DEFAULT NULL,
  `last` tinyint(1) unsigned DEFAULT '0',
  `allowEmpty` tinyint(1) unsigned DEFAULT '1',
  `displayorder` int(11) unsigned DEFAULT '0',
  PRIMARY KEY (`fieldsetvaluevalidation_id`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `fieldsetvalue_id` (`fieldsetvalue_id`),
  CONSTRAINT `fieldsetvaluevalidations_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvaluevalidations_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `fieldsetvaluevalidations_ibfk_3` FOREIGN KEY (`fieldsetvalue_id`) REFERENCES `fieldsetvalues` (`fieldsetvalue_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for fieldtypes
-- ----------------------------
DROP TABLE IF EXISTS `fieldtypes`;
CREATE TABLE `fieldtypes` (
  `fieldtype_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(50) DEFAULT NULL,
  `datatable` varchar(255) DEFAULT NULL,
  `modelname` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`fieldtype_id`),
  UNIQUE KEY `name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for floatvalues
-- ----------------------------
DROP TABLE IF EXISTS `floatvalues`;
CREATE TABLE `floatvalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` float(15,5) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `floatvalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `floatvalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for importfilefields
-- ----------------------------
DROP TABLE IF EXISTS `importfilefields`;
CREATE TABLE `importfilefields` (
  `importfilefield_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `importfile_id` int(11) unsigned DEFAULT NULL,
  `column_id` int(11) unsigned NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `campaign_field_id` int(11) unsigned DEFAULT NULL,
  PRIMARY KEY (`importfilefield_id`),
  UNIQUE KEY `file_id_name` (`importfile_id`,`name`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `importfilefields_ibfk_1` FOREIGN KEY (`importfile_id`) REFERENCES `importfiles` (`importfile_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `importfilefields_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27755 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for importfiles
-- ----------------------------
DROP TABLE IF EXISTS `importfiles`;
CREATE TABLE `importfiles` (
  `importfile_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('OPEN','DONE','ABORT','RUNNING','ERROR') DEFAULT 'OPEN',
  `campaign_id` int(11) unsigned DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `delimiter` varchar(5) DEFAULT NULL,
  `linecount` int(11) unsigned DEFAULT NULL,
  `totallines` int(11) unsigned DEFAULT NULL,
  `errormessage` text,
  PRIMARY KEY (`importfile_id`),
  KEY `campaign_id` (`campaign_id`),
  KEY `importfile_id` (`importfile_id`,`campaign_id`),
  CONSTRAINT `importfiles_ibfk_1` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1071 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for integervalues
-- ----------------------------
DROP TABLE IF EXISTS `integervalues`;
CREATE TABLE `integervalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `integervalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `integervalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=111037 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for items
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `item_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `parent_id` int(11) unsigned DEFAULT NULL,
  `lft` int(11) DEFAULT NULL,
  `rght` int(11) DEFAULT NULL,
  `plugin` varchar(45) DEFAULT NULL,
  `controller` varchar(45) DEFAULT NULL,
  `action` varchar(45) DEFAULT NULL,
  `icon` varchar(255) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`item_id`),
  KEY `parent_id` (`parent_id`) USING BTREE,
  CONSTRAINT `items_ibfk_1` FOREIGN KEY (`parent_id`) REFERENCES `items` (`item_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for markups
-- ----------------------------
DROP TABLE IF EXISTS `markups`;
CREATE TABLE `markups` (
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for organisations
-- ----------------------------
DROP TABLE IF EXISTS `organisations`;
CREATE TABLE `organisations` (
  `organisation_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(100) DEFAULT NULL,
  `logo` varchar(255) DEFAULT NULL,
  `campaign_count` int(11) unsigned DEFAULT '0',
  PRIMARY KEY (`organisation_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for qualifications
-- ----------------------------
DROP TABLE IF EXISTS `qualifications`;
CREATE TABLE `qualifications` (
  `qualification_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `campaign_id` int(11) unsigned DEFAULT NULL,
  `name` varchar(4) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `type` char(2) DEFAULT '0',
  `callback` tinyint(1) unsigned zerofill DEFAULT '0',
  `letter_type` tinyint(1) unsigned zerofill DEFAULT '0',
  `respondent_count` int(11) unsigned DEFAULT '0',
  PRIMARY KEY (`qualification_id`),
  UNIQUE KEY `idx_campaign_name` (`campaign_id`,`name`),
  KEY `qualification_id` (`qualification_id`,`campaign_id`),
  CONSTRAINT `fk_qualification_campaign` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1284 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for respondent_exportfiles
-- ----------------------------
DROP TABLE IF EXISTS `respondent_exportfiles`;
CREATE TABLE `respondent_exportfiles` (
  `respondent_exportfile_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `exportfile_id` int(11) unsigned NOT NULL,
  PRIMARY KEY (`respondent_exportfile_id`),
  UNIQUE KEY `respondent_id` (`respondent_id`,`exportfile_id`),
  KEY `exportfile_id` (`exportfile_id`),
  CONSTRAINT `respondent_exportfiles_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `respondent_exportfiles_ibfk_2` FOREIGN KEY (`exportfile_id`) REFERENCES `exportfiles` (`exportfile_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for respondents
-- ----------------------------
DROP TABLE IF EXISTS `respondents`;
CREATE TABLE `respondents` (
  `respondent_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE') DEFAULT 'ACTIVE',
  `campaign_id` int(11) unsigned DEFAULT NULL,
  `importfile_id` int(11) unsigned DEFAULT NULL,
  `qualification_id` int(11) unsigned DEFAULT NULL,
  `callbackdate` datetime DEFAULT NULL,
  `callbackphone` varchar(20) DEFAULT NULL,
  `nixxis_contact_id` varchar(32) DEFAULT NULL,
  `nixxis_activity_id` varchar(32) DEFAULT NULL,
  `nixxis_from` varchar(20) DEFAULT NULL,
  `nixxis_to` varchar(20) DEFAULT NULL,
  `nixxis_callagent_id` varchar(32) DEFAULT NULL,
  `nixxis_contactlist_id` varchar(32) DEFAULT NULL,
  `nixxis_agent_account` varchar(32) DEFAULT NULL,
  `nixxis_session_id` varchar(32) DEFAULT NULL,
  `nixxis_campaign_id` varchar(32) DEFAULT NULL,
  `nixxis_passkey` varchar(52) DEFAULT NULL,
  `calldate` datetime DEFAULT NULL,
  PRIMARY KEY (`respondent_id`),
  KEY `created_user_id` (`created_user_id`),
  KEY `modified_user_id` (`modified_user_id`),
  KEY `campaign_id` (`campaign_id`),
  KEY `qualification_id` (`qualification_id`,`campaign_id`),
  KEY `importfile_id` (`importfile_id`,`campaign_id`),
  CONSTRAINT `respondents_ibfk_1` FOREIGN KEY (`created_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `respondents_ibfk_2` FOREIGN KEY (`modified_user_id`) REFERENCES `users` (`user_id`) ON UPDATE CASCADE,
  CONSTRAINT `respondents_ibfk_3` FOREIGN KEY (`campaign_id`) REFERENCES `campaigns` (`campaign_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `respondents_ibfk_4` FOREIGN KEY (`qualification_id`) REFERENCES `qualifications` (`qualification_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `respondents_ibfk_5` FOREIGN KEY (`importfile_id`) REFERENCES `importfiles` (`importfile_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=191035 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for role_items
-- ----------------------------
DROP TABLE IF EXISTS `role_items`;
CREATE TABLE `role_items` (
  `role_item_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `role_id` int(11) unsigned DEFAULT NULL,
  `item_id` int(11) unsigned DEFAULT NULL,
  PRIMARY KEY (`role_item_id`),
  KEY `fk_role_items_roles` (`role_id`),
  KEY `fk_role_items_items` (`item_id`),
  CONSTRAINT `role_items_ibfk_1` FOREIGN KEY (`item_id`) REFERENCES `items` (`item_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `role_items_ibfk_2` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `role_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `role` varchar(45) DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `role_UNIQUE` (`role`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for rules
-- ----------------------------
DROP TABLE IF EXISTS `rules`;
CREATE TABLE `rules` (
  `rule_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('INACTIVE','ACTIVE') DEFAULT 'ACTIVE',
  `name` varchar(50) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `help` text,
  `param1_label` varchar(50) DEFAULT '0',
  `param1_description` text,
  `param2_label` varchar(50) DEFAULT NULL,
  `param2_description` text,
  `param3_label` varchar(50) DEFAULT NULL,
  `param3_description` text,
  `default_message` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`rule_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for stringvalues
-- ----------------------------
DROP TABLE IF EXISTS `stringvalues`;
CREATE TABLE `stringvalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`) USING BTREE,
  CONSTRAINT `stringvalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `stringvalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1579912 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for textvalues
-- ----------------------------
DROP TABLE IF EXISTS `textvalues`;
CREATE TABLE `textvalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` text,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `textvalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `textvalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for timevalues
-- ----------------------------
DROP TABLE IF EXISTS `timevalues`;
CREATE TABLE `timevalues` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `respondent_id` int(11) unsigned NOT NULL,
  `campaign_field_id` int(11) unsigned NOT NULL,
  `value` time DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_unique` (`respondent_id`,`campaign_field_id`),
  KEY `respondent_id` (`respondent_id`),
  KEY `campaign_field_id` (`campaign_field_id`),
  CONSTRAINT `timevalues_ibfk_1` FOREIGN KEY (`respondent_id`) REFERENCES `respondents` (`respondent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `timevalues_ibfk_2` FOREIGN KEY (`campaign_field_id`) REFERENCES `campaign_fields` (`campaign_field_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `user_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `created` datetime DEFAULT NULL,
  `created_user_id` int(11) unsigned DEFAULT NULL,
  `modified` datetime DEFAULT NULL,
  `modified_user_id` int(11) unsigned DEFAULT NULL,
  `state` enum('ACTIVE','INACTIVE','BLOCKED','CHANGEPASS') NOT NULL DEFAULT 'ACTIVE',
  `role_id` int(10) unsigned NOT NULL,
  `employee_number` varchar(50) DEFAULT NULL,
  `gender` enum('UNKNOWN','MALE','FEMALE') DEFAULT 'UNKNOWN',
  `initials` varchar(10) DEFAULT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `middlename` varchar(10) DEFAULT NULL,
  `lastname` varchar(40) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `team` varchar(50) DEFAULT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `avatar` varchar(255) DEFAULT NULL,
  `login` datetime DEFAULT NULL,
  `login_tries` int(1) unsigned DEFAULT '0',
  `online` datetime DEFAULT NULL,
  `token` varchar(255) DEFAULT NULL,
  `token_expiration_date` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `idx_username` (`username`),
  UNIQUE KEY `idx_employee_number` (`employee_number`),
  KEY `fk_user_role` (`role_id`),
  CONSTRAINT `fk_user_role` FOREIGN KEY (`role_id`) REFERENCES `roles` (`role_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=204 DEFAULT CHARSET=utf8;

-- ----------------------------
-- View structure for menuitems
-- ----------------------------
DROP VIEW IF EXISTS `menuitems`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `menuitems` AS select `u`.`user_id` AS `user_id`,`i`.`item_id` AS `item_id`,`i`.`parent_id` AS `parent_id`,`i`.`lft` AS `lft`,`i`.`rght` AS `rght`,`i`.`plugin` AS `plugin`,`i`.`controller` AS `controller`,`i`.`action` AS `action`,`i`.`icon` AS `icon`,`i`.`title` AS `title` from ((`users` `u` join `role_items` `ri` on((`u`.`role_id` = `ri`.`role_id`))) join `items` `i` on((`ri`.`item_id` = `i`.`item_id`))) order by `u`.`user_id`,`i`.`lft` ;

-- ----------------------------
-- View structure for qsel_callhistories
-- ----------------------------
DROP VIEW IF EXISTS `qsel_callhistories`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qsel_callhistories` AS select max(`callhistories`.`callhistory_id`) AS `callhistory_id`,`callhistories`.`respondent_id` AS `respondent_id`,max(`callhistories`.`startdate`) AS `beldt`,timediff(max(`callhistories`.`enddate`),max(`callhistories`.`startdate`)) AS `beltijd`,count(1) AS `callcount` from `callhistories` group by `callhistories`.`respondent_id` ;

-- ----------------------------
-- View structure for qsel_import_definitions
-- ----------------------------
DROP VIEW IF EXISTS `qsel_import_definitions`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qsel_import_definitions` AS select `Importfile`.`importfile_id` AS `importfile_id`,`Importfile`.`created` AS `created`,`Importfile`.`created_user_id` AS `created_user_id`,`Importfile`.`modified` AS `modified`,`Importfile`.`modified_user_id` AS `modified_user_id`,`Importfile`.`state` AS `state`,`Importfile`.`campaign_id` AS `campaign_id`,`Importfile`.`name` AS `Importfile_name`,`Importfile`.`delimiter` AS `delimiter`,`Importfile`.`linecount` AS `linecount`,`Importfile`.`totallines` AS `totallines`,`Importfile`.`errormessage` AS `errormessage`,`Importfilefield`.`column_id` AS `column_id`,`Importfilefield`.`name` AS `Importfilefield_name`,`Importfilefield`.`campaign_field_id` AS `campaign_field_id`,`CampaignField`.`fieldsetvalue_id` AS `fieldsetvalue_id`,`CampaignField`.`displayset_id` AS `displayset_id`,`CampaignField`.`name` AS `CampaignField_name`,`Fieldtype`.`name` AS `name`,`Fieldtype`.`datatable` AS `datatable`,`Fieldtype`.`modelname` AS `modelname` from (((`importfiles` `Importfile` join `importfilefields` `Importfilefield` on((`Importfilefield`.`importfile_id` = `Importfile`.`importfile_id`))) join `campaign_fields` `CampaignField` on((`Importfilefield`.`campaign_field_id` = `CampaignField`.`campaign_field_id`))) join `fieldtypes` `Fieldtype` on((`CampaignField`.`fieldtype_id` = `Fieldtype`.`fieldtype_id`))) where (`Importfilefield`.`campaign_field_id` is not null) order by `Fieldtype`.`modelname` ;

-- ----------------------------
-- View structure for qsel_respondent_field_values
-- ----------------------------
DROP VIEW IF EXISTS `qsel_respondent_field_values`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qsel_respondent_field_values` AS select `s`.`id` AS `id`,`s`.`respondent_id` AS `respondent_id`,`s`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`s`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`stringvalues` `s` join `campaign_fields` `cf` on((`s`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `i`.`id` AS `id`,`i`.`respondent_id` AS `respondent_id`,`i`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`i`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`integervalues` `i` join `campaign_fields` `cf` on((`i`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `dt`.`id` AS `id`,`dt`.`respondent_id` AS `respondent_id`,`dt`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`dt`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`datetimevalues` `dt` join `campaign_fields` `cf` on((`dt`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `d`.`id` AS `id`,`d`.`respondent_id` AS `respondent_id`,`d`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`d`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`datevalues` `d` join `campaign_fields` `cf` on((`d`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `t`.`id` AS `id`,`t`.`respondent_id` AS `respondent_id`,`t`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`t`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`timevalues` `t` join `campaign_fields` `cf` on((`t`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `b`.`id` AS `id`,`b`.`respondent_id` AS `respondent_id`,`b`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`b`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`booleanvalues` `b` join `campaign_fields` `cf` on((`b`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `txt`.`id` AS `id`,`txt`.`respondent_id` AS `respondent_id`,`txt`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`txt`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`textvalues` `txt` join `campaign_fields` `cf` on((`txt`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) union select `f`.`id` AS `id`,`f`.`respondent_id` AS `respondent_id`,`f`.`campaign_field_id` AS `campaign_field_id`,`cf`.`campaign_id` AS `campaign_id`,`fsv`.`name` AS `name`,`f`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype`,`cf`.`displayorder` AS `displayorder` from (((`floatvalues` `f` join `campaign_fields` `cf` on((`f`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) ;

-- ----------------------------
-- View structure for qsel_stringvalues
-- ----------------------------
DROP VIEW IF EXISTS `qsel_stringvalues`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `qsel_stringvalues` AS select `s`.`id` AS `id`,`s`.`respondent_id` AS `respondent_id`,`s`.`campaign_field_id` AS `campaign_field_id`,`fsv`.`name` AS `name`,`s`.`value` AS `value`,`fsv`.`label` AS `label`,`fsv`.`info` AS `info`,`fsv`.`required` AS `required`,`ft`.`name` AS `fieldtype` from (((`stringvalues` `s` join `campaign_fields` `cf` on((`s`.`campaign_field_id` = `cf`.`campaign_field_id`))) join `fieldsetvalues` `fsv` on((`cf`.`fieldsetvalue_id` = `fsv`.`fieldsetvalue_id`))) join `fieldtypes` `ft` on((`fsv`.`fieldtype_id` = `ft`.`fieldtype_id`))) ;

-- ----------------------------
-- View structure for QualificationPerCampaignPerAgentCount
-- ----------------------------
DROP VIEW IF EXISTS `QualificationPerCampaignPerAgentCount`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY INVOKER VIEW `QualificationPerCampaignPerAgentCount` AS select concat_ws(' - ',`organisations`.`name`,`c`.`name`) AS `campaign`,`q`.`description` AS `qualification`,concat_ws(' ',`u`.`firstname`,`u`.`middlename`,`u`.`lastname`) AS `agent`,count(1) AS `resultcount` from ((((`campaigns` `c` join `respondents` `r` on((`r`.`campaign_id` = `c`.`campaign_id`))) join `users` `u` on((`r`.`modified_user_id` = `u`.`user_id`))) join `qualifications` `q` on(((`q`.`campaign_id` = `c`.`campaign_id`) and (`r`.`qualification_id` = `q`.`qualification_id`)))) join `organisations` on((`c`.`organisation_id` = `organisations`.`organisation_id`))) group by `q`.`qualification_id`,`u`.`user_id` ;

-- ----------------------------
-- View structure for QualificationtypePerAgentCount
-- ----------------------------
DROP VIEW IF EXISTS `QualificationtypePerAgentCount`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `QualificationtypePerAgentCount` AS select replace(concat_ws(' ',`u`.`firstname`,`u`.`middlename`,`u`.`lastname`),'  ',' ') AS `agent`,if((`q`.`type` = '-1'),'Negatief',if((`q`.`type` = '1'),'Positief',if((`q`.`callback` = '1'),'Terugbellen','Neutraal'))) AS `result`,count(1) AS `result_count` from (((`respondents` `r` join `campaigns` `c` on((`r`.`campaign_id` = `c`.`campaign_id`))) join `qualifications` `q` on(((`q`.`campaign_id` = `c`.`campaign_id`) and (`r`.`qualification_id` = `q`.`qualification_id`)))) join `users` `u` on((`r`.`modified_user_id` = `u`.`user_id`))) where (date_format(`r`.`modified`,'%Y-%m-%d') = curdate()) group by `q`.`type`,`u`.`user_id` ;

-- ----------------------------
-- View structure for respondent_field_values
-- ----------------------------
DROP VIEW IF EXISTS `respondent_field_values`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `respondent_field_values` AS select `qsel_respondent_field_values`.`id` AS `id`,`qsel_respondent_field_values`.`respondent_id` AS `respondent_id`,`qsel_respondent_field_values`.`campaign_field_id` AS `campaign_field_id`,`qsel_respondent_field_values`.`campaign_id` AS `campaign_id`,`qsel_respondent_field_values`.`name` AS `name`,`qsel_respondent_field_values`.`value` AS `value`,`qsel_respondent_field_values`.`label` AS `label`,`qsel_respondent_field_values`.`info` AS `info`,`qsel_respondent_field_values`.`required` AS `required`,`qsel_respondent_field_values`.`fieldtype` AS `fieldtype`,`qsel_respondent_field_values`.`displayorder` AS `displayorder` from `qsel_respondent_field_values` order by `qsel_respondent_field_values`.`respondent_id`,`qsel_respondent_field_values`.`displayorder` ;

-- ----------------------------
-- Procedure structure for qprodGeneratePasskeys
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGeneratePasskeys`;
DELIMITER ;;
CREATE PROCEDURE `qprodGeneratePasskeys`(IN `_importfile_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	UPDATE respondents SET nixxis_passkey=SHA1(MD5(HEX(respondent_id))) WHERE importfile_id=_importfile_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetRespondent
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetRespondent`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetRespondent`(IN `_respondent_id` int,IN `_campaign_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _cfi INT DEFAULT 0;
	DECLARE _fsvName VARCHAR(100) DEFAULT '';
	DECLARE _done INT DEFAULT 0;
	DECLARE _variableFields TEXT DEFAULT '';


DECLARE _cur1 CURSOR FOR 
	SELECT cf.campaign_field_id, fsv.`name`
	FROM
		campaign_fields AS cf
		JOIN fieldsetvalues AS fsv ON cf.fieldsetvalue_id = fsv.fieldsetvalue_id
	WHERE
		cf.campaign_id = _campaign_id
AND NOT cf.fieldtype_id IN (10,11)
	ORDER BY
		cf.displayorder ASC;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET _done = 1;

	SET @sql = '';

	OPEN _cur1;
	REPEAT
		FETCH _cur1 INTO _cfi, _fsvName;
		IF NOT _done THEN 
			SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT("qfuncGetRespondentFieldValues(", _respondent_id,",", _cfi, ") AS ", _fsvName));
		END IF;
	UNTIL _done END REPEAT;
  CLOSE _cur1;

	SET @sql = CONCAT("SELECT r.respondent_id, r.campaign_id, q.`name` AS qualification, ", _variableFields, " FROM respondents AS r LEFT JOIN qualifications AS q ON r.qualification_id = q.qualification_id AND r.campaign_id = q.campaign_id WHERE r.respondent_id=", _respondent_id, " AND r.campaign_id=", _campaign_id);
	#select @sql;

	PREPARE stmt FROM @sql;
	EXECUTE stmt;
	DROP PREPARE stmt;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetRespondents
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetRespondents`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetRespondents`(IN `_campaign_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _cfi INT DEFAULT 0;
	DECLARE _fsvName VARCHAR(100) DEFAULT '';
	DECLARE _ftTable VARCHAR(100) DEFAULT '';
	DECLARE _done INT DEFAULT 0;
	DECLARE _variableFields TEXT DEFAULT '';
	DECLARE _variableJoins TEXT DEFAULT '';

DECLARE _cur1 CURSOR FOR 
	SELECT
		cf.campaign_field_id,
		fsv.`name`,
		LCASE(ft.datatable)
	FROM
		campaign_fields AS cf
		JOIN fieldsetvalues AS fsv ON cf.fieldsetvalue_id = fsv.fieldsetvalue_id
		JOIN fieldtypes AS ft ON fsv.fieldtype_id = ft.fieldtype_id
	WHERE
		cf.campaign_id = _campaign_id AND
		NOT cf.fieldtype_id IN (10,11)
	ORDER BY
		cf.displayorder ASC;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET _done = 1;

	SET @sql = '';

	OPEN _cur1;
	REPEAT
		FETCH _cur1 INTO _cfi, _fsvName, _ftTable;
		IF NOT _done THEN 
			SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT(_ftTable, _cfi, ".`value` AS ", _fsvName));
			SET _variableJoins = CONCAT(_variableJoins, " LEFT JOIN ", _ftTable, " ", _ftTable,_cfi, " ON ", _ftTable,_cfi,".respondent_id = respondents.respondent_id AND ", _ftTable,_cfi, ".campaign_field_id=", _cfi);
		END IF;
	UNTIL _done END REPEAT;
  CLOSE _cur1;

	SET @sql = CONCAT("SELECT respondents.respondent_id", _variableFields, " FROM respondents ", _variableJoins, " WHERE respondents.campaign_id=", _campaign_id, " ORDER BY respondent_id");
	select @sql;

	PREPARE stmt FROM @sql;
	EXECUTE stmt;
	DROP PREPARE stmt;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetRespondentsByExportFile
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetRespondentsByExportFile`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetRespondentsByExportFile`(IN `_exportfile_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _cfi INT DEFAULT 0;
	DECLARE _fsvName VARCHAR(100) DEFAULT '';
	DECLARE _ftTable VARCHAR(100) DEFAULT '';
	DECLARE _done INT DEFAULT 0;
	DECLARE _variableFields TEXT DEFAULT '';
	DECLARE _variableJoins TEXT DEFAULT '';

	DECLARE _cur1 CURSOR FOR 
	SELECT
		cf.campaign_field_id,
		cf.`name`,
		LCASE(ft.datatable)
	FROM
		campaign_fields AS cf
		LEFT JOIN fieldsetvalues AS fsv ON cf.fieldsetvalue_id = fsv.fieldsetvalue_id
		JOIN fieldtypes AS ft ON cf.fieldtype_id = ft.fieldtype_id
		JOIN exportfiles AS f ON cf.campaign_id = f.campaign_id
	WHERE
		f.exportfile_id = _exportfile_id AND
		NOT cf.fieldtype_id IN (10,11)
	ORDER BY
		cf.displayorder ASC;

	DECLARE CONTINUE HANDLER FOR NOT FOUND SET _done = 1;

	SET @sql = '';

	OPEN _cur1;
	REPEAT
		FETCH _cur1 INTO _cfi, _fsvName, _ftTable;
		IF NOT _done THEN 

			IF _ftTable = "floatvalues" THEN
				SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT("(SELECT REPLACE(FORMAT(",_ftTable,".`value`,2), '.',',') FROM ", _ftTable, " WHERE ", _ftTable, ".respondent_id = respondents.respondent_id AND ", _ftTable, ".campaign_field_id=", _cfi,") AS `", _fsvName, "`"));
			ELSE
				SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT("(SELECT ",_ftTable,".`value` FROM ", _ftTable, " WHERE ", _ftTable, ".respondent_id = respondents.respondent_id AND ", _ftTable, ".campaign_field_id=", _cfi,") AS `", _fsvName, "`"));
			END IF;
#			IF _ftTable = "FLOATVALUES" THEN
#				SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT("REPLACE(FORMAT(",_ftTable, _cfi, ".`value`,2), '.',',') AS ", _fsvName));
#			ELSE
#				SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT(_ftTable, _cfi, ".`value` AS ", _fsvName));
#			END IF;
#			SET _variableJoins = CONCAT(_variableJoins, " LEFT JOIN ", _ftTable, " ", _ftTable,_cfi, " ON ", _ftTable,_cfi,".respondent_id = respondents.respondent_id AND ", _ftTable,_cfi, ".campaign_field_id=", _cfi);
		END IF;
	UNTIL _done END REPEAT;
  CLOSE _cur1;

	SET @sql = CONCAT("SELECT respondents.respondent_id, respondents.calldate AS invoer_dt, c.beldt, c.beltijd, c.callcount, respondents.callbackdate,respondents.callbackphone,respondents.nixxis_contact_id,respondents.nixxis_activity_id,respondents.nixxis_from,respondents.nixxis_to,respondents.nixxis_callagent_id,respondents.nixxis_contactlist_id,respondents.nixxis_agent_account,respondents.nixxis_session_id,respondents.nixxis_campaign_id,respondents.nixxis_passkey, qualifications.name AS qualification", _variableFields, " FROM respondents JOIN qualifications ON (qualifications.qualification_id=respondents.qualification_id) JOIN respondent_exportfiles re ON (respondents.respondent_id = re.respondent_id) LEFT JOIN qsel_callhistories c ON (c.respondent_id = respondents.respondent_id) WHERE re.exportfile_id=", _exportfile_id, " ORDER BY respondents.respondent_id");
	#select @sql;
	PREPARE stmt FROM @sql;
	EXECUTE stmt;
	DROP PREPARE stmt;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodGetRespondentsByFile
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodGetRespondentsByFile`;
DELIMITER ;;
CREATE PROCEDURE `qprodGetRespondentsByFile`(IN `_importfile_id` int)
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	DECLARE _cfi INT DEFAULT 0;
	DECLARE _fsvName VARCHAR(100) DEFAULT '';
	DECLARE _ftTable VARCHAR(100) DEFAULT '';
	DECLARE _done INT DEFAULT 0;
	DECLARE _variableFields TEXT DEFAULT '';
	DECLARE _variableJoins TEXT DEFAULT '';

DECLARE _cur1 CURSOR FOR 
	SELECT
		cf.campaign_field_id,
		ff.`name`,
		LCASE(ft.datatable)
	FROM
		campaign_fields AS cf
		LEFT JOIN fieldsetvalues AS fsv ON cf.fieldsetvalue_id = fsv.fieldsetvalue_id
		JOIN fieldtypes AS ft ON cf.fieldtype_id = ft.fieldtype_id
		JOIN importfiles AS f ON cf.campaign_id = f.campaign_id
		JOIN importfilefields AS ff ON ff.importfile_id = f.importfile_id AND ff.campaign_field_id = cf.campaign_field_id
	WHERE
		f.importfile_id = _importfile_id AND
		cf.fieldtype_id <> 10
	ORDER BY
		ff.column_id ASC;
DECLARE CONTINUE HANDLER FOR NOT FOUND SET _done = 1;

	SET @sql = '';

	OPEN _cur1;
	REPEAT
		FETCH _cur1 INTO _cfi, _fsvName, _ftTable;
		IF NOT _done THEN 
			SET _variableFields = CONCAT_WS(', ', _variableFields, CONCAT(_ftTable, _cfi, ".`value` AS ", _fsvName));
			SET _variableJoins = CONCAT(_variableJoins, " LEFT JOIN ", _ftTable, " ", _ftTable,_cfi, " ON ", _ftTable,_cfi,".respondent_id = respondents.respondent_id AND ", _ftTable,_cfi, ".campaign_field_id=", _cfi);
		END IF;
	UNTIL _done END REPEAT;
  CLOSE _cur1;

	SET @sql = CONCAT("SELECT respondents.respondent_id, respondents.nixxis_passkey AS passkey ", _variableFields, " FROM respondents ", _variableJoins, " WHERE respondents.importfile_id=", _importfile_id, " ORDER BY respondent_id");
	
#SELECT @sql;
	PREPARE stmt FROM @sql;
	EXECUTE stmt;
	DROP PREPARE stmt;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodInsertRespondentExportfiles
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodInsertRespondentExportfiles`;
DELIMITER ;;
CREATE PROCEDURE `qprodInsertRespondentExportfiles`(IN `_exportfile_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	INSERT INTO respondent_exportfiles (respondent_id, exportfile_id) 
		SELECT respondent_id, _exportfile_id
		FROM respondents r JOIN exportfiles e ON (e.campaign_id = r.campaign_id)
		WHERE
		e.exportfile_id = _exportfile_id AND
		r.calldate >= e.date_from AND
		r.calldate < e.date_to AND
		r.qualification_id IS NOT NULL;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodSetCalldate
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodSetCalldate`;
DELIMITER ;;
CREATE PROCEDURE `qprodSetCalldate`(IN `_respondent_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Routine body goes here...
	UPDATE respondents SET calldate=NOW() WHERE respondent_id=_respondent_id;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for qprodSetCalldateIfNull
-- ----------------------------
DROP PROCEDURE IF EXISTS `qprodSetCalldateIfNull`;
DELIMITER ;;
CREATE PROCEDURE `qprodSetCalldateIfNull`(IN `_respondent_id` int)
    MODIFIES SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Routine body goes here...
	UPDATE respondents SET calldate=NOW() WHERE respondent_id=_respondent_id AND calldate IS NULL;
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for qfuncGetRespondentFieldValues
-- ----------------------------
DROP FUNCTION IF EXISTS `qfuncGetRespondentFieldValues`;
DELIMITER ;;
CREATE FUNCTION `qfuncGetRespondentFieldValues`(`_respondent_id` int,`_campaign_field_id` int) RETURNS text CHARSET utf8
    READS SQL DATA
    SQL SECURITY INVOKER
BEGIN
	#Voorbeeld: 1,1
	DECLARE _datatable VARCHAR(100);
	DECLARE _retval TEXT;
	
	SELECT ft.datatable INTO _datatable FROM respondents AS r
		JOIN campaign_fields AS cf ON r.campaign_id = cf.campaign_id
		JOIN fieldsetvalues AS fsv ON cf.fieldsetvalue_id = fsv.fieldsetvalue_id
		JOIN fieldtypes AS ft ON fsv.fieldtype_id = ft.fieldtype_id
	WHERE
		r.respondent_id = _respondent_id AND
		cf.campaign_field_id = _campaign_field_id;


	CASE _datatable
		WHEN 'stringvalues' THEN SELECT sv.`value` INTO _retval FROM stringvalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'datetimevalues' THEN SELECT sv.`value` INTO _retval FROM datetimevalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'textvalues' THEN SELECT sv.`value` INTO _retval FROM textvalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'booleanvalues' THEN SELECT sv.`value` INTO _retval FROM booleanvalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'datevalues' THEN SELECT sv.`value` INTO _retval FROM datevalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'timevalues' THEN SELECT sv.`value` INTO _retval FROM timevalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'integervalues' THEN SELECT sv.`value` INTO _retval FROM integervalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		WHEN 'floatvalues' THEN SELECT sv.`value` INTO _retval FROM floatvalues AS sv WHERE sv.respondent_id = _respondent_id AND sv.campaign_field_id = _campaign_field_id;
		ELSE SELECT 'UNKNOWN' INTO _retval;
	END CASE;
	
	RETURN _retval;
END
;;
DELIMITER ;
SET FOREIGN_KEY_CHECKS=1;
