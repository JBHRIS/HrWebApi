with temp as(
SELECT *, ROW_NUMBER() over(order by DATA_PASS,SALADR) as rnk
FROM DATA_PA
)
  
DELETE temp 
where rnk not IN
(SELECT Max(rnk) FROM temp  GROUP BY DATA_PASS,SALADR) 
GO