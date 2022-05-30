-- Select all columns from table where ...
SELECT * FROM VK_PrijsToeslagen 
WHERE vkptKlantklasse = 1;

-- Select a single cell from table where ...
SELECT csbGLN FROM CSBAdressen
WHERE csbUBN = '1005698';

-- Insert new row into table ...
INSERT INTO ScanVetten (svDatum, svMesterID, svOornummer, svOornummerMCC, svBeslag, svDatumInScanPaspoort)
VALUES ('2022/01/01', 'mesterID', 'BE12345683', 'BE945681297', 'beslagIn', '2022/01/01');

-- Update cells from table where ...
UPDATE Klassementen
SET klaKlassement = 1, klaRichtPrijs = 200, klaSync = false, klaUpdateDatum = '01/01/2000'
WHERE klaOornummer = 'BE45672138';

-- Delete records from table where ...
DELETE 
FROM Klassementen
WHERE klaOornummer = 'BE10035689';

-- ...
