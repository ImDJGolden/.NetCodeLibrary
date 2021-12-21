-- *** SQL functies

LIKE;                                       -- Zoek een specifiek patroon in een kolom.
IN;                                         -- specifieer meer waardes in een WHERE.
BETWEEN;                                    -- selecteer waardes in een gegeven range. 


-- *** LIKE ***
SELECT <kolom>
FROM <tabel>
WHERE kolom LIKE <"string">;


-- *** IN ***
SELECT <kolom>
FROM <tabel>
WHERE <kolom> IN (<waarde1>, <waarde2>, ...);


-- *** BETWEEN ***
SELECT <kolom>
FROM <tabel>
WHERE <kolom> BETWEEN <waarde1> and <waarde2>;