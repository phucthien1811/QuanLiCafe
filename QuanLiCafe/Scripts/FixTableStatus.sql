-- Script để fix trạng thái bàn không đúng
-- Tìm các bàn đang Serving nhưng không có OrderDetail
-- Chạy trên SQL Server Management Studio (SSMS)

USE [CafeDB]; -- Thay YourDatabaseName bằng tên database của bạn
GO

PRINT '========================================';
PRINT 'BẮT ĐẦU FIX TRẠNG THÁI BÀN';
PRINT '========================================';
PRINT '';

-- 1. Tìm các Order không có OrderDetail nào
PRINT '1. Tìm các bàn đang Serving nhưng không có món:';
PRINT '----------------------------------------';
SELECT o.Id as OrderId, o.TableId, t.Name as TableName, t.Status
FROM Orders o
INNER JOIN Tables t ON o.TableId = t.Id
LEFT JOIN OrderDetails od ON o.Id = od.OrderId
WHERE t.Status = 'Serving'
GROUP BY o.Id, o.TableId, t.Name, t.Status
HAVING COUNT(od.Id) = 0;
PRINT '';

-- 2. Đếm số lượng Order và Table sẽ bị ảnh hưởng
DECLARE @OrderCount INT;
DECLARE @TableCount INT;

SELECT @OrderCount = COUNT(DISTINCT o.Id)
FROM Orders o
INNER JOIN Tables t ON o.TableId = t.Id
LEFT JOIN OrderDetails od ON o.Id = od.OrderId
WHERE t.Status = 'Serving'
GROUP BY o.Id, o.TableId, t.Name, t.Status
HAVING COUNT(od.Id) = 0;

SELECT @TableCount = COUNT(DISTINCT t.Id)
FROM Tables t
WHERE t.Status = 'Serving'
AND t.Id NOT IN (
    SELECT DISTINCT o.TableId 
    FROM Orders o
    INNER JOIN OrderDetails od ON o.Id = od.OrderId
);

PRINT '2. Thống kê sẽ bị ảnh hưởng:';
PRINT '----------------------------------------';
PRINT 'Số Order rỗng sẽ xóa: ' + CAST(ISNULL(@OrderCount, 0) AS VARCHAR(10));
PRINT 'Số bàn sẽ chuyển về Free: ' + CAST(ISNULL(@TableCount, 0) AS VARCHAR(10));
PRINT '';

-- 3. Xóa các Order rỗng
PRINT '3. Đang xóa các Order rỗng...';
DELETE FROM Orders
WHERE Id IN (
    SELECT o.Id
    FROM Orders o
    INNER JOIN Tables t ON o.TableId = t.Id
    LEFT JOIN OrderDetails od ON o.Id = od.OrderId
    WHERE t.Status = 'Serving'
    GROUP BY o.Id
    HAVING COUNT(od.Id) = 0
);
PRINT 'Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR(10)) + ' Order rỗng';
PRINT '';

-- 4. Chuyển trạng thái bàn về Free
PRINT '4. Đang chuyển trạng thái bàn về Free...';
UPDATE Tables
SET Status = 'Free'
WHERE Status = 'Serving'
AND Id NOT IN (
    SELECT DISTINCT o.TableId 
    FROM Orders o
    INNER JOIN OrderDetails od ON o.Id = od.OrderId
);
PRINT 'Đã chuyển ' + CAST(@@ROWCOUNT AS VARCHAR(10)) + ' bàn về Free';
PRINT '';

-- 5. Verify kết quả
PRINT '5. Kết quả sau khi fix:';
PRINT '----------------------------------------';
SELECT 
    t.Id as TableId, 
    t.Name as TableName, 
    t.Status,
    COUNT(DISTINCT o.Id) as OrderCount,
    COUNT(od.Id) as OrderDetailCount
FROM Tables t
LEFT JOIN Orders o ON t.Id = o.TableId
LEFT JOIN OrderDetails od ON o.Id = od.OrderId
GROUP BY t.Id, t.Name, t.Status
ORDER BY t.Id;

PRINT '';
PRINT '========================================';
PRINT 'HOÀN TẤT FIX TRẠNG THÁI BÀN';
PRINT '========================================';
GO
