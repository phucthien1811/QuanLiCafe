-- Script ??n gi?n ?? fix tr?ng thái bàn
-- Ch?y trên SQL Server Management Studio (SSMS)
-- Database: CafeDB

USE [CafeDB];
GO

PRINT '==========================================';
PRINT 'B?T ??U XÓA ORDER R?NG VÀ FIX TR?NG THÁI';
PRINT '==========================================';

-- B??c 1: Xóa các Order không có OrderDetail
PRINT '?ang xóa các Order r?ng...';
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
PRINT '?ã xóa ' + CAST(@@ROWCOUNT AS VARCHAR(10)) + ' Order r?ng';
PRINT '';

-- B??c 2: Chuy?n tr?ng thái bàn v? Free n?u không có OrderDetail
PRINT '?ang chuy?n tr?ng thái bàn v? Free...';
UPDATE Tables
SET Status = 'Free'
WHERE Status = 'Serving'
AND Id NOT IN (
    SELECT DISTINCT o.TableId 
    FROM Orders o
    INNER JOIN OrderDetails od ON o.Id = od.OrderId
);
PRINT '?ã chuy?n ' + CAST(@@ROWCOUNT AS VARCHAR(10)) + ' bàn v? Free';
PRINT '';

-- B??c 3: Verify k?t qu?
PRINT 'K?t qu? sau khi fix:';
PRINT '==========================================';
SELECT 
    t.Id as [Mã Bàn], 
    t.Name as [Tên Bàn], 
    t.Status as [Tr?ng Thái],
    COUNT(DISTINCT o.Id) as [S? Order],
    COUNT(od.Id) as [S? Món]
FROM Tables t
LEFT JOIN Orders o ON t.Id = o.TableId AND t.Status = 'Serving'
LEFT JOIN OrderDetails od ON o.Id = od.OrderId
GROUP BY t.Id, t.Name, t.Status
ORDER BY t.Id;

PRINT '';
PRINT '==========================================';
PRINT 'HOÀN T?T!';
PRINT '==========================================';
GO
