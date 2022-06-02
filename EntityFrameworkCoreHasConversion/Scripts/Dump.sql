UPDATE dbo.SomeEntities
  SET 
      SomeDateTime = @SomeDateTime, 
      SomeGuid = @SomeGuid, 
      SomeInt = @SomeInt, 
      SomeEnum = @SomeEnum, 
      SomePrice = @SomePrice
WHERE Id = @Identifier;

UPDATE dbo.SomeEntities
    SET 
        SomeDateTime = '06/01/2022 15:03:51', 
        SomeGuid = 'c180074e-617e-4453-803a-869c615e1d3b', 
        SomeInt = '1111', 
        SomeEnum = 'Third', 
        SomePrice = 0
WHERE Id = 1;