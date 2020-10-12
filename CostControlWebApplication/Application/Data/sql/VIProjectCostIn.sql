CREATE OR REPLACE  VIEW `VIProjectCostIn` AS
SELECT
	`projectcostin`.`ID` AS `ID`,
	`projectcostin`.`CreatedDate` AS `CreatedDate`,
	`projectcostin`.`Created` AS `Created`,
	`projectcostin`.`ModifiedDate` AS `ModifiedDate`,
	`projectcostin`.`Modified` AS `Modified`,
	`projectcostin`.`ProjectId` AS `ProjectId`,
	`projectcostin`.`InvoiceNo` AS `InvoiceNo`,
	`projectcostin`.`InvoiceDate` AS `InvoiceDate`,
	`projectcostin`.`LastHomeId` AS `LastHomeId`,
	`projectcostin`.`Title` AS `Title`,
	`projectcostin`.`ContractAmount` AS `ContractAmount`,
	`projectcostin`.`AdditionalAmount` AS `AdditionalAmount`,
	`projectcostin`.`SettlementAmount` AS `SettlementAmount`,
	`projectcostin`.`OriginalContractAmount` AS `OriginalContractAmount`,
	`projectcostin`.`Remark` AS `Remark`,
	`projectcostin`.`InvoiceAmount` AS `InvoiceAmount`,
	`projectcostin`.`SecuringAmountRate` AS `SecuringAmountRate`,
	`projectcostin`.`SubtractSecuringAmount` AS `SubtractSecuringAmount`,
	`projectcostin`.`SubtractPrepaidAmount` AS `SubtractPrepaidAmount`,
	`projectcostin`.`SubtractOtherAmount` AS `SubtractOtherAmount`,
	`projectcostin`.`ReceivableInvoiceAmount` AS `ReceivableInvoiceAmount`,
	`projectcostin`.`ReceivedProjectAmount` AS `ReceivedProjectAmount`,
	`projectcostin`.`ReceivedProjectDate` AS `ReceivedProjectDate`,
	`projectcostin`.`ReceivedSecuringAmount` AS `ReceivedSecuringAmount`,
	`projectcostin`.`ReceivedSecuringAmountDate` AS `ReceivedSecuringAmountDate`,
	`projectcostin`.`SurplusSecuringAmount` AS `SurplusSecuringAmount`,
	`projectcostin`.`SurplusProjectAmount` AS `SurplusProjectAmount`,
	`supplier`.`Name` AS `LastHome`,
	`projectinfo`.`Code` AS `Code`,
	`projectinfo`.`Name` AS `Name` 
FROM
	  `projectcostin` 
		JOIN `supplier` ON  `projectcostin`.`LastHomeId` = `supplier`.`ID` 
	  JOIN `projectinfo` ON  `projectcostin`.`ProjectId` = `projectinfo`.`ID`  