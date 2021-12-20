-- *** Basic Syntax

SELECT;                                     -- Haal data van DB
UPDATE;                                     -- Update data van DB
DELETE;                                     -- Delete data van DB
INSERT INTO;                                -- Voeg nieuwe data to aan DB

WHERE;                                      -- Filter records
AND, OR, NOT;                               -- WHERE kan gecombineerd worden met deze.
ORDER BY;   ASC|DESC                        -- Sorteer resultaat ASC of DESC


-- *** SELECT
SELECT <column> FROM <tabel>
WHERE <conditie>;
--AND | OR | NOT <conditie>
--ORDER BY <tabel> ASC | DESC


-- *** UPDATE
UPDATE <tabel>
SET <column> = <waarde>, ...
WHERE <conditie>;


-- *** INSERT INTO
INSERT INTO <tabel> (<column1>, <column2>, ...)         -- Specifieer zowel columnen en waardes
VALUES (<waarde1>, <waarde2>, ...);

-- Or

INSERT INTO <tabel>                                     -- Voeg waardes toe aan alle columnen
VALUES (<waarde1>, <waarde2>, ...);


-- *** DELETE
DELETE FROM <tabel>
WHERE <conditie>;