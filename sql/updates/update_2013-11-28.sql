ALTER TABLE `characters` ADD COLUMN `lastLogin` DATETIME NOT NULL AFTER `type`;
UPDATE `characters` SET `lastLogin`=NOW();