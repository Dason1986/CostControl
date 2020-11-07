CREATE OR REPLACE  VIEW `VIProjectProcurement` AS
SELECT
projectmaster.`Name`,
projectmaster.`Code`,
projectprocurement.ID,
projectprocurement.ProjectId,
projectprocurement.ProcurementType,
projectprocurement.ManagerOpinion,
projectprocurement.SupplierType,
projectprocurement.SupplierID,
projectprocurement.CosterOpinion,
projectprocurement.DepartmentOpinion,
projectprocurement.ItemAmount,
projectprocurement.ProcurementAmount,
projectprocurement.ThisProcurementAmount,
projectprocurement.BeenProcurementAmount,
projectprocurement.AllProcurementAmount,
projectprocurement.OtherAmount,
projectprocurement.ProfitsRate,
projectprocurement.MaterialUsage,
projectprocurement.TotalPurchaseAmount,
projectprocurement.PaymentMethodId,
projectprocurement.Phone,
projectprocurement.Address,
projectprocurement.Remark,
projectprocurement.State,
projectprocurement.ExpenseCompany,
projectprocurement.PaidAmount,
SupplierID.`Name` AS SupplierName,
PaymentMethodId.`Name` AS PaymentMethod,
projectprocurement.CreatedDate,
projectprocurement.Created,
projectprocurement.ModifiedDate,
projectprocurement.Modified
FROM
projectprocurement
INNER JOIN projectmaster ON projectprocurement.ProjectId = projectmaster.ID
LEFT JOIN supplier as SupplierID ON projectprocurement.SupplierID = SupplierID.ID  
LEFT JOIN basicdata as PaymentMethodId ON projectprocurement.PaymentMethodId = PaymentMethodId.ID  
where projectprocurement.State!=0