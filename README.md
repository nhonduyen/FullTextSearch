Full-Text Search is a feature of Microsoft SQL Server that lets you perform search engine like queries against the string properties of your entities.

LINKS:
- https://www.bricelam.net/2020/08/08/mssql-freetext-and-efcore.html
- https://codingcanvas.com/full-text-queries-containscontainstablefree-text-and-freetexttable/

FreeText is more restrictive predicate which by default does a search based on various forms of a word or phrase (that means it by default includes Inflectional forms as well as thesaurus).

Contains, unlike FreeText, gives you flexibility to do various forms of search separately.