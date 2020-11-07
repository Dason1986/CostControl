CREATE OR REPLACE  VIEW VIProjectCalculationDetail AS
SELECT
	projectcalculationdetail.ID AS ID,
	projectcalculationdetail.CreatedDate AS CreatedDate,
	projectcalculationdetail.ModifiedDate AS ModifiedDate,
	projectcalculationdetail.Modified AS Modified,
	projectcalculationdetail.ProjectId AS ProjectId,
	projectcalculationdetail.CalculationId AS CalculationId,
	projectcalculationdetail.OrderNo AS OrderNo,
	projectcalculationdetail.ContractAmount AS ContractAmount,
	projectcalculationdetail.EstimateCost AS EstimateCost,
	projectcalculationdetail.GrossMargin AS GrossMargin,
	projectprocurement.SupplierID AS SupplierID,
	projectprocurement.ItemAmount AS ItemAmount,
	projectprocurement.OtherAmount AS OtherAmount,
	projectprocurement.ProfitsRate AS ProfitsRate,
	projectcalculationdetail.ProcurementId AS ProcurementId,
	supplier.Name AS SupplierName 
FROM	
	projectcalculationdetail
	JOIN projectprocurement ON    projectprocurement.ProjectId = projectcalculationdetail.ProjectId  AND  projectcalculationdetail.CalculationId = projectprocurement.ID    	
	LEFT JOIN supplier ON   projectprocurement.SupplierID = supplier.ID   
	