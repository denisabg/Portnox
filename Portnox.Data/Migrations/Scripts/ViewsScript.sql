    -- Switch
  Create View vw_Switches
  As
  select distinct switch_ip as Id
  from [dbo].[NetworkEvents]
  Go


  -- Device
  Create View vw_Devices
  As
  select distinct Device_Mac as Id
  from [dbo].[NetworkEvents]
  where Device_Mac is not null
  Go


  -- Ports
  Create View vw_Ports
  As
  select distinct concat(switch_ip, ':', PORT_ID) AS Id, switch_ip as SwitchId, PORT_ID as Number
  from [dbo].[NetworkEvents]
  Go

  -- Events
  Create View vw_Events
  As
  SELECT [Id]
      ,[Event_Id] as TypeId
      ,[Switch_Ip] as SwitchId
	  ,[Port_Id] as PortNumber
      , concat(switch_ip, ':', PORT_ID) as PortId
      ,[Device_Mac] as DeviceId
	  ,[Remarks] as Remarks
  FROM [PortnoxDb].[dbo].[NetworkEvents]
  Go

  Create View vw_Port_Devices
  As
	select distinct concat(switch_ip, ':', PORT_ID) AS PortId, [Device_Mac] as DeviceId 
	from [dbo].[NetworkEvents]
	WHERE [Device_Mac] IS NOT NULL
	GO


