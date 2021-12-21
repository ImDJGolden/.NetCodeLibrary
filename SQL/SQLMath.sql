-- *** Wiskundige functies

MIN() | MAX();                          -- Haal het kleinste of grootste getal uit een kolom.
COUNT();                                -- Geeft aantal rijen terug die voldoen aan conditie.
AVG();                                  -- Geeft het gemiddelde van een numerieke kolom.
SUM();                                  -- Geeft de totale som van een numerieke kolom.


-- *** MIN() | MAX() ***
SELECT MIN(<kolom>)                         -- Minimum waarde
FROM <tabel>;
--WHERE <condition>

-- Or

SELECT MAX(<kolom>)                         -- Maximum waarde
FROM <tabel>;
--WHERE <conditie>


-- *** COUNT() ***
SELECT COUNT(<kolom>)
FROM <tabel>
--WHERE <conditie>


-- *** AVG() ***
SELECT AVG(<kolom>)
FROM <tabel>
--WHERE <conditie>


-- *** SUM() ***
SELECT SUM(<kolom>)
FROM <tabel>
--WHERE <conditie>