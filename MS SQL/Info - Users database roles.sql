SELECT 
    rp.name as DatabaseRole
    , mp.name as DatabaseUser
FROM sys.database_role_members as drm
JOIN sys.database_principals as rp on (drm.role_principal_id = rp.principal_id)
JOIN sys.database_principals as mp on (drm.member_principal_id = mp.principal_id)