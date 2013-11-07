CREATE TABLE IF NOT EXISTS `chat_logs` (
  `messageId` int(11) NOT NULL AUTO_INCREMENT,
  `chatType` tinyint(4) DEFAULT NULL,
  `from` varchar(50) NOT NULL DEFAULT '',
  `to` varchar(50) NOT NULL DEFAULT '',
  `message` varchar(500) NOT NULL DEFAULT '',
  `command` VARCHAR(50) NOT NULL DEFAULT '',
  `dateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`messageId`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;
