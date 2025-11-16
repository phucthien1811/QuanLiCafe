-- ========================================
-- SCRIPT: Cleanup Orphaned Orders
-- MỤC ĐÍCH: Xóa các order "zombie" (chưa thanh toán) và reset trạng thái bàn
-- ========================================
USE [CafeDB]; -- Thay YourDatabaseName bằng tên database của bạn
GO
-- Bước 1: Xem danh sách các order chưa thanh toán
SELECT 
    o.Id AS OrderId,
    o.TableId,
    t.Name AS TableName,
    t.Status AS TableStatus,
    o.CreatedAt,
    o.TotalAmount,
    COUNT(od.Id) AS ItemCount
FROM Orders o
INNER JOIN Tables t ON o.TableId = t.Id
LEFT JOIN OrderDetails od ON o.Id = od.OrderId
WHERE t.Status = 'Serving'  -- Bàn đang phục vụ
GROUP BY o.Id, o.TableId, t.Name, t.Status, o.CreatedAt, o.TotalAmount
ORDER BY o.CreatedAt DESC;

-- Bước 2: Xóa OrderDetails của các order chưa thanh toán
DELETE FROM OrderDetails
WHERE OrderId IN (
    SELECT o.Id
    FROM Orders o
    INNER JOIN Tables t ON o.TableId = t.Id
    WHERE t.Status = 'Serving'
);

-- Bước 3: Xóa các Orders chưa thanh toán
DELETE FROM Orders
WHERE Id IN (
    SELECT o.Id
    FROM Orders o
    INNER JOIN Tables t ON o.TableId = t.Id
    WHERE t.Status = 'Serving'
);

-- Bước 4: Reset tất cả bàn về trạng thái Free
UPDATE Tables
SET Status = 'Free'
WHERE Status = 'Serving';

-- Bước 5: Kiểm tra lại
SELECT 
    Id,
    Name,
    Status
FROM Tables
ORDER BY Id;
